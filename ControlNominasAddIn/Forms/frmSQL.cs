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
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;


namespace ControlNominasAddIn.Forms {
	/// <summary>
	/// Form que ejecuta sentencias SQL personalizadas
	/// </summary>
	public partial class frmSQL : KryptonForm {

		/// <summary>
		/// Clase contenedora de informacion de un elemento de un comboBox
		/// </summary>
		private class ItemElement {
			// Cadena que se mostrara
			public string Display { get; set; }
			// Valor que devolvera
			public string Value { get; set; }
		}
		public List<SchemaSnippetItem> SchemaItems { get; set; } = new List<SchemaSnippetItem> ( );
		public frmSQL ( ) {
			// Inicializo los componentes
			InitializeComponent ( );

			// Genero una lista para el origen de datos del comboBox de Bases de Datos
			List<ItemElement> source = new List<ItemElement> ( );

			// Obtengo la cadena de conexion de la BD de permisos
			OleDbConnectionStringBuilder cn = new OleDbConnectionStringBuilder ( Properties.Settings.Default.PermisosConnectionString );

			// Agrego el nombre del archivo a la lista
			source.Add ( new ItemElement ( ) { Display = System.IO.Path.GetFileNameWithoutExtension ( cn.DataSource ) , Value = cn.ConnectionString } );

			// Obtengo la cadena de conexion para la BD del reloj1
			cn.ConnectionString = Properties.Settings.Default.Reloj1ConnectionString;

			// Agrego el nombre del archivo a la lista
			source.Add ( new ItemElement ( ) { Display = System.IO.Path.GetFileNameWithoutExtension ( cn.DataSource ) , Value = cn.ConnectionString } );

			// Obtengo la cadena de conexion para la BD del reloj2
			cn.ConnectionString = Properties.Settings.Default.Reloj2ConnectionString;

			// Agrego el nombre del archivo a la lista
			source.Add ( new ItemElement ( ) { Display = System.IO.Path.GetFileNameWithoutExtension ( cn.DataSource ) , Value = cn.ConnectionString } );

			// Asigno la lista como origen de datos del comboBox de BD
			cmbSchemas.ComboBox.DataSource = source;

			// Asigno la propiedad que se usara como visualizacion
			cmbSchemas.ComboBox.DisplayMember = "Display";

			// Asigno la propiedad que se usara como valor
			cmbSchemas.ComboBox.ValueMember = "Value";

			// Agrego el controlador del evento de cambio de valor seleccionado
			cmbSchemas.ComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;

			// Asigno el valor por defecto
			cmbSchemas.SelectedIndex = -1;
		}

		/// <summary>
		/// Se desencadena si la Base de Datos seleccionada cambia
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void ComboBox_SelectedValueChanged ( object sender , EventArgs e ) {
			if ( cmbSchemas.ComboBox.SelectedValue != null )
				await FillTreeView ( cmbSchemas.ComboBox.SelectedValue.ToString ( ) ); // Actualiza los valores del TreeView
		}

		/// <summary>
		/// Crea un documento nuevo de consultas SQL
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void nuevoArchivo_Click ( object sender , EventArgs e ) {
			// Creo un nuevo documento SQL
			var t = new Forms.SQLPage ( );

			// Agrego la pagina al navegador
			this.kryptonNavigator1.Pages.Add ( t.KP );

			// Hago que la pagina nueva sea la seleccionada en el navegador
			this.kryptonNavigator1.SelectedPage = t.KP;

			// Agrego la coleccion SchemaSnippets al FastColoredTextBox
			t.KP._SQLPage.SchemaItems = SchemaItems;

			// Creo y agrego los Snippets al FastColoredTextBox
			t.KP._SQLPage.buildSnippets ( );
		}

		private void frmSQL_Load ( object sender , EventArgs e ) {

		}

		/// <summary>
		/// Lleno el catalogo de tablas y vistas disponibles al seleccionar una base de datos
		/// </summary>
		/// <param name="stringConnection">cadena Conexion a la base de datos</param>
		/// <returns></returns>
		private async Task FillTreeView ( string stringConnection ) {
			try {
				// Limpio la coleccion de autocompletables.
				SchemaItems.Clear ( );

				// Limpio los nodos del treeView
				tvSchema.Nodes.Clear ( );

				// Instancio una nueva conexion
				using ( var cnn = new OleDbConnection ( stringConnection ) ) {

					// Abro asyncronicamente la conexion
					await cnn.OpenAsync ( );

					// Genero las restricciones para el metodo GetSchema, 'Solo Tablas'
					string [ ] restrictions = new string [ 4 ];
					restrictions [ 3 ] = "Table";

					// Obtengo los datos del Schema
					var t = cnn.GetSchema ( "Tables" , restrictions );

					// Construyo los nodos por niveles				
					tvSchema.Nodes.Add ( this.makeNode ( t , cnn , "Tables" , 1 , 0 ) );

					// Genero las restricciones para el metodo GetSchema, 'Solo Vistas'
					restrictions [ 3 ] = "View";

					// Obtengo los datos del Schema
					t = cnn.GetSchema ( "Tables" , restrictions );

					// Construyo los nodos por niveles
					tvSchema.Nodes.Add ( this.makeNode ( t , cnn , "Vistas" , 2 , 0 ) );

					// Cierro la conexión.
					cnn.Close ( );
				}
			} catch ( Exception ex ) {
				KryptonTaskDialog.Show ( "Algo va mal..." , "Error" , ex.Message , MessageBoxIcon.Error , TaskDialogButtons.OK );
			}
		}

		/// <summary>
		/// Construye los nodos en diferentes niveles, y asigna el icono correspondiente a cada nodo, dependiendo del tipo de datos
		/// </summary>
		/// <param name="tb">tabla de origend e datos</param>
		/// <param name="cnn">OleDbConection que se usara para obtener los datos</param>
		/// <param name="mainName">Nombre del nodo padre</param>
		/// <param name="childImageIndex">index de la imagen del nodo padre</param>
		/// <param name="Imageindex">imagen por default de los nodos hijo</param>
		/// <returns></returns>
		private TreeNode makeNode ( DataTable tb , OleDbConnection cnn , string mainName , int childImageIndex , int? Imageindex = null ) {

			// Genero una instancia nueva de TreeNode, si ImageIndex contiene valor, uso el constructor apropiado
			TreeNode mainTablesNode = Imageindex.HasValue ? new TreeNode ( mainName , Imageindex.Value , Imageindex.Value ) : new TreeNode ( mainName );

			// Recorro todas las filas de la tabla
			foreach ( DataRow rw in tb.Rows ) {

				// Genero una nueva instancia de TreeNode con el nombre del elemento en curso y le asigno los indices de la imagen
				TreeNode TableNode = new TreeNode ( rw [ 2 ].ToString ( ) , childImageIndex , childImageIndex );

				// Genero restriciiones para una nueva consulta, la restriccion corresponde al elemento en curso
				string [ ] restrictionsTable = new string [ 4 ];
				restrictionsTable [ 2 ] = rw [ 2 ].ToString ( );

				// Ejecuto la consulta y los ordeno por el numero cardinal del campo
				var u = from DataRow dt in cnn.GetSchema ( "Columns" , restrictionsTable ).Rows
						orderby dt [ 6 ]
						select dt;

				// Recorro todas las columnas de la fila en curso
				foreach ( DataRow col in u ) {
					// Genero una variable que contiene el tipo de datos de la columna
					var Type_ = ( OleDbType ) col [ 11 ];

					// Genero la variable donde se almacenara el index de la imagen
					int icon;

					// Selecciono el icono dependiendo del tipo de datos
					switch ( Type_ ) {
						case OleDbType.WChar:
							icon = 3;
							break;
						case OleDbType.Integer:
						case OleDbType.SmallInt:
						case OleDbType.Numeric:
						case OleDbType.TinyInt:
						case OleDbType.BigInt:
						case OleDbType.Double:
						case OleDbType.Decimal:
						case OleDbType.Single:
							icon = 4;
							break;
						case OleDbType.Boolean:
							icon = 5;
							break;
						case OleDbType.Date:
						case OleDbType.DBDate:
						case OleDbType.DBTime:
						case OleDbType.DBTimeStamp:
							icon = 6;
							break;
						default:
							icon = 3;
							break;
					}

					// Agrego el elemento autompletable
					SchemaItems.Add ( new SchemaSnippetItem (
						rw [ 2 ].ToString ( ) , // Nombre de la Table
						col [ 3 ].ToString ( ) ,// Nombre de la columna
						mainName == "Tablas" ? SchemaSnippetItem.Tipos.Tabla : SchemaSnippetItem.Tipos.Vista , // Tipo de elemento
						icon ) );// Index de la imagen

					// Genero el nodo de columna
					TreeNode ColumnNode = new TreeNode ( col [ 3 ].ToString ( ) , icon , icon );

					// Agrego el string que se devolvera como etiqueta del elemento
					ColumnNode.Tag = rw [ 2 ].ToString ( ) + "." + col [ 3 ].ToString ( );

					// Agrego el nodo Hijo al nodo Pagre
					TableNode.Nodes.Add ( ColumnNode );
				}

				// Agrego el nodo Padre al nodo Raiz
				mainTablesNode.Nodes.Add ( TableNode );
			}

			// Geenro una instancia de customKryptonPage desde la pagina seleccionada en el navegador
			customKryptonPage pg = ( customKryptonPage ) this.kryptonNavigator1.SelectedPage;

			// Si no es nulo
			if ( pg != null ) {
				// Agrego la coleccion SchemaSnippets al FastColoredTextBox
				pg._SQLPage.SchemaItems = SchemaItems;

				// Creo y agrego los Snippets al FastColoredTextBox
				pg._SQLPage.buildSnippets ( );
			}

			// Retorno el nodo raiz
			return mainTablesNode;

		}

		/// <summary>
		/// Intenta ejecutar el codigo de SQL presente en el documento de la pagina seleccionada
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExecuteQuery_Click ( object sender , EventArgs e ) {
			customKryptonPage pg = ( customKryptonPage ) this.kryptonNavigator1.SelectedPage;
			try {
				// Verifico si existe cadena de conexion
				if ( cmbSchemas.ComboBox.SelectedValue == null )
					throw new Exception ( "No se ha seleccionado ninguna Base de Datos" );
				// agrego las restricciones de codigo
				if ( pg.SQLString.ToLower ( ).Contains ( "delete" ) || pg.SQLString.ToLower ( ).Contains ( "insert" ) || pg.SQLString.ToLower ( ).Contains ( "update" ) )
					throw new Exception ( "No se permite hacer delets, updates o inserts" );

				if ( pg.SQLString.ToLower ( ).Contains ( "drop" ) || pg.SQLString.ToLower ( ).Contains ( "create" ) || pg.SQLString.ToLower ( ).Contains ( "alter" ) )
					throw new Exception ( "No se permite hacer drops, creates o alters" );

				// Limpio el origen de datos de DataGrid de resultados
				pg.DataSource = null;

				// Genero una variable de conexion Disposable 
				using ( var cnn = new OleDbConnection ( cmbSchemas.ComboBox.SelectedValue.ToString ( ) ) ) {
					// Genero una variable DataAdapter Disposable
					using ( var ODA = new OleDbDataAdapter ( pg.SQLString , cnn ) ) {
						// Genero una variable DataTable Disposable
						using ( var dt = new System.Data.DataTable ( ) ) {
							ODA.Fill ( dt );
							// Si hay resultados los muestro en el datagrid
							if ( dt.Rows.Count > 0 ) {
								pg.DataSource = dt;
								pg.ShowData = true;
							}
							// Si no hay datos termino.
							else {
								pg.ShowData = false;
							}
						}
					}
				}

			} catch ( Exception ex ) {
				if ( pg != null )
					pg.ShowData = false;
				KryptonTaskDialog.Show ( "Algo va mal..." , "Error" , ex.Message , MessageBoxIcon.Error , TaskDialogButtons.OK );
			}
		}

		private void guardarArchivo_Click ( object sender , EventArgs e ) {
			// Verifico que exista una pagina seleccionada, si no hay termino la tarea
			if ( this.kryptonNavigator1.SelectedPage == null )
				return;

			// Convierto la pagina seleccionada en una instancia de customKryptonPage
			customKryptonPage pg = ( customKryptonPage ) this.kryptonNavigator1.SelectedPage;

			// Si tiene una ruta de archivo confirmo la acción, si no se acepta termino
			if ( pg?.fullFilePath != null ) {
				if ( KryptonTaskDialog.Show ( "Guardar..." , "Guardar?" , "realmente desea guardar el codigo?" , MessageBoxIcon.Question , TaskDialogButtons.Yes | TaskDialogButtons.No ) == DialogResult.No )
					return;
			}
			// Si no tiene ruta de archivo, abro un saveFileDialog y si la respuesta es diferente de ok, termino, si es ok, agrego el path del archivo al pg
			else {
				if ( saveFileDialog1.ShowDialog ( ) != DialogResult.OK )
					return;
				pg.fullFilePath = saveFileDialog1.FileName;
			}

			// Guardo el archivo.
			pg.SaveToFile ( pg.fullFilePath , Encoding.UTF8 );
		}

		private void abrirArchivo_Click ( object sender , EventArgs e ) {
			// continuo si no se cancelo la acción en el cuadro de dialogo openFileDialog
			if ( openFileDialog1.ShowDialog ( ) == System.Windows.Forms.DialogResult.OK ) {
				// creo una instancia de SQLPage y tomo la pagina en la variable
				var t = new Forms.SQLPage ( ).KP;

				// Agrego la pagina al navegador
				this.kryptonNavigator1.Pages.Add ( t );

				// Abro el archivo seleccionado en el openFileDialog
				t.OpenFile ( openFileDialog1.FileName , Encoding.UTF8 );

				// Agrego el path del archivo a la pagina
				t.fullFilePath = openFileDialog1.FileName;

				// Agrego la coleccion SchemaSnippets al FastColoredTextBox
				t._SQLPage.SchemaItems = SchemaItems;

				// Creo y agrego los Snippets al FastColoredTextBox
				t._SQLPage.buildSnippets ( );

				// Hago que la pagina que cree sea la seleccionada y sea visible.
				this.kryptonNavigator1.SelectedPage = t;
			}
		}

		private void kryptonNavigator1_SelectedPageChanged ( object sender , EventArgs e ) {
			// Convierto la pagina seleccionada en una instancia de customKryptonPage
			customKryptonPage pg = ( customKryptonPage ) this.kryptonNavigator1.SelectedPage;

			// Habilito el boton ejecutar si existe una base de datos seleccionada y si la pagina no es nula
			btnExecute.Enabled = pg != null && cmbSchemas.SelectedIndex >= 0 ? true : false;

			// Si la pagina no es nula
			if ( pg != null ) {
				// Agrego la coleccion SchemaSnippets al FastColoredTextBox
				pg._SQLPage.SchemaItems = SchemaItems;
				// Creo y agrego los Snippets al FastColoredTextBox
				pg._SQLPage.buildSnippets ( );
			}
		}

		private void guardarComoArchivo_Click ( object sender , EventArgs e ) {
			// Reviso si hay una pagina seleccionada
			if ( this.kryptonNavigator1.SelectedPage != null )
				return;

			// Convierto la pagina seleccionada en una instancia de customKryptonPage
			customKryptonPage pg = ( customKryptonPage ) this.kryptonNavigator1.SelectedPage;

			// Abro un saveFileDialog y si la respuesta es diferente de OK termino
			if ( saveFileDialog1.ShowDialog ( ) != DialogResult.OK )
				return;

			// Agrego el path del archivo a la pagina
			pg.fullFilePath = saveFileDialog1.FileName;

			// Guardo el archivo
			pg.SaveToFile ( pg.fullFilePath , Encoding.UTF8 );
		}

		private void salirToolStripMenuItem_Click ( object sender , EventArgs e ) {
			// Cierro la ventana
			this.Close ( );
		}

		private void frmSQL_FormClosing ( object sender , FormClosingEventArgs e ) {
			// Si se intentó cerrar la ventana, confirmo la salida
			if ( KryptonTaskDialog.Show ( "salir..." , "Salir?" , "Realmente desea salir?\nSi sale los cambios no guardados se perderan!" , MessageBoxIcon.Question , TaskDialogButtons.Yes | TaskDialogButtons.No ) == DialogResult.No )
				e.Cancel = true;
		}
	}
}
