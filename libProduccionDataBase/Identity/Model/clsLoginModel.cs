using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Contexto;

namespace libProduccionDataBase.Identity.Model
{
    public class LoginModel
    {
        [Required( ErrorMessage = "El nombre de usuario es requerido" )]
        public string UserName { get; set; }
        [Required( ErrorMessage = "La contraseña es requerida" )]
        public string Password { get; set; }
    }

    public class UsuarioBasicInfo
    {
        [Required( ErrorMessage = "El Nombre el Requerido" )]
        public string Nombre { get; set; }

        [Required( ErrorMessage = "El Apellido Paterno es requerido" )]
        public string ApellidoPaterno { get; set; }

        [Required( ErrorMessage = "El Apellido Materno es requerido" )]
        public string ApellidoMaterno { get; set; }

        [Required( ErrorMessage = "La Clave del Trabajador es requerida" )]
        public string ClaveTrabajador { get; set; }

        [Required( ErrorMessage = "El Email es requerido" )]
        public string Email { get; set; }

        [Required( ErrorMessage = "El LoginName es requerido" )]
        public string UserName { get; set; }

        public int Id { get; set; }

        public async Task<ApplicationUser> ToUpdatedUser( ApplicationUserManager usrManager )
        {
            ApplicationUser  usr=  await usrManager.FindByIdAsync(this.Id);

            usr.Nombre = this.Nombre;
            usr.ApellidoPaterno = this.ApellidoPaterno;
            usr.ApellidoMaterno =this.ApellidoMaterno;
            usr.Email = this.Email;
            usr.ClaveTrabajador = this.ClaveTrabajador;
            usr.UserName = this.UserName;

            return usr;
        }


        public static async Task<List<UsuarioBasicInfo>> GetUsersBasicInfo()
        {

            List<UsuarioBasicInfo> toRet= new List<UsuarioBasicInfo>();

            using (DataBaseContexto DB = new DataBaseContexto())
            {
                await DB.Users.LoadAsync();
                var d= DB.Users.Local.ToList();

                d.ForEach( t =>
                {
                    toRet.Add( new UsuarioBasicInfo
                    {
                        Nombre = t.Nombre,
                        ApellidoPaterno = t.ApellidoPaterno,
                        ApellidoMaterno = t.ApellidoMaterno,
                        ClaveTrabajador = t.ClaveTrabajador,
                        Email = t.Email,
                        UserName = t.UserName,
                        Id = t.Id
                    } );
                } );
            }

            return toRet;
        }


    }


}
