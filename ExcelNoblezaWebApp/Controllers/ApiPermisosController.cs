//using libPermisos.Modelos;
//using libPermisos.ModelosCaptura;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Net.Mail;
//using System.Web.Http;
//using System.Data.Entity;
//using static libPermisos.Modelos.Permiso;
//using PagedList;
//using System.ComponentModel.DataAnnotations;
//using MySql.Data.MySqlClient;

//namespace ExcelNoblezaWebApp.Controllers
//{
//    public class ApiPermisosController : ApiController
//    {
//        [Route("api/ApiPermisos/crear")]
//        [HttpPost]
//        [Authorize]
//        public IHttpActionResult PostPermiso(CapturaPermiso cPermiso)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            else
//            {
//                try
//                {
//                    using (var db = new libPermisos.Modelos.DataBaseContexto())
//                    {

//                        if (db.Trabajadores.Any(t => t.Clave.Trim() == cPermiso.Clave.Trim()))
//                        {
//                            cPermiso.Inicio = cPermiso.Inicio.HasValue ? ((DateTime)cPermiso.Inicio).ToLocalTime() : cPermiso.Inicio;      //Convierte la fecha y Hora de UTC a formato Local
//                            cPermiso.Fin = cPermiso.Fin.HasValue ? ((DateTime)cPermiso.Fin).ToLocalTime() : cPermiso.Fin;                   //Convierte la fecha y Hora de UTC a formato Local

//                            var trab = db.Trabajadores.FirstOrDefault(t => t.Clave.Trim() == cPermiso.Clave.Trim());

//                            var perm = new Permiso()
//                            {
//                                TrabajadorId = trab.Id,
//                                DiaDescanso = (Dias)cPermiso.DiaDescanso,
//                                Tipo = (Tipos)cPermiso.Tipo,
//                                Turno = (Turnos)cPermiso.Turno,
//                                Estatus = _Estatus.Nuevo,
//                                Generado = DateTime.Now,
//                                Revisado = false,
//                                MotivoPermisoId = (int)cPermiso.MotivoPermiso,
//                                Inicio = cPermiso.Inicio,
//                                Fin = cPermiso.Fin,
//                                Comentarios = cPermiso.Comentarios,
//                                UCreador = User.Identity.Name
//                            };


//                            db.Permisos.Add(perm);
//                            trab.Email = cPermiso.Email;

//                            db.SaveChanges();

//                            if (perm.Id != null)
//                            {
//                                using (MailMessage email = new MailMessage("nominas@excelnobleza.com.mx", cPermiso.Email))
//                                {
//                                    email.Subject = "Solicitud de Permiso";
//                                    email.Body = "se genero un permiso para ";
//                                    email.Attachments.Add(new Attachment(libPermisos.Reportes.PermisoPDF.getPDF(perm.Id), "Permiso " + perm.Id, "application/pdf"));
//                                    email.IsBodyHtml = false;

//                                    using (SmtpClient smtp = new SmtpClient("mail.excelnobleza.com.mx", 25))
//                                    {
//                                        smtp.EnableSsl = false;
//                                        smtp.UseDefaultCredentials = true;
//                                        smtp.Credentials = new NetworkCredential("hsalinas@excelnobleza.com.mx", "hsj43295");
//                                        smtp.Port = 25;
//                                        smtp.Send(email);
//                                    }
//                                }
//                                return Ok(perm.Id);
//                            }
//                            else
//                            {
//                                throw new Exception("Error al generar el folio");
//                            }
//                        }
//                        else
//                        {
//                            throw new Exception("No existe un trabajador con esa clave");
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    return BadRequest(ex.Message);
//                }

//            }
//        }

//        [Authorize]
//        [Route("api/apiPermisos/getPermiso/{folio}")]
//        [HttpGet]
//        public HttpResponseMessage getPDF(string folio)
//        {
//            using (var db = new DataBaseContexto())
//            {
//                if (db.Permisos.Any(t => t.Id == folio))
//                {
//                    var result = new HttpResponseMessage(HttpStatusCode.OK)
//                    {
//                        Content = new ByteArrayContent(libPermisos.Reportes.PermisoPDF.getPDF(folio).ToArray())
//                    };

//                    result.Content.Headers.ContentDisposition =
//                        new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
//                        {
//                            FileName = "Permiso_" + folio + ".pdf"
//                        };
//                    result.Content.Headers.ContentType =
//                        new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

//                    return result;
//                }
//                else
//                {
//                    var result = new HttpResponseMessage(HttpStatusCode.NotFound) { };
//                    return result;
//                }
//            }
//        }

//        [Route("api/apiPermisos/getMenu")]
//        [HttpGet]
//        [AllowAnonymous]
//        public IHttpActionResult getMenu()
//        {
//            if (User.IsInRole("AdminNominas"))
//            {
//                List<Menu> Items = new List<Menu>();
//                Items.Add(new Menu(new List<Item>() {
//                    new Item("Validar", "Validar los permisos recientes", "playlist_add_check", "/administrar/validar"),
//                    new Item("Reporte Permisos", "Obtener los permisos de un periodo de tiempo", "assessment", "/administrar/reporte")
//                }, "Administrador"));
//                return Ok(Items);
//            }
//            else
//            {
//                return BadRequest("Sin Autorización");
//            }
//        }

//        [Route("api/apiPermisos/isAdmin")]
//        [HttpGet]
//        [AllowAnonymous]
//        public IHttpActionResult isAdminNominas()
//        {
//            return User.IsInRole("AdminNominas") ? Ok(true) : Ok(false);
//        }

//        [Route("api/apiPermisos/getPermisos/{page}/{pageSize}/{sort}/{order}/{filter}")]
//        [Authorize(Roles = "AdminNominas")]
//        [HttpGet]
//        public IHttpActionResult getPermisos(int filter, int? page, int pageSize, string sort, string order)
//        {
//            //System.Threading.Thread.Sleep(1500);
//            try
//            {
//                using (var db = new DataBaseContexto())
//                {
//                    var ret = from s in db.Permisos
//                              .Include(p => p.Validacion)
//                              .Include(y => y.Trabajador)
//                              .Include(y => y.MotivoPermiso)
//                              select s;

//                    ret = ret.Where(s => s.EstatusString.Contains("Nuevo"));


//                    switch (filter)
//                    {
//                        case 1:
//                            ret = ret.Where(d => d.ValidacionId == 1);
//                            break;
//                        case 2:
//                            ret = ret.Where(d => d.ValidacionId == 2 || d.ValidacionId==3);
//                            break;
//                        case 3:
//                            ret = ret.Where(d => d.ValidacionId == 4);
//                            break;
//                        default:
//                            break;
//                    }

//                    switch (sort)
//                    {
//                        case "Folio":
//                            ret = order == "asc" ? ret.OrderBy(c => c.Id) : ret.OrderByDescending(c => c.Id);
//                            break;
//                        case "TipoString":
//                            ret = order == "asc" ? ret.OrderBy(c => c.TipoString) : ret.OrderByDescending(c => c.TipoString);
//                            break;
//                        case "TrabajadorId":
//                            ret = order == "asc" ? ret.OrderBy(c => c.TrabajadorId) : ret.OrderByDescending(c => c.TrabajadorId);
//                            break;
//                        case "MotivoPermisoId":
//                            ret = order == "asc" ? ret.OrderBy(c => c.MotivoPermisoId) : ret.OrderByDescending(c => c.MotivoPermisoId);
//                            break;
//                        case "Inicio":
//                            ret = order == "asc" ? ret.OrderBy(c => c.Inicio) : ret.OrderByDescending(c => c.Inicio);
//                            break;
//                        case "ValidacionId":
//                            ret = order == "asc" ? ret.OrderBy(c => c.ValidacionId) : ret.OrderByDescending(c => c.ValidacionId);
//                            break;
//                        default:
//                            ret = ret.OrderBy(c => c.Id);
//                            break;
//                    }

//                    var paged = ret.ToPagedList((page ?? 1), pageSize).ToList();

//                    paged.ForEach(y => { y.MotivoPermiso.Permisos.Clear(); y.Trabajador.Permisos.Clear(); });

//                    return Ok(new pagedPermisos(paged, ret.Count()));

//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }

//        }

//        [Route("api/apiPermisos/afectar")]
//        [Authorize(Roles = "AdminNominas")]
//        [System.Web.Http.Description.ResponseType(typeof(ModelValidation))]
//        [HttpPost]
//        public IHttpActionResult Validation(ModelValidation data)
//        {
//            if (!ModelState.IsValid) { return BadRequest(ModelState); }
//            if (data.folios.Count <= 0)
//            {
//                return BadRequest("No hay permisos para procesar la acción");
//            }
//            else
//            {
//                Func<ModelValidation.Action, _Estatus> Estado = action_ =>
//                {
//                    switch (action_)
//                    {
//                        case ModelValidation.Action.aprobar: return _Estatus.Autorizado;
//                        case ModelValidation.Action.cancelar: return _Estatus.Cancelado;
//                        case ModelValidation.Action.denegar: return _Estatus.Denegado;
//                        default: return _Estatus.Nuevo;
//                    }
//                };

//                try
//                {
//                    using (var db = new DataBaseContexto())
//                    {
//                        data.folios.ForEach(t =>
//                        {
//                            var p = db.Permisos.Single(i => i.Id == t);
//                            p.Estatus = Estado(data.accion);
//                            p.UValido = User.Identity.Name;
//                            p.Revisado = true;
//                        });
//                        db.SaveChanges();
//                        return Ok(data);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    return BadRequest(ex.Message);
//                }

//            }
//        }

//        [Route("api/apiPermisos/getReportData")]
//       // [Authorize(Roles = "AdminNominas")]
//        [HttpPost]
//        [System.Web.Http.Description.ResponseType(typeof(ReporteData))]
//        public async System.Threading.Tasks.Task<IHttpActionResult> getReportData(ReporteData Reporte)
//        {
//            using (var db = new DataBaseContexto())
//            {
//                var sql = "call permisos.ReportePermisos(@fecha);";
//                try
//                {
//                    var t = db.Database.SqlQuery(typeof(ResultReport),
//                        sql,
//                        new MySqlParameter("@fecha", Reporte.Fecha));
//                    return Ok(await t.ToListAsync());
//                }
//                catch (Exception ex)
//                {
//                    return BadRequest(ex.Message);
//                }

//            }
//        }
//    }

//    public class pagedPermisos
//    {
//        public List<Permiso> Items { get; set; }
//        public int TotalLength { get; set; }
//        public pagedPermisos(List<Permiso> items, int TotalLength)
//        {
//            this.Items = items;
//            this.TotalLength = TotalLength;
//        }
//    }
//    public class ModelValidation
//    {
//        public enum Action { aprobar, denegar, cancelar }
//        [Required]
//        public Action accion { get; set; }
//        public List<string> folios { get; set; }
//    }
//    public class ResultReport
//    {
//        public string Clave { get; set; }
//        public string Folio { get; set; }
//        public string Dia1 { get; set; }
//        public string Dia2 { get; set; }
//        public string Dia3 { get; set; }
//        public string Dia4 { get; set; }
//        public string Dia5 { get; set; }
//        public string Dia6 { get; set; }
//        public string Dia7 { get; set; }
//        public string Dia8 { get; set; }
//        public string Dia9 { get; set; }
//        public string Dia10 { get; set; }
//        public string Concepto { get; set; }
//        public string Estatus { get; set; }
//        public string ValidadoPor { get; set; }
//        public string Comentarios { get; set; }
//    }
//    public class ReporteData
//    {
//        public DateTime Fecha { get; set; }
//        public _Estatus Estatus { get; set; } = _Estatus.Autorizado;
//    }
//}
