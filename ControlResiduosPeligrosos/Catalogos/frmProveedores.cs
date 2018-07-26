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
  public partial class frmProveedores : KryptonForm
  {
    private libProduccionDataBase.Contexto.DataBaseContexto DB;


    public frmProveedores()
    {
      InitializeComponent();
      DB = new libProduccionDataBase.Contexto.DataBaseContexto();
      DB.Database.Log = Console.Write;
    }

    private async void frmProveedores_Load(object sender, EventArgs e)
    {
     await DB.Proveedores.LoadAsync();
      proveedorBindingSource.DataSource = DB.Proveedores.Local.ToBindingList();
    }

    private async void proveedorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
    {
      this.proveedorBindingSource.EndEdit();
     await DB.SaveChangesAsync();
    }
  }
}
