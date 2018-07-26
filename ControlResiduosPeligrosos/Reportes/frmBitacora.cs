using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ControlResiduosPeligrosos.Reportes
{
  public partial class frmBitacora : KryptonForm
  {
    private libProduccionDataBase.Contexto.DataBaseContexto DB;
    public frmBitacora()
    {
      InitializeComponent();
      DB = new libProduccionDataBase.Contexto.DataBaseContexto();
    }

    private void frmBitacora_Load(object sender, EventArgs e)
    {

			this.reportViewer1.RefreshReport();
		}

		private void btnMostrar_Click(object sender, EventArgs e)
    {
      List<Reportes.Vistas.VstSalidaRP> dt;

      if (txtNoManifiesto.Text.Trim() != string.Empty)
      {
        dt = (from itm in DB.SalidasRP
              where itm.ManifiestoDetalle.Manifiesto.NoManifiesto == txtNoManifiesto.Text.Trim()
              select new Reportes.Vistas.VstSalidaRP()
              {
                Linea = itm.Linea.Nombre,
                ResponsableLinea = itm.Linea.Responsable,
                TipoRP = itm.TipoRP.Descripcion,
                RiesgoRP = itm.TipoRP.Riesgo.ToString(),
                UnidadRP = itm.TipoRP.Unidad.ToString(),
                FechaEnvasado = itm.FechaEnvasado,
                FechaIngreso = itm.FechaIngreso,
                Cantidad = itm.Cantidad,
                FolioRP = itm.FolioRP,
                FechaSalida = itm.ManifiestoDetalle.Manifiesto.Fecha,
                NombreTransportista = itm.ManifiestoDetalle.Manifiesto.NombreChofer,
                NumeroSEMARNAT = itm.ManifiestoDetalle.Manifiesto.Transportista.AutSEMARNAT,
                Manifiesto = itm.ManifiestoDetalle.Manifiesto.NoManifiesto,
                valRiesgoRP = (int)itm.TipoRP.Riesgo
              }).ToList();
      }
      else
      {
        dt = (from itm in DB.SalidasRP
              where itm.FechaIngreso<= this.dtFechaFinal.Value.Date & itm.FechaIngreso>= this.dtFechaInicial.Value.Date
              select new Reportes.Vistas.VstSalidaRP()
              {
                Linea = itm.Linea.Nombre,
                ResponsableLinea = itm.Linea.Responsable,
                TipoRP = itm.TipoRP.Descripcion,
                RiesgoRP = itm.TipoRP.Riesgo.ToString(),
                UnidadRP = itm.TipoRP.Unidad.ToString(),
                FechaEnvasado = itm.FechaEnvasado,
                FechaIngreso = itm.FechaIngreso,
                Cantidad = itm.Cantidad,
                FolioRP = itm.FolioRP,
                FechaSalida = itm.ManifiestoDetalle.Manifiesto.Fecha,
                NombreTransportista = itm.ManifiestoDetalle.Manifiesto.NombreChofer,
                NumeroSEMARNAT = itm.ManifiestoDetalle.Manifiesto.Transportista.AutSEMARNAT,
                Manifiesto = itm.ManifiestoDetalle.Manifiesto.NoManifiesto,
                valRiesgoRP = (int)itm.TipoRP.Riesgo
              }).ToList();
      }

      VstSalidaRPBindingSource.DataSource = dt;
      this.reportViewer1.RefreshReport();
    }
  }
}
