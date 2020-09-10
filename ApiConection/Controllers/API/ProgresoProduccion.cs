using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ApiConection.Controllers.API
{
	public partial class ApisController
	{
		[HttpGet]
		[Route ( "progresoOT" )]
		public async Task<IHttpActionResult> getProgresoOT ( string ot )
		{
			var par = new MySql.Data.MySqlClient.MySqlParameter ( "@OT", MySql.Data.MySqlClient.MySqlDbType.VarString );
			par.Value = ot;



			var y = await DB.Database.SqlQuery<Models.progressItem> ( Models.progressItem.SQL_STR, par )
				.ToListAsync ( );


			if ( y.Count <= 0 )
			{
				y = await DB.Database.SqlQuery<Models.progressItem> ( Models.progressItem.SQL_STR_EMPTY, par )
				.ToListAsync ( );
			}


			var T = y
				.GroupBy ( itm => new
				{
					itm.OT,
					itm.Cliente,
					itm.Producto,
					itm.TipoProducto,
					itm.ClaveIntelisis,
					itm.OrdenCompra,
					itm.FechaEntregaSol,
					itm.FechaRecibido,
					itm.FechaCaptura,
					itm.ML,
					itm.Cantidad,
					itm.Unidad,
					itm.KGXMILL
				}, itm => new
				{
					itm.PesoNeto,
					itm.Conteo,
					itm.Bobinas,
					itm.Banderas,
					itm.maximoBanderasBobina,
					itm.BobinasArrugas,
					itm.NombreProceso,
					itm.UltimaCaptura,
					itm.Maquinas
				}, ( baseP, p ) => new
				{
					baseP.OT,
					baseP.Cliente,
					baseP.Producto,
					baseP.TipoProducto,
					baseP.ClaveIntelisis,
					baseP.OrdenCompra,
					baseP.FechaEntregaSol,
					baseP.FechaRecibido,
					baseP.FechaCaptura,
					baseP.ML,
					baseP.Cantidad,
					baseP.Unidad,
					baseP.KGXMILL,
					Procesos = p,
					Count = p.Count ( )
				} ).FirstOrDefault ( );


			return Ok ( T );
		}

		[HttpGet]
		[Route ( "progresoPDF" )]
		public async Task<IHttpActionResult> getProgresoOT_PDF ( string ot, libProduccionDataBase.Reportes.Models.OrdenTrabajoModel.Procesos? proceso )
		{
			if (proceso == null )  return NotFound ( );

			byte[] buffer = await libProduccionDataBase.Reportes.OrdenTrabajo_ReportViewer.ToPDFAsync ( ot, proceso.Value );

			if ( buffer != null )
			{
				var contentLength = buffer.Length;
				var result = new System.Net.Http.HttpResponseMessage ( System.Net.HttpStatusCode.OK )
				{
					Content = new System.Net.Http.ByteArrayContent ( buffer )
				};

				result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue ( "application/pdf" );
				result.Content.Headers.ContentLength = contentLength;
				System.Net.Http.Headers.ContentDispositionHeaderValue contentDisposition = null;

				if ( System.Net.Http.Headers.ContentDispositionHeaderValue.TryParse ( $"inline; filename= Progreso_OT_{ ot }_{DateTime.Now:dd_MM_yyyy_HH_mm}.pdf", out contentDisposition ) )
				{
					result.Content.Headers.ContentDisposition = contentDisposition;
				}
				var response = ResponseMessage ( result );
				return response;
			}
			else
			{
				return NotFound();
			}
		}
	}

	namespace Models
	{
		public class progressItem
		{
			public const string SQL_STR = @"
SELECT o.OT, o.CLIENTE AS Cliente, o.PRODUCTO AS Producto, n.NombreTipoProducto AS TipoProducto, o.ClaveIntelisis,
    o.OrdenCompra, o.FechaRecibido, o.FechaEntregaSol, c.FechaCaptura, c.ML, o.Cantidad, o.Unidad, round(o.KGXMILL,6) as KGXMILL,
    ROUND(SUM(PESOBRUTO - PESOCORE), 2) AS PesoNeto, SUM(piezas) AS conteo, COUNT(numero) AS Bobinas,
    SUM(banderas) AS Banderas, MAX(banderas) AS maximoBanderasBobina, SUM(IF(t.EnSaneoArrugas <> 0, 1, 0)) AS BobinasArrugas,
    p.NombreProceso, MAX(FECHA) AS UltimaCaptura, GROUP_CONCAT(DISTINCT m.NombreMaquina SEPARATOR ', ') AS Maquinas
FROM
    production.tproduccion t INNER JOIN
    maquinas m ON m.id = t.maquina INNER JOIN
    procesos p ON p.id = t.tipoproceso INNER JOIN
    tordentrabajo o ON o.ot = t.ot INNER JOIN
    tiposproducto n ON n.id = (o.tipo + 1) INNER JOIN
    tempcapt c ON c.OT = t.OT
WHERE t.ot = @OT
GROUP BY t.Ot , t.tipoproceso
ORDER BY t.Ot DESC , ultimaCaptura;";

			public const string SQL_STR_EMPTY = @"
SELECT o.OT, o.CLIENTE AS Cliente, o.PRODUCTO AS Producto, n.NombreTipoProducto AS TipoProducto, o.ClaveIntelisis,
    o.OrdenCompra, o.FechaRecibido, o.FechaEntregaSol, c.FechaCaptura, c.ML, o.Cantidad, o.Unidad, round(o.KGXMILL,6) as KGXMILL,
    0 AS PesoNeto, 
    0 AS Bobinas,
    0 AS Banderas, 
    0 AS maximoBanderasBobina, 
    0 AS BobinasArrugas,
    'Sin Procesar', null, '' AS Maquinas
FROM  tordentrabajo o INNER JOIN
    tiposproducto n ON n.id = (o.tipo + 1) INNER JOIN
    tempcapt c ON c.OT = o.OT
WHERE o.ot = @OT";


			public string OT { get; set; }
			public string Cliente { get; set; }
			public string Producto { get; set; }
			public string TipoProducto { get; set; }
			public string ClaveIntelisis { get; set; }
			public string OrdenCompra { get; set; }
			public DateTime FechaEntregaSol { get; set; }
			public DateTime FechaRecibido { get; set; }
			public DateTime FechaCaptura { get; set; }
			public int ML { get; set; }
			public double Cantidad { get; set; }
			public string Unidad { get; set; }
			public double KGXMILL { get; set; }
			public double PesoNeto { get; set; }
			public int Conteo { get; set; }
			public int Bobinas { get; set; }
			public int Banderas { get; set; }
			public int maximoBanderasBobina { get; set; }
			public int BobinasArrugas { get; set; }
			public string NombreProceso { get; set; }
			public DateTime UltimaCaptura { get; set; }
			public string Maquinas { get; set; }
		}
	}
}