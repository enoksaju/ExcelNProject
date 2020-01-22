using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace libIntelisisReports.Controles
{
	public partial class ctlCierreOrdenes : UserControl
	{

		public event EventHandler<string> changedOT;
		public string OT { get; set; }

		[DefaultValue ( typeof ( DockStyle ), "Fill" )]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		public ctlCierreOrdenes ()
		{
			base.Dock = DockStyle.Fill;
			InitializeComponent ( );
		}
		private void textBox1_KeyDown ( object sender, KeyEventArgs e )
		{
			if ( e.KeyCode != System.Windows.Forms.Keys.Return )
				return;
			this.button1_Click ( (object)this.button1, (EventArgs)null );
		}

		private void updateProgressbar (int val)
		{
			progressBar1.Invoke ( new Action ( () => {
				progressBar1.Value = val;
			} ) );
		}

		private async void button1_Click ( object sender, EventArgs e )
		{
			updateProgressbar ( 0 );
			this.OT = this.textBox1.Text.Trim ( );
			this.progressBar1.Visible = true;
			try
			{
				int t = await Task.Run<int> ( (Func<int>)( () =>
				{
					List<GruposTinta.tintaItem> gpoTintas = GruposTinta.getTintas ( );
					updateProgressbar ( 20);
					this.MovOtTableAdapter.Fill ( this.CapacitaExcelNDataSet.CierreOrdenes, this.OT );
					updateProgressbar ( 50);

					var VAL = Math.Ceiling ( ((double)this.CapacitaExcelNDataSet.CierreOrdenes.Rows.Count*10) / 50 );
					var counter = 0;
					foreach ( ExcelNoblezaDataSet.CierreOrdenesRow rw in this.CapacitaExcelNDataSet.CierreOrdenes.Rows )
					{

						counter++;

						updateProgressbar( this.progressBar1.Value + (counter % VAL == 0 ? 10 : 0));
						System.Threading.Thread.Sleep ( 50 );
						if ( gpoTintas.Any ( u => u.clave == rw.Articulo.TrimEnd ( ) ) )
						{
							rw.Componentes = decimal.Parse ( gpoTintas.First ( o => o.clave == rw.Articulo.TrimEnd ( ) ).factor.ToString ( ) );
						}
					}

					return 1;

				}
			) );
				this.Invoke ( (Delegate)new System.Action<string> ( this.onChangeOT ), (object)this.OT );
			}
			catch ( Exception ex )
			{
				int num = (int)MessageBox.Show ( (IWin32Window)this, ex.Message, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand );
			}
			finally
			{
				this.Invoke ( (Delegate)new System.Action ( this.disableProgressBar ) );
			}
		}
		private void disableProgressBar ()
		{
			this.progressBar1.Visible = false;
		}
		protected void onChangeOT ( string OT )
		{
			this.reportViewer1.RefreshReport ( );
			this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
			this.changedOT?.Invoke ( this, OT );
		}

	}
}
