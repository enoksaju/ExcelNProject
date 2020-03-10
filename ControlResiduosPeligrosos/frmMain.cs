using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;
using libProduccionDataBase.Tablas;
using ControlResiduosPeligrosos.Reportes.Vistas;

namespace ControlResiduosPeligrosos
{
	public partial class frmMain : KryptonForm
	{
		private Catalogos.frmProveedores frmProv;
		private Catalogos.frmTransportistas frmTransp;
		private Catalogos.frmTiposResiduo frmTipoRP;
		private Movimientos.frmSalidaRP frmSalidaRP;
		private Movimientos.frmCapturaManifiesto frmCapturaMan;
		private Reportes.frmBitacora frmBitacora;

		public frmMain ()
		{
			InitializeComponent ( );
			updateSelectedTheme ( );
		}

		private void proveedoresToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			frmProv = new Catalogos.frmProveedores ( );
			frmProv.MdiParent = this;
			frmProv.Show ( );
		}

		private void transportistasToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			frmTransp = new Catalogos.frmTransportistas ( );
			frmTransp.MdiParent = this;
			frmTransp.Show ( );
		}

		private void tiposDeResiduosToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			frmTipoRP = new Catalogos.frmTiposResiduo ( );
			frmTipoRP.MdiParent = this;
			frmTipoRP.Show ( );
		}

		private void salidasDeResiduosToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			frmSalidaRP = new Movimientos.frmSalidaRP ( );
			frmSalidaRP.MdiParent = this;
			frmSalidaRP.Show ( );
		}

		private void manifiestosToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			frmCapturaMan = new Movimientos.frmCapturaManifiesto ( );
			frmCapturaMan.MdiParent = this;
			frmCapturaMan.Show ( );
		}

		private void bitacoraResiduosPeligrososToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			frmBitacora = new Reportes.frmBitacora ( );
			frmBitacora.MdiParent = this;
			frmBitacora.Show ( );
		}

		private void salirToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			this.Close ( );
		}

		private void themeSelector_Click ( object sender, EventArgs e )
		{
			if ( sender == azulToolStripMenuItem )
			{
				this.kryptonManager1.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
			}
			else if ( sender == plataToolStripMenuItem )
			{
				this.kryptonManager1.GlobalPaletteMode = PaletteModeManager.Office2010Silver;
			}
			else if ( sender == negroToolStripMenuItem )
			{
				this.kryptonManager1.GlobalPaletteMode = PaletteModeManager.Office2010Black;
			}
			else if ( sender == purpuraToolStripMenuItem )
			{
				this.kryptonManager1.GlobalPaletteMode = PaletteModeManager.SparklePurple;
			}
			else if ( sender == naranjaToolStripMenuItem )
			{
				this.kryptonManager1.GlobalPaletteMode = PaletteModeManager.SparkleOrange;
			}
			else
			{
				this.kryptonManager1.GlobalPaletteMode = PaletteModeManager.Office2010Silver;
			}

			Properties.Settings.Default.Tema = this.kryptonManager1.GlobalPaletteMode;
			Properties.Settings.Default.Save ( );
			updateSelectedTheme ( );
		}

		private void updateSelectedTheme ()
		{
			azulToolStripMenuItem.Checked = false;
			plataToolStripMenuItem.Checked = false;
			negroToolStripMenuItem.Checked = false;
			purpuraToolStripMenuItem.Checked = false;
			naranjaToolStripMenuItem.Checked = false;

			switch ( this.kryptonManager1.GlobalPaletteMode )
			{
				case PaletteModeManager.Office2010Blue:
					azulToolStripMenuItem.Checked = true;
					break;
				case PaletteModeManager.Office2010Silver:
					plataToolStripMenuItem.Checked = true;
					break;
				case PaletteModeManager.Office2010Black:
					negroToolStripMenuItem.Checked = true;
					break;
				case PaletteModeManager.SparkleOrange:
					naranjaToolStripMenuItem.Checked = true;
					break;
				case PaletteModeManager.SparklePurple:
					purpuraToolStripMenuItem.Checked = true;
					break;
				default:
					break;
			}
		}

		private void reimprimirReporteToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			try
			{

				int Folio = int.Parse ( KryptonInputBox.Show(this, "Ingrese el Folio", "Reimprimir Formato", "#") );
				SalidaRP curr;

				using ( var db = new libProduccionDataBase.Contexto.DataBaseContexto ( ) )
				{
					db.Configuration.LazyLoadingEnabled = true;
					curr = db.SalidasRP.FirstOrDefault ( c => c.FolioRP == Folio );
					if ( curr == null ) throw new Exception ( "El folio no se encontró registrado" );


					using ( var repView = new ReportViewer ( ) )
					{
						using ( var vstSalidaRPBindingSource = new System.Windows.Forms.BindingSource ( ) )
						{
							ReportDataSource reportDataSource1 = new ReportDataSource ( );
							reportDataSource1.Name = "dsVstSalidaRP";
							reportDataSource1.Value = vstSalidaRPBindingSource;
							repView.LocalReport.DataSources.Add ( reportDataSource1 );
							repView.LocalReport.ReportEmbeddedResource = "ControlResiduosPeligrosos.Reportes.repSalidaRP.rdlc";

							var y = new List<VstSalidaRP> ( );
							y.Add ( new VstSalidaRP
							{
								Linea = curr.Linea.Nombre,
								ResponsableLinea = curr.Linea.Responsable,
								TipoRP = curr.TipoRP.Descripcion,

								RiesgoRP = curr.TipoRP.Riesgo.ToString ( ),
								UnidadRP = curr.TipoRP.Unidad.ToString ( ),
								FechaEnvasado = curr.FechaEnvasado,
								FechaIngreso = curr.FechaIngreso,
								Cantidad = curr.Cantidad,
								FolioRP = curr.FolioRP,
								valRiesgoRP = (int)curr.TipoRP.Riesgo
							} );

							vstSalidaRPBindingSource.DataSource = y;
							Stream pdf = new MemoryStream ( repView.LocalReport.Render ( "pdf" ) );

							Movimientos.frmSalidaRP.WriteFile ( $"{curr.Linea.Nombre.Replace ( " ", "" )}_{curr.TipoRP.Descripcion}_{curr.FolioRP}.pdf", pdf );



							using ( var frm = new KryptonForm ( ) { ClientSize = new Size ( 400, 400 ), Text = "Vista previa de Formato", ShowIcon = false, MinimizeBox = false, MaximizeBox = false } )
							{
								repView.Dock = DockStyle.Fill;
								frm.Controls.Add ( repView );
								repView.RefreshReport ( );
								frm.ShowDialog ( );
							}
						}
					}

				}
			}
			catch ( Exception ex )
			{
				KryptonTaskDialog.Show ( "Algo va mal...", "Error", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
			}
		}
	}
}
