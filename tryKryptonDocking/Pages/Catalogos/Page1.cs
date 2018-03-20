using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Docking;

namespace EstacionPesaje.Pages.Catalogos
{
    [ToolboxItem(true)]
    public partial class Page1 : Base.CatalogBase<libProduccionDataBase.Tablas.Material>
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Page1_Load(object sender, EventArgs e)
        {

        }
    }
}
