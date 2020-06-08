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

		private void updateProgressbar ( int val )
		{
			progressBar1.Invoke ( new Action ( () =>
			{
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
				await Task.Run( ( () =>
				{
					// Traigo los grupos de tintas que se encuentran en el XML del proyecto
					// TODO: Buscar que estos valores se obtengan desde una base de datos en vez de un archivo XML
					List<GruposTinta.tintaItem> gpoTintas = GruposTinta.getTintas ( );

					// Actualizo la barra de progreso
					updateProgressbar ( 20 );

					// ---------------------------------------------------------------------------------------
					// Lleno el tableAdapter con los datos de la orden en el dataSet 
					this.MovOtTableAdapter.Fill ( this.CapacitaExcelNDataSet.CierreOrdenes, this.OT );
					// ---------------------------------------------------------------------------------------
					
					
					// Actualizo nuevamente la barra de progreso
					updateProgressbar ( 50 );

					// Calculo el avance por unidad de la barra de progreso 
					var VAL = Math.Ceiling ( ( (double)this.CapacitaExcelNDataSet.CierreOrdenes.Rows.Count * 10 ) / 50 );
					var counter = 0;
					foreach ( ExcelNoblezaDataSet.CierreOrdenesRow rw in this.CapacitaExcelNDataSet.CierreOrdenes.Rows )
					{
						// incremento el valor del contador de elementos
						counter++;
						// Actualizo la barra de estado
						updateProgressbar ( this.progressBar1.Value + ( counter % VAL == 0 ? 10 : 0 ) );

						// Busco la tinta en la lista y si la encuentro, agrego el valor al campo componente
						// este valor sera usado para el calculo de tinta solida.
						if ( gpoTintas.Any ( u => u.clave == rw.Articulo.TrimEnd ( ) ) )
						{
							rw.Componentes = decimal.Parse ( gpoTintas.First ( o => o.clave == rw.Articulo.TrimEnd ( ) ).factor.ToString ( ) );
						}
					}

					// Si todo sale de manera correcta, retorno el valor 1
					return 1;
				} ) );
				

				this.Invoke ( new Action<string> ( onChangeOT ), OT );


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
