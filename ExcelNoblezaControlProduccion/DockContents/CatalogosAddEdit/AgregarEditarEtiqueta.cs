using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;
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

namespace ExcelNoblezaControlProduccion.DockContents.CatalogosAddEdit
{
    public partial class AgregarEditarEtiqueta : BaseForm.BaseFormCatalogosAddEdit
    {
        public AgregarEditarEtiqueta(ICatalogForm Catalogo, Etiqueta etiqueta = null)
        {
            InitializeComponent( );
            this.Catalogo = Catalogo;

            var DbLocal = new DataBaseContexto();

            if (etiqueta != null) DbLocal.Etiquetas.Where(t => t.Id == etiqueta.Id).Load();
            var Entity = DbLocal.Etiquetas.Local.FirstOrDefault(p => p.Id == etiqueta?.Id);

            base.Initialize(DbLocal, DbLocal.Etiquetas.Local.ToBindingList(), DbLocal.Etiquetas, Entity);
        }


        public override void AgregarNuevo()
        {
            CrearForm(t => new AgregarEditarEtiqueta(t));
        }
    }
}
