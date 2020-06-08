using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Pruebas_Cotizador
{
	class Program
	{
		//public static libProduccionDataBase.Contexto.DataBaseContexto DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );

		static void Main ( string[] args )
		{

			try
			{
				//libIntelisisReports.Models.CierreOrdenesItmObj.Initialice ( "61176" );

				//foreach ( var item in libIntelisisReports.Models.CierreOrdenesItmObj.allMoves ( ) )
				//{
				//	Console.WriteLine ( $"{item.Linea,15} {item.Tipo,15} {item.TipoMovimiento,25} {item.Articulo,20} {item.Cantidad,12:N2}{item.Unidad,-5} {item.CantidadInventario,12:N2} {item.Estatus,15} { $"{item.AlmacenOrg}->{item.AlmacenDes}",22 }" );
				//}

				//Console.Read ( );

				var frm = new System.Windows.Forms.Form ( );
				var tr = new libIntelisisReports.Controles.TransferenciasOT ( ) { Dock = System.Windows.Forms.DockStyle.Fill };
				
				frm.Controls.Add ( tr );
				frm.Height = 500;
				frm.Width = 900;


				tr.ChangedOT += ( sender, eventargs ) => {

					Console.Clear ( );
					foreach ( var item in libIntelisisReports.Models.CierreOrdenesItmObj.allMoves ( ) )
					{
						Console.WriteLine ( $"{item.Linea,15} {item.Tipo,15} {item.TipoMovimiento,25} {item.Articulo,20} {item.Cantidad,12:N2}{item.Unidad,-10} {item.CantidadInventario,12:N2} {item.Estatus,15} { $"{item.AlmacenOrg}->{item.AlmacenDes}",22 }" );
					}
				};

				frm.ShowDialog ( );
			}
			catch ( Exception ex )
			{
				throw ex;
			}



			//try
			//{

			//	var cot = new libProduccionDataBase.Tablas.Cotizador.Cotizacion ( )
			//	{
			//		Agente = DB.Users.FirstOrDefault ( ),
			//		Cliente = DB.Clientes.FirstOrDefault ( ),
			//		DiasVigencia = 30
			//	};
			//	var itm = new libProduccionDataBase.Tablas.Cotizador.PeliculaSinImpresion ( 1, 12, 80, 200 );

			//	Console.WriteLine ( $"Precio Material: {itm.Peliculas[ 0 ].Material.PrecioActual} " );
			//	Console.WriteLine ( $" Costo Material: {itm.Peliculas[ 0 ].Material.CostoActual}" );
			//	Console.WriteLine ( $" gm/mt2: {itm.Peliculas[ 0 ].pesoM2,5:N4}" );

			//	cot.Items.Add ( itm );
			//	WriteResults ( itm.Resultados );
			//	Console.Write ( itm.Resultados.GetResumen ( ) );
			//}
			//catch ( Exception ex )
			//{
			//	Console.WriteLine ( ex.Message );
			//}
			//finally
			//{
			//	Console.ReadLine ( );
			//}
		}

		//static void WriteResults ( libProduccionDataBase.Tablas.Cotizador.IResultadosCotizacion Resultados )
		//{
		//	Console.WriteLine ( $"     Precio Objetivo: { Resultados.PrecioObjetivo,5:C2}" );
		//	Console.WriteLine ( $"       Precio Ultimo: { Resultados.PrecioUltimo,5:C2}" );
		//	Console.WriteLine ( $"         Comision Kg: { Resultados.ComisionKg,5:C2}" );
		//	Console.WriteLine ( $"Comision Equivalente: { Resultados.ComisionEquivalente,5:P2}" );
		//	Console.WriteLine ( $"      Comision Total: { Resultados.ComisionTotal,5:C2}" );
		//}

	}
}
