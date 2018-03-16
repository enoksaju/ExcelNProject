using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesPesaje.Pages.Base
{
    /// <summary>
    /// Banderas para identificar la funcion del formulario
    /// </summary>
    [Flags]
    public enum FlagActiveFormFunctions
    {
        Ninguno = 0x0,
        Editar = 0x1,
        Buscar = 0x2,
        Detalles = 0x4,
        Eliminar = 0x8,
        Todas = Editar | Detalles | Buscar| Eliminar
    }
}
