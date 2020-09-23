using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;

namespace CapturaVariablesCriticas
{
	public partial class MainForm : KryptonForm
	{
		private int _count = 1;


		public MainForm ()
		{
			InitializeComponent ( );
		}
		private void MainForm_Load ( object sender, EventArgs e )
		{
			KryptonDockingWorkspace w = K_DockingManager.ManageWorkspace ( "Workspace", kryptonDockableWorkspace1 );
			K_DockingManager.ManageControl ( "Control", kryptonPanel1, w );
			K_DockingManager.ManageFloating ( "Floating", this );



			//K_DockingManager.AddToWorkspace ( "Workspace", new KryptonPage[] { NewPage ( ), NewPage ( ) } );

			//K_DockingManager.AddDockspace ( "Control", DockingEdge.Bottom, new KryptonPage[] { NewPage ( ), NewPage ( ) } );
			//K_DockingManager.AddAutoHiddenGroup ( "Control", DockingEdge.Left, new KryptonPage[] { NewPage ( ), NewPage ( ), NewPage ( ) } );

			//K_DockingManager.AddFloatingWindow ( "Floating", new KryptonPage[] { NewPage ( ), NewPage ( ) } );

		}

		private void nuevoToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			K_DockingManager.AddToWorkspace ( "Workspace", new KryptonPage[] { NewPage ( ) } );

		}

		private KryptonPage NewPage ()
		{
			// Create and uniquely name the page
			KryptonPage page = new KryptonPage ( );
			page.ClearFlags ( KryptonPageFlags.All );
			page.SetFlags ( KryptonPageFlags.DockingAllowWorkspace | KryptonPageFlags.AllowPageDrag | KryptonPageFlags.AllowPageReorder );

			page.Text = "Page " + ( _count++ ).ToString ( );
			page.TextTitle = page.Text;
			page.UniqueName = page.Text;

			// Add rich text box as content of the page
			Pages.Captura_Page rtb = new Pages.Captura_Page ( );
			rtb.Dock = DockStyle.Fill;
			page.Controls.Add ( rtb );

			return page;


		}


	}
}
