using libProduccionDataBase.Tablas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryEntity
{
    public partial class frmEditAddClientes : Form
    {
        public Cliente Cliente;
        public frmEditAddClientes(Cliente Cliente= null)
        {
            InitializeComponent();
            this.Cliente = Cliente;
        }

        private void frmEditAddClientes_Load(object sender, EventArgs e)
        {
            if(Cliente!= null)
            {
                clienteBindingSource.DataSource = new List<Cliente>() { Cliente};
                this.Text = "Editar Cliente";
            }
            else
            {
                clienteBindingSource.DataSource = new List<Cliente>();
                clienteBindingSource.AddNew();
                this.Cliente = (Cliente)clienteBindingSource.Current;
                this.Text = "Agregar Cliente";
            }
        }

        private void frmEditAddClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult== DialogResult.OK)
            {
                if (MessageBox.Show(this, "Realmente desea procesar la acción?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) e.Cancel = true;
            }
        }
    }
}
