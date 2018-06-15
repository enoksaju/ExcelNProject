using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using System.Data.OleDb;
using FastColoredTextBoxNS;

namespace ControlNominasAddIn.Forms {
	public partial class SQLPage : UserControl {

		/// <summary>
		/// Elemtos de autocompletado del lenguaje SQL
		/// </summary>
		private string [ ] SQLSnippets = {
			"SELECT |",
			"WHERE |",
			"ORDER BY |",
			"INNER JOIN |",
			"LEFT JOIN |",
			"ROGTH JOIN |",
			"DATEDIFF([tipo],[fecha1],[fecha2])",
			"DATEADD([interval],[number], [date])",
			"AND |",
			"OR |",
			"CHOOSE([posicion], [valor1, valor2, ... valor_n])",
			"SWITCH([condicion1], [valor1], [condicion2], [valor2], ...)",
			"IIF( [condition] , [valor_si_verdadero], [valor_si_falso])",
			"SUM( | )",
			"COUNT( | )",
			"MAX( | )",
			"MIN( | )",
			"AVG( | )",
			"ISDATE( | )",
			"ISNUMERIC( | )",
			"ISNULL( | )",
			"ABS( | )",
			"FIX( | )",
			"ROUND( | , [[decimales]])",
			"LEN( | )",
			"LEFT( | , [numero_caracteres])",
			"RIGHT( | , [numero_caracteres])",
			"MID(  | , [posicion_inicial], [numero_caracteres])",
			"TRIM( | )",
			"LTRIM( | )",
			"RTRIM( | )",
			"UCASE( | )",
			"LCASE( | )",
			"REPLACE( | , [buscar], [reemplazo])",
			"REPLACE( | , [buscar], [reemplazo], [[start,[count,[compare]]]])",
			"SPACE( | )",
			"FORMAT( | , [format])",
			"CINT( | )",
			"CDBL( | )",
			"CSNG( | )",
			"CSTR( | )",
			"DATEVALUE( | )",
			"YEAR( | )",
			"MOTH( | )",
			"DAY( | )",
			"HOUR( | )",
			"MINUTE( | )",
			"TIMEVALUE( | )"
		};

		/// <summary>
		/// Elementos de autocompletado de las tablas y vistas de la base de datos
		/// </summary>
		public List<SchemaSnippetItem> SchemaItems { get; set; } = new List<SchemaSnippetItem> ( );
		

		/// <summary>
		/// Lista emergente con los elementos autocompletados
		/// </summary>
		private AutocompleteMenu popupMenu;

		/// <summary>
		///  Krypton Page que se devolvera
		/// </summary>
		public customKryptonPage KP { get; set; }

		/// <summary>
		/// Titulo de la pagina
		/// </summary>
		public string PageTitleText {
			get { return KP.TextTitle; }
			set { KP.TextTitle = value; KP.Text = value; }
		}

		/// <summary>
		/// Descripcion de la pagina
		/// </summary>
		public string PageDescriptionText {
			get { return KP.TextDescription; }
			set { KP.TextDescription = value; }
		}
		/// <summary>
		/// Guardar a archivo
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="enc"></param>
		public void SaveToFile ( string fileName , Encoding enc ) {
			this.fastColoredTextBox1.SaveToFile ( fileName , enc );
		}

		/// <summary>
		/// Abrir Archivo
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="enc"></param>
		public void OpenFile ( string fileName , Encoding enc ) {
			this.fastColoredTextBox1.OpenFile ( fileName , enc );
		}

		/// <summary>
		/// Sentencia SQL que se ejecutara
		/// </summary>
		public string SQLString {
			get { return this.fastColoredTextBox1.Text; }
			set { this.fastColoredTextBox1.Text = value; }
		}

		/// <summary>
		/// DataGridView del control
		/// </summary>
		public KryptonDataGridView GridView => this.kryptonDataGridView1;

		/// <summary>
		/// Muestra u oculta el dataGridView
		/// </summary>
		public bool ShowData {
			get {
				return !this.kryptonSplitContainer1.Panel2Collapsed;
			}
			set {
				this.kryptonSplitContainer1.Panel2Collapsed = !value;
			}
		}


		/// <summary>
		/// Construye los elementos autompletables
		/// </summary>
		/// <param name="snippets"></param>
		public void buildSnippets ( string [ ] snippets = null ) {
			// instancio una lista nueva de elementos
			List<AutocompleteItem> items = new List<AutocompleteItem> ( );

			// Recorro todos los elementos autompletables del lenguaje SQL
			foreach ( var snipString in SQLSnippets ) {
				items.Add ( new SnippetAutocompleteItem ( snipString ) { ImageIndex = 0 } );
			}

			// Agrupo y recorro todas las tablas de la base de datos seleccionada
			foreach ( var item in SchemaItems.GroupBy ( o => o.TableName ) )
				items.Add ( new SnippetAutocompleteItem ( item.Key + "|" ) { ImageIndex = 1 } );

			// Recorro todos los campos de las tablas de la base de datos seleccionada
			foreach ( var item in SchemaItems )
				items.Add ( new PartAutocompleteItem ( item.ColumnName , item.TableName ) { ImageIndex = item.ImageIndex } );

			// Agrego los elementos a la lista desplegable
			popupMenu.Items.SetAutocompleteItems ( items );
		}

		/// <summary>
		/// Inicializo el control
		/// </summary>
		public SQLPage ( ) {
			// inicializo los componentes
			InitializeComponent ( );

			// Creo la instancia de la pagina
			KP = new customKryptonPage ( this );

			// Asigno el valor por defecto del titulo de la pagina
			this.PageTitleText = "new query";

			// Asigno la lista desplegable de autocompletado al FastColoredTextBox
			popupMenu = new AutocompleteMenu ( this.fastColoredTextBox1 );

			// Asigno el patron de busqueda de autocompletados
			popupMenu.SearchPattern = @"[\w\.:=!<>]";

			// Habilito el uso de TAB par seleccionar el elemento
			popupMenu.AllowTabKey = true;

			// Asigno la lista de imagenes a los elementos seleccionados
			popupMenu.ImageList = this.imageList1;

			// Construyo los autocompletables
			buildSnippets ( );
		}
		public KryptonPage GetKryptonPage ( ) => this.KP;
	}

	/// <summary>
	/// This autocomplete item appears after dot
	/// </summary>
	public class PartAutocompleteItem : AutocompleteItem {
		string firstPart;
		string lowercaseText;
		string tentativeFirstPart;

		public PartAutocompleteItem ( string text , string InitialString , char autoLocationChar = '|' )
			: base ( text , autoLocationChar ) {
			lowercaseText = Text.ToLower ( );
			this.tentativeFirstPart = InitialString;
		}

		public override CompareResult Compare ( string fragmentText ) {
			int i = fragmentText.LastIndexOf ( '.' );
			if ( i < 0 )
				return CompareResult.Hidden;


			firstPart = fragmentText.Substring ( 0 , i );

			if ( firstPart.ToLower ( ) != tentativeFirstPart.ToLower ( ) )
				return CompareResult.Hidden;
			string lastPart = fragmentText.Substring ( i + 1 );

			if ( lastPart == "" )
				return CompareResult.Visible;
			if ( Text.StartsWith ( lastPart , StringComparison.InvariantCultureIgnoreCase ) )
				return CompareResult.VisibleAndSelected;
			if ( lowercaseText.Contains ( lastPart.ToLower ( ) ) )
				return CompareResult.Visible;

			return CompareResult.Hidden;
		}

		public override string GetTextForReplace ( ) {
			return firstPart + "." + Text;
		}
	}

	public class SchemaSnippetItem {
		public enum Tipos { Tabla, Vista }
		public string TableName { get; set; }
		public string ColumnName { get; set; }
		public Tipos Tipo { get; set; }
		public int ImageIndex { get; set; }
		public SchemaSnippetItem ( string TableName , string ColumnName , Tipos Tipo = Tipos.Tabla , int ImageIndex = 0 ) {
			this.TableName = TableName;
			this.ColumnName = ColumnName;
			this.Tipo = Tipo;
			this.ImageIndex = ImageIndex;
		}
	}
}
