using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Identity;

namespace libProduccionDataBase.Tablas
{
    [Table("Clientes")]
    public class Cliente
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage ="EL nombre del cliente es requerido"), MaxLength(250)]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage ="La clave del cliente es requerida"), 
         MaxLength(10, ErrorMessage ="El largo maximo para la clave del Cliente es de 10 caracteres"),
         Index("ClaveCliente_IDX", IsUnique = true)]
        public string ClaveCliente { get; set; }

		[Required ( ErrorMessage = "EL nombre del contacto es requerido" ), MaxLength ( 250 )]
		public string NombreContacto { get; set; }
		[Phone ( ErrorMessage = "No es un valor de telefono valido" )]
		public string Telefono { get; set; }
		[EmailAddress ( ErrorMessage = "No es un Email Valido" )]
		public string Email { get; set; }
		public string Domicilio { get; set; }
		public string Ciudad { get; set; }
		public string Estado { get; set; }


		[ForeignKey ( "Agente" )]
		public int? AgenteId { get; set; }
		public virtual ApplicationUser Agente { get; set; }


		public override string ToString()
        {
            return this.NombreCliente;
        }
    }
}
