using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace EstacionesPesaje.DockContents
{
    public interface ICatalogForm
    {
        event KryptonDockContentFormBase.ChangeStatusMessage StatusStringChanged;
        void Actualizar( object sender, EventArgs e );
        void Agregar( object sender, EventArgs e );
        void Eliminar( object sender, EventArgs e );
        void Editar( object sender, EventArgs e );
        void Buscar( object sender, string SearchString );
        void showDetails( object sender, EventArgs e );
        void Show( DockPanel Panel, DockContents.ICatalogFormEnums.FlagActiveFunctions Functions );       
        void RefreshBindingSource( object sender, EventArgs e );
    }
}

namespace EstacionesPesaje.DockContents.ICatalogFormEnums
{
    /// <summary>
    /// Banderas para identificar la funcion del formulario
    /// </summary>
    [Flags]
    public enum FlagActiveFunctions
    {
        Ninguno = 0x0,
        Editar = 0x1,
        Buscar = 0x2,
        Detalles = 0x4,
        EditarYDetalles = Editar | Detalles,
        EditarYBuscar = Editar | Buscar,
        BuscarYDetalles = Buscar | Detalles,
        Todas = Editar | Detalles | Buscar
    }
}
