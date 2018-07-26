using ComponentFactory.Krypton.Toolkit;
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

namespace ControlResiduosPeligrosos.Catalogos
{
  public partial class frmTransportistas : KryptonForm
  {
    private libProduccionDataBase.Contexto.DataBaseContexto DB;


    public frmTransportistas()
    {
      InitializeComponent();
      DB = new libProduccionDataBase.Contexto.DataBaseContexto();
      DB.Database.Log = Console.Write;
    }

    private async void frmProveedores_Load(object sender, EventArgs e)
    {
      await DB.Transportistas.LoadAsync();
      trasportistaBindingSource.DataSource = DB.Transportistas.Local.ToBindingList();
    }

    private async void proveedorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
    {
      this.trasportistaBindingSource.EndEdit();
      await DB.SaveChangesAsync();
    }

    private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}
