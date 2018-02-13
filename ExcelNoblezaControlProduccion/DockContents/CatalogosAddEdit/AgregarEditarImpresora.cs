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
    public partial class AgregarEditarImpresora : BaseForm.BaseFormCatalogosAddEdit
    {
        public AgregarEditarImpresora( ICatalogForm Catalogo, Maquina maquina= null )
        {
            InitializeComponent();

            this.Catalogo = Catalogo;

            var DbLocal= new DataBaseContexto();

            DbLocal.Lineas.Load();
            lineaBindingSource.DataSource = DbLocal.Lineas.Local.ToBindingList();


            if (maquina != null)
                DbLocal.Maquinas.Where( t => t.Id == maquina.Id ).Load();
            var Entity = DbLocal.Maquinas.Local.FirstOrDefault(p=> p.Id== maquina?.Id);


            base.Initialize( DbLocal, DbLocal.Maquinas.Local.ToBindingList(), DbLocal.Maquinas, Entity );

        }

        public override void AgregarNuevo()
        {
            CrearForm( t => new AgregarEditarImpresora( t ) );
        }

        public override void Guardar()
        {
            ((Maquina)base.BindingSource.Current).TipoMaquina_Id = 1;
            base.Guardar();
        }

        private void AgregarEditarImpresora_Load( object sender, EventArgs e )
        {

           

        }
    }
}
