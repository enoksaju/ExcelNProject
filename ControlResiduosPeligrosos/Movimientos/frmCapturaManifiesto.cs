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
  public partial class frmCapturaManifiesto : KryptonForm
  {
    private libProduccionDataBase.Contexto.DataBaseContexto DB;

    public frmCapturaManifiesto()
    {
      InitializeComponent();
      this.Load += FrmCapturaManifiesto_Load;
      this.DB = new libProduccionDataBase.Contexto.DataBaseContexto();

#if DEBUG
      this.DB.Database.Log = Console.Write;
#endif
    }

    private async void FrmCapturaManifiesto_Load(object sender, EventArgs e)
    {
      await DB.Proveedores.LoadAsync();
      await DB.Transportistas.LoadAsync();

      this.proveedorBindingSource.DataSource = this.DB.Proveedores.Local.ToBindingList();
      this.transportistaBindingSource.DataSource = this.DB.Transportistas.Local.ToBindingList();

      this.manifiestoBindingSource.DataSource = DB.Manifiestos.Local.ToBindingList();
      this.manifiestoBindingSource.AddNew();
      ((Manifiesto)this.manifiestoBindingSource.Current).ManifiestoDetalle = new ObservableListSource<ManifiestoDetalle>();
      ((Manifiesto)this.manifiestoBindingSource.Current).Fecha = DateTime.Now;

      this.manifiestoBindingSource.ResetCurrentItem();

    }

    private void btnAddDetalle_Click(object sender, EventArgs e)
    {
      using (var frm = new frmLigarSalidasRP_DetalleManifiesto())
      {
        if (frm.ShowDialog() == DialogResult.OK)
        {

          ManifiestoDetalle det = new ManifiestoDetalle()
          {
            SalidaResiduosPeligrosos = new ObservableListSource<SalidaRP>()
          };

          var res = DB.TiposRP.FirstOrDefault(o => o.ClaveRP == frm.Response.ClaveRP);
          det.ClaveRP = res.ClaveRP;
          det.TipoRP = res;

          foreach (var itm in frm.Response.SalidaResiduosPeligrosos)
          {
            var rp = (from resp in DB.SalidasRP
                      where resp.FolioRP == itm.FolioRP
                      select resp).FirstOrDefault();
            det.SalidaResiduosPeligrosos.Add(rp);
          }

          ((Manifiesto)this.manifiestoBindingSource.Current).ManifiestoDetalle.Add(det);
          this.manifiestoBindingSource.ResetCurrentItem();
        };
      }
    }

    private void kryptonButton1_Click(object sender, EventArgs e)
    {
      try
      {
        this.manifiestoBindingSource.EndEdit();
        if (((Manifiesto)this.manifiestoBindingSource.Current).ManifiestoDetalle.Count <= 0) throw new Exception("El manifiesto debe tener elementos en el Detalle");

        this.DB.SaveChanges();
      }
      catch (Exception ex)
      {
        MessageBox.Show(libProduccionDataBase.Auxiliares.ValidationAndErrorMessages(this.DB, ex));
      }
    }
  }
}
