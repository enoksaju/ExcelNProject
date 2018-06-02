using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using ComponentFactory.Krypton.Toolkit;
using libProduccionDataBase.Tablas;

namespace ControlTintas.Pages.Pages {
	public partial class CatalogoArticulo : Base.BasePage {

		libProduccionDataBase.Contexto.DataBaseContexto DB;

		public CatalogoArticulo ( ) {
			InitializeComponent ( );
		}

		private async void CatalogoArticulo_Load ( object sender , EventArgs e ) {
			await CrearTreeList ( );
		}

		private void articuloTintaKryptonDataGridView_DataError ( object sender , DataGridViewDataErrorEventArgs e ) {
			e.ThrowException = false;
		}

		/// <summary>
		/// Tarea que crea y/o Actualiza el TreeView con el catalogo de Tintas y Proveedores.
		/// </summary>
		/// <returns></returns>
		async Task CrearTreeList ( ) {
			this.kryptonTreeView1.Nodes.Clear ( );
			DB?.Dispose ( );
			DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );

			DB.Database.Log = Console.Write;
			DB.Configuration.LazyLoadingEnabled = false;


			await DB.ProveedoresTinta
				.Include ( o => o.TiposTinta )
				.LoadAsync ( );

			articuloTintaBindingSource.DataSource = DB.ArticulosTintas.Local.ToList ( );

			this.proveedorTintaBindingSource.DataSource = DB.ProveedoresTinta.Local.ToList ( );

			foreach ( var prov in DB.ProveedoresTinta.Local ) {

				List<TreeNode> cNode = new List<TreeNode> ( );
				foreach ( var TTint in prov.TiposTinta ) {
					cNode.Add ( new TreeNode ( TTint.Nombre , 2 , 3 ) { Tag = $"TTint,{prov.Id},{ TTint.Id }" } );
				}
				kryptonTreeView1.Nodes.Add ( new TreeNode ( prov.Nombre , 1 , 0 , cNode.ToArray ( ) ) { Tag = $"Prov,{prov.Id },0" } );
			}
		}


		/// <summary>
		/// Accion al hacer click en el boton Nuevo del toolStrip
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bindingNavigatorAddNewItem_Click ( object sender , EventArgs e ) {
			toogleEditor ( false );
			claveKryptonTextBox.Focus ( );
			claveKryptonTextBox.Select ( );
		}

		/// <summary>
		/// Accion al hacer click en el boton Editar del toolStrip
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EditButton1_Click ( object sender , EventArgs e ) {
			toogleEditor ( false , true );
			descripcionKryptonTextBox.Focus ( );
			descripcionKryptonTextBox.Select ( );
		}

		/// <summary>
		/// Acción al hacer click en el boton cancelar del toolstrip
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripButton1_Click ( object sender , EventArgs e ) {
			articuloTintaBindingSource.CancelEdit ( );

			var entry = articuloTintaBindingSource.Current != null ? DB?.Entry ( ( ArticuloTinta ) articuloTintaBindingSource.Current ) : null;

			if ( entry != null && entry.State == EntityState.Modified ) {
				entry.Reload ( );
			}

			toogleEditor ( true );
		}

		/// <summary>
		/// Acción al hacer click en el boton Guardar del toolStrip
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void articuloTintaBindingNavigatorSaveItem_Click ( object sender , EventArgs e ) {
			try {
				proveedorTintaComboBox.Focus ( );
				proveedorTintaComboBox.Select ( );

				var entry = ( libProduccionDataBase.Tablas.ArticuloTinta ) articuloTintaBindingSource.Current;
				var t = libProduccionDataBase.Auxiliares.ValidateEntry ( DB , entry );

				if ( !t.IsValid )
					throw new Exception ( t.ValidationErrorsString );
				if ( ( t.State == EntityState.Added | t.State == EntityState.Detached ) && DB.ArticulosTintas.Any ( o => o.Clave.Trim ( ) == entry.Clave.Trim ( ) ) )
					throw new Exception ( $"La clave {entry.Clave} ya fue asignada a otro articulo en la colección" );
				articuloTintaBindingSource.EndEdit ( );

				if ( t.State == EntityState.Added | t.State == EntityState.Detached )
					DB.ArticulosTintas.Add ( entry );

				DB.SaveChanges ( );
				toogleEditor ( true );
			} catch ( Exception ex ) {
				KryptonTaskDialog.Show ( "Algo va mal..." , "Error al guardar" , libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) , MessageBoxIcon.Error , ComponentFactory.Krypton.Toolkit.TaskDialogButtons.OK );
			}
		}

		/// <summary>
		/// Acción la hacer click en el boton Actualizar del toolStrip
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void Refresh_Click ( object sender , EventArgs e ) {
			await this.CrearTreeList ( );
		}

		/// <summary>
		/// Cambia la configuracion de los controles para modo de Edicion o modo de Explorador
		/// </summary>
		/// <param name="Enabled"></param>
		/// <param name="IsEditing"></param>
		private void toogleEditor ( bool Enabled , bool IsEditing = false ) {
			articuloTintaKryptonDataGridView.Enabled = Enabled;
			this.kryptonTreeView1.Enabled = Enabled;

			CancelAddStripButton.Visible = !Enabled;
			articuloTintaBindingNavigatorSaveItem.Visible = !Enabled;

			bindingNavigatorAddNewItem.Visible = Enabled;
			bindingNavigatorEditItem.Visible = Enabled;
			refreshToolStripButton.Visible = Enabled;
			toFindToolStripTextBox.Visible = Enabled;
			findClaveToolStripButton.Visible = Enabled;


			bindingNavigatorPositionItem.Visible = Enabled;
			bindingNavigatorMovePreviousItem.Visible = Enabled;
			bindingNavigatorMoveFirstItem.Visible = Enabled;
			bindingNavigatorMoveLastItem.Visible = Enabled;
			bindingNavigatorMoveNextItem.Visible = Enabled;
			bindingNavigatorCountItem.Visible = Enabled;
			this.bindingNavigatorSeparator.Visible = Enabled;
			this.bindingNavigatorSeparator1.Visible = Enabled;
			this.bindingNavigatorSeparator2.Visible = Enabled;
			this.toolStripSeparator2.Visible = Enabled;

			foreach ( var ctl in kryptonGroupBox1.Panel.Controls ) {
				if ( ctl.GetType ( ) == typeof ( KryptonTextBox ) ) {
					//if ( ctl != existenciasKryptonTextBox )
						( ( KryptonTextBox ) ctl ).ReadOnly = Enabled;
				} else if ( ctl.GetType ( ) == typeof ( KryptonComboBox ) ) {
					( ( KryptonComboBox ) ctl ).Enabled = !Enabled;
				}
			}

			if ( IsEditing ) {
				claveKryptonTextBox.ReadOnly = true;
				proveedorTintaComboBox.Enabled = false;
			}

		}

		/// <summary>
		/// Actualiza los datos mostrados en el DataGrid al seleccionar un nodo del TreeView con el catalogo de Tintas y proveedores.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void kryptonTreeView1_AfterSelect ( object sender , TreeViewEventArgs e ) {
			var t = e.Node.Tag.ToString ( ).Split ( ',' );

			var idProv = int.Parse ( t [ 1 ] );
			var idTTint = int.Parse ( t [ 2 ] );

			if ( t [ 0 ] == "Prov" ) {
				articuloTintaBindingSource.DataSource = DB.ArticulosTintas
					//.Include ( o => o.Entradas )
					//.Include ( o => o.Salidas )
					.Where ( o => o.Proveedor_Id == idProv )
					.OrderBy ( o => o.TiposTinta_Id )
					.ThenBy ( o => o.Clave )
					.ToList ( );

			} else if ( t [ 0 ] == "TTint" ) {
				articuloTintaBindingSource.DataSource = DB.ArticulosTintas
					//.Include ( o => o.Entradas )
					//.Include ( o => o.Salidas )
					.Where ( o => o.TiposTinta_Id == idTTint )
					.OrderBy ( o => o.Clave )
					.ToList ( );
			}
			this.proveedorTintaBindingSource.Position = this.proveedorTintaBindingSource.IndexOf ( DB.ProveedoresTinta.Local.Where ( o => o.Id == int.Parse ( t [ 1 ] ) ) );
		}

		/// <summary>
		/// Muestra el menuContextual al hacer click derecho en algun nodo del TreeView, habilita o deshabilita las acciones posibles en cada nodo.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void kryptonTreeView1_NodeMouseClick ( object sender , TreeNodeMouseClickEventArgs e ) {
			if ( e.Button == MouseButtons.Right ) {
				kryptonTreeView1.SelectedNode = kryptonTreeView1.GetNodeAt ( e.X , e.Y );

				if ( kryptonTreeView1.SelectedNode != null ) {

					var t = e.Node.Tag.ToString ( ).Split ( ',' );

					if ( t [ 0 ] == "Prov" ) {
						agregarProveedorToolStripMenuItem.Enabled = true;
						agregarFamiliaDeTintaToolStripMenuItem.Enabled = true;
						agregarArticuloToolStripMenuItem.Enabled = false;
					} else if ( t [ 0 ] == "TTint" ) {
						agregarProveedorToolStripMenuItem.Enabled = false;
						agregarFamiliaDeTintaToolStripMenuItem.Enabled = false;
						agregarArticuloToolStripMenuItem.Enabled = true;
					}

					this.contextMenuStrip1.Show ( this.kryptonTreeView1 , e.Location );
				}
			}
		}

		/// <summary>
		/// Acción al hacer click en el boton AgregarFamilia del contectMenu del treeView.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void agregarFamiliaDeTintaToolStripMenuItem_Click ( object sender , EventArgs e ) {
			try {

				var t = kryptonTreeView1.SelectedNode.Tag.ToString ( ).Split ( ',' );

				string FamName = KryptonInputBox.Show ( this , "Escriba el nombre de la Familia" , "Agregar Familia" , "" );
				int ProvId = int.Parse ( t [ 1 ] );

				if ( FamName.Trim ( ) != "" ) {
					if ( DB.TiposTinta.Any ( o => o.Nombre.Trim ( ).ToLower ( ) == FamName.ToLower ( ).Trim ( ) & o.Proveedor_Id == ProvId ) )
						throw new Exception ( "El nombre de la Familia Indicado ya existe para este proveedor." );

					tiposTintaBindingSource.Add ( new TiposTinta ( ) { Nombre = FamName , Proveedor_Id = ProvId } );
					DB.SaveChanges ( );
					await this.CrearTreeList ( );
				} else {
					throw new Exception ( "No se indico ningun nombre" );
				}
			} catch ( Exception ex ) {
				KryptonTaskDialog.Show ( "Algo va mal..." , "Error al agregar la Familia" , libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) , MessageBoxIcon.Error , TaskDialogButtons.OK );
			}
		}

		/// <summary>
		/// Acción al hacer click en el boton agregarArticulo del ContextMenu del TreeView de catalogos de Tintas
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void agregarArticuloToolStripMenuItem_Click ( object sender , EventArgs e ) {
			articuloTintaBindingSource.AddNew ( );
			toogleEditor ( false );

			var Ttint = kryptonTreeView1.SelectedNode.Tag.ToString ( ).Split ( ',' );

			var entry = ( ArticuloTinta ) articuloTintaBindingSource.Current;
			entry.Proveedor_Id = int.Parse ( Ttint [ 1 ] );
			entry.TiposTinta_Id = int.Parse ( Ttint [ 2 ] );
			articuloTintaBindingSource.ResetCurrentItem ( );

			proveedorTintaComboBox.Enabled = false;
			tiposTinta_IdKryptonComboBox.Enabled = false;
		}

		private async void agregarProveedorToolStripMenuItem_Click ( object sender , EventArgs e ) {
			try {

				var t = kryptonTreeView1.SelectedNode.Tag.ToString ( ).Split ( ',' );

				string ProvName = KryptonInputBox.Show ( this , "Escriba el nombre del Proveedor" , "Agregar Proveedor" , "" );
				int ProvId = int.Parse ( t [ 1 ] );

				if ( ProvName.Trim ( ) != "" ) {

					if ( DB.ProveedoresTinta.Any ( o => o.Nombre.Trim ( ).ToLower ( ) == ProvName.ToLower ( ).Trim ( ) ) )
						throw new Exception ( "El nombre del Proveedor indicado ya existe." );

					proveedorTintaBindingSource.Add ( new ProveedorTinta ( ) { Nombre = ProvName } );
					DB.SaveChanges ( );

					await this.CrearTreeList ( );
				} else {
					throw new Exception ( "No se indico ningun nombre" );
				}
			} catch ( Exception ex ) {
				KryptonTaskDialog.Show ( "Algo va mal..." , "Error al agregar la Familia" , libProduccionDataBase.Auxiliares.ValidationAndErrorMessages ( DB , ex ) , MessageBoxIcon.Error , TaskDialogButtons.OK );
			}
		}

		private async void findClaveToolStripButton_Click ( object sender , EventArgs e ) {
			await this.search ( );
		}

		private async void toFindToolStripTextBox_KeyUp ( object sender , KeyEventArgs e ) {
			if ( e.KeyCode == Keys.Enter )
				await this.search ( );
		}

		async Task search ( ) {
			await this.CrearTreeList ( );
			articuloTintaBindingSource.DataSource = DB.ArticulosTintas
					.Where ( o => o.Clave.Contains ( toFindToolStripTextBox.Text ) | o.Descripcion.Contains ( toFindToolStripTextBox.Text ) )
					.OrderBy ( o => o.TiposTinta_Id )
					.ThenBy ( o => o.Clave )
					.ToList ( );
		}

		private void articuloTintaBindingSource_CurrentChanged ( object sender , EventArgs e ) {
			this.bindingNavigatorEditItem.Enabled = articuloTintaBindingSource.Current != null ? true : false;
		}
	}
}
