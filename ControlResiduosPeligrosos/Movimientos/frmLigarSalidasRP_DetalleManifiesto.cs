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

namespace ControlResiduosPeligrosos.Movimientos
{
  public partial class frmLigarSalidasRP_DetalleManifiesto : KryptonForm
  {
    private libProduccionDataBase.Contexto.DataBaseContexto DB;
    public ManifiestoDetalle Response;

    public frmLigarSalidasRP_DetalleManifiesto()
    {
      InitializeComponent();
      this.Load += FrmLigarSalidasRP_DetalleManifiesto_Load;

      DB = new libProduccionDataBase.Contexto.DataBaseContexto();
#if DEBUG
      DB.Database.Log = Console.Write;
#endif
    }

    private async void FrmLigarSalidasRP_DetalleManifiesto_Load(object sender, EventArgs e)
    {
      await this.DB.TiposRP.LoadAsync();
      this.tipoRPBindingSource.DataSource = this.DB.TiposRP.Local.ToBindingList();
    }

    private void tipoRPBindingSource_CurrentItemChanged(object sender, EventArgs e)
    {
      if (this.tipoRPBindingSource.Current != null)
      {
        var lst = from itm in DB.SalidasRP
                  where itm.FolioDM == null & itm.ClaveRP == ((TipoRP)this.tipoRPBindingSource.Current).ClaveRP
                  select itm;
        this.salidaResiduosPeligrososBindingSource.DataSource = lst.ToList();
      }
    }

    private void frmLigarSalidasRP_DetalleManifiesto_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.DialogResult == DialogResult.OK)
      {
        ObservableListSource<SalidaRP> salidas = new ObservableListSource<SalidaRP>();

        foreach (DataGridViewRow itm in this.salidaResiduosPeligrososKryptonDataGridView.Rows)
        {
          if ((bool?)itm.Cells[0].Value == true)
          {
            salidas.Add((SalidaRP)itm.DataBoundItem);           
          }
        }

        if (salidas.Count <= 0)
        {
          MessageBox.Show("No se indicaron elementos");
          e.Cancel = true;          
        }
        else
        {
          this.Response = new ManifiestoDetalle();
          this.Response.ClaveRP = ((TipoRP)this.tipoRPBindingSource.Current).ClaveRP;
          this.Response.TipoRP = (TipoRP)this.tipoRPBindingSource.Current;
          Response.SalidaResiduosPeligrosos = salidas;
        }
      }
    }
  }
}
