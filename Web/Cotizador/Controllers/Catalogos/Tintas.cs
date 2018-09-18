using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Linq.Dynamic;
using libProduccionDataBase.Tablas;

namespace Cotizador.Controllers
{
	public partial class CatalogosController : ApiController
	{
		[HttpGet]
		[Route ( "Tintas" )]
		public async Task<IHttpActionResult> getTintas ( int pageSize, int pageNumber, OrderTypes orderType, string orderBy, string query )
		{
			try
			{
				// Reemplazo el valor por defecto para regresar todo.
				query = query.Replace ( "%", "" );

				// Obtengo el total de elementos
				var _totalItems = await DB.Tintas.Where ( o => ( o.Nombre.Contains ( query ) | o.Tipo.Contains ( query ) ) ).CountAsync ( );

				// Obtengo el numero de paginas.
				var _totalPages = Math.Ceiling ( (double)_totalItems / pageSize );

				// Creo la variable IQueriable para interactuar con LINQ
				var Query = DB.Tintas.AsQueryable ( );

				// Obtengo el query que contiene el nombre de la columna con que se ordenaran los datos
				string _columnToOrder = $"{( HasProperty ( typeof ( libProduccionDataBase.Tablas.Tinta ), orderBy ) ? orderBy : "TintaId" )} {orderType}";

				// Obtengo la lista de elementos, la pagina requerida y el orden de las columnas
				List<libProduccionDataBase.Tablas.Tinta> ret = await Query.Where ( o => ( o.Nombre.Contains ( query ) | o.Tipo.Contains ( query ) ) )
					.OrderBy ( _columnToOrder ).Skip ( ( pageNumber - 1 ) * pageSize ).Take ( pageSize ).ToListAsync ( );

				// Regreso la informacion al FrontEnd
				return Ok ( new
				{
					TotalPages = _totalPages,
					TotalCount = _totalItems,
					Items = from itm in ret
							select itm
				} );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}

		[HttpGet]
		[Route ( "Tintas" )]
		public async Task<IHttpActionResult> getTinta ( int id )
		{
			try
			{
				if ( !await DB.Tintas.AnyAsync ( t => t.TintaId == id ) ) return NotFound ( );
				return Ok ( await DB.Tintas.FirstOrDefaultAsync ( t => t.TintaId == id ) );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}

		[HttpPost]
		[Route ( "Tintas" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop, Administrador Ventas" )]
		public async Task<IHttpActionResult> postTinta ( Models.FrontEndModels.Catalogos.Tinta model )
		{
			try
			{
				if ( !ModelState.IsValid ) return BadRequest ( ModelState );
				DB.Tintas.Add ( model.ToNewTinta ( ) );
				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_INSERT_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}
		}

		[HttpPut]
		[Route ( "Tintas" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop, Administrador Ventas" )]
		public async Task<IHttpActionResult> putTinta ( Models.FrontEndModels.Catalogos.Tinta model )
		{
			try
			{
				if ( !ModelState.IsValid ) return BadRequest ( ModelState );
				if ( !await DB.Tintas.AnyAsync ( t => t.TintaId == model.TintaId ) ) return NotFound ( );

				Tinta tint = await DB.Tintas.FirstOrDefaultAsync ( t => t.TintaId == model.TintaId );

				tint.Costo = (double)model.Costo;
				tint.Nombre = model.Nombre;
				tint.Precio = (double)model.Precio;
				tint.Tipo = model.Tipo;

				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_UPDATE_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}

		}

		[HttpDelete]
		[Route ( "Tintas" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop, Administrador Ventas" )]
		public async Task<IHttpActionResult> deleteTinta ( int id )
		{
			try
			{
				if ( !await DB.Tintas.AnyAsync ( t => t.TintaId == id ) ) return NotFound ( );
				DB.Tintas.Remove ( DB.Tintas.FirstOrDefault ( t => t.TintaId == id ) );
				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_DELETE_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}

		}
	}
}