using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryEntity
{
    public enum TiposFormulario{ Lista, editForm, detailsForm, reportForm}
    public enum TipoExport { Excel, PDF}
    interface IformRibbonTab
    {
        TiposFormulario TipoFRM { get; }
        void Actualizar();
        DialogResult Edit();
        DialogResult AddNew();
        void Search(object param);
        DialogResult Delete();
        void Export(TipoExport Tipo);
        void Guardar();
    }
}
