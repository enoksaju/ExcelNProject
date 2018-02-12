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
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;

namespace ExcelNoblezaControlProduccion.DockContents.CatalogosAddEdit
{
    public partial class AgregarEditarCliente : BaseForm.BaseFormCatalogosAddEdit, IActionsDockContent
    {
        //private  Catalogos.CatalogoClientes Catalogo;
        public AgregarEditarCliente(ICatalogForm Catalogo, Cliente Cliente = null )
        {
            InitializeComponent();
            this.Catalogo = Catalogo;

            var DbLocal= new DataBaseContexto();

            if (Cliente != null) DbLocal.Clientes.Where( t => t.Id == Cliente.Id ).Load();
            var Entity = DbLocal.Clientes.Local.FirstOrDefault(p=> p.Id== Cliente.Id);
            
            base.Initialize( DbLocal, DbLocal.Clientes.Local.ToBindingList(), DbLocal.Clientes, Entity );
            
        }

        public override void AgregarNuevo()
        {
            CrearForm( t => new AgregarEditarCliente( t ) );
        }
    }
}
