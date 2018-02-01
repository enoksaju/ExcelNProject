using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ControlProduccion.ConfiguracionForms
{
    public partial class BasculaConfigForm : DockContent
    {
        private readonly string[] propsToHidde= {"StatusLabel"};
        public BasculaConfigForm( libBascula.ControlBascula Bascula )
        {
            InitializeComponent();            

            this.filteredPropertyGrid1.SelectedObject = Bascula;

            this.filteredPropertyGrid1.BrowsableAttributes =
                new AttributeCollection(
                    new Attribute[] {
                        new CategoryAttribute( "Bascula" ),
                        new CategoryAttribute( "Conexion Bascula" )
                    }
                    );            

        }

        private void BasculaConfigForm_Load( object sender, EventArgs e )
        {

        }
    }
}
