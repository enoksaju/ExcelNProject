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
using WeifenLuo.WinFormsUI.Docking;

namespace ControlProduccion.Catalogos
{
    public partial class MaterialesCatalogoForm : CatalogosBaseForm 
    {
        public MaterialesCatalogoForm(libProduccionDataBase.Contexto.DataBaseContexto DB):base(DB )
        {
            InitializeComponent();
            familiaMaterialesBindingSource.DataSource = DB.FamiliasMateriales.Local.ToBindingList();
            this.visualStudioToolStripExtender1.SetStyle( toolStrip3, VisualStudioToolStripExtender.VsVersion.Vs2015, this.VS2015Theme );
        }

        private void MaterialesCatalogoForm_Load( object sender, EventArgs e )
        {

        }
    }
}
