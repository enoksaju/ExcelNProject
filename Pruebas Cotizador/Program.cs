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
		public static libProduccionDataBase.Contexto.DataBaseContexto DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
		static void Main ( string[] args )
		{
			try
			{

				var cot = new libProduccionDataBase.Tablas.Cotizador.Cotizacion ( )
				{
					Agente = DB.Users.FirstOrDefault ( ),
					Cliente = DB.Clientes.FirstOrDefault ( ),
					DiasVigencia = 30
				};
				var itm = new libProduccionDataBase.Tablas.Cotizador.PeliculaSinImpresion ( 1, 12, 80, 200 );

				Console.WriteLine ( $"Precio Material: {itm.Peliculas[ 0 ].Material.PrecioActual} " );
				Console.WriteLine ( $" Costo Material: {itm.Peliculas[ 0 ].Material.CostoActual}" );
				Console.WriteLine ( $" gm/mt2: {itm.Peliculas[ 0 ].pesoM2,5:N4}" );

				cot.Items.Add ( itm );
				WriteResults ( itm.Resultados );
				Console.Write ( itm.Resultados.GetResumen ( ) );
			}
			catch ( Exception ex )
			{
				Console.WriteLine ( ex.Message );
			}
			finally
			{
				Console.ReadLine ( );
			}
		}

		static void WriteResults ( libProduccionDataBase.Tablas.Cotizador.IResultadosCotizacion Resultados )
		{
			Console.WriteLine ( $"     Precio Objetivo: { Resultados.PrecioObjetivo,5:C2}" );
			Console.WriteLine ( $"       Precio Ultimo: { Resultados.PrecioUltimo,5:C2}" );
			Console.WriteLine ( $"         Comision Kg: { Resultados.ComisionKg,5:C2}" );
			Console.WriteLine ( $"Comision Equivalente: { Resultados.ComisionEquivalente,5:P2}" );
			Console.WriteLine ( $"      Comision Total: { Resultados.ComisionTotal,5:C2}" );
		}

	}
}
