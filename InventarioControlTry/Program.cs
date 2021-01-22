using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventarioControlTry.Models;

namespace InventarioControlTry
{
	class Program
	{
		static Models.DbInventarioContexto Db = new Models.DbInventarioContexto ( );
		static void Main ( string[] args )
		{
			try
			{
				 //makeProd_RolloImpresion ( );
				// makeProd_RolloLam ( );
				tryProgram ( );
			}
			catch ( Exception ex )
			{
				Debug.WriteLine ( ex );
			}

			Console.WriteLine ( "please, press any key..." );
			Console.Read ( );
		}

		static void writeGramaje ( Rollo t, int level )
		{
			var tabs = "";

			var col = Console.ForegroundColor;
			switch ( level )
			{
				case 0:
					Console.ForegroundColor = ConsoleColor.Blue;
					break;
				case 1:
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					break;
				case 2:
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					break;
				case 3:
					Console.ForegroundColor = ConsoleColor.DarkCyan;
					break;
				case 4:
					Console.ForegroundColor = ConsoleColor.White;
					break;
				case 5:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				default:
					break;
			}

			for ( int i = 0; i < level; i++ )
			{
				tabs += "|\t";
			}

			foreach ( var org in t.RollosOrigenList )
			{
				Console.WriteLine ( $"{tabs}{org.code} -> {org.gramaje,6:n3} g/m² : {org.gramaje / t.gramaje,6:p2}" );
				writeGramaje ( org, level + 1 );

			}
			Console.WriteLine ( $"{tabs}{"------ToAdd",11} -> {t.gramajeToAdd,6:n3} g/m² : {t.gramajeToAdd / t.gramaje,6:p2}" );
			Console.ForegroundColor = col;
		}
		static void makeProd_RolloImpresion ()
		{
			TempProduccion P_RI = new TempProduccion ( )
			{
				FECHA = DateTime.Now,
				MAQUINA = 1,
				NUMERO = 1,
				OT = "00000",
				OPERADOR = "5547",
				ORIGEN = "0",
				PESOBRUTO = 185.6,
				PESOCORE = 5,
				BANDERAS = 1,
				PIEZAS = 250,
				TIPOPROCESO = 2,
				TURNO = 1
			};

			RolloImpresion RI = new Models.RolloImpresion ( );

			RI.RollProduccion = P_RI;
			RI.gramajeToAdd = 2;
			RI.FechaRegistro = DateTime.Now;
			RI.OT = "00000";

			RI.Origen.Add ( new OrigenRollo ( ) { RolloOrigenId = 1 } );

			Db.Rollos.Add ( RI );
			Db.SaveChanges ( );
		}
		static void makeProd_RolloLam ()
		{
			TempProduccion P_RI = new TempProduccion ( )
			{
				FECHA = DateTime.Now,
				MAQUINA = 2,
				NUMERO = 1,
				OT = "00000",
				OPERADOR = "5547",
				ORIGEN = "0",
				PESOBRUTO = 845.8,
				PESOCORE = 5,
				BANDERAS = 1,
				PIEZAS = 240,
				TIPOPROCESO = 4,
				TURNO = 1
			};

			RolloLaminacion RI = new RolloLaminacion ( );
			RI.RollProduccion = P_RI;
			RI.gramajeToAdd = 3;
			RI.FechaRegistro = DateTime.Now;
			RI.OT = "00000";

			RI.Origen.Add ( new OrigenRollo ( ) { RolloOrigenId = 8 } );
			RI.Origen.Add ( new OrigenRollo ( ) { RolloOrigenId = 5 } );

			Db.Rollos.Add ( RI );
			Db.SaveChanges ( );
		}
		static void tryProgram ()
		{

			var t = Db.Rollos.FirstOrDefault(c => c.RolloId == 9);

			Console.WriteLine($"{t.code} -> {t.gramaje,8:n2} g/m²");
			writeGramaje(t, 1);

			foreach (var e in t.Estructura)
			{
				Console.WriteLine($"{e.Code,12}: {e.Gramaje,6:n3} -> {e.Porcentaje,8:p2}");
			}

			Console.WriteLine($"{"Total",12}: {t.Estructura.Sum(y => y.Gramaje),6:n3} -> {t.Estructura.Sum(y => y.Porcentaje),8:p2}");
		}
	}
}
