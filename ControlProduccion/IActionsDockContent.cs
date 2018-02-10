using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlProduccion
{
    interface IActionsDockContent
    {
        void Guardar();
        void Actualizar();
        void AgregarNuevo();
        void Cancelar();
        void Refrescar();
        void Abrir();
        void GuardarComo();        
    }
}
