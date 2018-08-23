using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Cotizador.Models;
using libProduccionDataBase.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Cotizador.Controllers
{
	[Authorize]
	[RoutePrefix ( "api/Catalogos" )]
	public partial class CatalogosController : ApiController
	{
		private ApplicationUserManager _userManager;
		public enum OrderTypes { ASC, DESC }
		private const string SUCCESS_INSERT_MESSAGE = "Se inserto correctamente el elemento:";
		private const string SUCCESS_UPDATE_MESSAGE = "Se actualizó correctamente el elemento:";
		private const string SUCCESS_DELETE_MESSAGE = "Se Eliminó correctamente el elemento:";
		private const string NOT_VALID_ENTITY = "La entidad solicitada no es valida:";

		private libProduccionDataBase.Contexto.DataBaseContexto DB = new libProduccionDataBase.Contexto.DataBaseContexto ( );
		public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; }

		public CatalogosController ()
		{
			UserManager = new ApplicationUserManager ( new ApplicationUserStore ( DB ) );
		}
		public CatalogosController ( ApplicationUserManager userManager, ISecureDataFormat<AuthenticationTicket> accessTokenFormat )
		{
			UserManager = userManager;
			AccessTokenFormat = accessTokenFormat;
		}
		public ApplicationUserManager UserManager
		{
			get { return _userManager ?? Request.GetOwinContext ( ).GetUserManager<ApplicationUserManager> ( ); }
			private set { _userManager = value; }
		}

		/// <summary>
		/// Obtiene y envia el estado de los catalogos
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route ( nameof ( EstadoCatalogos ) )]
		public async Task<IHttpActionResult> EstadoCatalogos () => Ok ( new object[] {
				new {
					Nombre = "Clientes",
					Route = "Clientes",
					Icono = "users",
					Content= $"{await DB.Clientes.CountAsync()} Elementos"
				},
				new {
					Nombre = "Materiales",
					Route = "Materiales",
					Icono = "clone",
					Content= $"{await DB.Materiales.CountAsync()} Elementos"
				},
				new {
					Nombre = "Familias de Materiales",
					Route = "FamiliasMateriales",
					Icono = "object-group",
					Content= $"{await DB.FamiliasMateriales.CountAsync()} Elementos"
				},
				new {
					Nombre = "Maquinas",
					Route = "Maquinas",
					Icono = "cogs",
					Content= $"{await DB.Maquinas.CountAsync()} Elementos"
				},
				new {
					Nombre = "Rodillos",
					Route = "Rodillos",
					Icono = "dot-circle",
					Content= $"{await DB.Rodillos.CountAsync()} Elementos"
				},
				new {
					Nombre = "Tipos Tinta",
					Route = "Tintas",
					Icono = "tint",
					Content= $"{await DB.Tintas.CountAsync()} Elementos"
				},
				new {
					Nombre = "Otros",
					Route = "Otros",
					Icono = "box",
					Content= $"{await DB.Otros.CountAsync()} Elementos"
				}
			} );

		/// <summary>
		/// Revisa si un objeto contiene alguna propiedad con el nombre que se especifica en los argumentos
		/// </summary>
		/// <param name="obj">tipo del objeto que se analizara.</param>
		/// <param name="propertyName">Nombre de la propiedad.</param>
		/// <returns></returns>
		public static bool HasProperty ( Type obj, string propertyName ) => obj.GetProperty ( propertyName ) != null;

		public bool IsInAdminRol ( System.Security.Principal.IPrincipal User ) => ( User.IsInRole ( "Administrador" ) | User.IsInRole ( "Develop" ) | User.IsInRole ( "Sistemas" ) | User.IsInRole ( "Administrador Ventas" ) );
	}
}
