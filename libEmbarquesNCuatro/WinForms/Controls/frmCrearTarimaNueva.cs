using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libProduccionDataBase.Tablas;

namespace libEmbarquesNCuatro.WinForms.Controls {
	public partial class frmCrearTarimaNueva : KryptonForm {
		private libProduccionDataBase.Contexto.DataBaseContexto DB;
		public string OTString { get; set; }

		private NaveCuatro_Tarima CurrentTarima;
		private TemporalOrdenTrabajo OT;

		public frmCrearTarimaNueva ( string OT ) {
			InitializeComponent ( );
			this.OTString = OT;
			this.Text = $"Nueva Tarima [{OT}]";
			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );


		}

		private async void frmCrearTarimaNueva_Load ( object sender , EventArgs e ) {

			//if ( !DB.tempOt.Any ( o => o.OT == OTString ) )
			//	throw new Exception ( "Orden incorrecta" );

			await DB.tempOt.Where ( o => o.OT == OTString ).LoadAsync ( );

			temporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToBindingList ( );

			OT = ( TemporalOrdenTrabajo ) temporalOrdenTrabajoBindingSource.Current;

			OT.TarimasNCuatro.Add ( new NaveCuatro_Tarima ( ) );
			tarimasNCuatroBindingSource.MoveLast ( );
			CurrentTarima = ( NaveCuatro_Tarima ) tarimasNCuatroBindingSource.Current;

			if(OT.TarimasNCuatro .Count > 0 ) {
				var t = OT.TarimasNCuatro.OrderBy (o=>o.Id ).Select ( o => new { Ancho = o.Ancho , Calibre = o.Calibre } ).FirstOrDefault ( );
				CurrentTarima.Ancho = t.Ancho;
				CurrentTarima.Calibre = t.Calibre;
			}




			this.kryptonTextBox1.Focus ( );
			this.kryptonTextBox1.SelectAll ( );


		}

		private bool isDialogError = false;

		private class DuplicateElementException : Exception {
			public DuplicateElementException ( string message ) : base ( message ) { }
		}
		private void kryptonTextBox1_KeyUp ( object sender , KeyEventArgs e ) {
			if ( e.KeyCode == Keys.Enter && !isDialogError ) {
				bool forceInsert = false;
				int Id;
				if ( System.Text.RegularExpressions.Regex.IsMatch ( kryptonTextBox1.Text , @"(\*)[0-9]+(\*)" ) && int.TryParse ( kryptonTextBox1.Text.Replace ( "*" , "" ) , out Id ) ) {
					try {

						if ( !DB.TempProduccion.Any ( o => o.Id == Id ) )
							throw new Exception ( "No se encontró el Item en la Base de Datos" );

						if ( CurrentTarima.Items.Any ( o => o.Item.Id == Id ) )
							return;

						var y = ( from tar in DB.NCuatro_Tarimas
								  where tar.OT == OTString
								  from itm in tar.Items
								  where itm.Item_Id == Id
								  select new { itm.Item_Id } ).Any ( );
						if ( y )
							throw new DuplicateElementException ( "El elemento ya se ha agregado anteriormente en otra tarima a la Orden de trabajo\n Desea Agregarlo nuevamente a otra tarima?" );


						CurrentTarima.Items.Add ( new NaveCuatro_TarimaItem ( ) {
							Item = DB.TempProduccion.FirstOrDefault ( o => o.Id == Id )
						} );


					} catch ( DuplicateElementException ex ) {

						using ( var dlg = new KryptonTaskDialog ( ) {
							DefaultButton = TaskDialogButtons.No ,
							CommonButtons = TaskDialogButtons.Yes | TaskDialogButtons.No ,
							Content = ex.Message ,
							WindowTitle = "Confirme la acción..." ,
							MainInstruction = "Elemento Duplicado en la OT" ,
							Icon = MessageBoxIcon.Question
						} ) {
							isDialogError = true;
							forceInsert = dlg.ShowDialog ( ) == DialogResult.Yes ? true : false;
						}

					} catch ( Exception ex ) {

						using ( var dlg = new KryptonTaskDialog ( ) {
							DefaultButton = TaskDialogButtons.OK ,
							CommonButtons = TaskDialogButtons.OK ,
							Content = ex.Message ,
							WindowTitle = "Algo va mal..." ,
							MainInstruction = "Error" ,
							Icon = MessageBoxIcon.Error
						} ) {
							isDialogError = true;
							dlg.ShowDialog ( );
						}

					} finally {

						if ( forceInsert ) {
							CurrentTarima.Items.Add ( new NaveCuatro_TarimaItem ( ) {
								Item = DB.TempProduccion.FirstOrDefault ( o => o.Id == Id )
							} );
						}

						tarimasNCuatroBindingSource.ResetCurrentItem ( );
						itemsBindingSource.MoveLast ( );
						this.kryptonTextBox1.Focus ( );
						this.kryptonTextBox1.SelectAll ( );
					}
				} else {
					this.kryptonTextBox1.Focus ( );
					this.kryptonTextBox1.SelectAll ( );
				}
			} else {
				isDialogError = false;
			}
		}

		private void borrarToolStripMenuItem_Click ( object sender , EventArgs e ) {

			if ( this.itemsBindingSource.Current != null )
				CurrentTarima.Items.Remove ( ( NaveCuatro_TarimaItem ) this.itemsBindingSource.Current );

			tarimasNCuatroBindingSource.ResetCurrentItem ( );
		}

		private void kryptonTextBox1_Enter ( object sender , EventArgs e ) {
			BeginInvoke ( ( Action ) delegate {
				kryptonTextBox1.SelectAll ( );
			} );
		}

		private void frmCrearTarimaNueva_Enter ( object sender , EventArgs e ) {
			this.kryptonTextBox1.Focus ( );
			this.kryptonTextBox1.SelectAll ( );
		}

		private void kryptonListBox1_KeyUp ( object sender , KeyEventArgs e ) {
			if ( e.KeyCode == Keys.Escape ) {
				this.kryptonTextBox1.Focus ( );
				this.kryptonTextBox1.SelectAll ( );
			}
		}

		private void frmCrearTarimaNueva_FormClosing ( object sender , FormClosingEventArgs e ) {
			if ( DialogResult == DialogResult.OK ) {
				try {
					temporalOrdenTrabajoBindingSource.EndEdit ( );

					if ( CurrentTarima.Items.Count <= 0 )
						throw new Exception ( "La tarima no contiene Elementos, no se procesara la acción" );

					DB.SaveChanges ( );
				} catch ( Exception ex ) {
					isDialogError = true;
					KryptonTaskDialog.Show ("Algo va mal...", "Error", ex.Message, MessageBoxIcon.Exclamation, TaskDialogButtons.OK, TaskDialogButtons.OK );					
					e.Cancel = true;
					this.kryptonTextBox1.Focus ( );
					this.kryptonTextBox1.SelectAll ( );
				}
			}
		}
	}
}
