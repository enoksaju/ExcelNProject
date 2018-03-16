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

namespace EstacionesPesaje.DockContents.CatalogosAddEdit
{
    public partial class AgregarEditarMaquina : BaseForm.BaseFormCatalogosAddEdit
    {
        public AgregarEditarMaquina( ICatalogForm Catalogo, Maquina maquina = null )
        {
            InitializeComponent();
            this.Catalogo = Catalogo;

            var DbLocal= new DataBaseContexto();

            DbLocal.Lineas.Load();
            DbLocal.TiposMaquina.Load();

            lineaBindingSource.DataSource = DbLocal.Lineas.Local.ToBindingList();
            tipoMaquinaBindingSource.DataSource = DbLocal.TiposMaquina.Local.ToBindingList();
            
            if (maquina != null) DbLocal.Maquinas.Where( t => t.Id == maquina.Id ).Load();

            var Entity = DbLocal.Maquinas.Local.FirstOrDefault(p=> p.Id== maquina?.Id);

            base.Initialize( DbLocal, DbLocal.Maquinas.Local.ToBindingList(), DbLocal.Maquinas, Entity );
        }
        public override void AgregarNuevo()
        {
            CrearForm( t => new AgregarEditarMaquina( t ) );
        }
    }
}
