using System;
using System.Collections.Generic;
using System.Data.Entity;
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
		[Route ( "materiales" )]
		public async Task<IHttpActionResult> getMateriales ( int pageSize, int pageNumber, OrderTypes orderType, string orderBy, string query )
		{
			try
			{
				query = query.Replace ( "%", "" );
				int _totalItems = await DB.Materiales.Where ( o => o.Apariencia.Contains ( query ) | o.Caracteristicas.Contains ( query ) | o.Familia.NombreFamilia.Contains ( query ) ).CountAsync ( );
				double _totalPages = Math.Ceiling ( (double)_totalItems / pageSize );

				IQueryable<Material> famMatQuery = DB.Materiales.AsQueryable ( );

				string _columnOrder = $"{( HasProperty ( typeof ( FamiliaMateriales ), orderBy ) ? orderBy : "Id" ) } {orderType}";

				List<Material> ret = await famMatQuery.Where ( o => o.Apariencia.Contains ( query ) | o.Caracteristicas.Contains ( query ) | o.Familia.NombreFamilia.Contains ( query ) )
					.OrderBy ( _columnOrder ).Skip ( ( pageNumber - 1 ) * pageSize ).Take ( pageSize ).ToListAsync ( );

				return Ok ( new
				{
					TotalPages = _totalPages,
					TotalCount = _totalItems,
					Items = from itm in ret
							select new Models.FrontEndModels.Catalogos.Material ( )
							{
								Id = itm.Id,
								FamiliaMateriales_Id = itm.FamiliaMateriales_Id,
								NombreFamilia = itm.NombreFamilia,
								Apariencia = itm.Apariencia,
								Caracteristicas = itm.Caracteristicas,
								Calibres = itm.Calibres,
								Convenio = itm.Convenio,
								Metalizado = itm.Metalizado,
								Unidad = itm.Unidad,
								FactorDensidad = itm.FactorDensidad,
								PrecioInicial = itm.PrecioInicial,
								CostoInicial = itm.CostoInicial,
								PrecioActual = itm.PrecioActual,
								FechaOperacion = itm.FechaOperacion,
								FechaRegistro = itm.FechaRegistro
							}
				} );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}

		}

		[HttpGet]
		[Route ( "materiales" )]
		public async Task<IHttpActionResult> getMaterial ( int id )
		{
			try
			{
				//System.Threading.Thread.Sleep ( 3000 );
				List<Material> ret = await DB.Materiales.Where ( u => u.Id == id ).ToListAsync ( );


				// Busco la entidad con el id especificado
				var fm = ( from itm in ret
						   where itm.Id == id
						   select new Models.FrontEndModels.Catalogos.Material ( )
						   {
							   Id = itm.Id,
							   FamiliaMateriales_Id = itm.FamiliaMateriales_Id,
							   NombreFamilia = itm.NombreFamilia,
							   Apariencia = itm.Apariencia,
							   Caracteristicas = itm.Caracteristicas,
							   Calibres = itm.Calibres,
							   Convenio = itm.Convenio,
							   Metalizado = itm.Metalizado,
							   Unidad = itm.Unidad,
							   FactorDensidad = itm.FactorDensidad,
							   PrecioInicial = itm.PrecioInicial,
							   CostoInicial = itm.CostoInicial,
							   PrecioActual = itm.PrecioActual,
							   FechaOperacion = itm.FechaOperacion,
							   FechaRegistro = itm.FechaRegistro
						   } ).FirstOrDefault ( );




				//var fm = await DB.Materiales.FirstOrDefaultAsync ( u => u.Id == id );


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
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}

		[HttpPost]
		[Route ( "materiales" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop, Administrador Ventas" )]
		public async Task<IHttpActionResult> postMaterial ( Models.FrontEndModels.Catalogos.Material model )
		{
			if ( !ModelState.IsValid ) return BadRequest ( ModelState );
			try
			{

				var entity = new Material ( )
				{
					FamiliaMateriales_Id = model.FamiliaMateriales_Id,
					Apariencia = model.Apariencia,
					Caracteristicas = model.Caracteristicas,
					Convenio = model.Convenio,
					CostoInicial = model.CostoInicial,
					FactorDensidad = model.FactorDensidad,
					FechaOperacion = model.FechaOperacion,
					FechaRegistro = DateTime.Now.Date,
					Metalizado = model.Metalizado,
					PrecioInicial = model.PrecioInicial,
					Unidad = model.Unidad,

				};

				foreach ( var item in model.Calibres )
				{
					entity.Calibres.Add ( item );
				}


				DB.Materiales.Add ( entity );
				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_INSERT_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}
		}

		[HttpPut]
		[Route ( "materiales" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop, Administrador Ventas" )]
		public async Task<IHttpActionResult> putMaterial ( Models.FrontEndModels.Catalogos.Material model )
		{
			if ( !ModelState.IsValid ) return BadRequest ( ModelState );
			try
			{
				var entity = await DB.Materiales.FirstOrDefaultAsync ( e => e.Id == model.Id );
				if ( entity == null ) return NotFound ( );

				entity.FamiliaMateriales_Id = model.FamiliaMateriales_Id;
				entity.Apariencia = model.Apariencia;
				entity.Caracteristicas = model.Caracteristicas;
				entity.Convenio = model.Convenio;
				entity.CostoInicial = model.CostoInicial;
				entity.FactorDensidad = model.FactorDensidad;
				entity.FechaOperacion = model.FechaOperacion;
				entity.Metalizado = model.Metalizado;
				entity.PrecioInicial = model.PrecioInicial;
				entity.Unidad = model.Unidad;


				entity.Calibres.ToList ( ).ForEach ( item =>
				{
					if ( !model.Calibres.Any ( u => u.Valor == item.Valor ) )
					{
						System.Diagnostics.Debug.WriteLine ( $"Quitando {item.Valor}" );
						entity.Calibres.Remove ( item );
					}
				} );

				foreach ( var item in model.Calibres )
				{
					if ( !entity.Calibres.Any ( u => u.Valor == item.Valor ) )
					{
						System.Diagnostics.Debug.WriteLine ( $"Agregando {item.Valor}" );
						entity.Calibres.Add ( item );
					}
				}

				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_UPDATE_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}
		}

		[HttpDelete]
		[Route ( "materiales" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop, Administrador Ventas" )]
		public async Task<IHttpActionResult> deleteMaterial ( int id )
		{
			try
			{
				var fm = await DB.Materiales.FirstAsync ( e => e.Id == id );
				if ( fm == null ) return NotFound ( );
				DB.Materiales.Remove ( fm );
				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_DELETE_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}

		}

		[HttpGet]
		[Route ( "materiales/chart/{id}" )]
		public async Task<IHttpActionResult> getChartMaterial ( int id )
		{
			Material ret = await DB.Materiales.SingleOrDefaultAsync ( u => u.Id == id );
			var movs = ret.Familia.Movimientos.Where ( i => i.FechaOperacion >= ret.FechaOperacion && i.FechaOperacion <= DateTime.Now.Date );
			List<dataOfChart> toRet = new List<dataOfChart> ( );

			double Acum = ret.PrecioInicial;
			toRet.Add ( new dataOfChart ( ret.FechaOperacion.Date, Acum ) );

			foreach ( var mov in movs )
			{
				Acum += Math.Round ( mov.Valor, 4 );
				toRet.Add ( new dataOfChart ( mov.FechaOperacion.Date, Math.Round ( Acum, 4 ) ) );
			}

			toRet.Add ( new dataOfChart ( DateTime.Now.Date, Math.Round ( Acum, 4 ) ) );

			return Ok ( toRet );
		}
	}

	public class dataOfChart
	{
		public object label { get; set; }
		public object data { get; set; }
		public dataOfChart ( object label, object data )
		{
			this.label = label;
			this.data = data;
		}
	}
}