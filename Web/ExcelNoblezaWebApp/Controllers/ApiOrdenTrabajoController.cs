using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using libProduccionDataBase.Tablas;
using libReportsOTS;
using System.Text.RegularExpressions;

namespace ExcelNoblezaWebApp.Controllers {
	public class ApiOrdenTrabajoController : ApiController {
		libProduccionDataBase.Contexto.DataBaseContexto DB;

		public ApiOrdenTrabajoController ( ) {
			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
		}



		[Route ( "api/OrdenTrabajo/ver" )]
		[HttpPost]
		[System.Web.Http.Description.ResponseType ( typeof ( GetOTModel ) )]
		[Authorize ( Roles = "Admin, Supervisor, User" )]
		public IHttpActionResult ver ( GetOTModel OT ) {
			if ( !DB.tempOt.Any ( o => o.OT.Trim ( ) == OT.OrderNumber ) ) {
				return BadRequest ( "No se encontro la OT " + OT.OrderNumber );
			}
			var y = DB.tempOt.FirstOrDefault ( o => o.OT.Trim ( ) == OT.OrderNumber );
			y.Desperdicios.Clear ( );
			y.Produccion.Clear ( );
			y.TarimasNCuatro.Clear ( );
			return Ok ( y);
		}

		[Route ( "api/OrdenTrabajo/{ot}/{proceso}/" )]
		[HttpGet]
		[Authorize ( Roles = "Admin, Supervisor, User" )]
		public HttpResponseMessage getPdf ( string ot , string proceso ) {

			HttpResponseMessage response = Request.CreateResponse ( HttpStatusCode.BadRequest );

			if ( !DB.tempOt.Any ( r => r.OT.Trim ( ) == ot ) ) {
				var statuscode = HttpStatusCode.NotFound;
				response = Request.CreateResponse ( statuscode );
			} else {

				GetOTModel.procesos p = ( GetOTModel.procesos ) Enum.Parse ( typeof ( GetOTModel.procesos ) , proceso );
				TemporalOrdenTrabajo temp = DB.tempOt.FirstOrDefault ( o => o.OT == ot );
				List<objectReport> objList = new List<objectReport> ( );

				switch ( p ) {
					case GetOTModel.procesos.Corte:
						if ( temp.INSTCORTE != "" )
							for ( int i = 1; i <= 46; i++ ) {
								objList.Add ( new objectReport ( temp , 0 , i ) );
							}
						break;
					case GetOTModel.procesos.Doblado:
						if ( temp.INSTDOBLADO != "" )
							for ( int i = 1; i <= 42; i++ ) {
								objList.Add ( new objectReport ( temp , 1 , i ) );
							}
						break;
					case GetOTModel.procesos.Embobinado:
						if ( temp.INSTEMBOBINADO != "" )
							for ( int i = 1; i <= 42; i++ ) {
								objList.Add ( new objectReport ( temp , 2 , i ) );
							}
						break;
					case GetOTModel.procesos.Extrusion:
						if ( temp.INSTEXTRUSION != "" )
							for ( int i = 1; i <= 38; i++ ) {
								objList.Add ( new objectReport ( temp , 3 , i ) );
							}
						break;
					case GetOTModel.procesos.Impresion:
						if ( temp.INSTIMPRESION != "" )
							for ( int i = 1; i <= 39; i++ ) {
								objList.Add ( new objectReport ( temp , 4 , i ) );
							}
						break;
					case GetOTModel.procesos.Laminacion:
						if ( temp.INSTLAMINACION != "" )
							for ( int i = 1; i <= 40; i++ ) {
								objList.Add ( new objectReport ( temp , 5 , i ) );
							}
						break;
					case GetOTModel.procesos.Mangas:
						if ( temp.INSTMANGAS != "" )
							for ( int i = 1; i <= 38; i++ ) {
								objList.Add ( new objectReport ( temp , 6 , i ) );
							}
						break;
					case GetOTModel.procesos.Refinado:
						if ( temp.INSTREFINADO != "" )
							for ( int i = 1; i <= 46; i++ ) {
								objList.Add ( new objectReport ( temp , 7 , i ) );
							}
						break;
					case GetOTModel.procesos.Sellado:
						if ( temp.INSTSELLADO != "" )
							for ( int i = 1; i <= 42; i++ ) {
								objList.Add ( new objectReport ( temp , 8 , i ) );
							}
						break;
					case GetOTModel.procesos.Todas:
						if ( temp.INSTCORTE != "" )
							for ( int i = 1; i <= 46; i++ ) {
								objList.Add ( new objectReport ( temp , 0 , i ) );
							};
						if ( temp.INSTDOBLADO != "" )
							for ( int i = 1; i <= 42; i++ ) {
								objList.Add ( new objectReport ( temp , 1 , i ) );
							};
						if ( temp.INSTEMBOBINADO!= "" )
							for ( int i = 1; i <= 42; i++ ) {
								objList.Add ( new objectReport ( temp , 2 , i ) );
							};
						if ( temp.INSTEXTRUSION != "" )
							for ( int i = 1; i <= 38; i++ ) {
								objList.Add ( new objectReport ( temp , 3 , i ) );
							};
						if ( temp.INSTIMPRESION != "" )
							for ( int i = 1; i <= 39; i++ ) {
								objList.Add ( new objectReport ( temp , 4 , i ) );
							};
						if ( temp.INSTLAMINACION != "" )
							for ( int i = 1; i <= 40; i++ ) {
								objList.Add ( new objectReport ( temp , 5 , i ) );
							};
						if ( temp.INSTMANGAS != "" )
							for ( int i = 1; i <= 38; i++ ) {
								objList.Add ( new objectReport ( temp , 6 , i ) );
							};
						if ( temp.INSTREFINADO != "" )
							for ( int i = 1; i <= 46; i++ ) {
								objList.Add ( new objectReport ( temp , 7 , i ) );
							};
						if ( temp.INSTSELLADO != "" )
							for ( int i = 1; i <= 42; i++ ) {
								objList.Add ( new objectReport ( temp , 8 , i ) );
							};
						break;
				}

				byte [ ] buffer = new byte [ 0 ];
				buffer = OT_PDF.getPDF ( objList ).ToArray ( );

				var contentLength = buffer.Length;
				var statuscode = HttpStatusCode.OK;
				response = Request.CreateResponse ( statuscode );
				response.Content = new StreamContent ( new MemoryStream ( buffer ) );
				response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue ( "application/pdf" );
				response.Content.Headers.ContentLength = contentLength;
				System.Net.Http.Headers.ContentDispositionHeaderValue contentDisposition = null;
				if ( System.Net.Http.Headers.ContentDispositionHeaderValue.TryParse ( "inline; filename= OT_" + ot + "_" + proceso + ".pdf" , out contentDisposition ) ) {
					response.Content.Headers.ContentDisposition = contentDisposition;
				}
			}

			return response;
		}
	}
	public class GetOTModel {
		public enum procesos { Corte, Doblado, Embobinado, Extrusion, Impresion, Laminacion, Mangas, Refinado, Sellado, Todas }
		public string OrderNumber { get; set; }
		public procesos Proceso { get; set; }
	}

	public class OT_PDF {
		public static System.IO.MemoryStream getPDF ( object DataSourceValue ) {
			try {
				var rpv = new ReportViewer ( ) { ZoomMode = ZoomMode.PageWidth , ShowPrintButton = true };
				System.Reflection.Assembly Assembly = System.Reflection.Assembly.LoadFrom ( libReportsOTS.PathInit.Path );
				System.IO.Stream Stream = Assembly.GetManifestResourceStream ( "libReportsOTS.Report1.rdlc" );

				rpv.LocalReport.LoadReportDefinition ( Stream );
				rpv.LocalReport.DataSources.Clear ( );
				rpv.LocalReport.DataSources.Add ( new ReportDataSource ( "DataSet1" , DataSourceValue ) );

				return new System.IO.MemoryStream ( rpv.LocalReport.Render ( "pdf" ) );
			} catch ( Exception ex ) {
				throw ex;
			}
		}
	}
}
