using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using libProduccionDataBase.Tablas;
using static Cotizador.Controllers.CatalogosController;
using System.Data.Entity;
using System.Linq.Dynamic;

namespace Cotizador.Controllers
{
	public partial class CatalogosController : ApiController
	{
		[HttpGet]
		[Route ( "impresoras" )]
		public async Task<IHttpActionResult> getImpresoras ( int pageSize, int pageNumber, OrderTypes orderType, string orderBy, string query )
		{
			try
			{
				query = query.Replace ( "%", "" );
				int _totalItems = await DB.Maquinas.Where ( o => ( o.ModeloMaquina.Contains ( query ) | o.NombreMaquina.Contains ( query ) | o.Linea.Nombre.Contains ( query ) ) & o.TipoMaquina_Id == 1 ).CountAsync ( );
				double _totalPages = Math.Ceiling ( (double)_totalItems / pageSize );

				IQueryable<Maquina> famMatQuery = DB.Maquinas.AsQueryable ( );

				string _columnOrder = $"{( HasProperty ( typeof ( Maquina ), orderBy ) ? orderBy : "Id" ) } {orderType}";

				List<Maquina> ret = await famMatQuery.Where ( o => ( o.ModeloMaquina.Contains ( query ) | o.NombreMaquina.Contains ( query ) | o.Linea.Nombre.Contains ( query ) ) & o.TipoMaquina_Id == 1 )
					.OrderBy ( _columnOrder ).Skip ( ( pageNumber - 1 ) * pageSize ).Take ( pageSize ).ToListAsync ( );


				return Ok ( new
				{
					TotalPages = _totalPages,
					TotalCount = _totalItems,
					Items = from itm in ret
							select new Models.FrontEndModels.Catalogos.Impresora ( )
							{
								Id = itm.Id,
								NombreMaquina = itm.NombreMaquina,
								ModeloMaquina = itm.ModeloMaquina,
								Linea_Id = itm.Linea_Id,
								AnchoMaximoImpresion = itm.AnchoMaximoImpresion,
								AnchoMaximoMaterial = itm.AnchoMaximoMaterial,
								AnchoMinimoImpresion = itm.AnchoMinimoImpresion,
								AnchoMinimoMaterial = itm.AnchoMinimoMaterial,
								CostoArranque = itm.CostoArranque,
								CostoTurno = itm.CostoTurno,
								Decks = itm.Decks,
								MinutosTurno = itm.MinutosTurno,
								PorcentajeDesperdicio = itm.PorcentajeDesperdicio,
								Velocidad = itm.Velocidad,
								LineaNombre = itm.Linea.Nombre,

								ConfiguracionTintas = itm.ConfiguracionTintas,
								Rodillos = Models.FrontEndModels.Catalogos.Rodillo.fromObservableList ( itm.Rodillos )
							}
				} );

			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}

		}

		[HttpGet]
		[Route ( "impresoras" )]
		public async Task<IHttpActionResult> getImpresora ( int id )
		{
			try
			{
				Maquina itm = await DB.Maquinas.FirstOrDefaultAsync ( m => m.Id == id && m.TipoMaquina_Id == 1 );

				if ( itm != null )
				{
					return Ok ( new Models.FrontEndModels.Catalogos.Impresora ( )
					{
						Id = itm.Id,
						NombreMaquina = itm.NombreMaquina,
						ModeloMaquina = itm.ModeloMaquina,
						Linea_Id = itm.Linea_Id,
						AnchoMaximoImpresion = itm.AnchoMaximoImpresion,
						AnchoMaximoMaterial = itm.AnchoMaximoMaterial,
						AnchoMinimoImpresion = itm.AnchoMinimoImpresion,
						AnchoMinimoMaterial = itm.AnchoMinimoMaterial,
						CostoArranque = itm.CostoArranque,
						CostoTurno = itm.CostoTurno,
						Decks = itm.Decks,
						MinutosTurno = itm.MinutosTurno,
						PorcentajeDesperdicio = itm.PorcentajeDesperdicio,
						Velocidad = itm.Velocidad,
						LineaNombre = itm.Linea.Nombre,

						ConfiguracionTintas = itm.ConfiguracionTintas,
						Rodillos = Models.FrontEndModels.Catalogos.Rodillo.fromObservableList ( itm.Rodillos )
					} );
				}
				else
				{
					return NotFound ( );

				}
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}

		[HttpPost]
		[Route ( "impresoras" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop" )]
		public async Task<IHttpActionResult> postImpresora ( Models.FrontEndModels.Catalogos.Impresora model )
		{
			try
			{
				if ( !ModelState.IsValid ) return BadRequest ( ModelState );
				libProduccionDataBase.Tablas.Maquina maq = new Maquina ( )
				{
					AnchoMaximoImpresion = model.AnchoMaximoImpresion,
					AnchoMaximoMaterial = model.AnchoMaximoMaterial,
					AnchoMinimoImpresion = model.AnchoMinimoImpresion,
					AnchoMinimoMaterial = model.AnchoMinimoMaterial,
					CostoArranque = model.CostoArranque,
					CostoTurno = model.CostoTurno,
					Linea_Id = model.Linea_Id,
					MinutosTurno = model.MinutosTurno,
					ModeloMaquina = model.ModeloMaquina,
					NombreMaquina = model.NombreMaquina,
					PorcentajeDesperdicio = model.PorcentajeDesperdicio,
					TipoMaquina_Id = 1,
					Velocidad = model.Velocidad
				};

				foreach ( var rod in model.Rodillos )
				{
					maq.Rodillos.Add ( new Rodillo ( ) { Cantidad = (int)rod.Cantidad, Medida = (int)rod.Medida } );
				}

				foreach ( var confT in model.ConfiguracionTintas )
				{
					maq.ConfiguracionTintas.Add ( new configTintaMaquina ( ) { Cantidad = confT.Cantidad, MinimoMetros = confT.MinimoMetros } );
				}

				DB.Maquinas.Add ( maq );
				await DB.SaveChangesAsync ( );

				return Ok ( SUCCESS_INSERT_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}

		}

		[HttpPut]
		[Route ( "impresoras" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop" )]
		public async Task<IHttpActionResult> putImpresora ( Models.FrontEndModels.Catalogos.Impresora model )
		{
			try
			{
				DB.Configuration.LazyLoadingEnabled = false;
				if ( !ModelState.IsValid ) return BadRequest ( ModelState );

				Maquina entity = await DB.Maquinas
					.Include(r =>  r.Rodillos)
					.Include(p=> p.ConfiguracionTintas)
					.FirstOrDefaultAsync ( m => m.Id == model.Id );

				if ( entity == null ) return NotFound ( );

				entity.AnchoMaximoImpresion = model.AnchoMaximoImpresion;
				entity.AnchoMaximoMaterial = model.AnchoMaximoMaterial;
				entity.AnchoMinimoImpresion = model.AnchoMinimoImpresion;
				entity.AnchoMinimoMaterial = model.AnchoMinimoMaterial;
				entity.CostoArranque = model.CostoArranque;
				entity.CostoTurno = model.CostoTurno;
				entity.Linea_Id = model.Linea_Id;
				entity.MinutosTurno = model.MinutosTurno;
				entity.ModeloMaquina = model.ModeloMaquina;
				entity.NombreMaquina = model.NombreMaquina;
				entity.PorcentajeDesperdicio = model.PorcentajeDesperdicio;
				entity.TipoMaquina_Id = 1;
				entity.Velocidad = model.Velocidad;


				entity.Rodillos.ToList ( ).ForEach ( item =>
				{
					if ( !model.Rodillos.Any ( u => u.Medida == item.Medida ) )
					{
						System.Diagnostics.Debug.WriteLine ( $"Quitando {item.Medida}" );
						//entity.Rodillos.Remove ( item );
						DB.Rodillos.Remove ( item );
					}
				} );



				foreach ( var item in model.Rodillos )
				{
					if ( !entity.Rodillos.Any ( u => u.Medida == item.Medida ) )
					{
						System.Diagnostics.Debug.WriteLine ( $"Agregando {item.Medida}" );
						entity.Rodillos.Add ( new Rodillo ( ) { Medida = (double)item.Medida, Cantidad = (int)item.Cantidad } );
					}
				}

				entity.ConfiguracionTintas.ToList ( ).ForEach ( item =>
				{
					if ( !model.ConfiguracionTintas.Any ( u => u.Cantidad == item.Cantidad ) )
					{
						System.Diagnostics.Debug.WriteLine ( $"Quitando {item.Cantidad}" );
						entity.ConfiguracionTintas.Remove ( item );												
					}
				} );

				foreach ( var item in model.ConfiguracionTintas )
				{
					if ( !entity.ConfiguracionTintas.Any ( u => u.Cantidad == item.Cantidad ) )
					{
						System.Diagnostics.Debug.WriteLine ( $"Agregando {item.Cantidad}" );
						entity.ConfiguracionTintas.Add ( new configTintaMaquina ( ) { Cantidad = item.Cantidad, MinimoMetros = item.MinimoMetros } );
					}
				}

				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_UPDATE_MESSAGE );

			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}
			finally
			{
				DB.Configuration.LazyLoadingEnabled = true;
			}
		}

		[HttpDelete]
		[Route ( "impresoras" )]
		[Authorize ( Roles = "Administrador, Sistemas, Develop" )]
		public async Task<IHttpActionResult> deleteImpresora ( int id )
		{
			try
			{
				Maquina entity = await DB.Maquinas.FirstOrDefaultAsync ( m => m.Id == id );
				if ( entity == null ) return NotFound ( );
				DB.Maquinas.Remove ( entity );
				await DB.SaveChangesAsync ( );
				return Ok ( SUCCESS_DELETE_MESSAGE );
			}
			catch ( Exception ex )
			{
				return BadRequest ( libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB, ex ) );
			}

		}

		[HttpGet]
		[Route ( "lineas" )]
		public async Task<IHttpActionResult> getImpresorasLineas ()
		{
			try
			{
				return Ok ( await ( from linea in DB.Lineas
									select new
									{
										linea.Id,
										linea.Nombre
									} ).ToListAsync ( ) );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}
	}
}