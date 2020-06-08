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
			var T = ( await DB.Database.SqlQuery<Models.progressItem> ( Models.progressItem.SQL_STR, par )
				.ToListAsync ( ) )
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
				} ).FirstOrDefault();


			return Ok ( T );
		}
	}

	namespace Models
	{
		public class progressItem
		{
			public const string SQL_STR = @"
SELECT o.OT, o.CLIENTE AS Cliente, o.PRODUCTO AS Producto, n.NombreTipoProducto AS TipoProducto, o.ClaveIntelisis,
    o.OrdenCompra, o.FechaRecibido, o.FechaEntregaSol, c.FechaCaptura, c.ML, o.Cantidad, o.Unidad, round(o.KGXMILL,6),
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