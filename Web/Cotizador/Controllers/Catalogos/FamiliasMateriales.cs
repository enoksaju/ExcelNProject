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

namespace Cotizador.Controllers
{
	public partial class CatalogosController : ApiController
	{
		[HttpGet]
		[Route ( "familiasmateriales" )]
		public async Task<IHttpActionResult> getFamsMats ( int pageSize, int pageNumber, OrderTypes orderType, string orderBy, string query )
		{
			try
			{
				query = query.Replace ( "%", "" );
				int _totalItems = await DB.FamiliasMateriales.Where ( o => o.NombreFamilia.Contains ( query ) ).CountAsync ( );
				double _totalPages = Math.Ceiling ( (double)_totalItems / pageSize );
				IQueryable<FamiliaMateriales> famMatQuery = DB.FamiliasMateriales.AsQueryable ( );

				string _columnOrder = $"{( HasProperty ( typeof ( FamiliaMateriales ), orderBy ) ? orderBy : "Id" ) } {orderType}";

				List<FamiliaMateriales> ret = await famMatQuery.Where ( o => o.NombreFamilia.Contains ( query ) )
					.OrderBy ( _columnOrder ).Skip ( ( pageNumber - 1 ) * pageSize ).Take ( pageSize ).ToListAsync ( );
				return Ok ( new
				{
					TotalPages = _totalPages,
					TotalCount = _totalItems,
					Items = from itm in ret
							select new Models.FrontEndModels.Catalogos.FamiliasMateriales ( )
							{
								Id = itm.Id,
								NombreFamilia = itm.NombreFamilia
							}
				} );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}

		[HttpGet]
		[Route ( "familiasmateriales" )]
		public async Task<IHttpActionResult> getFamMat ( int id )
		{
			// Busco la entidad con el id especificado
			var fm = await ( from itm in DB.FamiliasMateriales
							 where itm.Id == id
							 select new Models.FrontEndModels.Catalogos.FamiliasMateriales ( )
							 {
								 Id = itm.Id,
								 NombreFamilia = itm.NombreFamilia
							 } ).FirstAsync ( );

			if ( fm != null )
			{
				// Regreso la info al FrontEnd
				return Ok ( fm );
			}
			else
			{
				// Si no se encontro regreso error 404
				return NotFound ( );
			}
		}

		[HttpPost]
		[Route ( "familiasmateriales" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop" )]
		public async Task<IHttpActionResult> postFamMat ( Models.FrontEndModels.Catalogos.FamiliasMateriales model )
		{
			if ( !ModelState.IsValid )
			{
				return BadRequest ( ModelState );
			}

			try
			{
				DB.FamiliasMateriales.Add ( new FamiliaMateriales ( )
				{
					NombreFamilia = model.NombreFamilia
				} );

				await DB.SaveChangesAsync ( );

				return Ok ( SUCCESS_INSERT_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}

		}

		[HttpPut]
		[Route ( "familiasmateriales" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop" )]
		public async Task<IHttpActionResult> putFamMat ( Models.FrontEndModels.Catalogos.FamiliasMateriales model )
		{
			if ( !ModelState.IsValid )
			{
				return BadRequest ( ModelState );
			}

			try
			{
				var fm = await DB.FamiliasMateriales.FirstAsync ( e => e.Id == model.Id );
				if ( fm == null ) return NotFound ( );
				fm.NombreFamilia = model.NombreFamilia;
				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_UPDATE_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}

		}
		[HttpDelete]
		[Route ( "familiasmateriales" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop" )]
		public async Task<IHttpActionResult> deleteFamMat ( int id )
		{
			try
			{
				var fm = await DB.FamiliasMateriales.FirstAsync ( e => e.Id == id );
				if ( fm == null ) return NotFound ( );
				DB.FamiliasMateriales.Remove ( fm );
				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_DELETE_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}

		}

		#region MovimientosPrecios
		[HttpGet]
		[Route ( "familiasmateriales/mov/{Id}" )]
		public async Task<IHttpActionResult> getMovimientosPrecio ( int Id )
		{
			var t = await DB.FamiliasMateriales.Include ( o => o.Movimientos ).FirstOrDefaultAsync ( o => o.Id == Id );
			if ( t == null ) return NotFound ( );

			System.Threading.Thread.Sleep ( 1000 );
			var movs = from mov in t.Movimientos
					   select new
					   {
						   Id = mov.MovimientoPrecioId,
						   mov.FechaRegistro,
						   mov.FechaOperacion,
						   mov.Valor,
						   mov.FamiliaMateriales_Id
					   };

			return Ok ( movs.OrderBy ( u => u.FechaOperacion ) );
		}

		[HttpGet]
		[Route ( "familiasmateriales/mov" )]
		public async Task<IHttpActionResult> getMovimientoPrecio ( int Id )
		{
			var itm = await ( from mov in DB.MovimientosPrecioFamiliaMateriales
							  where mov.MovimientoPrecioId == Id
							  select new Models.FrontEndModels.Catalogos.Movimiento
							  {
								  Id = mov.MovimientoPrecioId,
								  FechaRegistro = mov.FechaRegistro,
								  FechaOperacion = mov.FechaOperacion,
								  Valor = mov.Valor,
								  FamiliaMateriales_Id = mov.FamiliaMateriales_Id
							  } ).FirstOrDefaultAsync ( );

			if ( itm == null ) return NotFound ( );
			return Ok ( itm );
		}

		[HttpPost]
		[Route ( "familiasmateriales/mov" )]
		public async Task<IHttpActionResult> postMovimientoPrecio ( Models.FrontEndModels.Catalogos.Movimiento model )
		{
			try
			{
				if ( !ModelState.IsValid ) return BadRequest ( ModelState );
				if ( model.Valor == 0 ) return BadRequest ( "El valor debe ser diferente de 0" );
				var itm = new MovimientoPrecio ( )
				{
					FamiliaMateriales_Id = (int)model.FamiliaMateriales_Id,
					Valor = (double)model.Valor.Value,
					FechaRegistro = DateTime.Now.Date,
					FechaOperacion = (DateTime)model.FechaOperacion
				};

				DB.MovimientosPrecioFamiliaMateriales.Add ( itm );
				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_INSERT_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}
		}

		[HttpPut]
		[Route ( "familiasmateriales/mov" )]
		public async Task<IHttpActionResult> putMovimientoPrecio ( Models.FrontEndModels.Catalogos.Movimiento model )
		{
			if ( !ModelState.IsValid ) return BadRequest ( ModelState );
			try
			{
				var itm = await DB.MovimientosPrecioFamiliaMateriales.FirstOrDefaultAsync ( o => o.MovimientoPrecioId == model.Id );
				if ( itm == null ) return NotFound ( );

				itm.FamiliaMateriales_Id = (int)model.FamiliaMateriales_Id;
				itm.FechaOperacion = (DateTime)model.FechaOperacion;
				itm.Valor = (double)model.Valor;

				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_UPDATE_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}
		}

		[HttpDelete]
		[Route ( "familiasmateriales/mov" )]
		public async Task<IHttpActionResult> deleteMovimientoPrecio ( int Id )
		{
			try
			{
				var itm = await DB.MovimientosPrecioFamiliaMateriales
					.FirstOrDefaultAsync ( o => o.MovimientoPrecioId == Id );
				if ( itm == null ) return NotFound ( );
				DB.MovimientosPrecioFamiliaMateriales.Remove ( itm );
				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_DELETE_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}

		}


		[HttpGet]
		[Route ( "familiasmateriales/mov/chartdata/{Id}" )]
		public async Task<IHttpActionResult> getAllMovimientosPrecioChartDataFamilia ( int Id )
		{
			var movs = await ( from fm in DB.FamiliasMateriales
							   where fm.Id == Id
							   from mov in fm.Movimientos
							   select new SeriesValuesMovimientosPreciosMateriales
							   {
								   value = mov.Valor,
								   name = mov.FechaOperacion
							   } ).OrderBy ( o => o.name ).ToListAsync ( );

			double acum = 0;

			movs.ForEach ( mov =>
			{
				acum += (double)mov.value;
				mov.value = Math.Round ( acum, 3 );

			} );


			// movs.Add ( new SeriesValuesMovimientosPreciosMateriales ( ) { name = DateTime.Now, value = Math.Round ( acum, 3 ) } );


			return Ok ( new[] { new { name = "Movimientos", series = movs.OrderBy ( o => o.name ) } } );
		}


		[HttpGet]
		[Route ( "familiasmateriales/mov/chartdata" )]
		public async Task<IHttpActionResult> getMovimientosPrecioChartData ( int Id )
		{
			var mat = await ( from fm in DB.Materiales
							  where fm.Id == Id
							  select fm ).FirstOrDefaultAsync ( );

			var movs = await ( from fm in DB.FamiliasMateriales
							   where fm.Id == mat.FamiliaMateriales_Id
							   from mov in fm.Movimientos
							   where mov.FechaOperacion >= mat.FechaOperacion
							   select new SeriesValuesMovimientosPreciosMateriales
							   {
								   value = mov.Valor,
								   name = mov.FechaOperacion
							   } ).OrderBy ( o => o.name ).ToListAsync ( );


			double acum = mat.PrecioInicial;

			movs.ForEach ( mov =>
			{
				acum += (double)mov.value;
				mov.value = Math.Round ( acum, 3 );

			} );

			movs.Insert ( 0, new SeriesValuesMovimientosPreciosMateriales ( ) { name = mat.FechaOperacion, value = Math.Round ( mat.PrecioInicial, 3 ) } );


			return Ok ( new { material = $"{mat.NombreFamilia} {mat.Apariencia} {mat.Caracteristicas}".ToUpper ( ), data = new { name = "Precio", series = movs.OrderBy ( o => o.name ) } } );
		}

		private class SeriesValuesMovimientosPreciosMateriales
		{
			public DateTime name { get; set; }
			public double value { get; set; }
		}


		#endregion
	}
}