using libProduccionDataBase.Contexto;
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

namespace ControlProduccion
{
    public partial class MainForm : Form
    {
        DataBaseContexto DB;
        Catalogos.ClientesCatalogoForm ClientesCatalogForm;

        ConfiguracionForms.BasculaConfigForm BasculaConfigForm;


        public MainForm()
        {

            InitializeComponent();
            DB = new DataBaseContexto();
            this.visualStudioToolStripExtender1.SetStyle(statusStrip1, WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender.VsVersion.Vs2015, this.VS2015Theme);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB.Clientes.Load();
            controlBascula.Initialize();
        }

        private void ClientesCatalogRibbonButton_Click(object sender, EventArgs e)
        {
            if (ClientesCatalogForm == null)
            {
                ClientesCatalogForm = new Catalogos.ClientesCatalogoForm(DB);
                ClientesCatalogForm.StatusStringChanged += CatalogosStatusStringChanged;
            }

            ClientesCatalogForm.Show(dockPanel1, Catalogos.CatalogosBaseForm.FlagActiveFunctions.Todas);
        }

        private void CatalogosStatusStringChanged( object sender, Catalogos.ChangeStatusMessageEventArgs e )
        {
            Task.Run(()=> {
                StatusToolStripStatusLabel.Text = e.Message;
                System.Threading.Thread.Sleep(5000);
                StatusToolStripStatusLabel.Text = "Listo";
            });
            
        }

        private void ConectarBasculaRibbonButton_Click( object sender, EventArgs e )
        {
            controlBascula.toogleConection();
        }
        private void controlBascula_CambioValor( object sender, libBascula.CambioValorEventArgs e )
        {
           // BasculaToolStripStatusLabel.Text = String.Format("{0:N2} kg", e.NuevoValor);
        }

        private void ConfigurarBasculaRibbonButton_Click( object sender, EventArgs e )
        {
            if (BasculaConfigForm == null)
            {
               BasculaConfigForm = new ConfiguracionForms.BasculaConfigForm(this.controlBascula);
            }

            BasculaConfigForm.Show(dockPanel1);
        }

        private void button1_Click( object sender, EventArgs e )
        {
            controlBascula.CaracterFinLinea = "0A";
        }

        private void controlBascula_CambioEstado( object sender, libBascula.EstadoConexion e )
        {
            switch (e) {
                case libBascula.EstadoConexion.Conectado:
                    ConectarBasculaRibbonButton.Text = "Desconectar";
                    break;
                case libBascula.EstadoConexion.Desconectado:
                    ConectarBasculaRibbonButton.Text = "Conectar";
                    break;
                default:
                    break;
            }
        }
    }
}
