using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libProduccionDataBase.Tablas;
namespace tryEntity
{
    public partial class frmEditAddMaterial : Form
    {
        public frmEditAddMaterial(FamiliaMateriales FamiliaMat, Material Material = null)
        {
            InitializeComponent();
            materialesBindingSource.DataSource = FamiliaMat.Materiales;
            if (Material != null)
            {
                materialesBindingSource.Position = materialesBindingSource.IndexOf(Material);
            }
            else
            {
                materialesBindingSource.AddNew();
            }
        }

        private void frmEditAddMaterial_Load(object sender, EventArgs e)
        {

        }
    }
}
