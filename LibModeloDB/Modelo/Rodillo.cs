//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibModeloDB.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rodillo
    {
        public long RodillosId { get; set; }
        public double Medida { get; set; }
        public short Cantidad { get; set; }
        public int ImpresoraImpresoraId { get; set; }
    
        public virtual Impresora Impresora { get; set; }
    }
}
