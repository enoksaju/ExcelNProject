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

    public frmMain()
    {
      InitializeComponent();
    } 

    private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmProv = new Catalogos.frmProveedores();
      frmProv.MdiParent = this;
      frmProv.Show();
    }

    private void transportistasToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmTransp = new Catalogos.frmTransportistas ();
      frmTransp.MdiParent = this;
      frmTransp.Show();
    }

    private void tiposDeResiduosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmTipoRP = new Catalogos.frmTiposResiduo();
      frmTipoRP.MdiParent = this;
      frmTipoRP.Show();
    }

    private void salidasDeResiduosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmSalidaRP = new Movimientos.frmSalidaRP();
      frmSalidaRP.MdiParent = this;
      frmSalidaRP.Show();
    }

    private void manifiestosToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmCapturaMan = new Movimientos.frmCapturaManifiesto();
      frmCapturaMan.MdiParent = this;
      frmCapturaMan.Show();      
    }

    private void bitacoraResiduosPeligrososToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmBitacora = new Reportes.frmBitacora();
      frmBitacora.MdiParent = this;
      frmBitacora.Show();
    }

    private void salirToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
