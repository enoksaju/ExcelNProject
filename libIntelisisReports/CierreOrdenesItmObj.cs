using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace libIntelisisReports.Models
{
	public class CierreOrdenesItmObj
	{

		public delegate void OnChangeProgress ( CierreEventArgs e );
		public static event OnChangeProgress ChangeProgress;

		#region Constantes
		const string SQL_STR = @"
/* Transferencias de materiales (Entradas, Proceso y Salidas)*/
/*DECLARE @PEDIDO VARCHAR(10) = '61744';*/

SELECT --Selecciono los datos del Pedido 
	Cte_1.Nombre AS Cliente -- Cliente
	,CONCAT( RTRIM( Venta.[Mov]),' ',Venta.[MovID]) as Movimiento  --Movimiento
	,'' as Estatus --Estatus
	,Art_1.Linea as AlmacenOrg -- Almacen Origen
	,'' as AlmacenDes -- Almacen Destino
	,Art_1.Articulo as Articulo -- Articulo
	,Art_1.Descripcion1 as ArticuloDescripcion -- Descripcion Articulo
	,VentaD.Cantidad as Cantidad -- Cantidad
	,CASE 
		WHEN UPPER(VentaD.Unidad) = 'PZA' THEN 'PZAS'
		WHEN UPPER(VentaD.Unidad) = 'PIEZA' THEN 'PZAS'
		ELSE UPPER(VentaD.Unidad)
	END
	 as Unidad -- Unidad Articulo
	,isnull((select Top 1 AU.[Factor] from ArtUnidad AU where AU.Articulo= Art_1.Articulo and AU.Unidad= VentaD.Unidad),1) as Factor  -- Factor
	,(VentaD.Cantidad * isnull((select Top 1 AU.[Factor] from ArtUnidad AU where AU.Articulo= Art_1.Articulo and AU.Unidad= VentaD.Unidad),1))as CantidadInventario -- Cantidad Inventario
	,VentaD.DescripcionExtra as DescripcionExtra -- Descripcion extra
	,Venta.Usuario as Usuario -- Usuario (quien realiza el movimiento)
	,UPPER(RTrim(Venta.Referencia)) as Referencia -- Referencia al pedido u OT
	,CURRENT_TIMESTAMP AS FechaConclusion -- Fecha Conclusion (para traer los pedidos, aun no cuentan con fecha de conclusion)
	,CURRENT_TIMESTAMP as FechaEmision -- FEcha Emision del movimiento
	,Art_1.Grupo AS ArticuloGrupo -- Grupo del articulo
	,Art_1.Categoria as ArticuloCategoria -- Categoria del Articulo
	,Art_1.Familia as ArticuloFamilia -- Familia del Articulo
	,'Pedido' AS TipoElemento -- Tipo de Elemento
	,'' AS LineaOrg
	,'' as LineaDes
	,'PEDIDO' AS TipoMovimiento -- Tipo de Movimientos (obsoleto para formato con separacion de movimientos por linea)
	, 0 as Componente -- Componente
FROM Venta AS Venta 
	INNER JOIN Cte AS Cte_1 ON Venta.Cliente = Cte_1.Cliente 
	INNER JOIN VentaD ON Venta.ID = VentaD.ID 
	INNER JOIN Art AS Art_1 ON Art_1.Articulo = VentaD.Articulo
WHERE (Venta.Mov = 'PEDIDO') 
	AND (Venta.MovID = @PEDIDO) 
	AND (Cte_1.Nombre <> 'EXCEL NOBLEZA, S.A. DE C.V.') 
	AND (Venta.Estatus <> 'CANCELADO')

UNION

SELECT 
	'',
	CONCAT( RTRIM([Mov]),' ',[MovID])
    ,LTRIM(RTRIM(I.[Estatus]))
    ,I.[Almacen]
	,I.[AlmacenDestino]   
	,ID.[Articulo] 
	,A.[Descripcion1]
	,[Cantidad]  
	,LTRIM(RTRIM(UPPER(ID.[Unidad])))
	,ID.[Factor]
	,[CantidadInventario]
	,[DescripcionExtra]
	,I.[Usuario]
	,UPPER(RTrim([Referencia]))
	,I.FechaConclusion
	,I.FechaEmision
	,A.Grupo
	,A.Categoria
	,A.Familia
	,'Transferencia'
	, CASE I.Almacen 
		WHEN 'TERMINADO' THEN 'TERMINADO' 
		WHEN 'RCALMACEN' THEN 'RCALMACEN' 
		WHEN 'TINTAS' THEN 'TINTAS' 
		WHEN 'MATPRIMA' THEN 'MATPRIMA' 
		WHEN 'RECHAZADOS' THEN 'RECHAZADOS' 
		WHEN 'RE-LAMXEST' THEN 'LAMXEXT'
		ELSE SUBSTRING(I.Almacen, 4, len(I.Almacen) - 3) 
		END
	, CASE I.AlmacenDestino 
		WHEN 'TERMINADO' THEN 'TERMINADO' 
		WHEN 'RCALMACEN' THEN 'RCALMACEN' 
		WHEN 'TINTAS' THEN 'TINTAS' 
		WHEN 'MATPRIMA' THEN 'MATPRIMA' 
		WHEN 'RECHAZADOS' THEN 'RECHAZADOS'
		WHEN 'RE-LAMXEST' THEN 'LAMXEXT'
		ELSE SUBSTRING(I.AlmacenDestino, 4, len(I.AlmacenDestino) - 3) 
		END
	,CASE 
		WHEN I.almacenDestino = 'TERMINADO' THEN 'TERMINADO'
		WHEN (I.AlmacenDestino = 'RECHAZADOS' OR LEFT(I.AlmacenDestino,3)='RE-') THEN 'RECHAZADO'
		WHEN (I.AlmacenDestino IN( 'RCALMACEN', 'RC-CALIDAD')) THEN 'DESPERDICIOS'
		WHEN (I.AlmacenDestino) IN ( 'MATPRIMA' ) THEN 'DEVOLUCION'
		WHEN A.Categoria IN ('ME-Material Empaque') THEN 'MATERIAL DE EMPAQUE'
		WHEN A.Grupo IN ('MP-Tintas', 'MP-Solventes', 'Mp-Barniz') THEN 'TINTAS'
		WHEN A.Grupo IN ('MP-Adh Impr') THEN 'ADHESIVOS'
		WHEN A.Grupo IN ('MP-Aditivo', 'MP-Recuperado', 'MP-Pigmento', 'MP-Resinas', 'Ribete', 'MP-Telas') THEN 'ENTRADA MP'
		WHEN CASE I.Almacen 
				WHEN 'TERMINADO' THEN 'TERMINADO' 
				WHEN 'RCALMACEN' THEN 'RCALMACEN' 
				WHEN 'TINTAS' THEN 'TINTAS' 
				WHEN 'MATPRIMA' THEN 'MATPRIMA' 
				WHEN 'RECHAZADOS' THEN 'RECHAZADOS' 
				ELSE SUBSTRING(I.Almacen, 4, len(I.Almacen) - 3) 
			END = CASE I.AlmacenDestino 
						WHEN 'TERMINADO' THEN 'TERMINADO' 
						WHEN 'RCALMACEN' THEN 'RCALMACEN' 
						WHEN 'TINTAS' THEN 'TINTAS' 
						WHEN 'MATPRIMA' THEN 'MATPRIMA' 
						WHEN 'RECHAZADOS' THEN 'RECHAZADOS'
						ELSE SUBSTRING(I.AlmacenDestino, 4, len(I.AlmacenDestino) - 3) 
					END THEN 'PROCESO DE LINEA'		
		WHEN (A.Categoria IN('MP-Materia Prima')) THEN 'MATERIA PRIMA'
		WHEN (A.Categoria IN('PT-Producto Terminado')) THEN 'PRODUCTO TERMINADO'
	END 
	,CASE 
		WHEN A.Grupo IN ('MP-Solventes') THEN 0
		WHEN A.Grupo IN ('MP-Tintas','Mp-Barniz') THEN 0.34
		ELSE 1
	END
FROM [ExcelNobleza].[dbo].[InvD] ID
  INNER JOIN [ExcelNobleza].[dbo].[Inv] I ON I.ID= ID.ID
  INNER JOIN [ExcelNobleza].[dbo].[Art] A ON A.Articulo = ID.Articulo
  WHERE [Mov]='Transferencia' and Referencia like '%' + @Pedido + '%'

UNION

SELECT 
	'',
	CONCAT( RTRIM([Mov]),' ',[MovID])
    ,LTRIM(RTRIM(I.[Estatus]))
    ,I.[Almacen]
	,I.[AlmacenDestino]   
	,ID.[Articulo] 
	,A.[Descripcion1]
	,[Cantidad]  
	,LTRIM(RTRIM(UPPER(ID.[Unidad])))
	,ID.[Factor]
	,[CantidadInventario]
	,[DescripcionExtra]
	,I.[Usuario]
	,UPPER(RTrim([Referencia]))
	,ISNULL(I.FechaConclusion,0)
	,ISNULL(I.FechaEmision,0)
	,A.Grupo
	,A.Categoria
	,A.Familia
	,'Consumos'
	, CASE I.Almacen 
		WHEN 'TERMINADO' THEN 'TERMINADO' 
		WHEN 'RCALMACEN' THEN 'RCALMACEN' 
		WHEN 'TINTAS' THEN 'TINTAS' 
		WHEN 'MATPRIMA' THEN 'MATPRIMA' 
		WHEN 'RECHAZADOS' THEN 'RECHAZADOS' 
		ELSE SUBSTRING(I.Almacen, 4, len(I.Almacen) - 3) 
		END
	,''
	,'CONSUMO'
	, 0
FROM [ExcelNobleza].[dbo].[InvD] ID
  INNER JOIN [ExcelNobleza].[dbo].[Inv] I ON I.ID= ID.ID
  INNER JOIN [ExcelNobleza].[dbo].[Art] A ON A.Articulo = ID.Articulo
  WHERE [Mov] like 'Consumo Material' and Referencia like '%' + @Pedido + '%'

UNION

SELECT 
	''
	,CONCAT( RTRIM([Mov]),' ',[MovID])
	,LTRIM(RTRIM(I.[Estatus]))
    ,I.[Almacen]
	,I.[AlmacenDestino]   
	,ID.[Articulo] 
	,A.[Descripcion1]
	,[Cantidad]  
	,LTRIM(RTRIM(UPPER(ID.[Unidad])))
	,ID.[Factor]
	,[CantidadInventario]
	,[DescripcionExtra]
	,I.[Usuario]
	,UPPER(RTrim([Referencia]))
	,ISNULL(I.FechaConclusion,0)
	,ISNULL(I.FechaEmision,0)
	,A.Grupo
	,A.Categoria
	,A.Familia
	,'Requerido'
	, CASE I.Almacen 
		WHEN 'TERMINADO' THEN 'TERMINADO' 
		WHEN 'RCALMACEN' THEN 'RCALMACEN' 
		WHEN 'TINTAS' THEN 'TINTAS' 
		WHEN 'MATPRIMA' THEN 'MATPRIMA' 
		WHEN 'RECHAZADOS' THEN 'RECHAZADOS' 
		ELSE SUBSTRING(I.Almacen, 4, len(I.Almacen) - 3) 
		END
	, CASE I.AlmacenDestino 
		WHEN 'TERMINADO' THEN 'TERMINADO' 
		WHEN 'RCALMACEN' THEN 'RCALMACEN' 
		WHEN 'TINTAS' THEN 'TINTAS' 
		WHEN 'MATPRIMA' THEN 'MATPRIMA' 
		WHEN 'RECHAZADOS' THEN 'RECHAZADOS'
		WHEN 'RE-LAMXEST' THEN 'LAMXEXT'
		ELSE SUBSTRING(I.AlmacenDestino, 4, len(I.AlmacenDestino) - 3) 
		END
	,'REQUERIDO'
	, 0
FROM Inv AS I INNER JOIN InvD AS ID ON I.ID = ID.ID INNER JOIN Art AS A ON ID.Articulo = A.Articulo
WHERE (I.Empresa = 'GRAL') 
	AND (I.Mov = 'Orden Transferencia') 
	AND (I.Referencia LIKE '%' + @PEDIDO) 
	AND (I.Estatus = 'CONCLUIDO'  or I.Estatus = 'Pendiente') 
	AND (I.Usuario in ('JOSECG', 'HECTORH', 'LAMXEXT'))
	AND (RTRIM(UPPER(ID.Unidad)) = 'KG') AND (SUBSTRING(I.AlmacenDestino, 1, 3) = 'MP-')
";
		#endregion
		public class item
		{
			private string _Referencia;
			public string Cliente { get; set; }
			[Key, Column ( Order = 0 )]
			public string Movimiento { get; set; }
			public string Estatus { get; set; }
			public string AlmacenOrg { get; set; }
			public string AlmacenDes { get; set; }
			[Key, Column ( Order = 1 )]
			public string Articulo { get; set; }
			public string ArticuloDescripcion { get; set; }
			public double? Cantidad { get; set; }
			public string Unidad { get; set; }
			public double? Factor { get; set; }
			public double? CantidadInventario { get; set; }
			public string DescripcionExtra { get; set; }
			public string Usuario { get; set; }
			public string Referencia { get { return _Referencia; } set { _Referencia = value.ToUpper ( ); } }
			public DateTime? FechaConclusion { get; set; }
			public DateTime? FechaEmision { get; set; }
			public string ArticuloGrupo { get; set; }
			public string ArticuloCategoria { get; set; }
			public string ArticuloFamilia { get; set; }
			public string TipoElemento { get; set; }
			public string LineaOrg { get; set; }
			public string LineaDes { get; set; }
			public string TipoMovimiento { get; set; }
			public decimal Componente { get; set; }
		}

		public class itmCv : item, ICloneable
		{
			public string Tipo { get; set; }
			public string Linea { get; set; }
			public object Clone ()
			{
				itmCv nuevo = (itmCv)this.MemberwiseClone ( );
				return nuevo;
			}
		}

		public class CierreEventArgs
		{
			public int Progress { get; set; }
			public string OT { get; set; }
			public string Paso { get; set; }

			public CierreEventArgs ( int _progress, string _paso )
			{
				this.OT = CierreOrdenesItmObj.OT;
				this.Progress = _progress;
				this.Paso = _paso;
			}
		}

		private static string _OT;
		public static string OT => CierreOrdenesItmObj._OT;

		private static List<CierreOrdenesItmObj.itmCv> Elementos { get; set; } = new List<CierreOrdenesItmObj.itmCv> ( );
		public static void Initialice ( string OT )
		{
			_OT = OT;
			Elementos.Clear ( );
			ChangeProgress?.Invoke ( new CierreEventArgs ( 0, "Conectanco..." ) );
			using ( var cnn = new SqlConnection ( Properties.Settings.Default.ExcelNoblezaConnectionString ) )
			{
				cnn.Open ( );


				using ( var ad = new SqlCommand ( SQL_STR, cnn ) )
				{
					ad.Parameters.AddWithValue ( "@Pedido", OT );
					var reader = ad.ExecuteReader ( );
					var properties = typeof ( CierreOrdenesItmObj.item ).GetProperties ( );

					ChangeProgress?.Invoke ( new CierreEventArgs ( 10, "Cargando Datos..." ) );
					while ( reader.Read ( ) )
					{
						var itm = new CierreOrdenesItmObj.itmCv ( );
						foreach ( var property in properties )
						{
							if ( !reader.IsDBNull ( reader.GetOrdinal ( property.Name ) ) )
							{
								Type ConverTo = Nullable.GetUnderlyingType ( property.PropertyType ) ?? property.PropertyType;
								property.SetValue ( itm, Convert.ChangeType ( reader[ property.Name ], ConverTo ), null );
							}
						}
						Elementos.Add ( itm );
					}
				}
			}


			var tnt = Elementos.Where ( o => o.TipoMovimiento == "TINTAS" );

			// Traigo los grupos de tintas que se encuentran en el XML del proyecto
			// TODO: Buscar que estos valores se obtengan desde una base de datos en vez de un archivo XML
			List<GruposTinta.tintaItem> gpoTintas = GruposTinta.getTintas ( );

			ChangeProgress?.Invoke ( new CierreEventArgs ( 20, "Cargando Tintas..." ) );
			foreach ( var itm in tnt )
			{


				if ( gpoTintas.Any ( u => u.clave == itm.Articulo.TrimEnd ( ) ) )
				{
					itm.Factor = gpoTintas.First ( o => o.clave == itm.Articulo.TrimEnd ( ) ).factor;
				}

				if ( itm.Articulo.Substring ( 0, 4 ) == "MPSO" )
				{
					itm.Factor = 0;
				}

				itm.CantidadInventario = itm.Factor * itm.Cantidad;
			}



		}

		public static string[] Lineas
		{
			get
			{
				var elems = Elementos
					   .Where ( o => o.TipoElemento == "Transferencia" )
					   .OrderBy ( u => u.FechaEmision );


				var org = elems.Where ( o => o.LineaOrg != "TINTAS" && o.LineaOrg != "MATPRIMA" ).Select ( u => u.LineaOrg );
				var des = elems.Where ( o => o.LineaDes != "TERMINADO" && o.LineaDes != "MATPRIMA" && o.LineaDes != "RECHAZADOS" && o.LineaDes != "RCALMACEN" && o.LineaDes != "CALIDAD" ).Select ( u => u.LineaDes );
				return org.Union ( des ).Distinct ( ).ToArray ( );
			}
		}

		public static List<itmCv> allMoves ( string OT )
		{
			if ( OT == null ) return null;
			Initialice ( OT );
			return allMoves ( );
		}

		public static List<itmCv> allMoves ()
		{
			List<itmCv> toRet = new List<itmCv> ( );
			var lns = CierreOrdenesItmObj.Lineas;

			ChangeProgress?.Invoke ( new CierreEventArgs ( 30, "Buscando Lineas..." ) );

			var paso = CierreOrdenesItmObj.Lineas.Length > 0 ? 50 / CierreOrdenesItmObj.Lineas.Length : 1;
			var count = 0;

			foreach ( var linea in CierreOrdenesItmObj.Lineas )
			{
				count += 1;
				ChangeProgress?.Invoke ( new CierreEventArgs ( 30 + ( count * paso ), $"Analisando linea {linea}" ) );

				var inputs = Elementos
					.Where ( o => o.TipoElemento == "Transferencia" && o.TipoMovimiento != "MATERIAL DE EMPAQUE" && o.Estatus == "CONCLUIDO" )
					.Where ( o => o.LineaDes == linea && o.TipoMovimiento != "PROCESO DE LINEA" )
					.OrderBy ( o => o.Movimiento ).ToList ( );

				var outputs = Elementos
					.Where ( o => o.TipoElemento == "Transferencia" && o.TipoMovimiento != "MATERIAL DE EMPAQUE" && o.Estatus == "CONCLUIDO" )
					.Where ( o => o.LineaOrg == linea && o.TipoMovimiento != "PROCESO DE LINEA" && o.TipoMovimiento != "TINTAS" && o.TipoMovimiento != "ADHESIVOS" && o.TipoMovimiento != "ENTRADA MP" )
					.OrderBy ( o => o.Movimiento ).ToList ( );

				var proceso = Elementos
					.Where ( o => o.TipoElemento == "Transferencia" && o.TipoMovimiento != "MATERIAL DE EMPAQUE" && o.Estatus == "CONCLUIDO" )
					.Where ( o => o.LineaOrg == linea && o.LineaDes == linea && o.TipoMovimiento == "PROCESO DE LINEA" )
					.OrderBy ( o => o.Movimiento ).ToList ( );

				var consumos = Elementos
					.Where ( o => o.TipoElemento == "Consumos" )
					.Where ( o => o.LineaOrg == linea )
					.OrderBy ( o => o.Movimiento ).ToList ( );

				var requeridos = Elementos
					.Where ( o => o.TipoElemento == "Requerido" )
					.Where ( o => o.LineaDes == linea )
					.OrderBy ( o => o.Movimiento ).ToList ( );



				foreach ( var item in inputs )
				{
					var u = (itmCv)item.Clone ( );
					u.Linea = linea;
					u.Tipo = "3.Entrada";
					toRet.Add ( u );
				}

				foreach ( var item in outputs )
				{
					var u = (itmCv)item.Clone ( );
					u.Linea = linea;
					u.Tipo = "5.Salida";
					u.CantidadInventario *= -1;
					toRet.Add ( u );
				}

				foreach ( var item in proceso )
				{
					var u = (itmCv)item.Clone ( );
					u.Linea = linea;
					u.Tipo = "4.Proceso";
					u.CantidadInventario = 0;
					toRet.Add ( u );
				}

				foreach ( var item in consumos )
				{
					var u = (itmCv)item.Clone ( );
					u.Linea = linea;
					u.Tipo = "2.(Consumo)";
					u.CantidadInventario = 0;
					toRet.Add ( u );
				}

				foreach ( var item in requeridos )
				{
					var u = (itmCv)item.Clone ( );
					u.Linea = linea;
					u.Tipo = "1.(Requerido)";
					u.CantidadInventario = 0;
					u.Estatus = "CONCLUIDO";
					toRet.Add ( u );
				}


			}


			ChangeProgress?.Invoke ( new CierreEventArgs ( 80, "Analizando la orden global..." ) );
			var pedido = Elementos
					.Where ( o => o.TipoElemento == "Pedido" )
					.OrderBy ( o => o.Movimiento ).ToList ( );

			var salidas = Elementos
				.Where ( o => o.TipoElemento == "Transferencia" && o.Estatus == "CONCLUIDO" )
				.Where ( o => o.TipoMovimiento == "DEVOLUCION" || ( o.TipoMovimiento == "DESPERDICIOS" ) || ( o.LineaDes == "RECHAZADOS" || o.LineaDes == "PENAVE7" ) || ( o.LineaDes == "TERMINADO" && o.LineaOrg != "RECHAZADOS" ) )
				.OrderBy ( o => o.Movimiento ).ToList ( );

			var entradas = Elementos
				.Where ( o => o.TipoElemento == "Transferencia" && o.Estatus == "CONCLUIDO" )
				.Where ( o => ( o.LineaOrg == "MATPRIMA" || o.LineaOrg == "PENAVE7" || o.LineaOrg == "TERMINADO" || o.TipoMovimiento == "ENTRADA MP" || o.TipoMovimiento == "ADHESIVOS" || o.TipoMovimiento == "TINTAS" ) && o.TipoMovimiento != "MATERIAL DE EMPAQUE" )
				.OrderBy ( o => o.Movimiento ).ToList ( );


			double? Factor = 1;
			string UnidadPedido = "KG";

			foreach ( var item in pedido )
			{
				var u = (itmCv)item.Clone ( );
				u.Linea = "Pedido";
				u.Tipo = "(Requerido)";
				u.CantidadInventario = 0;
				toRet.Add ( u );

				var i = (itmCv)item.Clone ( );
				i.Linea = "(Entrega)";
				i.Tipo = "1.Requerido";
				//i.CantidadInventario = i.Cantidad * i.Factor;
				if ( i.Factor != 1 ) Factor = i.Factor;
				UnidadPedido = i.Unidad;
				toRet.Add ( i );
			}

			foreach ( var item in salidas )
			{
				var u = (itmCv)item.Clone ( );
				u.Linea = "(GLOBAL)";
				u.Tipo = "(Salida)";
				u.CantidadInventario *= -1;
				toRet.Add ( u );

				if ( u.TipoMovimiento == "TERMINADO" )
				{
					var I = (itmCv)item.Clone ( );
					I.Linea = "(Entrega)";
					I.Tipo = "2.Entregado";
					if ( Factor == 1 && I.Factor != 1 ) Factor = I.Factor;
					toRet.Add ( I );
				}
			}

			foreach ( var item in entradas )
			{
				var u = (itmCv)item.Clone ( );
				u.Linea = $"(GLOBAL)";
				u.Tipo = "(Entrada)";
				u.TipoMovimiento = u.TipoMovimiento == "ENTRADA MP" ? "MATERIA PRIMA" : u.TipoMovimiento;
				toRet.Add ( u );
			}

			foreach ( var item in toRet.Where ( o => o.Linea == "(Entrega)" ) )
			{
				item.Factor = Factor;
				//item.CantidadInventario = item.Factor * item.Cantidad;

				if ( item.Tipo == "2.Entregado" && item.Unidad == "KG" )
				{
					item.CantidadInventario = item.Cantidad;
					item.Cantidad = item.CantidadInventario / item.Factor;
					item.Unidad = UnidadPedido;
				}
				else
				{
					item.CantidadInventario = item.Cantidad * Factor;
				}

			}
			ChangeProgress?.Invoke ( new CierreEventArgs ( 100, "Completado..." ) );

			Task.Run ( () =>
			{
				System.Threading.Thread.Sleep ( 1500 );
				ChangeProgress?.Invoke ( new CierreEventArgs ( 0, "" ) );
			} );

			return toRet.OrderBy ( o => o.Linea ).ThenBy ( o => o.Tipo ).ToList ( );
		}
	}
}
