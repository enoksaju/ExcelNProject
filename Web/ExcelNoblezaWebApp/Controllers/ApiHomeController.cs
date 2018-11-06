using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExcelNoblezaWebApp.Controllers
{
    public class ApiHomeController : ApiController
    {
        [Route("api/home/isloged")]
        [HttpGet]
        public IHttpActionResult IsLoged()
        {
            return User.Identity.IsAuthenticated ? Ok(true) : Ok(false);
        }

        [Route("api/home/getmenu")]
        [HttpGet]
        public IHttpActionResult getMenu()
        {
            List<Item> Items = new List<Item>();
            if (User.Identity.IsAuthenticated)
            {
                Items.Add(new Item("Aplicaciones", "centro de Aplicaciones", "apps", "/aplicaciones"));
            }
            return Ok(Items);
        }
        [Route("api/home/getApps")]
        [HttpGet]
        public IHttpActionResult getApps()
        {
            List<Appitem> Items = new List<Appitem>();
            Items.Add(new Appitem("Calculadora", "calculator", "/Calculadora", fa: true));


            if (User.IsInRole("Develop"))
            {
                Items.Add(new Appitem("Permisos",
                    "file-o",
                    "home/permisos",
                    fa: true));
            }


            if (User.IsInRole("Supervisor") || User.IsInRole("Admin") || User.IsInRole("User"))
            {
                Items.Add(new Appitem("Ordenes Trabajo",
                    "file-text-o",
                    "home/OrdenTrabajo",
                    fa: true));
            }

            if (User.IsInRole("EjecutivoVentas"))
            {
                Items.Add(new Appitem("Cotizador",
                    "file-text",
                    "home/Cotizador",
                    fa: true));
            }

            if (User.IsInRole("Admin"))
            {
                Items.Add(new Appitem("Usuarios",
                    "users",
                    "home/Usuarios",
                    fa: true));
            }

            return Ok(Items);
        }



    }
    #region Modelos
    public class Item
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string routerLink { get; set; }
        public SubMenu SubMenu { get; set; }
        public Item(string Label, string Description, string Icon = null, string routerLink = null, SubMenu SubMenu = null)
        {

            this.Label = Label;
            this.Description = Description;
            this.Icon = !string.IsNullOrEmpty(Icon) ? Icon.ToLower() : null;
            this.routerLink = routerLink;
            this.SubMenu = SubMenu;
        }
    }

    public class Menu
    {
        public string NombreGrupo { get; set; }
        public string Icon { get; set; }
        public List<Item> Items { get; set; }

        public Menu(List<Item> Items, string NombreGrupo = null, string Icon = null)
        {
            this.Icon = Icon;
            this.Items = Items;
            this.NombreGrupo = NombreGrupo;
        }
    }

    public class SubMenu
    {
        public Item[] Items { get; set; }
        public SubMenu(Item[] items)
        {
            this.Items = items;
        }
    }
    public class Appitem
    {
        public string Label { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public bool fa { get; set; }
        public Appitem(string Label, string Icon, string Link, string Color = null, string Description = null, bool fa = false)
        {
            this.Label = Label;
            this.Icon = Icon.ToLower();
            this.Color = Color;
            this.Link = Link;
            this.fa = fa;
        }
    }
    #endregion
}
