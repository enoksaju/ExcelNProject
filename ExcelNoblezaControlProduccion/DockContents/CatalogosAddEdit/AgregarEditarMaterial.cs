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
    public partial class AgregarEditarMaterial : BaseForm.BaseFormCatalogosAddEdit
    {
        public AgregarEditarMaterial( ICatalogForm Catalogo, Material Entidad = null )
        {
            InitializeComponent();

            this.Catalogo = Catalogo;

            var DbLocal= new DataBaseContexto();

            if (Entidad != null) DbLocal.Materiales.Include( u => u.FamiliaMateriales ).Where( t => t.Id == Entidad.Id ).Load();
            var Entity = DbLocal.Materiales.Local.FirstOrDefault(p=> p.Id== Entidad.Id);

            DbLocal.FamiliasMateriales.Load();
            familiaMaterialesBindingSource.DataSource = DbLocal.FamiliasMateriales.Local.ToBindingList();

            base.Initialize( DbLocal, DbLocal.Materiales.Local.ToBindingList(), DbLocal.Materiales, Entity );
        }
        public override void AgregarNuevo()
        {
            CrearForm( t=> new CatalogosAddEdit.AgregarEditarMaterial( t ) );
        }

    }
}
