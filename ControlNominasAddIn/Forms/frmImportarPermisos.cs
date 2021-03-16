using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Office.Interop.Excel;
using ControlNominasAddIn.Data;

namespace ControlNominasAddIn.Forms {
	public partial class frmImportarPermisos : KryptonForm {
		public frmImportarPermisos ( ) {
			InitializeComponent ( );
		}

		public int countSelectedDays => ( int ) ( clDateRange.SelectionEnd - clDateRange.SelectionStart ).TotalDays + 1;
        AppSetting appSetting = new AppSetting();

        private Microsoft.Office.Interop.Excel.Application ExApp => Globals.ThisAddIn.Application;
		private Microsoft.Office.Interop.Excel.Workbook ExLibro => this.ExApp.ActiveWorkbook;
		private Microsoft.Office.Interop.Excel.Worksheet ExHoja => this.ExLibro.Worksheets [ 1 ];
		public Microsoft.Office.Interop.Excel.Range Rge { get; set; }

		#region "SQL strings"
		public const string SQL_MAIN_SELECT = @"
SELECT 
	CINT(PERMISOS.CLAVE) AS CLAVE 
	,PERMISOS.Id AS FOLIO
	$permisoDays
	,IIf([PERMISOS]![TIEMPO]=1,
		IIf((DateDiff('n',TimeValue([PERMISOS]![HORA1]),TimeValue([PERMISOS]![HORA2]),2)/60)-Int((DateDiff('n',TimeValue([PERMISOS]![HORA1]),TimeValue([PERMISOS]![HORA2]),2)/60))=0,
			Format((DateDiff('n',TimeValue([PERMISOS]![HORA1]),TimeValue([PERMISOS]![HORA2]),2)/60),'""0 ""0""/8"" '),
			Format((DateDiff('n',TimeValue([PERMISOS]![HORA1]),TimeValue([PERMISOS]![HORA2]),2)/30),'""0 ""0""/16"" ')
		),
		IIf([PERMISOS]![TIEMPO]=2,
			IIf(DatePart('w',DateValue([PERMISOS]![DIA1]),2)=[PERMISOS]![DIA_DESCANSO],
				'',
				1
			),
			IIf([PERMISOS]![TIEMPO]=3,
				(
				$totalDays
				),
				''
			)
		)
	) AS CONCEPTO
	,IIf(PERMISOS.VALIDADO=True,1,0) AS AUTORIZADO 
	,PERMISOS.VALIDADOPOR
	,PERMISOS.COMENTARIOS, 
FROM (PERMISOS INNER JOIN CAT_PERM ON PERMISOS.TIPO = CAT_PERM.TIPO) INNER JOIN 
	TRABAJADOR ON PERMISOS.CLAVE = TRABAJADOR.Clave
WHERE 
	(PERMISOS.REVISADO=True) and (
		$whereDays
	)
ORDER BY  PERMISOS.VALIDADO ASC, CINT(PERMISOS.CLAVE) ASC
";

		/// <summary>
		/// <para>$ToAdd => integer to add to @FECHA</para>
		/// <para>$Nombre => Alias of Column</para>
		/// <para>Reemplace los valores anteriores</para>
		/// </summary>
		public const string SQL_DAY_PERMISO_VALUE = @"
	 ,IIf(DLookUp('FECHA_FERIADO','FERIADOS','FECHA_FERIADO=' & Format(DateAdd('d',$ToAdd,@FECHA),'dmmyyyy'))=Format(DateAdd('d',$ToAdd,@FECHA),'dmmyyyy'),
		'',
		IIf ( DateValue(@FECHA)+$ToAdd>= PERMISOS.DIA1
			And DateValue ( @FECHA)+$ToAdd<=PERMISOS.DIA2,
			IIf ( DatePart('w', DateValue(@FECHA)+$ToAdd,2)=PERMISOS.DIA_DESCANSO,
				'D',
				IIf ( CAT_PERM.MOTIVO= 'IMSS' ,
					'I',
					IIf(CAT_PERM.MOTIVO= 'DR DE LA EMPRESA' ,
						'DR',
						IIf(CAT_PERM.MOTIVO= 'VACACIONES' ,
							'V',
							IIf(CAT_PERM.MOTIVO= 'PB_Vac' OR CAT_PERM.MOTIVO= 'PB_Sab' ,
								'PB',
								IIf(CAT_PERM.DESCONTABLE= True ,'PS','PG')
							)
						)
					)
				)
			),
			''
		)
	) AS $Nombre
";
		public const string SQL_TO_SUM = @"
				IIf((DATEVALUE(@FECHA)+$ToAdd)>= PERMISOS.DIA1 AND (DATEVALUE(@FECHA)+$ToAdd)<= PERMISOS.DIA2,
					IIf(DLookUp('FECHA_FERIADO','FERIADOS','FECHA_FERIADO=' & Format(DateAdd('d',$ToAdd,@FECHA),'dmmyyyy'))=Format(DateAdd('d',$ToAdd,@FECHA),'dmmyyyy'),
						0,
						IIf(DatePart('w',(DateValue(@FECHA)+$ToAdd),2)=PERMISOS.DIA_DESCANSO,
							0,
							1
						)
					),
					0
				) 
				$+
";

		public const string SQL_WHERE_DAY = @"
		((DateValue(@FECHA)+$ToAdd)>=PERMISOS.DIA1 And (DateValue(@FECHA)+$ToAdd)<=PERMISOS.DIA2) OR";



		#endregion

		/// <summary>
		/// Propiedad de solo lectura que construye y devuelve la cadena con el SQL con el que se obtendran los datos
		/// </summary>
		public string SQLToExecute {
			get {
				// Genero las variables StringBulders
				StringBuilder strbld = new StringBuilder ( ),
					strbldDays = new StringBuilder ( ),
					strbldCountDays = new StringBuilder ( ),
					strbldWhereDays = new StringBuilder ( );

				// Agrego la sentencia principal
				strbld.Append ( SQL_MAIN_SELECT );


				// Recorro los dias seleccionados para agregar las columnas de los dias
				for ( int i = 0; i < countSelectedDays; i++ ) {
					// Genero la variable toSQL, que contendra los parametros para la columna del dia
					string toSQL = SQL_DAY_PERMISO_VALUE;

					// Sustituyo $ToAdd, que indica el numero de dias a sumar
					toSQL = toSQL.Replace ( "$ToAdd" , i.ToString ( ) );

					// Sustituyo $Nombre, que indica el nombre de la columna, será un valor numerico que despues se convertira en una fecha
					toSQL = toSQL.Replace ( "$Nombre" , clDateRange.SelectionStart.AddDays ( i ).ToOADate ( ).ToString ( ) );

					// Agrego la cadena al stringBuilder
					strbldDays.Append ( toSQL );
				}


				// Recorro los dias seleccionados para agregar el concepto de dias
				for ( int i = 0; i < countSelectedDays; i++ ) {
					// Genero la variable toSQL, que contendra los parametros para obtener el valor 1 o cero de la suma
					string toSQL = SQL_TO_SUM;

					// Sustituyo $ToAdd, que indica el numero de dias a sumar
					toSQL = toSQL.Replace ( "$ToAdd" , i.ToString ( ) );

					// Si es la ultima sentencia que se agregará, quito el operador "+"
					toSQL = toSQL.Replace ( "$+" , ( i == countSelectedDays - 1 ? "" : "+" ) );

					// Agrego la cadena al stringBuilder
					strbldCountDays.Append ( toSQL );
				}


				// Recorro los dias seleccionados para construir la clausula WHERE
				for ( int i = 0; i < countSelectedDays; i++ ) {
					// Genero la variable toSQL, que contendra los parametros de filtro
					string toSQL = SQL_WHERE_DAY;

					// Sustituyo $ToAdd, que indica el numero de dias a sumar
					toSQL = toSQL.Replace ( "$ToAdd" , i.ToString ( ) );

					// Si es la ultima sentencia que se agregará, quito el operador "OR"
					if ( i == countSelectedDays - 1 )
						toSQL = toSQL.Replace ( "OR" , "" );
					// Agrego la cadena al stringBuilder
					strbldWhereDays.Append ( toSQL );
				}


				// Reeplazo $permisoDays por el string que contine la definicion de las columnas
				strbld.Replace ( "$permisoDays" , strbldDays.ToString ( ) );

				// Reemplazo "totalDays que contien el conteo de dias si el permiso es de tipo 3(varios dias)
				strbld.Replace ( "$totalDays" , strbldCountDays.ToString ( ) );

				// Reemplazo $whereDays que contien la clausula de filtro para la consulta
				strbld.Replace ( "$whereDays" , strbldWhereDays.ToString ( ) );

				// Devuelvo la sentencia resultante
				return strbld.ToString ( );
			}
		}

		/// <summary>
		/// Obtiene la informacion desde la base de datos y la pega en la hoja de calculo de Excel.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImportar_Click ( object sender , EventArgs e ) {

			// Genero una variable de conexion Disposable 
			using ( var cnn = new OleDbConnection ( this.appSetting.GetConnectionString(AppSetting.PERMISOS_KEY) ) ) {

				// Genero una variable DataAdapter Disposable
				using ( var ODA = new OleDbDataAdapter ( SQLToExecute , cnn ) ) {

					// Agrego parametros al comando select => @FECHA => Fecha Inicial
					ODA.SelectCommand.Parameters.Add ( new OleDbParameter ( "@FECHA" , clDateRange.SelectionStart ) );

					// Genero una variable DataTable Disposable
					using ( var dt = new System.Data.DataTable ( ) ) {

						// Relleno el DataTable con el resultado de la consulta
						ODA.Fill ( dt );

						// Recorro las columnas de la tabla
						for ( int col = 0; col < dt.Columns.Count; col++ ) {

							// Asigno el valor de la celda con el nombre de la columna
							ExHoja.Cells [ 1 , col + 1 ] = dt.Columns [ col ].ColumnName;

							// Configuro Ancho de columna y Formato de numero segun el criterio If
							if ( col <= 1 ) {
								( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).EntireColumn.ColumnWidth = 5;
							} else if ( col > 1 && col < dt.Columns.Count - 4 ) {
								( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).NumberFormat = "dd/mm/yyyy";
								( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).EntireColumn.ColumnWidth = 3;
							} else if ( col > dt.Columns.Count - 4 && col < dt.Columns.Count - 1 ) {
								( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).EntireColumn.ColumnWidth = 13;
							} else if ( col == dt.Columns.Count - 1 ) {
								( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).EntireColumn.ColumnWidth = 100;
							}
							
							// Asigno el color de fondo
							( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).Interior .Color = ColorTranslator.ToOle ( Color.CadetBlue );

							// Establesco las letras en negritas
							( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).Font.Bold = true;

							// Indico la alineacion del contenido
							( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).VerticalAlignment = XlVAlign.xlVAlignBottom;
							( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).HorizontalAlignment = XlHAlign.xlHAlignCenter;

							// Indico la orientacion del texto, el valor es un angulo
							( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).Orientation = 90;

							// Configuro otros valores
							( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).WrapText = false;							
							( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).AddIndent = false;
							( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).IndentLevel = 0;
							( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).ShrinkToFit = false;
							( ( Range ) ExHoja.Cells [ 1 , col + 1 ] ).ReadingOrder = ( int ) Constants.xlContext;
						}

						// Establezco el alto de la primera fila
						( ( Range ) ExHoja.Rows [ "1,1" ] ).RowHeight = 75;

						// Recorro las filas del DataTable
						foreach ( DataRow rDt in dt.Rows ) {
							// Recorro las columnas
							for ( int col = 0; col < rDt.ItemArray.Count ( ); col++ ) {
								// Asigno de la columna y la fila en curso a la celda de Excel indicada
								ExHoja.Cells [ dt.Rows.IndexOf ( rDt ) + 2 , col + 1 ] = rDt [ col ];
							}
						}
					}
				}

				// Cierro la Conexión
				cnn.Close ( );
			}

			//// Escribo en la consola de depuración la sentensia SQL resultante
			//System.Diagnostics.Debug.WriteLine ( this.SQLToExecute );
		}
	}
}
