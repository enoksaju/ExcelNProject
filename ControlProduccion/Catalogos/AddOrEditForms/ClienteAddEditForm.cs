using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using libProduccionDataBase.Tablas;
using libProduccionDataBase.Contexto;

namespace ControlProduccion.Catalogos.AddOrEditForms
{
    public partial class ClienteAddEditForm : BaseAddOrEditForms, IActionsDockContent
    {
        public ClienteAddEditForm(DataBaseContexto DB, Cliente Cliente= null):base(DB, DB.Clientes.Local.ToBindingList(), DB.Clientes,Cliente)
        {           
            InitializeComponent();
        }

        private void ClearNombreKryptonButton_Click( object sender, EventArgs e )
        {
            ClienteKryptonTextBox.Text = "";
        }
    }
}
