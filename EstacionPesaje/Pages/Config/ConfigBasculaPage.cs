using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Workspace;
using ComponentFactory.Krypton.Navigator;

namespace EstacionPesaje.Pages.Config {
	public partial class ConfigBasculaPage :Base.DefaultPageContent {
		public ConfigBasculaPage ( libBascula .ControlBascula Bascula) {
			InitializeComponent ( );

			KP.ClearFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.All  );
			KP.SetFlags ( ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowDocked |
				ComponentFactory.Krypton.Navigator.KryptonPageFlags.DockingAllowClose);

			this.FilterPropertyGrid .SelectedObject = Bascula;

			Bascula.CambioValor += Bascula_CambioValor;

			this.FilterPropertyGrid.BrowsableAttributes =
				new AttributeCollection (
					new Attribute [] {
						new CategoryAttribute( "Bascula" ),
						new CategoryAttribute( "Conexion Bascula" )
					}
					);
		}

		private void Bascula_CambioValor ( object sender, libBascula.CambioValorEventArgs e ) {
			setValue ( e.FullString );
		}

		private void setValue(string value ) {
			if(kryptonTextBox1 .InvokeRequired) {
				kryptonTextBox1.Invoke ( new Action<string> ( setValue ), value );
				return;
			}
			kryptonTextBox1.Text = value;
		}

		public override void Show ( KryptonDockingManager kryptonDockingManager, KryptonWorkspaceCell kryptonWorkspaceCell ) {

			
			OnStatusStringChanged ( "Abriendo " + KP.TextTitle );

			var t = kryptonDockingManager.FindPageElement ( this.GetKryptonPage ( ) );

			if (( kryptonWorkspaceCell == null || kryptonWorkspaceCell.IsDisposed ) && t == null) {

				try {
					kryptonDockingManager.AddDockspace ( "Catalogos", DockingEdge.Right, new KryptonPage [] { this.GetKryptonPage ( ) } );
				}
				catch (Exception) {

				}
			}						

			kryptonDockingManager.ShowPage ( this.GetKryptonPage ( ) );
		}
	}
}
