using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;

namespace PruebasGral
{
	class Program
	{
		static void Main ( string[] args )
		{
			//AddOT ( "0004" );
			//UpdateOT ( "0000" );
			ReadPlaneacion ( "0001" );
			Console.ReadLine ( );
		}

		static void AddOT ( string OT_ )
		{
			using ( var db = new DataBaseContexto ( ) )
			{
				var OT = new TemporalOrdenTrabajo ( )
				{
					OT = OT_,
					INSTCORTE = "",
					INSTDOBLADO = "",
					INSTEMBOBINADO = "",
					INSTEXTRUSION = "",
					INSTIMPRESION = "IMPRIMIR",
					INSTLAMINACION = "",
					INSTMANGAS = "",
					INSTREFINADO = "REFINAR",
					INSTSELLADO = "",
					CANTIDAD = 500,
					ALTO = 25,
					ANCHO = 25,
					CLIENTE = "PRUEBA PLANEACION " + OT_,
					PRODUCTO = "PRODUCTO PRUEBA PLANEACION " + OT_,
					TIPO = TemporalOrdenTrabajo.Tipos.Pelicula,
					REPDES = 2,
					REPEJE = 2,
					UNIDAD = "KG",
					TIPOTRABAJO = 1,
					TIPOIMPRESION = 2,
					Planeacion = new Planeacion ( )
				};

				OT.Planeacion.FechaMateriales = DateTime.Now.AddDays ( 5 );
				OT.Planeacion.FechaPE = DateTime.Now.AddDays ( 6 );
				OT.Planeacion.Comentarios = "Planeacion de prueba";

				db.tempOt.Add ( OT );
				db.SaveChanges ( );
			}
		}
		static void UpdateOT ( string OT_ )
		{
			using ( var db = new DataBaseContexto ( ) )
			{
				var OT = db.tempOt.Include ( u => u.Planeacion ).FirstOrDefault ( y => y.OT == OT_ );
				if ( OT == null ) return;
				OT.INSTSELLADO = "SELLAR";
				OT.INSTLAMINACION = "LAMINAR";
				db.SaveChanges ( );
			}
		}
		static void ReadPlaneacion ( string OT_ )
		{
			using ( var db = new DataBaseContexto ( ) )
			{
				var OT = db.tempOt.FirstOrDefault ( u => u.OT == OT_ );
				Console.WriteLine ( $"{OT.Planeacion.OT} {OT.Planeacion.FechaCaptura} : {OT.Planeacion.Status}" );

				//var Impresion = OT.Planeacion.Procesos.FirstOrDefault ( o => o.TipoProceso == Planeacion.TiposProcesoProduccion.Impresion );
				//Impresion.MaquinaId = 5;
				//Impresion.FechaProgramada = new DateTime ( 2020, 3, 10 );
				//Impresion.Estatus |= PlaneacionProduccion.statusProcesoProduccion.Programada;

				//db.SaveChanges ( );

				foreach ( var procc in OT.Planeacion.Procesos.Where ( o => o.Estatus.HasFlag ( PlaneacionProduccion.statusProcesoProduccion.Activa ) ) )
				{
					Console.WriteLine ( $"\t{procc.TipoProceso,20} -> {procc.Activa,5}: FechaProg={( procc.FechaProgramada.HasValue ? procc.FechaProgramada.Value.ToString ( "dd/MMM/yy" ) : "" ),10} Estatus={procc.Estatus}" );
				}
			}
		}
	}
}
