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
							select new Models.FrontEndModels.Catalogos.FronEndModel_FamiliasMateriales ( )
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
							 select new Models.FrontEndModels.Catalogos.FronEndModel_FamiliasMateriales ( )
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
		public async Task<IHttpActionResult> postFamMat ( Models.FrontEndModels.Catalogos.FronEndModel_FamiliasMateriales model )
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
		public async Task<IHttpActionResult> putFamMat ( Models.FrontEndModels.Catalogos.FronEndModel_FamiliasMateriales model )
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
	}
}