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
		[Route ( "Otros" )]
		public async Task<IHttpActionResult> getOtros ( int pageSize, int pageNumber, OrderTypes orderType, string orderBy, string query )
		{
			try
			{
				// Reemplazo el valor por defecto para regresar todo.
				query = query.Replace ( "%", "" );

				// Obtengo el total de elementos
				var _totalItems = await DB.Otros.Where ( o => ( o.Nombre.Contains ( query ) ) ).CountAsync ( );

				// Obtengo el numero de paginas.
				var _totalPages = Math.Ceiling ( (double)_totalItems / pageSize );

				// Creo la variable IQueriable para interactuar con LINQ
				var Query = DB.Otros.AsQueryable ( );

				// Obtengo el query que contiene el nombre de la columna con que se ordenaran los datos
				string _columnToOrder = $"{( HasProperty ( typeof ( libProduccionDataBase.Tablas.Otro ), orderBy ) ? orderBy : "OtroId" )} {orderType}";

				// Obtengo la lista de elementos, la pagina requerida y el orden de las columnas
				List<libProduccionDataBase.Tablas.Otro> ret = await Query.Where ( o => ( o.Nombre.Contains ( query ) ) )
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
		[Route ( "Otros" )]
		public async Task<IHttpActionResult> getOtro ( int id )
		{
			try
			{
				if ( !await DB.Otros.AnyAsync ( t => t.OtroId == id ) ) return NotFound ( );
				return Ok ( await DB.Otros.FirstOrDefaultAsync ( t => t.OtroId == id ) );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}

		[HttpPost]
		[Route ( "Otros" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop, Administrador Ventas" )]
		public async Task<IHttpActionResult> postOtro ( Models.FrontEndModels.Catalogos.Otro model )
		{
			try
			{
				if ( !ModelState.IsValid ) return BadRequest ( ModelState );
				DB.Otros.Add ( model.toNewOtro ( ) );
				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_INSERT_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}
		}

		[HttpPut]
		[Route ( "Otros" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop, Administrador Ventas" )]
		public async Task<IHttpActionResult> putOtro ( Models.FrontEndModels.Catalogos.Otro model )
		{
			try
			{
				if ( !ModelState.IsValid ) return BadRequest ( ModelState );
				if ( !await DB.Otros.AnyAsync ( t => t.OtroId == model.OtroId ) ) return NotFound ( );

				Otro tint = await DB.Otros.FirstOrDefaultAsync ( t => t.OtroId == model.OtroId );

				tint.Costo = (double)model.Costo;
				tint.Nombre = model.Nombre;
				tint.Precio = (double)model.Precio;

				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_UPDATE_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}

		}

		[HttpDelete]
		[Route ( "Otros" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop, Administrador Ventas" )]
		public async Task<IHttpActionResult> deleteOtro ( int id )
		{
			try
			{
				if ( !await DB.Otros.AnyAsync ( t => t.OtroId == id ) ) return NotFound ( );
				DB.Otros.Remove ( DB.Otros.FirstOrDefault ( t => t.OtroId == id ) );
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