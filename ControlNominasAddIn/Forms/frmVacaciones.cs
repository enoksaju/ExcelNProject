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

namespace ControlNominasAddIn.Forms {
	public partial class frmVacaciones : KryptonForm {
		private OleDbParameter _parFechaIni = new OleDbParameter ( "@FECHAINI" , OleDbType.Date );
		private OleDbParameter _parFechaFin = new OleDbParameter ( "@FECHAINI" , OleDbType.Date );
		private Microsoft.Office.Interop.Excel.Application ExApp => Globals.ThisAddIn.Application;
		private Microsoft.Office.Interop.Excel.Workbook ExLibro => this.ExApp.ActiveWorkbook;
		private Microsoft.Office.Interop.Excel.Worksheet ExHoja => this.ExLibro.Worksheets [ 1 ];
		private OleDbDataAdapter _adapter;
		private OleDbConnection _conexion;
		private DataSet _dataSet;

		OleDbParameter parFechaIni => _parFechaIni;
		OleDbParameter parFechaFin => _parFechaFin;

		#region SQL strings

		/// <summary>
		/// Sql que cuenta los dias feriados o el dia de descanso si se encuentra dentro del lapso del permiso.
		/// </summary>
		public const string SQL_COUNT_FERIADOS = @"
	IIf(
		DateAdd('d',$ToAdd,[PERMISOS]![DIA1])<=[PERMISOS]![DIA2],
		IIf(
			DLookUp('FECHA_FERIADO','FERIADOS','FECHA_FERIADO=' & Format(DateAdd('d',$ToAdd,[PERMISOS]![DIA1]),'dmmyyyy'))=Format(DateAdd('d',$ToAdd,[PERMISOS]![DIA1]),'dmmyyyy') OR Weekday(DateAdd('d',$ToAdd,[PERMISOS]![DIA1]),2)=[PERMISOS]![DIA_DESCANSO],
			1,
			0
		),
		0
	)
	$OperatorSymbol";

		/// <summary>
		/// SQL que obtiene la descripcion de los motivos de dias feriados que se encuentran dentro del lapso de tiempo del permiso.
		/// </summary>
		public const string SQL_MOTIVOS_FERIADO = @"
	IIf(
		DateAdd('d',$ToAdd,[PERMISOS]![DIA1])<=[PERMISOS]![DIA2],
		IIf(
			DLookUp('FECHA_FERIADO','FERIADOS','FECHA_FERIADO=' & Format(DateAdd('d',$ToAdd,[PERMISOS]![DIA1]),'dmmyyyy'))=Format(DateAdd('d',$ToAdd,[PERMISOS]![DIA1]),'dmmyyyy'),
			DLookUp('MOTIVO','FERIADOS','FECHA_FERIADO=' & Format(DateAdd('d',$ToAdd,[PERMISOS]![DIA1]),'dmmyyyy')) & ', ',
			''
		),
		''
	)  
	$OperatorSymbol";

		/// <summary>
		/// SQL que devuelve los datos, se deben concatenar los parametros $
		/// </summary>
		public const string SQL_MAIN = @"
SELECT 
	CINT(PERMISOS.CLAVE) AS CLAVE
	, PERMISOS.DIA1 AS DIAINICIO
	, (
		$CountFeriados
	) AS DOMFER
	, PERMISOS.DIA2 AS DIAFIN	
	, 'DIAS DISFRUTADOS' AS TIPO
	, '' AS OBSERVACIONES		
	, (
		$Motivos
	) AS MOTIVO
	, PERMISOS.BITACORA AS EN_BITACORA
	, PERMISOS.ID
	, (DATEDIFF('d',  PERMISOS.DIA1, PERMISOS.DIA2)+1) AS DIFF
 FROM TRABAJADOR INNER JOIN 
	PERMISOS ON TRABAJADOR.Clave = PERMISOS.CLAVE 
 WHERE 
	PERMISOS.TIPO=9 AND 
	PERMISOS.VALIDADO=TRUE AND 
	PERMISOS.DIA1 >= @FECHAINI AND 
	PERMISOS.DIA1 <= @FECHAFIN	
 ORDER BY
	CINT (PERMISOS.CLAVE) ASC, 
	CDbl (PERMISOS.DIA1) ASC;
";


		#endregion

		/// <summary>
		/// Crea una instancia del control
		/// </summary>
		public frmVacaciones ( ) {
			InitializeComponent ( );
			// Genero una instancia nueva de la conexion
			_conexion = new OleDbConnection ( Properties.Settings.Default.PermisosConnectionString );

			// Genero una instancia nueva del DataSet
			_dataSet = new DataSet ( "VacacionesDataSet" );

			// Genero una instancia nueva del DataAdapter
			_adapter = new OleDbDataAdapter ( this.SQLtoExecute , _conexion );
		}

		/// <summary>
		/// Devuelve la sentencia SQL que devolvera los datos del reporte
		/// </summary>
		public string SQLtoExecute {
			get {
				// Genero las variables de tipo StringBuilder
				StringBuilder mainSQLstrbld = new StringBuilder ( ), countFeriadosSQLstrbld = new StringBuilder ( ), motivosSQLstrbld = new StringBuilder ( );

				// Agrego 20 instancias de las sentencias SQL complementarias, en cada una incremento el numero de dias a considerar
				for ( int i = 0; i < 21; i++ ) {
					// Agrego una sentencia de conteo
					countFeriadosSQLstrbld.Append ( SQL_COUNT_FERIADOS.Replace ( "$ToAdd" , i.ToString ( ) ).Replace ( "$OperatorSymbol" , i == 20 ? "" : "+" ) );
					// Agrego una sentencia de Motivos
					motivosSQLstrbld.Append ( SQL_MOTIVOS_FERIADO.Replace ( "$ToAdd" , i.ToString ( ) ).Replace ( "$OperatorSymbol" , i == 20 ? "" : "&" ) );
				}

				// Concateno, reemplazo los valores y devuelvo la cadena resultante
				return mainSQLstrbld
					.Append ( SQL_MAIN )
					.Replace ( "$CountFeriados" , countFeriadosSQLstrbld.ToString ( ) ) // Agrego el resultante de las sentencias Count
					.Replace ( "$Motivos" , motivosSQLstrbld.ToString ( ) ) // Agrego el resultante de las sentencias Motivo
					.ToString ( ); // Convierto a cadena y lo devuelvo
			}
		}

		/// <summary>
		/// Obtiene la informacion desde la Base de datos y la muestra en el DataGridView y en el Libro de Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGetData_Click ( object sender , EventArgs e ) {
			// Pregunto si prosigue la acción.
			if ( KryptonTaskDialog.Show ( "Confirmar..." , "Traer Datos?" , "Realmente desea traer la informacion desde la Base de Datos?\nTodos los cambios no guardados se perderan" , MessageBoxIcon.Question , TaskDialogButtons.Yes | TaskDialogButtons.No ) == DialogResult.No )
				return;

			// Limpio el rango de datos.
			( ( Range ) ExHoja.Columns [ "A:K" ] ).Clear ( );

			// Cierro la conexion si está abierta
			if ( _conexion.State == ConnectionState.Open )
				_conexion.Close ( );

			// Abro la conexion
			_conexion.Open ( );

			// Asigno valores a los parametros de las fechas =>  @FECHAINI, @FECHAFIN 
			parFechaIni.Value = this.clFechaIni.Value;
			parFechaFin.Value = this.clFechaFin.Value;

			// Limpio loas parametros anteriores.
			_adapter.SelectCommand.Parameters.Clear ( );

			// Agrego el rango de parametros al DataAdapter
			_adapter.SelectCommand.Parameters.AddRange ( new OleDbParameter [ ] { parFechaIni , parFechaFin } );

			// Relleno la Tabla Vacaciones del DataSet
			_adapter.FillSchema ( _dataSet , SchemaType.Source , "Vacaciones" );
			_adapter.Fill ( _dataSet , "Vacaciones" );

			// Agrego la columna calculada "DIAS" si no existe
			if ( _dataSet.Tables [ "Vacaciones" ].Columns.IndexOf ( "DIAS" ) <= 0 )
				_dataSet.Tables [ "Vacaciones" ].Columns.Add ( new DataColumn ( "DIAS" , typeof ( int ) ) { Expression = "DIFF-DOMFER" , ReadOnly = true } );

			// Configuro las columnas del DataTable
			_dataSet.Tables [ "Vacaciones" ].Columns [ "DIAS" ].SetOrdinal ( 4 );
			_dataSet.Tables [ "Vacaciones" ].Columns [ "DIFF" ].ColumnMapping = MappingType.Hidden;
			_dataSet.Tables [ "Vacaciones" ].Columns [ "MOTIVO" ].ColumnMapping = MappingType.Hidden;
			_dataSet.Tables [ "Vacaciones" ].Columns [ "TIPO" ].ColumnMapping = MappingType.Hidden;
			_dataSet.Tables [ "Vacaciones" ].Columns [ "OBSERVACIONES" ].ColumnMapping = MappingType.Hidden;


			// Asigno la tabla "Vacaciones" como origen de datos del DataGridView 
			vacacionesKryptonDataGridView.DataSource = _dataSet.Tables [ "Vacaciones" ];

			// Pego los datos en el archivo de Excel abierto en el momento
			// Recorro Las columnas excepto la ultima
			for ( int i = 0; i < _dataSet.Tables [ "Vacaciones" ].Columns.Count - 2; i++ ) {

				// Pego el nombre de la columna
				ExHoja.Cells [ 1 , i + 1 ] = _dataSet.Tables [ "Vacaciones" ].Columns [ i ].ColumnName;

				// Asigno el color de fondo a la cabecera
				( ( Range ) ExHoja.Cells [ 1 , i + 1 ] ).Interior.Color = ColorTranslator.ToOle ( System.Drawing.Color.CadetBlue );

				// Configuro la fuente como negritas.
				( ( Range ) ExHoja.Cells [ 1 , i + 1 ] ).Font.Bold = true;

				// Asigno el ancho de la columna personalizada, dependera del index de la columna
				switch ( i ) {
					case 0:
					case 2:
					case 4:
						( ( Range ) ExHoja.Cells [ 1 , i + 1 ] ).EntireColumn.ColumnWidth = 8;
						break;
					case 1:
					case 3:
						( ( Range ) ExHoja.Cells [ 1 , i + 1 ] ).EntireColumn.ColumnWidth = 12;
						break;
					case 5:
					case 6:
					case 8:
						( ( Range ) ExHoja.Cells [ 1 , i + 1 ] ).EntireColumn.ColumnWidth = 20;
						break;
					case 7:
						( ( Range ) ExHoja.Cells [ 1 , i + 1 ] ).EntireColumn.ColumnWidth = 30;
						break;
				}
			}

			// Recorro todas las filas de la tabla "Vacaciones"
			for ( int i = 0; i < _dataSet.Tables [ "Vacaciones" ].Rows.Count; i++ ) {
				// Para La fila en curso, recorro todas sus columnas
				for ( int J = 0; J < _dataSet.Tables [ "Vacaciones" ].Columns.Count - 2; J++ ) {
					// Pego los datos en la celda de Excel correspondiente
					ExHoja.Cells [ i + 2 , J + 1 ] = _dataSet.Tables [ "Vacaciones" ].Rows [ i ] [ J ];
				}
			}

		}

		/// <summary>
		/// Guarda los cambios en la base de datos
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click ( object sender , EventArgs e ) {

			// Confirma la acción.
			if ( KryptonTaskDialog.Show ( "Confirmar..." , "Guardar?" , "Realmente desea guardar los cambios en la Base de Datos?" , MessageBoxIcon.Question , TaskDialogButtons.Yes | TaskDialogButtons.No ) == DialogResult.No )
				return;
			// Crea la sentencia Update
			OleDbCommandBuilder _cBuilder = new System.Data.OleDb.OleDbCommandBuilder ( _adapter );
			// Actualiza la Base de datos
			_adapter.Update ( _dataSet , "Vacaciones" );
		}

		/// <summary>
		/// Da formato a la fila con base al valor de la columna "EN_BITACORA"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void vacacionesKryptonDataGridView_CellFormatting ( object sender , DataGridViewCellFormattingEventArgs e ) {
			( ( KryptonDataGridView ) sender )
				.Rows [ e.RowIndex ]
				.DefaultCellStyle.BackColor = ( ( bool ) _dataSet.Tables [ "Vacaciones" ].Rows [ e.RowIndex ] [ "EN_BITACORA" ] == true ? Color.LightGreen : Color.Orange );
		}

		/// <summary>
		/// Modifica los cambios en la hoja de Excel actual
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void vacacionesKryptonDataGridView_CellEndEdit ( object sender , DataGridViewCellEventArgs e ) {
			ExHoja.Cells [ e.RowIndex + 2 , 9 ] = _dataSet.Tables [ "Vacaciones" ].Rows [ e.RowIndex ] [ "EN_BITACORA" ];
		}

		/// <summary>
		/// Marca todos los checkBox como verdaderos en la columna "EN_BITACORA"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCheckAll_Click ( object sender , EventArgs e ) {
			// Confirma la acción
			if ( KryptonTaskDialog.Show ( "Confirmar..." , "Marcar?" , "Realmente desea marcar todos los elementos en bitacora?" , MessageBoxIcon.Question , TaskDialogButtons.Yes | TaskDialogButtons.No ) == DialogResult.No )
				return;

			// Recorro todas las filas de la tabla
			for ( int i = 0; i < _dataSet.Tables [ "Vacaciones" ].Rows.Count; i++ ) {

				// Asigno el valor como verdadero
				_dataSet.Tables [ "Vacaciones" ].Rows [ i ] [ "EN_BITACORA" ] = true;

				// Actualizo la celda de Excel
				ExHoja.Cells [ i + 2 , 9 ] = _dataSet.Tables [ "Vacaciones" ].Rows [ i ] [ "EN_BITACORA" ];
			}
		}

		/// <summary>
		/// Cierra el formulario actual
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmVacaciones_FormClosing ( object sender , FormClosingEventArgs e ) {
			// Confirma la accion
			if ( KryptonTaskDialog.Show ( "Confirmar..." , "Cerrar?" , "Realmente desea salir del formulario?\nTodos los cambios no guardados se perderan" , MessageBoxIcon.Question , TaskDialogButtons.Yes | TaskDialogButtons.No ) == DialogResult.No ) {
				e.Cancel = true;
				return;
			}

			// Libera recursos usados
			_conexion.Close ( );
			_conexion.Dispose ( );
			_dataSet.Dispose ( );
			_adapter.Dispose ( );
		}
	}
}