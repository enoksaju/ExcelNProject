using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using libProduccionDataBase.Tablas;
using System.Linq.Dynamic;
using Cotizador.Models.FrontEndModels.Catalogos;

namespace Cotizador.Controllers
{
	public partial class CatalogosController : ApiController
	{
		/// <summary>
		/// Devuelve una lista de clientes, comprueba si el usuario actual es Admin
		/// </summary>
		/// <param name="pageSize">Tamaño del paginado</param>
		/// <param name="pageNumber">Numero de la pagina</param>
		/// <param name="orderType">Tipo de orden [ASC, DESC]</param>
		/// <param name="orderBy">Nombre de la columna con que se ordenará</param>
		/// <param name="query">Query que se usara para filtar los Datos</param>
		/// <returns>Lista de Clientes</returns>
		[HttpGet]
		[Route ( "Clientes" )]
		public async Task<IHttpActionResult> GetClientes ( int pageSize, int pageNumber, OrderTypes orderType, string orderBy, string query, bool allUsers )
		{
			try
			{
				// Reemplazo el valor por defecto para regresar todo.
				query = query.Replace ( "%", "" );

				// Obtengo el Id del usuario actual
				var id = ( await UserManager.FindByNameAsync ( User.Identity.Name ) ).Id;

				// Obtengo el total de elementos, si no es admin, regreso solo los datos que son propiedad del usuario
				var _totalItems = await DB.Clientes.Where ( o => ( o.ClaveCliente.Contains ( query ) | o.NombreCliente.Contains ( query ) | o.NombreContacto.Contains ( query ) | ( o.Agente.Nombre + " " + o.Agente.ApellidoPaterno + " " + o.Agente.ApellidoMaterno ).Contains ( query ) ) & ( o.AgenteId == id | allUsers ) ).CountAsync ( );

				// Obtengo el numero de paginas.
				var _totalPages = Math.Ceiling ( (double)_totalItems / pageSize );

				// Creo la variable IQueriable para interactuar con LINQ
				var clientesQuery = DB.Clientes.AsQueryable ( );

				// Obtengo el query que contiene el nombre de la columna con que se ordenaran los datos
				string _columnToOrder = $"{( HasProperty ( typeof ( Cliente ), orderBy ) ? orderBy : "ClienteId" )} {orderType}";

				// Obtengo la lista de elementos, la pagina requerida y el orden de las columnas, si no es admin solo devuelvo los datos que son propiedad del usuario actual
				List<Cliente> ret = await clientesQuery.Where ( o => ( o.ClaveCliente.Contains ( query ) | o.NombreCliente.Contains ( query ) | o.NombreContacto.Contains ( query ) | ( o.Agente.Nombre + " " + o.Agente.ApellidoPaterno + " " + o.Agente.ApellidoMaterno ).Contains ( query ) ) & ( o.AgenteId == id | allUsers ) )
					.OrderBy ( _columnToOrder ).Skip ( ( pageNumber - 1 ) * pageSize ).Take ( pageSize ).ToListAsync ( );

				// Si el cliente no tiene usuario asignado, le asigno un valor por defecto
				ret.ForEach ( o =>
				{
					if ( o.Agente == null )
					{
						var agente = DB.Users.FirstOrDefault ( u => u.Id == 1 );
						o.Agente = agente;
						o.AgenteId = agente.Id;
					}
				} );

				// Regreso la informacion al FrontEnd, el objeto que regreso es generico
				return Ok ( new
				{
					TotalPages = _totalPages,
					TotalCount = _totalItems,
					Items = from itm in ret
							select new
							{
								itm.Id,
								itm.ClaveCliente,
								itm.NombreCliente,
								itm.NombreContacto,
								itm.Telefono,
								itm.Email,
								itm.Ciudad,
								itm.Domicilio,
								itm.Estado,
								itm.AgenteId,
								NombreEjecutivo = $"{itm.Agente.Nombre} {( itm.Agente.ApellidoPaterno == "x" ? "" : itm.Agente.ApellidoPaterno ) } {( itm.Agente.ApellidoMaterno == "x" ? "" : itm.Agente.ApellidoMaterno )}".TrimEnd ( )
							}
				} );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}

		/// <summary>
		/// Devuelve un solo cliente al FrontEnd
		/// </summary>
		/// <param name="id">Primary Key del Cliente</param>
		/// <returns>Modelo FrontEndModel_Cliente con datos del cliente encontrado</returns>
		[HttpGet]
		[Route ( "Clientes" )]
		public async Task<IHttpActionResult> GetCliente ( int id )
		{
			// Busco el cliente en la Base de Datos, convierto la entidad en un modelo limitado
			var cte = await ( from itm in DB.Clientes
							  where itm.Id == id
							  select new FrontEndModel_Cliente
							  {
								  Id = itm.Id,
								  AgenteId = itm.AgenteId,
								  NombreCliente = itm.NombreCliente,
								  Telefono = itm.Telefono,
								  NombreContacto = itm.NombreContacto,
								  Ciudad = itm.Ciudad,
								  ClaveCliente = itm.ClaveCliente,
								  Domicilio = itm.Domicilio,
								  Email = itm.Email,
								  Estado = itm.Estado
							  } ).FirstAsync ( );

			// Compruebo que existe el cliente  
			if ( cte != null )
			{
				// Regreso la info al FrontEnd
				return Ok ( cte );
			}
			else
			{
				// Si no se encontro regreso error 404
				return NotFound ( );
			}
		}

		/// <summary>
		/// Inserta un cliente nuevo, comprueba si el usuario actual es Admin
		/// </summary>
		/// <param name="model">Modelo con informacion del nuevo cliente</param>
		/// <returns>Confirma que se procesaron los datos</returns>
		[HttpPost]
		[Route ( "Clientes" )]
		public async Task<IHttpActionResult> PostCliente ( FrontEndModel_Cliente model )
		{
			// Valido el modelo
			if ( !ModelState.IsValid )
			{
				// si es invalido regreso un BadRequest con el estado del modelo
				return BadRequest ( ModelState );
			}

			// Compruebo que el Id del Agente sea correcto
			if ( model.AgenteId == 1 ) return BadRequest ( "Debe seleccionar un agente Valido" );

			// Compruebo que el Usuario actual se Admin
			if ( !IsInAdminRol ( User ) | model.AgenteId == null )
			{
				// Si no es Admin, Asigno su Id como clave de agente (un usuario que no es admin no guarda clientes para otro usuario)
				model.AgenteId = ( await UserManager.FindByNameAsync ( User.Identity.Name ) ).Id;
			}

			// Genero la nueva entidad
			var cte = new Cliente ( )
			{
				ClaveCliente = model.ClaveCliente,
				NombreCliente = model.NombreCliente,
				NombreContacto = model.NombreContacto,
				Telefono = model.Telefono,
				Email = model.Email,
				Domicilio = model.Domicilio,
				Ciudad = model.Ciudad,
				Estado = model.Estado,
				AgenteId = model.AgenteId
			};


			try
			{
				// Agrego la nueva entidad
				DB.Clientes.Add ( cte );
				// Intento Guardar los datos
				await DB.SaveChangesAsync ( );
				// Si se guardó correctamente conformo la accion
				return Ok ( SUCCESS_INSERT_MESSAGE );
			}
			catch ( Exception ex )
			{
				// Si sucede algun error busco el error y lo devuelvo al cliente
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );//.GetInnerException ( ex ) );
			}
		}

		/// <summary>
		/// Actualiza la informacion de un cliente
		/// </summary>
		/// <param name="model">Modelo que contiene la informacion del cliente</param>
		/// <returns>regresa el estado resultante de la operacion</returns>
		[HttpPut]
		[Route ( "Clientes" )]
		public async Task<IHttpActionResult> PutCliente ( FrontEndModel_Cliente model )
		{
			// Valido el modelo
			if ( !ModelState.IsValid ) return BadRequest ( ModelState );

			// Valido el campo AgenteId
			if ( model.AgenteId == 1 ) return BadRequest ( "Debe seleccionar un agente Valido" );

			// Verifico si el usuario es Admin
			if ( !IsInAdminRol ( User ) | model.AgenteId == null )
			{
				// Si no es admin, asigno el Id del usuario actual
				model.AgenteId = ( await UserManager.FindByNameAsync ( User.Identity.Name ) ).Id;
			}

			try
			{
				// Busco el cliente que se editara
				var cte = await DB.Clientes.FirstAsync ( o => o.Id == model.Id );

				// Verifico que el cliente existe
				if ( cte == null ) throw new Exception ( "Id Invalido" );

				// Asigno los nuevos valores
				cte.NombreCliente = model.NombreCliente;
				cte.ClaveCliente = model.ClaveCliente;
				cte.NombreContacto = model.NombreContacto;
				cte.Telefono = model.Telefono;
				cte.AgenteId = model.AgenteId;
				cte.Ciudad = model.Ciudad;
				cte.Domicilio = model.Domicilio;
				cte.Email = model.Email;
				cte.Estado = model.Estado;

				// Intento Guardar los cambios en la Base de Datos
				DB.SaveChanges ( );

				// Confirmo al cliente el resultado de la accion
				return Ok ( SUCCESS_UPDATE_MESSAGE );
			}
			catch ( Exception ex )
			{
				// Si sucede un error, busco el mensaje y lo regreso al cliente
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}
		}

		/// <summary>
		/// Borra un cliente de la Base de Datos
		/// </summary>
		/// <param name="Id">Llave Primaris del Cliente que se eliminara</param>
		/// <returns></returns>
		[HttpDelete]
		[Route ( "Clientes" )]
		public async Task<IHttpActionResult> DeleteCliente ( int Id )
		{
			try
			{
				// Obtengo el Id del usuario Actual
				var AgenteId_ = ( await UserManager.FindByNameAsync ( User.Identity.Name ) ).Id;

				// Verifico que el cliente existe y que el usuario actual lo puede eliminar, (los roles admin pueden borrar cualquier cliente, un usuario normal, solo puede borrar los de su propiedad)
				var cte = this.IsInAdminRol ( User ) ? await DB.Clientes.FirstAsync ( o => o.Id == Id ) : await DB.Clientes.FirstAsync ( o => o.Id == Id & o.AgenteId == AgenteId_ );

				// Verifico que el cliente es valido
				if ( cte != null )
				{
					// Lo elimino de la Base de Datos
					DB.Clientes.Remove ( cte );
				}
				else
				{
					// Si no es valido se lo informo al cliente
					throw new Exception ( "El Cliente no existe" );
				}

				// Intento guardar los cambios en la Base de Datos
				await DB.SaveChangesAsync ( );

				// Confirmo el estado de la accion al cliente
				return Ok ( SUCCESS_DELETE_MESSAGE );

			}
			catch ( Exception ex )
			{
				// Si sucede un error, lo busco y lo devuelvo al cliente
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}
		}
	}
}