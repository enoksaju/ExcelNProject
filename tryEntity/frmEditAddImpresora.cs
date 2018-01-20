using libProduccionDataBase;
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
    public partial class frmEditAddImpresora : Form
    {
        public Maquina Maquina;
        public libProduccionDataBase.Contexto.DataBaseContexto DB;
        public bool readOnly;
        public frmEditAddImpresora(libProduccionDataBase.Contexto.DataBaseContexto DB,Maquina Maquina = null, bool readOnly = false)
        {
            InitializeComponent();
            this.Maquina = Maquina;
            this.DB = DB;
            this.readOnly = readOnly;
        }

        private void frmEditAddImpresora_Load(object sender, EventArgs e)
        {
            if (Maquina != null)
            {
                if (!readOnly)
                {
                    maquinaBindingSource.DataSource = new List<Maquina>() { Maquina };
                    this.Text = "Editar Impresora";
                }else
                {
                    nombreMaquinaTextBox.ReadOnly = true;
                    velocidadTextBox.ReadOnly = true;
                    decksTextBox.ReadOnly = true;
                    rodillosDataGridView.ReadOnly = true;
                    rodillosDataGridView.AllowUserToAddRows = false;
                    rodillosDataGridView.AllowUserToDeleteRows = false;
                    rodillosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    maquinaBindingSource.DataSource = new List<Maquina>() { Maquina };
                    this.Text = "Detalles Impresora";
                }                
            }
            else
            {
                maquinaBindingSource.DataSource = new List<Maquina>();
                maquinaBindingSource.AddNew();
                this.Maquina = (Maquina)maquinaBindingSource.Current;
                this.Maquina.TipoMaquina_Id = 1;
                this.Text = "Agregar Impresora";
            }
        }

        private void frmEditAddImpresora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK && !readOnly)
            {
                if (MessageBox.Show(this, "Realmente desea procesar la acción?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) e.Cancel = true;
            }
        }

        private void rodillosDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.Context.ToString());
            switch (e.Context)
            {
                case DataGridViewDataErrorContexts.Commit:
                    MessageBox.Show("Datos no validos");
                    break;
                default:
                    break;
            }
            e.Cancel = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
