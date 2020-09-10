using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionPesaje.Pages.MainPages
{
	public partial class ViewOTPage : Base.DocumentPageBase
	{
		public ViewOTPage ()
		{
			InitializeComponent ( );
			KP.ImageSmall = Properties.Resources.report_open1;
		}

		private async void btnTodas_Click ( object sender, EventArgs e )
		{
			try
			{
				this.ordenTrabajo_ReportViewer1.OT = txtOT.TextBox.Text.Trim ( );
				this.ordenTrabajo_ReportViewer1.Proceso = libProduccionDataBase.Reportes.Models.OrdenTrabajoModel.Procesos.Todas;
				await this.ordenTrabajo_ReportViewer1.initializeReport ( );

				PageTitleText = $"OT[{txtOT.Text}]";
			}
			catch ( Exception ex )
			{
				MessageBox.Show ( ex.Message, "Algo va mal...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
			}

		}

		private async void OpenOrder_Click_1 ( object sender, EventArgs e )
		{
			var ct = (ToolStripButton)sender;
			await LoadEmptyOT ( ct.Tag.ToString ( ) );
		}

		private async void txtOT_KeyDown ( object sender, KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.Enter )
			{
				btnTodas_Click ( sender, e );
			}
			if ( e.Control && e.KeyCode == Keys.I )
			{
				await LoadEmptyOT ( "Impresion" );
			}
			if (e.Control && e.KeyCode == Keys.L )
			{
				await LoadEmptyOT ( "Laminacion" );
			}
			if (e.Control && e.KeyCode == Keys.R )
			{
				await LoadEmptyOT ( "Refinado" );
			}
			if (e.Control && e.KeyCode == Keys.E )
			{
				await LoadEmptyOT ( "Embobinado" );
			}
			if (e.Control && e.KeyCode == Keys.S )
			{
				await LoadEmptyOT ( "Sellado" );
			}
			if (e.Control && e.KeyCode == Keys.C )
			{
				await LoadEmptyOT ( "Corte" );
			}
			if (e.Control && e.KeyCode == Keys.D )
			{
				await LoadEmptyOT ( "Doblado" );
			}
			if (e.Control && e.KeyCode == Keys.E )
			{
				await LoadEmptyOT ( "Extrusion" );
			}
			if (e.Control && e.KeyCode == Keys.M )
			{
				await LoadEmptyOT ( "Mangas" );
			}
		}


		private async Task LoadEmptyOT ( string Proceso )
		{
			try
			{
				libProduccionDataBase.Reportes.Models.OrdenTrabajoModel.Procesos en;

				if ( Enum.TryParse ( Proceso, out en ) )
				{
					this.ordenTrabajo_ReportViewer1.OT = txtOT.TextBox.Text.Trim ( );
					this.ordenTrabajo_ReportViewer1.Proceso = en;
					await this.ordenTrabajo_ReportViewer1.initializeReport ( );

					PageTitleText = $"OT[{txtOT.Text}|{Proceso}]";
				}
			}
			catch ( Exception ex )
			{
				MessageBox.Show ( ex.Message, "Algo va mal...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
			}
		}

		private void ViewOTPage_Load ( object sender, EventArgs e )
		{
			txtOT.Focus ( );
		}

	}
}
