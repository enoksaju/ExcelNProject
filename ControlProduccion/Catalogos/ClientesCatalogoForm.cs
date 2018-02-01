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

namespace ControlProduccion.Catalogos
{    
    public partial class ClientesCatalogoForm : CatalogosBaseForm
    {
        /// <summary>
        /// Inicializa una nueva instancia de la ventana de catalogos de clientes
        /// </summary>
        /// <param name="DB_">Contexto de la Base de datos</param>
        public ClientesCatalogoForm(DataBaseContexto DB_):base(DB_)
        {
            InitializeComponent();
            clienteBindingSource.DataSource = this.DB.Clientes.Local.ToBindingList();
        }

        private void ClientesCatalogoForm_Load(object sender, EventArgs e)
        {
            
        }

        public override void Agregar( object sender, EventArgs e )
        {
            MessageBox.Show("Agregar");
        }
    }
}
