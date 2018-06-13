using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Office.Interop.Excel;

namespace ControlNominasAddIn.Forms {
	public partial class frmImportarReloj : KryptonForm {		
		private Microsoft.Office.Interop.Excel.Application ExApp => Globals.ThisAddIn.Application;
		private Microsoft.Office.Interop.Excel.Workbook ExLibro => this.ExApp.ActiveWorkbook;
		private Microsoft.Office.Interop.Excel.Worksheet ExHoja => this.ExLibro.Worksheets [ 1 ];
		public Microsoft.Office.Interop.Excel.Range Range { get; set; }
		public Models.Checadas Checadas { get; set; } = new Models.Checadas ( );

		#region SQLStrings
		/// <summary>
		/// SQL_RELOJ_1
		/// Reemplace los valores de los parametros @FechaIni y @FechaFin de tipo DateTime con los valores de las fechas seleccionadas
		/// </summary>

		const string SQL_RELOJ_1 = @"
SELECT       
	NGAC_USERINFO.username AS CLAVE, 
	CDbl(DateValue(NGAC_LOG.logtime)) AS fecha, 
	CDbl(TimeValue(NGAC_LOG.logtime)) AS hora
FROM (NGAC_USERINFO INNER JOIN
	NGAC_LOG ON NGAC_USERINFO.userid = NGAC_LOG.userid)
WHERE (NGAC_LOG.authresult = 0) 
	AND (NGAC_LOG.logtime BETWEEN @FechaIni 
		AND DATEADD(""S"",59,DATEADD(""N"",59,DATEADD(""h"",23,DATEADD(""d"", 6, @FechaIni)))))
";
		/// <summary>
		/// SQL_RELOJ_2
		/// Reemplace los valores de los parametros @FechaIni y @FechaFin de tipo DateTime con los valores de las fechas seleccionadas
		/// </summary>
		const string SQL_RELOJ_2 = @"
SELECT USERINFO.Name AS CLAVE, 
	CDbl(DateValue(CHECKINOUT.CHECKTIME)) AS fecha, 
	CDbl(TimeValue(CHECKINOUT.CHECKTIME)) AS hora
FROM (USERINFO INNER JOIN 
	CHECKINOUT ON USERINFO.USERID = CHECKINOUT.USERID)
WHERE (CHECKINOUT.CHECKTIME BETWEEN @FechaIni AND DATEADD(""S"",59,DATEADD(""N"",59,DATEADD(""h"",23,DATEADD(""d"", 6, @FechaIni)))))
";
		/// <summary>
		/// SQL_RELOJ_1_COUNT
		/// Reemplace los valores de los parametros @FechaIni y @FechaFin de tipo DateTime con los valores de las fechas seleccionadas
		/// </summary>
		const string SQL_RELOJ_1_COUNT = @"
Select Count([NGAC_LOG]![logtime])
FROM NGAC_LOG
WHERE (([NGAC_LOG]![logtime] BETWEEN @FechaIni AND @FechaFin) And [NGAC_LOG]![authresult]= 0);
";
		/// <summary>
		/// SQL_RELOJ_2_COUNT
		/// Reemplace los valores de los parametros @FechaIni y @FechaFin de tipo DateTime con los valores de las fechas seleccionadas
		/// </summary>
		const string SQL_RELOJ_2_COUNT = @"
Select Count(CHECKINOUT.CHECKTIME) 
FROM CHECKINOUT 
WHERE (CHECKINOUT.CHECKTIME BETWEEN @FechaIni AND DATEADD(""S"",59,DATEADD(""N"",59,DATEADD(""h"",23,DATEADD(""d"", 6, @FechaIni)))))
";
		#endregion

		public DateTime SelectedDate => clFechaInicial.SelectionStart;

		/// <summary>
		/// Obtiene o establece el valor actual del progreebar
		/// </summary>
		private int progressValue {
			set {
				if ( this.statusStrip1.InvokeRequired ) {
					this.Invoke ( new System.Action ( ( ) => {
						this.toolStripProgressBar1.Value = value;
					} ) );
				} else {
					this.toolStripProgressBar1.Value = value;
				}

			}
		}

		/// <summary>
		/// Obtiene o establece el valor maximo del progressbar
		/// </summary>
		private int totalItems {
			get {
				return this.toolStripProgressBar1.Maximum;
			}
			set {
				if ( this.statusStrip1.InvokeRequired ) {
					this.Invoke ( new System.Action ( ( ) => {
						this.toolStripProgressBar1.Maximum = value;
					} ) );
				} else {
					this.toolStripProgressBar1.Maximum = value;
				}
			}
		}

		/// <summary>
		/// Obtiene o establece el mensaje mostrado en el statusbar
		/// </summary>
		private string statusMessage {
			get {
				return this.toolStripStatusLabel1.Text;
			}
			set {
				this.toolStripStatusLabel1.Text = value;
				this.statusStrip1.Refresh ( );
			}
		}
		/// <summary>
		/// Indica o estabece si se pueden obtener los datos, (habilita o deshabilita los controles)
		/// </summary>
		private bool canGetData {
			get { return this.toolStripProgressBar1.Visible; }
			set {
				this.Invoke ( new System.Action ( ( ) => {
					this.toolStripProgressBar1.Visible = value;
					this.kryptonButton1.Enabled = !value;
					this.kryptonButton2.Enabled = !value;
					ExApp.Calculation = value ? XlCalculation.xlCalculationManual : XlCalculation.xlCalculationAutomatic;
					ExApp.ScreenUpdating = !value;

				} ) );
			}
		}

		/// <summary>
		/// Inicializa una instancia de la clase
		/// </summary>
		public frmImportarReloj ( ) {
			InitializeComponent ( );
			this.clFechaInicial.SelectionStart = DateTime.Now;
		}

		/// <summary>
		/// Asigna una formula a una columna determinada
		///  </summary>
		/// <param name="column">string con la <b>letra</b> de la columna</param>
		/// <param name="formula">string con la formula de tipo R1C1</param>
		private void fillR1C1Formula ( string column , string formula ) {

			Range = ExHoja.Range [ $"{column}11" ];
			Range.FormulaR1C1 = formula;
			Range = ExHoja.Range [ "B:B" ];
			var fila = ExApp.WorksheetFunction.CountA ( Range );
			Range = ExHoja.Range [ $"{column}11" ];

			Range.AutoFill ( Destination: ExHoja.Range [ $"{column}11:{column}{fila}" ] , Type: XlAutoFillType.xlFillDefault );

			Range.AutoFill ( Destination: ExHoja.Range [ $"{column}11:{column}2" ] , Type: XlAutoFillType.xlFillDefault );
		}

		/// <summary>
		/// Obtiene los registros de entradas y salidas de las bases de datos de los Relojes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void kryptonButton1_Click ( object sender , EventArgs e ) {

			canGetData = true;

			// Asigno los valores de la cabecera en la hoja de datos.
			ExHoja.Cells.Item [ 1 , 1 ] = "CLAVE";
			ExHoja.Cells.Item [ 1 , 2 ] = "FECHA";
			ExHoja.Cells.Item [ 1 , 3 ] = "HORA";
			ExHoja.Cells.Item [ 1 , 4 ] = "TIPO_IO";
			ExHoja.Cells.Item [ 1 , 5 ] = "CONTADOR";
			ExHoja.Cells.Item [ 1 , 6 ] = "TOTAL";

			int countFila = 0; //Contador de filas


			// Obtengo datos del Reloj1
			try {

				// Obtengo la cadena de conexion desde la configuracion y genero una conexión.
				using ( var cnn = new OleDbConnection ( Properties.Settings.Default.Reloj1ConnectionString ) ) {

					cnn.Open ( );
					statusMessage = "Obteniendo datos del Reloj 1...";

					// Obtengo el total de elementos que se obtendran con clausula where.
					using ( var cmd = new OleDbCommand ( SQL_RELOJ_1_COUNT , cnn ) ) {
						cmd.Parameters.Add ( new OleDbParameter ( "@FechaIni" , SelectedDate ) );
						cmd.Parameters.Add ( new OleDbParameter ( "@FechaFin" , SelectedDate.AddDays ( 7 ).AddSeconds ( -1 ) ) );

						//asigno el total de elementos al valor maximo del progressbas e inicializo el valor de progreso en 0.
						progressValue = 0;
						totalItems = ( int ) cmd.ExecuteScalar ( );
					}

					statusMessage = $"{totalItems } elementos detectados";

					// Obtengo los elementos desde la base de datos y ejecuto un datareader
					using ( var cmd = new OleDbCommand ( SQL_RELOJ_1 , cnn ) ) {
						cmd.Parameters.Add ( new OleDbParameter ( "@FechaIni" , SelectedDate ) );
						using ( var dr = cmd.ExecuteReader ( ) ) {

							// Mientras lee
							while ( dr.Read ( ) ) {
								for ( int i = 0; i < dr.FieldCount; i++ ) {
									// Pego los datos en la hoja de Excel para cada columna de la fila del datareader
									ExHoja.Cells.Item [ countFila + 2 , i + 1 ] = dr [ i ];
								}
								countFila += 1;

								// Actualizo el valor del progressbar
								progressValue = countFila;
							}
						}
					}

					// Cierro la conexion
					cnn.Close ( );
				}
			} catch ( Exception ex ) {
				ExApp.StatusBar = "Error al importar datos del Reloj1...";
#if DEBUG
				System.Diagnostics.Debug.Fail ( "Error al importar datos del Reloj1" , ex.Message );
#endif
			}


			// Obtengo datos del Reloj1
			try {
				var previusValue = totalItems;
				using ( var cnn = new OleDbConnection ( Properties.Settings.Default.Reloj2ConnectionString ) ) {
					cnn.Open ( );
					statusMessage = "Obteniendo datos del Reloj 2...";
					using ( var cmd = new OleDbCommand ( SQL_RELOJ_2_COUNT , cnn ) ) {
						cmd.Parameters.Add ( new OleDbParameter ( "@FechaIni" , SelectedDate ) );
						progressValue = 0;
						totalItems = ( int ) cmd.ExecuteScalar ( );
					}
					statusMessage = $"{totalItems } elementos detectados";

					using ( var cmd = new OleDbCommand ( SQL_RELOJ_2 , cnn ) ) {
						cmd.Parameters.Add ( new OleDbParameter ( "@FechaIni" , SelectedDate ) );
						using ( var dr = cmd.ExecuteReader ( ) ) {
							while ( dr.Read ( ) ) {
								for ( int i = 0; i < dr.FieldCount; i++ ) {
									ExHoja.Cells.Item [ countFila + 2 , i + 1 ] = dr [ i ];
								}
								countFila += 1;
								progressValue = countFila - previusValue;
							}
						}
					}
					cnn.Close ( );
				}
			} catch ( Exception ex ) {
				ExApp.StatusBar = "Error al importar datos del Reloj1...";
#if DEBUG
				System.Diagnostics.Debug.Fail ( "Error al importar datos del Reloj2" , ex.Message );
#endif
			}



			// Agrego el tipo de orde a las columnas A, B, C
			statusMessage = $"Ordenando Columnas...";
			ExHoja.Columns [ "A:C" ].Select ( );
			ExHoja.Sort.SortFields.Clear ( );

			ExHoja.Sort.SortFields.Add (
				Key: ExHoja.Range [ "B2:B131521" ] ,
				SortOn: XlSortOn.xlSortOnValues ,
				Order: XlSortOrder.xlAscending ,
				DataOption: XlSortDataOption.xlSortNormal );

			ExHoja.Sort.SortFields.Add (
				Key: ExHoja.Range [ "A2:A131521" ] ,
				SortOn: XlSortOn.xlSortOnValues ,
				Order: XlSortOrder.xlAscending ,
				DataOption: XlSortDataOption.xlSortNormal );

			ExHoja.Sort.SortFields.Add (
				Key: ExHoja.Range [ "C2:C131521" ] ,
				SortOn: XlSortOn.xlSortOnValues ,
				Order: XlSortOrder.xlAscending ,
				DataOption: XlSortDataOption.xlSortNormal );

			ExHoja.Sort.SetRange ( ExHoja.Range [ "A1:C131521" ] );
			ExHoja.Sort.Header = XlYesNoGuess.xlYes;
			ExHoja.Sort.MatchCase = false;
			ExHoja.Sort.SortMethod = XlSortMethod.xlPinYin;
			ExHoja.Sort.Apply ( );

			statusMessage = $"Agregando columnas calculadas...";

			// Agrego las columnas calculadas

			// Tipo de entrada
			fillR1C1Formula ( "D" , "=IF(RC[-3]=R[-1]C[-3],IF((RC[-1]-R[-1]C[-1])<0.00347222222222222,2,IF(R[-1]C>1,IF(R[-2]C>1,IF(R[-3]C>1,IF(R[-4]C>1,IF(R[-5]C>1,IF(R[-6]C>1,IF(R[-7]C>1,IF(R[-8]C>1,IF(R[-9]C>1,IF(R[-10]C>1,1,IF(R[-10]C=1,0,1)),IF(R[-9]C=1,0,1)),IF(R[-8]C=1,0,1)),IF(R[-7]C=1,0,1)),IF(R[-6]C=1,0,1)),IF(R[-5]C=1,0,1)),IF(R[-4]C=1,0,1)),IF(R[-3]C=1,0,1)),IF(R[-2]C=1,0,1)),IF(R[-1]C=1,0,1))),1)" );
			// Contador de registros
			fillR1C1Formula ( "E" , "=IF(RC[-4]<>R[-1]C[-4],1,IF(RC[-1]=2,R[-1]C,(R[-1]C+1)))" );
			// Total de registros
			fillR1C1Formula ( "F" , "=IF(AND(R[1]C[-1]=1,R[1]C[-2]<>2),RC[-1],IF(R[2]C[-1]=1,R[1]C[-1],IF(R[3]C[-1]=1,R[2]C[-1],IF(R[4]C[-1]=1,R[3]C[-1],IF(R[5]C[-1]=1,R[4]C[-1],IF(R[6]C[-1]=1,R[5]C[-1],IF(R[7]C[-1]=1,R[6]C[-1],IF(R[8]C[-1]=1,R[7]C[-1],IF(R[9]C[-1]=1,R[8]C[-1],IF(R[10]C[-1]=1,R[9]C[-1],IF(R[11]C[-1]=1,R[10]C[-1],IF(R[12]C[-1]=1,R[11]C[-1],IF(R[13]C[-1]=1,R[14]C[-1],IF(R[15]C[-1]=1,R[14]C[-1],IF(R[16]C[-1]=1,R[15]C[-1],IF(R[17]C[-1]=1,R[16]C[-1],IF(R[18]C[-1]=1,R[17]C[-1],IF(R[19]C[-1]=1,R[18]C[-1],IF(R[19]C[-1]=1,R[18]C[-1],IF(R[20]C[-1]=1,R[19]C[-1],IF(R[21]C[-1]=1,R[20]C[-1],IF(R[22]C[-1]=1,R[21]C[-1],IF(R[23]C[-1]=1,R[22]C[-1],23)))))))))))))))))))))))" );


			statusMessage = "Dando formato a los datos...";

			// Asigno el formato a cada una de las columnas de acuerdo al tipo de datos
			ExHoja.Columns [ "B:B" ].NumberFormat = "dd/mm/aaaa";
			ExHoja.Columns [ "C:C" ].NumberFormat = "hh:mm";
			ExHoja.Columns [ "E:F" ].EntireColumn.Hidden = true;

			// Agrego el autoFiltro a las cabeceras de las columnas
			ExHoja.Range [ "A1" ].AutoFilter ( 1 , Type.Missing , XlAutoFilterOperator.xlAnd , Type.Missing , true );
			ExHoja.Range [ "A1" ].Select ( );

			canGetData = false;
			ExHoja.Calculate ( );
			statusMessage = "Listo...";
		}

		/// <summary>
		/// Invierte el valor del tipo de registro
		/// </summary>
		/// <param name="Tipo"></param>
		/// <returns></returns>
		private Models.Checadas.Tipos_IO ChangeTipo ( Models.Checadas.Tipos_IO Tipo ) {
			switch ( Tipo ) {
				case Models.Checadas.Tipos_IO.Entrada:
					return Models.Checadas.Tipos_IO.Salida;
				case Models.Checadas.Tipos_IO.Salida:
					return Models.Checadas.Tipos_IO.Entrada;
				default:
					return Models.Checadas.Tipos_IO.Salida;
			}
		}

		/// <summary>
		/// Crea una Hoja de calculo para cada dia con los datos de entradas y salidas de un trabajador.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void kryptonButton2_Click ( object sender , EventArgs e ) {
			canGetData = true;

			// Limpio la coleccion de checadas
			Checadas.Clear ( );


			// Genero variables locales
			int FilaFinal = ( int ) ExApp.WorksheetFunction.CountA ( ExHoja.Range [ "B1:B50000" ] ), //Cuento el total de elementos en la hoja
				_anteriorId = 0,
				_vecesChofer = 0,
				_numericId = 0,
				_tryTipo = 0,
				_Duplicados = 0;

			string _prevId, _Nombre;
			DateTime _Fecha, _Checada;
			Models.Checadas.Tipos_IO _Tipo, _TipoChofer = Models.Checadas.Tipos_IO.Entrada;
			bool _Mayor = false;

			// Asigno el valor maximo del progressbar
			this.totalItems = FilaFinal;


			// Recorro todas las filas de la hoja
			for ( int fila2 = 2; fila2 <= FilaFinal; fila2++ ) {
				// Convierto a numero la clave del trabajador
				_prevId = ExHoja.Cells [ fila2 , 1 ].Value.ToString ( );
				if ( !int.TryParse ( _prevId , out _numericId ) ) {
					_numericId = 99999;
				}

				// Asigno valores a las variables
				_Nombre = "0";
				_Fecha = ExHoja.Cells [ fila2 , 2 ].Value;
				_Checada = DateTime.FromOADate ( ExHoja.Cells [ fila2 , 3 ].Value );
				_Tipo = ( Models.Checadas.Tipos_IO ) ( int.TryParse ( ExHoja.Cells [ fila2 , 4 ].Value.ToString ( ) , out _tryTipo ) ? _tryTipo : 2 );

				// Obtengo el total de registros de la fila en curso.
				int _Registro = ( int ) ExHoja.Cells [ fila2 , 6 ].Value;

				// Salto a etiqueta "Siguiente" si el tipo de registro es duplicado
				if ( _numericId == 99999 | _Tipo == Models.Checadas.Tipos_IO.Duplicado )
					goto Siguiente;

				// Si la clave es diferente a la clave anterior
				if ( _anteriorId != _numericId ) {

					// Si la clave es igual a la del chofer asigno valores y salto a la etiqueta "Continua"
					if ( _numericId == Properties.Settings.Default.claveChofer ) {
						_TipoChofer = _Tipo;
						_vecesChofer = 2;
						goto Continua;
					}

					// Reviso si la persona tiene mas de 8 registros en ese dia
					_Mayor = _Registro >= 8 && _Registro <= 10 ? true : false;

					// Salto a la etiqueta siguiente si el trabajador tiene > de 7 registros
					if ( _Registro >= 7 )
						goto Siguiente;

				}
				// Si la clave es igual a la clave anterior.
				else {
					// Si la clave es igual a la clave del chofer, ajusto valores y salto a la etiqueta "Continua"
					if ( _numericId == Properties.Settings.Default.claveChofer ) {

						// Si el numero de veces del chofer es par, agrego una vez al contador y salto a la etiqueta "Siguiente"
						if ( _vecesChofer % 2 == 0 ) {
							++_vecesChofer;
							goto Siguiente;
						}
						// Si el numero de veces del chofer no es par, ajusto el tipo de registro e incremento el numero de veces del chofer 
						else {
							_Tipo = ( _Tipo == _TipoChofer ? ChangeTipo ( _Tipo ) : _Tipo );
							_TipoChofer = _Tipo;
							++_vecesChofer;
						}
						goto Continua;
					}

					// Si es mayor, asigno valores a la variable _anteriorID y salto a la etiqueta "Siguiente"
					if ( _Mayor ) {
						_Mayor = false;
						_anteriorId = _numericId;
						goto Siguiente;
					}

					// Si el trabajador tiene 7 registros , cambio el tipo de registro
					if ( _Registro == 7 )
						_Tipo = ChangeTipo ( _Tipo );
				}
Continua:

// Agrego un elemento a la coleccion de checcadas.
				Checadas.Add ( _numericId.ToString ( ) , _Nombre , _Fecha , _Checada , _Tipo );
Siguiente:

// Si el tipo de registro es duplicado, incremento el contador de duplicados.
				if ( _Tipo == Models.Checadas.Tipos_IO.Duplicado )
					++_Duplicados;

				// Asigno el valor a la variable _anteriorId con el valor de la fila en curso.
				_anteriorId = _numericId;


				statusMessage = $"Se han encontrado {_Duplicados } registros duplicados...";
				progressValue = fila2;
			}


			statusMessage = $"Creando Hojas de calculo...";

			// Creo la coleccion de nombres de las hojas que se crearan.
			string [ ] _NombreHojas = new String [ ] { "AA" , "BB" , "A" , "B" , "M1" , "J2" , "V2" , "S2" , "D2" , "L2" , "M2" };

			// Indico cual es la hoja actual
			Worksheet _CurrentHoja = ExLibro.Worksheets [ 1 ];

			// Recorro todos los nombres de las hojas
			foreach ( var _nombreHoja in _NombreHojas ) {
				// creo una variable local para la hoja que se procesara.
				Worksheet _Hoja = null;

				// Recorro la coleccion de hojas en el libro y asigno la que coincida con el nombre para no crear una nueva.
				foreach ( Worksheet _sHoja in ExLibro.Worksheets ) {
					if ( _sHoja.Name == _nombreHoja ) {
						_Hoja = _sHoja;
						break;
					}
				}

				// Si no se asigno ninguna hoja existente, agrego una hoja nueva despues de la actual y le asigno el nombre, está hoja se convierte en la actual
				_Hoja = ( _Hoja != null ? _Hoja : ExLibro.Worksheets.Add ( After: _CurrentHoja ) );
				_Hoja.Name = _nombreHoja;
				_CurrentHoja = _Hoja;

				// Limpio la hoja
				_Hoja.Columns [ "B:F" ].Clear ( );

				// Agrego los valores de las cabeceras
				_Hoja.Cells [ 2 , 2 ] = "CLAVE";
				_Hoja.Cells [ 2 , 3 ] = "NOMBRE";
				_Hoja.Cells [ 2 , 4 ] = "FECHA";
				_Hoja.Cells [ 2 , 5 ] = "ENTRADA";
				_Hoja.Cells [ 2 , 6 ] = "SALIDA";


				// Si el indice de la hoja es mayor que 3, asigno valores de checadas.
				if ( _NombreHojas.ToList ( ).IndexOf ( _nombreHoja ) > 3 ) {

					// Selecciono la hoja
					_Hoja.Select ( );
 
					statusMessage = $"Pegando datos en la Hoja {_nombreHoja } del dia {SelectedDate.AddDays ( _NombreHojas.ToList ( ).IndexOf ( _nombreHoja ) - 4 ).ToString ( "dd/MMM/yyyy" )}";


					// Obtengo la coleccion por medio de LINQ desde la coleccion de checadas y filtro los datos que corresponden al dia del index

					var y = from ch in Checadas.Elementos									// Genero la variable ch, que representa una fila de la coleccion checadas
							where ch.Fecha == SelectedDate.AddDays (						// Filtro, agrego el numero de dias a la fecha seleccionada
								_NombreHojas.ToList ( ).IndexOf ( _nombreHoja ) - 4			// Busco el indice del _nombre de la hoja en la coleccion de nombres y le resto 4 por ser el indice inicial
								) 
							select ch;														// Si se cumple la condicion agrego el elemento a la coleccion y


					// Asigno el valor maximo del progreebar
					totalItems = y.Count ( );


					// Recorro los datos de la seleccion LINQ y pego los valores en la hoja
					for ( int i = 0; i < y.Count ( ); i++ ) {
						_Hoja.Cells [ 3 + i , 2 ] = y.ElementAt ( i ).Id;
						_Hoja.Cells [ 3 + i , 3 ] = y.ElementAt ( i ).Nombre;
						_Hoja.Cells [ 3 + i , 4 ] = y.ElementAt ( i ).Fecha;
						_Hoja.Cells [ 3 + i , 5 ] = y.ElementAt ( i ).Entrada;
						_Hoja.Cells [ 3 + i , 6 ] = y.ElementAt ( i ).Salida;
						progressValue = i + 1; // Asigno el valor del progreso
					}

					
					statusMessage = $"Dando formato a la Hoja {_nombreHoja }";
					// doy formato a la columna de acuerdo al tipo de datos que contienen
					_Hoja.Columns [ "E:E" ].NumberFormat = "hh:mm";
					_Hoja.Columns [ "F:F" ].NumberFormat = "hh:mm";
					_Hoja.Columns [ "D:D" ].NumberFormat = "dd/MM/aaaa";

					// Cuento el nuemro de filas en la hoja actual
					var _SheetRows = ExApp.WorksheetFunction.CountA ( _Hoja.Range [ "B1:B999999" ] );

					// reeplazo los registrros vacios con la cadena "NO REGISTRADA"
					_Hoja.Range [ $"F3:F{_SheetRows }" ].Replace ( What: "" , Replacement: "NO REGISTRADA" , LookAt: XlLookAt.xlPart ,
							SearchOrder: XlSearchOrder.xlByRows , MatchCase: false , SearchFormat: false ,
							ReplaceFormat: false );
				}
			}

			statusMessage = $"Correcto, se han encontrado y descartado {_Duplicados} registros duplicados.";

			canGetData = false;

			KryptonTaskDialog.Show ( "Muy bien..." , "Correcto!" , $"Los datos se han ordenado correctamente!,\nSe han encontrado y descartado {_Duplicados} registros duplicados." , MessageBoxIcon.Information , TaskDialogButtons.OK );

		}
	}

}
