using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExcelNobleza.Shared.Models.Tablas.Otros
{
	public class Etiqueta
	{
		public int Id { get; set; }
		[MaxLength(250)]
		[Required(ErrorMessage = "El nombre de la etiqueta es requerido")]
		// [Index(IsUnique = true)]
		public string Nombre { get; set; }
		public string ZPLCode { get; set; }
		public string Definition { get; set; }
		public Etiqueta()
		{
			this.ZPLCode = @"
^FX
              Autor: Excel Nobleza
        Descripción: Etiqueta ***
            Cliente:
 Nombre del Archivo:
^FS

^XA

    ^FX Ingrese el codigo de la etiqueta aqui ^FS

^XZ";
		}

		public override string ToString()
		{
			return this.Nombre;
		}
	}
}
