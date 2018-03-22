using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionPesaje.Pages.MainPages.Embarques {
	public class DataPackingList {

		public string OT { get; set; }
		public string CLIENTE { get; set; }
		public string PRODUCTO { get; set; }
		public int TIPOPROCESO { get; set; }
		public int NUMERO { get; set; }
		public string NUMERO_EXT { get; set; }
		public float PESOBRUTO { get; set; }
		public float PESOCORE { get; set; }
		public float PESONETO { get; set; }
		public float PIEZAS { get; set; }
		public string MAQUINA { get; set; }
		public int REPETICION { get; set; }
		public int ENSANEO { get; set; }
		public int FUESANEADA { get; set; }
		public int RECHAZADA { get; set; }
		public string USUARIO { get; set; }

		public int PAGINA { get; set; }
		public int COLUMNA { get; set; }
		public int TOTAL_ITEMS { get; set; }

		public bool includeOnFilter ( int filter, int inicial, int final ) {

			if (final <= 0) final = 999999;
			if (inicial <= 0) throw new Exception ( "El valor inicial debe ser mayor o igual a 1" );
			if (inicial > final) throw new Exception ( "Los valores del rango de Numeros de Bobina son incorrectos" );	

			switch (filter) {
				case 0:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( this.ENSANEO == 0 & this.FUESANEADA == 0 & this.RECHAZADA == 0 );
				case 1:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( this.RECHAZADA == 0 & FUESANEADA == 0 );
				case 2:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( ( FUESANEADA != 0 & RECHAZADA == 0 ) | ( ENSANEO == 0 & RECHAZADA == 0 ) );
				case 3:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( ( FUESANEADA != 0 & RECHAZADA == 0 ) | ( RECHAZADA == 0 ) );
				case 4:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( ( FUESANEADA != 1 & RECHAZADA == 0 ) | ( FUESANEADA == 0 & ENSANEO == 0 ) );
				case 5:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( ( FUESANEADA != 1 & RECHAZADA == 0 ) | ( FUESANEADA == 0 ) );
				case 6:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( ( FUESANEADA != 1 & RECHAZADA == 0 ) | ( ENSANEO == 0 | FUESANEADA != 0 ) );
				case 7:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( ( FUESANEADA != 1 & RECHAZADA == 0 ) );
				case 8:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( RECHAZADA == 0 & FUESANEADA == 0 & ENSANEO == 0 );
				case 9:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( RECHAZADA == 0 & FUESANEADA == 0 );
				case 10:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( ( FUESANEADA != 0 & RECHAZADA == 0 ) | ( ENSANEO == 0 & RECHAZADA == 0 ) ) | ( FUESANEADA != 0 & RECHAZADA == 0 );
				case 11:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( RECHAZADA == 0 );
				case 12:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( FUESANEADA == 0 & ENSANEO == 0 );
				case 13:
					return this.NUMERO >= inicial & this.NUMERO <= final & ( FUESANEADA == 0 );
				case 14:
					return this.NUMERO >= inicial & this.NUMERO <= final | ( ENSANEO == 0 & FUESANEADA != 0 );
				case 15:
					return this.NUMERO >= inicial & this.NUMERO <= final | ( ENSANEO != 0 & FUESANEADA != 0 & RECHAZADA != 0 );
				default:
					return false;
			}
		}

		public static int getFilter(bool TodasSaneadas, bool Rechazadas, bool saneadas, bool enSaneo ) {
			return ( TodasSaneadas ? 8 : 0 ) + ( Rechazadas ? 4 : 0 ) + ( saneadas ? 2 : 0 ) + ( enSaneo ? 8 : 0 );
		}

		/// <summary>
		/// Regresa una lista con elementos para formar el reporte de 'Lista de Embarque'
		/// </summary>
		/// <param name="OT">Orden de trabajo</param>
		/// <param name="TipoProceso">Proceso del que se tomaran los elementos</param>
		/// <param name="Filtro">Filtro de saneos o rechazados</param>
		/// <param name="inicio">Numero inicial</param>
		/// <param name="fin">Numero Final</param>
		/// <param name="initPage">Numero de pagina de inicio</param>
		/// <param name="byTar">Numero de elementos por tarima(pagina)</param>
		/// <param name="unirPaginas">Concentrar los ultimos elementos en la ultima pagina</param>
		/// <param name="Repeticiones">Repeticiones a considerar</param>
		/// <returns>lista con elementos para formar el reporte de 'Lista de Embarque'</returns>
		public static List<DataPackingList> getList (string OT, int TipoProceso, int Filtro, int inicio, int fin, int initPage, int byTar, bool unirPaginas= false,string Repeticiones= "[0-9]*" ) {
			int elmTarCount = 0;
			int pageCount = initPage;
			int currenPage = 0;

			using (var DB = new libProduccionDataBase.Contexto.DataBaseContexto ( )) {

				var t = DB.Database.SqlQuery<DataPackingList> ( "SELECT * FROM packing_list WHERE OT='"+ OT + "' AND TIPOPROCESO="+ TipoProceso + "  AND REPETICION REGEXP '" + Repeticiones + "'" );

				var o = ( from fl in t
						  where fl.includeOnFilter ( Filtro , inicio, fin )
						  select fl ).ToList ( );

				double TotalPag = Math.Ceiling ( ( double ) ( o.Count ( ) / byTar ) );
				int TotalItems = o.Count ( );

				foreach (var y in o) {

					if (elmTarCount < ( byTar + ( currenPage == TotalPag && unirPaginas ? ( TotalItems % byTar ) : 0 ) )) {

						y.COLUMNA = elmTarCount % 2 == 0 ? 2 : 1;
						currenPage = pageCount;
						++elmTarCount;

					} else {
						++pageCount;
						elmTarCount = 0;
						currenPage = pageCount;
						++elmTarCount;
					}

					y.PAGINA = pageCount;
					y.COLUMNA = elmTarCount % 2 == 0 ? 2 : 1;
					y.TOTAL_ITEMS = TotalItems;
				}
				return o;

			}
		}


	}
}
