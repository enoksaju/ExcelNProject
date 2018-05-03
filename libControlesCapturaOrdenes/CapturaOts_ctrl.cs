using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using unvell.ReoGrid.CellTypes;
using unvell.ReoGrid.Rendering;
using System.Data.Entity;

namespace libControlesCapturaOrdenes {

	[ToolboxItem ( true )]
	public partial class CapturaOts_ctrl : Base {

		libProduccionDataBase.Contexto.DataBaseContexto DB;

		DropdownListCell TipoProductoCell = new DropdownListCell ( "PELICULA" , "PELICULA LAMINADA" , "PELICULA TRILAMINADA" , "FLOWPACK LAMINADA" , "FLOWPACK TRILAMINADA" , "SELLO LATERAL NO IMPRESA" , "SELLO LATERAL IMPRESA" , "SELLO LATERAL LAMINADA NO IMPRESA" , "SELLO LATERAL LAMINADA IMPRESA" , "SELLO LATERAL TRILAMINADA" , "ETIQUETA" , "PVC" , "PROTOTIPOS" , "PIEZAS" , "ETIQUETA TIPO MANGA" );
		DropdownListCell TipoImpresionCell = new DropdownListCell ( "PIE" , "CABEZA" , "POR DENTRO" , "POR FUERA" , "REPETICION" , "PIE DE IMPRESIÓN" );
		DropdownListCell TipoTrabajoCell = new DropdownListCell ( "REPETIDO" , "NUEVO" );
		DropdownListCell MaterialesCell = new DropdownListCell ( "NINGUNO" , "PEBD" , "PEHD" , "PET" , "BOPP" , "BOPP-CAVITADO" , "BOPP PERLEC" , "PVC" , "PET-G" , "POLIOLEFINA" , "PVX" , "CPP" , "NOPP" , "GUALAPACK" );

		DropdownListCell MaquinasCell = new DropdownListCell ( );
		DropdownListCell RodillosCell = new DropdownListCell ( );


		private System.IO.MemoryStream plant = new System.IO.MemoryStream ( Properties.Resources.plantilla );
		public CapturaOts_ctrl ( ) {
			InitializeComponent ( );
			this.Dock = DockStyle.Fill;

		}

		private void Rb_CheckChanged ( object sender , EventArgs e ) {
			reoGridControl1.CurrentWorksheet.RecalcCell ( "B59" );
		}

		private async void CapturaOts_ctrl_Load ( object sender , EventArgs e ) {

			if ( !DesignMode ) {

				DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );

				reoGridControl1.Reset ( );
				reoGridControl1.Load (
					plant ,
					unvell.ReoGrid.IO.FileFormat.ReoGridFormat , Encoding.Default );

				await DB.Maquinas.Where ( y => y.TipoMaquina_Id == 1 ).LoadAsync ( );
				MaquinasCell.Items.Clear ( );
				MaquinasCell.Items.AddRange ( DB.Maquinas.Local.ToArray ( ) );

				// Set Style of Grid on control
				reoGridControl1.CurrentWorksheet.SetSettings ( unvell.ReoGrid.WorksheetSettings.View_ShowGridLine , false );
				reoGridControl1.CurrentWorksheet.SetSettings ( unvell.ReoGrid.WorksheetSettings.View_ShowHeaders , false );
				reoGridControl1.CurrentWorksheet.SetSettings ( unvell.ReoGrid.WorksheetSettings.View_ShowRulers , false );
				//reoGridControl1.CurrentWorksheet.SetSettings ( unvell.ReoGrid.WorksheetSettings.View_AntialiasDrawing , true );

				// Customize checkbox on cells booleans

				reoGridControl1.CurrentWorksheet [ "A56" ] = new object [ ] { new MyCheckBox ( "Especial" ) };
				reoGridControl1.CurrentWorksheet [ "A58" ] = new object [ ] { new MyCheckBox ( "Especial" ) };

				// Customize Group buttons for Extrusion selected materials
				reoGridControl1.CurrentWorksheet [ "A92" ] = new object [ ] { new MyCheckBox ( "Mat 1" ) };
				reoGridControl1.CurrentWorksheet [ "A93" ] = new object [ ] { new MyCheckBox ( "Mat 2" ) };
				reoGridControl1.CurrentWorksheet [ "A94" ] = new object [ ] { new MyCheckBox ( "Mat 3" ) };


				// Customize radio butons for special instructions of Refinado
				var radioGroup = new RadioButtonGroup ( );
				reoGridControl1.CurrentWorksheet [ "A60" ] = new object [ , ] {
				{ new MyRadioButton("Especial") { RadioGroup = radioGroup },"" },
				{ new MyRadioButton("Sencilla") { RadioGroup = radioGroup },"" } ,
				{ new MyRadioButton("Doble") { RadioGroup = radioGroup },"" },
				{ new MyRadioButton("Ninguno") { RadioGroup = radioGroup },"" }
				};

				// Customize DropDownList Cells
				reoGridControl1.CurrentWorksheet [ "B1" ] = TipoProductoCell;
				reoGridControl1.CurrentWorksheet [ "B15" ] = TipoImpresionCell;
				reoGridControl1.CurrentWorksheet [ "B16" ] = TipoTrabajoCell;

				// Set DropDownCells for Materials
				reoGridControl1.CurrentWorksheet [ "B25" ] = MaterialesCell.Clone ( );
				reoGridControl1.CurrentWorksheet [ "E25" ] = MaterialesCell.Clone ( );
				reoGridControl1.CurrentWorksheet [ "G25" ] = MaterialesCell.Clone ( );


				reoGridControl1.CurrentWorksheet [ "B19" ] = new DropdownListCell ( "KG" , "MILL" );

				// Set DropdownCell for Maquinas
				reoGridControl1.CurrentWorksheet [ "E15" ] = MaquinasCell;
				reoGridControl1.CurrentWorksheet [ "E16" ] = RodillosCell;


				// Set Handled for selecteditem changed on changed TipoProducto
				TipoProductoCell.SelectedItemChanged += TipoProductoCell_SelectedItemChanged;

				MaquinasCell.SelectedItemChanged += MaquinasCell_SelectedItemChanged;

				// Set Handled for refresh the cell when selected optionbutton changed
				radioGroup.RadioButtons.ForEach ( rb => {
					rb.CheckChanged += Rb_CheckChanged;
				} );

				Clear ( );
				OpenOT ( "0000" );
				// Run Scripts and Recalculate the grid
				reoGridControl1.RunScript ( );
				reoGridControl1.CurrentWorksheet.Recalculate ( );
			}

		}

		private async void MaquinasCell_SelectedItemChanged ( object sender , EventArgs e ) {
			bool EsImpreso;
			bool EsBool = bool.TryParse ( reoGridControl1.CurrentWorksheet.Cells [ "C27" ].Data.ToString ( ) , out EsImpreso );

			RodillosCell.Items.Clear ( );

			if ( EsBool && EsImpreso ) {
				//await DB.Rodillos.Where ( y => y.Maquina.Id == (( libProduccionDataBase.Tablas.Maquina ) MaquinasCell.SelectedItem).Id ).LoadAsync ( );

				RodillosCell.Items.AddRange ( await DB.Rodillos.Where ( y => y.Maquina.Id == ( ( libProduccionDataBase.Tablas.Maquina ) MaquinasCell.SelectedItem ).Id ).ToArrayAsync ( ) );//DB.Rodillos.Local.ToArray ( ) );
			}

			reoGridControl1.CurrentWorksheet.Cells [ "E16" ].Data = "";
		}


		#region StylizeTipeOfProduct 
		private const string S = "B8";
		private const string FL = "B9";
		private const string FF = "B10";
		private const string C = "B11";
		private const string ASR = "B12";
		private const string ASF = "B13";
		private unvell.ReoGrid.WorksheetRangeStyle disabledCell = new unvell.ReoGrid.WorksheetRangeStyle {
			Flag = unvell.ReoGrid.PlainStyleFlag.BackColor | unvell.ReoGrid.PlainStyleFlag.TextColor ,
			BackColor = unvell.ReoGrid.Graphics.SolidColor.Gray ,
			TextColor = unvell.ReoGrid.Graphics.SolidColor.Gray
		};
		private unvell.ReoGrid.WorksheetRangeStyle enabledCell = new unvell.ReoGrid.WorksheetRangeStyle {
			Flag = unvell.ReoGrid.PlainStyleFlag.BackColor | unvell.ReoGrid.PlainStyleFlag.TextColor ,
			BackColor = unvell.ReoGrid.Graphics.SolidColor.LightGreen ,
			TextColor = unvell.ReoGrid.Graphics.SolidColor.Black
		};

		private void TipoProductoCell_SelectedItemChanged ( object sender , EventArgs e ) {
			int Tipo;
			bool num = int.TryParse ( reoGridControl1.CurrentWorksheet.Cells [ "G1" ].Data.ToString ( ) , out Tipo );
			if ( num ) {

				var Sheet = reoGridControl1.CurrentWorksheet;
				Sheet.SetRangeStyles ( "B8:B13" , disabledCell );
				switch ( Tipo ) {
					case 3:
					case 4:
						Sheet.SetRangeStyles ( FL + ":" + FL , enabledCell );
						Sheet.SetRangeStyles ( ASR + ":" + ASF , enabledCell );
						break;
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
						Sheet.SetRangeStyles ( S + ":" + S , enabledCell );
						Sheet.SetRangeStyles ( FF + ":" + C , enabledCell );
						break;

					default:
						break;
				}
			}
		}
		#endregion

		private Dictionary<string , itemDictionary> _campos;
		public Dictionary<string , itemDictionary> Campos {
			get {
				if ( _campos == null ) {
					_campos = new Dictionary<string , itemDictionary> {
						{ "TIPOPRODUCTO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B1" ], "PELICULA")},
						{ "OT", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B2" ],"")},
						{ "FECHARECIBIDO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B3" ],DateTime .Now.Date)},
						{ "CLIENTE", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B4" ],"")},
						{ "PRODUCTO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B5" ],"")},
						{ "DISENIOAUT", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B6" ],"")},
						{ "ALTO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B7" ],0)},
						{ "SOLAPA", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B8" ],0)},
						{ "FUELLELATERAL", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B9" ],0)},
						{ "FUELLEFONDO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B10" ],0)},
						{ "COPETE", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B11" ],0)},
						{ "AREASELLOREV", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B12" ],0)},
						{ "AREASELLOFONDO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B13" ],0)},
						{ "ORDENCOMPRA", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E1" ],"")},
						{ "CLAVEINTELISIS", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E2" ],"")},
						{ "FECHAENTREGASOL", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E3" ],DateTime .Now.Date)},
						{ "FEGURASALIDAFINAL", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E6" ],0)},
						{ "ANCHO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E7" ],0)},
						{ "REPEJE", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E8" ],1)},
						{ "REPDES", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E9" ],1)},
						{ "CENTROS", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E10" ],3)},

						{ "IMPRESORA", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E15" ],"")},
						{ "RODILLO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E16" ],"")},

						{ "TIPOIMPRESION", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B15" ],"POR DENTRO")},
						{ "TIPOTRABAJO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B16" ],"NUEVO")},

						{ "CANTIDAD", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B18" ],0)},
						{ "UNIDAD", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B19" ],"KG")},

						{ "MATBASE", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B25" ],"NINGUNO")},
						{ "MATBASECALIBRE", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B24" ],0)},
						{ "MATBASEAMU", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B27" ],0)},
						{ "MATBASEAPARIENCIA", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B26" ],"")},

						{ "MATLAMINACION", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E25" ],"NINGUNO")},
						{ "MATLAMINACIONCALIBRE", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E24" ],0)},
						{ "MATLAMINACIONAMU", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E27" ],0)},
						{ "MATLAMINACIONAPARIENCIA", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "E26" ],"")},

						{ "MATTRILAMINACION", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "G25" ],"NINGUNO")},
						{ "MATTRILAMINACIONCALIBRE", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "G24" ],0)},
						{ "MATTRILAMINACIONAMU", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "G27" ],0)},
						{ "MATTRILAMINACIONAPARIENCIA", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "G26" ],"")},

						{ "TINTA", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "C28" ],0)},
						{ "ADH1", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "D28" ],0)},
						{ "ADH2", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "F28" ],0)},
						{ "OBSERVACIONES", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "G34" ],"")},

						{ "AJUIMP", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B35" ],0)},
						{ "LAMIMP", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B36" ],0)},
						{ "TRIIMP", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B37" ],0)},
						{ "AJULAM", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "C35" ],0)},
						{ "LAMLAM", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "C36" ],0)},
						{ "TRILAM", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "C37" ],0)},
						{ "AJUTRI", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "D35" ],0)},
						{ "TRITRI", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "D37" ],0)},

						{ "PORCTOLERANCIA", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "D20" ],0.05)},

						{ "ZIPPER", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "H8" ],false)},
						{ "ADHPERM", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "H12" ],false)},
						{ "ADHREM", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "H13" ],false)},
						{ "ESPECIAL", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "A56" ],false)},
						{ "ESPECIALLAM", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "A58" ],false)},

						{ "ESPECIALREF_ESPECIAL", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "A60" ],false)},
						{ "ESPECIALREF_SENCILLA", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "A61" ],false)},
						{ "ESPECIALREF_DOBLE", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "A62" ],false)},
						{ "ESPECIALREF_NINGUNO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "A63" ],true)},

						{ "EX1", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "A92" ],false)},
						{ "EX2", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "A93" ],false)},
						{ "EX3", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "A94" ],false)},
						{ "ZIPPER_TYPE", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "H9" ],false)},
						{ "MERMAPROCESO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B38" ],0.00)},

						{ "INSTIMPRESION", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "H55" ],".")},
						{ "INSTLAMINACION", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "H57" ],".")},
						{ "INSTREFINADO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "H59" ],".")},
						{ "INSTDOBLADO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B64" ],"")},
						{ "INSTCORTE", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B66" ],"")},
						{ "INSTEMBOBINADO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B68" ],"")},
						{ "INSTMANGAS", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B70" ],"")},
						{ "INSTSELLADO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B72" ],"")},

						{ "EXTIPO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B83" ],"")},
						{ "EXCOLOR", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B84" ],"")},
						{ "EXTRATADO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B85" ],"")},
						{ "EXDINAS", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B86" ],"")},
						{ "EXDESLIZ", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B87" ],"")},
						{ "EXANTIESTATICA", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B88" ],"")},
						{ "EXKG", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B89" ],"")},
						{ "EXANCHO", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B90" ],"")},
						{ "INSTEXTRUSION", new itemDictionary(reoGridControl1.CurrentWorksheet.Cells [ "B91" ],"")},


					};
				}
				return _campos;
			}
		}
		public void Clear ( ) {
			foreach ( var item in Campos ) {
				item.Value.Data = item.Value.defaultValue;
			}
			TipoProductoCell_SelectedItemChanged ( this , null );
		}

		public async void OpenOTAsync ( string OT_ ) {

			var OT = await DB.TEMPCAPT.Where ( o => o.OT == OT_.Trim ( ) ).FirstOrDefaultAsync ( );

			foreach ( var p in OT.GetType ( ).GetProperties ( ) ) {
				if ( Campos.Keys.Contains ( p.Name ) ) {

					if ( p.Name == "ZIPPER_TYPE" ) {
						Campos [ p.Name ].Data = (int)p.GetValue ( OT ) == 2 ? true : false;
					} else {
						Campos [ p.Name ].Data = Convert.ChangeType ( p.GetValue ( OT ) , Campos [ p.Name ].getType ( ) );// p.GetValue ( OT );
					}
				}
			}

			foreach ( var p in OT.OrdenTrabajo.GetType ( ).GetProperties ( ) ) {
				if ( Campos.ContainsKey ( p.Name ) ) {

					if ( p.Name == "MATBASE" || p.Name == "MATLAMINACION" || p.Name == "MATTRILAMINACION" ) {

						var splited = ( ( string ) p.GetValue ( OT.OrdenTrabajo ) )
							.Split ( new char [ ] { '_' } , StringSplitOptions.RemoveEmptyEntries );

						if ( splited.Count ( ) == 1 ) {
							Campos [ p.Name ].Data = splited [ 0 ];
							Campos [ p.Name + "APARIENCIA" ].Data = "";
						} else if ( splited.Count ( ) > 1 ) {
							Campos [ p.Name ].Data = splited [ 0 ];
							Campos [ p.Name + "APARIENCIA" ].Data = splited [ 1 ];
						} else {
							Campos [ p.Name ].Data = "NINGUNO";
							Campos [ p.Name + "APARIENCIA" ].Data = "";
						}

					} else if ( p.Name == "MATBASECALIBRE" || p.Name == "MATLAMINACIONCALIBRE" || p.Name == "MATTRILAMINACIONCALIBRE" ) {

						var mat = ( ( string ) Campos [ p.Name.Replace ( "CALIBRE" , "" ) ].Data )
							.Split ( new char [ ] { '_' } , StringSplitOptions.RemoveEmptyEntries );

						if ( mat.Count ( ) > 0 ) {

							Campos [ p.Name ].Data = mat [ 0 ] == "PEBD" || mat [ 0 ] == "PEHD" ? ( double ) p.GetValue ( OT.OrdenTrabajo ) / 4 : p.GetValue ( OT.OrdenTrabajo );
						} else {
							Campos [ p.Name ].Data = 0;
						}

					} else {
						Campos [ p.Name ].Data = Convert.ChangeType ( p.GetValue ( OT.OrdenTrabajo ) , Campos [ p.Name ].getType ( ) );
					}
				}
			}

		}
		public void OpenOT ( string OT_ ) {
			OpenOTAsync ( OT_ );
		}
	}

	#region itemDictionary
	public class itemDictionary {

		private object _defaultValue;
		public unvell.ReoGrid.Cell Cell {
			get;
			private set;
		}

		public object Data {
			get {
				return Cell.Data;
			}
			set {
				Cell.Data = value;
			}
		}
		public object defaultValue {
			get {
				return _defaultValue;
			}
			private set {
				_defaultValue = value;
			}
		}

		public Type getType ( ) {
			return _defaultValue.GetType ( );
		}

		public itemDictionary ( unvell.ReoGrid.Cell _Cell , object defaultValue_ ) {
			this.Cell = _Cell;
			this.defaultValue = defaultValue_;
		}
	}
	#endregion

	#region CustomCellsTypes

	public class MyCheckBox : CheckBoxCell {
		Image checkedImage, uncheckedImage;
		string _Label = "";
		public MyCheckBox ( string Label ) {
			checkedImage = Properties.Resources.CheckBox_16x;
			uncheckedImage = Properties.Resources.CheckboxUncheck_16x;
			this._Label = Label;
		}

		protected override void OnContentPaint ( CellDrawingContext dc ) {


			dc.Graphics.DrawImage ( ( this.IsChecked ? checkedImage : uncheckedImage ) , this.ContentBounds );

			dc.Graphics.DrawText ( _Label , "Arial" , 10 , unvell.ReoGrid.Graphics.SolidColor.Black ,
				new unvell.ReoGrid.Graphics.Rectangle ( this.ContentBounds.X + 20 , this.ContentBounds.Y , 60 , ContentBounds.Height ) );

		}
	}

	public class MyRadioButton : RadioButtonCell {
		string _Label = "";
		public MyRadioButton ( string Label ) {
			this._Label = Label;
		}
		protected override void OnContentPaint ( CellDrawingContext dc ) {
			base.OnContentPaint ( dc );

			dc.Graphics.DrawText ( _Label , "Arial" , 10 , unvell.ReoGrid.Graphics.SolidColor.Black ,
				new unvell.ReoGrid.Graphics.Rectangle ( this.ContentBounds.X + 20 , this.ContentBounds.Y , 50 , ContentBounds.Height ) );

		}


	}
	#endregion
}
