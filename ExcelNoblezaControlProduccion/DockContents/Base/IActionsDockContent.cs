using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace EstacionPesaje.DockContents
{
    public interface IActionsDockContent
    {
        event KryptonDockContentFormBase.ChangeStatusMessage StatusStringChanged;
        void Guardar();
        void Actualizar();
        void AgregarNuevo();
        void Cancelar();
        void Refrescar();
        void Abrir();
        void GuardarComo();
        void Show( DockPanel Panel );
    }
}
