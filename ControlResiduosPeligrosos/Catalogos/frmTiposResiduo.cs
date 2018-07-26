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
  public partial class frmTiposResiduo : KryptonForm
  {
    private libProduccionDataBase.Contexto.DataBaseContexto DB;
    public frmTiposResiduo()
    {
      InitializeComponent();
      DB = new libProduccionDataBase.Contexto.DataBaseContexto();
      riesgoKryptonComboBox.DataSource = Enum.GetValues(typeof(libProduccionDataBase.Tablas.TipoRP.Riesgos));
      unidadKryptonComboBox.DataSource = Enum.GetValues(typeof(libProduccionDataBase.Tablas.TipoRP.Unidades));
    }

    private void frmTiposResiduo_Load(object sender, EventArgs e)
    {
      DB.TiposRP.LoadAsync();
      this.tipoRPBindingSource.DataSource = DB.TiposRP.Local.ToBindingList();
    }

    private void tipoRPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
    {
      this.tipoRPBindingSource.EndEdit();
      DB.SaveChanges();
    }
  }
}
