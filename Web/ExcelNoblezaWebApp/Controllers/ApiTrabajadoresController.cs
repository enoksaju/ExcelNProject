//using libPermisos.Modelos;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Net.Mail;
//using System.Web.Http;
//using System.Data.Entity;
//using libPermisos.ModelosCaptura;
//using static libPermisos.Modelos.Permiso;

//namespace ExcelNoblezaWebApp.Controllers
//{
//    public class TrabajadoresController : ApiController
//    {
//        [Route("api/trabajadores/search"), HttpGet]
//        public IHttpActionResult searchTrab(string clave)
//        {
//            using (var db = new DataBaseContexto())
//            {

//                if (!db.Trabajadores.Any(t => t.Clave == clave))
//                {
//                    return BadRequest("Trabajador no encontrado");
//                }
//                Trabajador trabajador = db.Trabajadores
//                   .Include(d => d.Departamento.Linea.SubDivision.Division.Empresa)
//                   .ToList()
//                   .Find(t => t.Clave == clave);
//                return Ok(CapturaTrabajador.fromTrabajador(trabajador));
//            }
//        }
//        [Route("api/trabajadores/getMotivos/{Clave}")]
//        [HttpGet]
//        public IHttpActionResult getMotivos(string Clave)
//        {
//            using (var bd = new DataBaseContexto())
//            {
//                if (bd.Trabajadores.Any(t => t.Clave.Trim() == Clave.Trim()))
//                {
//                    //var u = bd.Trabajadores.FirstOrDefault(t=>t.Clave== Clave);
//                    //u.trystr = "";
//                    //bd.SaveChanges();
//                    return Ok(bd.MotivosPermiso.ToList().Where(t => t.Especial == false || t.Especial == bd.Trabajadores.SingleOrDefault(o => o.Clave.Trim() == Clave.Trim()).PermisosEspeciales).ToList());
//                }
//                else
//                {
//                    return BadRequest("No hay ningun trabajador con la clave :" + Clave);
//                }

//            }
//        }
//    }
//}