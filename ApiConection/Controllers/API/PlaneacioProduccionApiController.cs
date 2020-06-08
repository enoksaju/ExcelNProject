using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static libProduccionDataBase.Tablas.PlaneacionProduccion;

namespace ApiConection.Controllers.API
{
	public partial class ApisController
	{
		[HttpGet]
		[Route ( "planeacionSemana" )]
		[Authorize]
		public async Task<IHttpActionResult> getPlaneacionSemana ( int anio, int semana, int maquinaId )
		{
			try
			{
				var DiaInicial = Models.itemCalendar.YearWeekDayToDateTime ( anio, DayOfWeek.Monday, semana );
				var endDay = DiaInicial.AddDays ( 7 );
				var items = await this.getSemana ( anio, semana, maquinaId, DiaInicial, endDay );
				var ret = new
				{
					data = items,
					DiaInicial = DiaInicial.ToUniversalTime ( ),
					DiaFinal = endDay.ToUniversalTime ( )
				};

				return Ok ( ret );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}

		[HttpGet]
		[Route ( "unasignedPlaneacion" )]
		[Authorize]
		public async Task<IHttpActionResult> getUnasignedCalendarItems ( libProduccionDataBase.Tablas.Planeacion.TiposProcesoProduccion Proceso )
		{
			try
			{
				var t = await getunasigned ( Proceso );
				return Ok ( t );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}


		private async Task<List<Models.itemCalendar>> getunasigned ( libProduccionDataBase.Tablas.Planeacion.TiposProcesoProduccion Proceso )
		{
			return await ( from itm in DB.PlaneacionProduccion
						   where itm.TipoProceso.HasFlag ( Proceso )
						   && itm.Estatus.HasFlag ( statusProcesoProduccion.PorProgramar )
						   && itm.Activa == true
						   && !itm.Estatus.HasFlag ( statusProcesoProduccion.Programada )
						   select new Models.itemCalendar ( )
						   {
							   Proceso = itm.TipoProceso,
							   Estatus = itm.Estatus,
							   Activa = itm.Activa,
							   OT = itm.OT,
							   Ml = itm.Planeacion.OrdenTrabajo.TempCapt.ML,
							   Prioridad = itm.prioridad,
							   NombreProceso = itm.TipoProcesoNombre,
							   Cliente = itm.Planeacion.OrdenTrabajo.CLIENTE,
							   Producto = itm.Planeacion.OrdenTrabajo.PRODUCTO,
							   FechaEntrega = itm.Planeacion.FechaProgEntregaAlmacen,
							   FechaProgramada = itm.FechaProgramada,
							   FechaProcesada = itm.FechaProcesada
						   } ).ToListAsync ( );
		}

		private async Task<List<Models.itemCalendar>> getSemana ( int anio, int semana, int maquinaId, DateTime ini, DateTime end )
		{
			var DiaInicial = Models.itemCalendar.YearWeekDayToDateTime ( anio, DayOfWeek.Monday, semana );
			var endDay = DiaInicial.AddDays ( 7 );

			return await ( from itm in DB.PlaneacionProduccion
						   where itm.FechaProgramada >= ini
						   && itm.FechaProgramada <= end
						   && itm.Estatus.HasFlag ( libProduccionDataBase.Tablas.PlaneacionProduccion.statusProcesoProduccion.Programada )
						   && itm.MaquinaId == maquinaId
						   orderby itm.prioridad
						   select new Models.itemCalendar
						   {
							   Proceso = itm.TipoProceso,
							   Estatus = itm.Estatus,
							   Activa = itm.Activa,
							   OT = itm.OT,
							   Ml = itm.Planeacion.OrdenTrabajo.TempCapt.ML,
							   Prioridad = itm.prioridad,
							   NombreProceso = itm.TipoProcesoNombre,
							   Cliente = itm.Planeacion.OrdenTrabajo.CLIENTE,
							   Producto = itm.Planeacion.OrdenTrabajo.PRODUCTO,
							   FechaEntrega = itm.Planeacion.FechaProgEntregaAlmacen,
							   FechaProgramada = itm.FechaProgramada,
							   MaquinaId = itm.MaquinaId,
							   Maquina = itm.Maquina.NombreMaquina
						   } ).ToListAsync ( );
		}

		[HttpGet]
		[Route ( "initialSemana" )]
		[Authorize]
		public async Task<IHttpActionResult> getInitCalendarioSemanal ( libProduccionDataBase.Tablas.Planeacion.TiposProcesoProduccion Proceso, int anio, int semana, int maquinaId )
		{
			try
			{
				var DiaInicial = Models.itemCalendar.YearWeekDayToDateTime ( anio, DayOfWeek.Monday, semana );
				var endDay = DiaInicial.AddDays ( 7 );
				var items = await this.getSemana ( anio, semana, maquinaId, DiaInicial, endDay );
				var t = await getunasigned ( Proceso );

				var init = new
				{
					semana = new
					{
						data = items,
						DiaInicial = DiaInicial.ToUniversalTime ( ),
						DiaFinal = endDay.ToUniversalTime ( )
					},
					unasigned = t
				};

				return Ok ( init );

			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}
		}


		[HttpPost]
		[Route ( "updatePrioridadCalendarItem" )]
		[Authorize ( Roles = "Administrador, Develop, Sistemas, Administrador Produccion" )]
		public async Task<IHttpActionResult> updatePrioridadCalendarItems ( Models.itemCalendar[] itms )
		{
			if ( !ModelState.IsValid ) return BadRequest ( ModelState );
			try
			{
				foreach ( var itm in itms )
				{
					var entity = itm.toPlaneacionProduccion ( );
					entity.prioridad = null;
					DB.PlaneacionProduccion.Attach ( entity );
					entity.prioridad = itm.Prioridad;
				}

				await DB.SaveChangesAsync ( );
				return Ok ( true );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );

			}
		}

		[HttpPost]
		[Route ( "updateCalendarItem" )]
		[Authorize ( Roles = "Administrador, Develop, Sistemas, Administrador Produccion" )]
		public async Task<IHttpActionResult> updateCalendarItem ( Models.itemCalendar itm )
		{
			if ( !ModelState.IsValid ) return BadRequest ( ModelState );
			try
			{
				var entity = itm.toPlaneacionProduccion ( );
				DB.PlaneacionProduccion.Attach ( entity );
				DB.Entry ( entity ).State = EntityState.Modified;

				await DB.SaveChangesAsync ( );
				return Ok ( true );
			}
			catch ( Exception ex )
			{
				return InternalServerError ( ex );
			}

		}
	}

	namespace Models
	{
		public class itemCalendar
		{
			public libProduccionDataBase.Tablas.Planeacion.TiposProcesoProduccion Proceso { get; set; }
			public libProduccionDataBase.Tablas.PlaneacionProduccion.statusProcesoProduccion Estatus { get; set; }
			public string OT { get; set; }
			public bool Activa { get; set; }
			public int? Prioridad { get; set; }
			public string NombreProceso { get; set; }
			public string Cliente { get; set; }
			public string Producto { get; set; }
			public int Ml { get; set; }
			public DateTime FechaEntrega { get; set; }
			public DateTime? FechaProgramada { get; set; }
			public DateTime? FechaProcesada { get; set; }
			public int? MaquinaId { get; set; }
			public string Maquina { get; set; }

			public itemCalendar () { }
			public itemCalendar ( libProduccionDataBase.Tablas.PlaneacionProduccion entity )
			{
				this.Activa = entity.Activa;
				this.Cliente = entity.Planeacion.OrdenTrabajo.CLIENTE;
				this.Estatus = entity.Estatus;
				this.FechaEntrega = entity.Planeacion.FechaProgEntregaAlmacen;
				this.FechaProcesada = entity.FechaProcesada;
				this.FechaProgramada = entity.FechaProgramada != null ? entity.FechaProgramada?.ToUniversalTime ( ) : null;
				this.FechaProgramada = entity.FechaProgramada;
				this.MaquinaId = entity.MaquinaId;
				this.Ml = entity.Planeacion.OrdenTrabajo.TempCapt.ML;
				this.NombreProceso = entity.TipoProcesoNombre;
				this.OT = entity.OT;
				this.Prioridad = entity.prioridad;
				this.Proceso = entity.TipoProceso;
				this.Producto = entity.Planeacion.OrdenTrabajo.PRODUCTO;
			}

			public libProduccionDataBase.Tablas.PlaneacionProduccion toPlaneacionProduccion ()
			{
				var t = new libProduccionDataBase.Tablas.PlaneacionProduccion ( );
				t.OT = this.OT;
				t.TipoProceso = this.Proceso;
				t.Activa = this.Activa;
				t.Estatus = this.Estatus;
				t.FechaProcesada = this.FechaProcesada;
				t.FechaProgramada = this.FechaProgramada != null ? this.FechaProgramada?.Date : null;
				t.MaquinaId = this.MaquinaId;
				t.prioridad = this.Prioridad;
				return t;
			}

			public static DateTime YearWeekDayToDateTime ( int year, DayOfWeek day, int week )
			{
				DateTime startOfYear = new DateTime ( year, 1, 1 );

				// The +7 and %7 stuff is to avoid negative numbers etc.
				int daysToFirstCorrectDay = ( ( (int)day - (int)startOfYear.DayOfWeek ) + 7 ) % 7;

				return startOfYear.AddDays ( 7 * ( week - 1 ) + daysToFirstCorrectDay );
			}
		}
	}
}
