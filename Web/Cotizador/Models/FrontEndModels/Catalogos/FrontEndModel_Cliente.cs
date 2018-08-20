using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cotizador.Models.FrontEndModels.Catalogos
{
	public class FrontEndModel_Cliente
	{
		private string _telefono;
		private string _email;
		public int? Id { get; set; }
		[Required ( ErrorMessage = "EL nombre es Requerido" )]
		public string NombreCliente { get; set; }
		[MaxLength ( 10 ), Required ( ErrorMessage = "La clave del cliente es Requerida" )]
		public string ClaveCliente { get; set; }
		[Required(ErrorMessage = "El nombre del contacto es requerido")]
		public string NombreContacto { get; set; }
		[Phone ( ErrorMessage = "No es un valor de telefono valido" )]
		public string Telefono
		{
			get
			{
				return _telefono;
			}
			set
			{
				_telefono = value.Trim ( ) != "" ? value.Trim ( ) : null;
			}
		}
		[EmailAddress ( ErrorMessage = "No es un Email Valido" )]
		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value.Trim ( ) != "" ? value.Trim ( ) : null;
			}
		}
		public string Domicilio { get; set; }
		public string Ciudad { get; set; }
		public string Estado { get; set; }
		public int? AgenteId { get; set; }
	}
}