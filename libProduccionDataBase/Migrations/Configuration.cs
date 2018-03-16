namespace libProduccionDataBase.Migrations {
	using Identity;
	using MySql.Data.Entity;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;

	internal sealed class Configuration : DbMigrationsConfiguration<libProduccionDataBase.Contexto.DataBaseContexto> {
		public Configuration () {
			

			DbConfiguration.SetConfiguration ( new MySqlEFConfiguration ( ) );
			AutomaticMigrationsEnabled = true;
			SetSqlGenerator ( "MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator ( ) );

			//try {
			//	using (var context = new libProduccionDataBase.Contexto.DataBaseContexto ( )) {
			//		using (var writer = new System.Xml.XmlTextWriter ( System.AppDomain.CurrentDomain.BaseDirectory + @"\Model.edmx", System.Text.Encoding.Default )) {
			//			System.Data.Entity.Infrastructure.EdmxWriter.WriteEdmx ( context, writer );
			//		}
			//	}
			//}
			//catch (Exception) {
			//}
		}

		protected override void Seed ( libProduccionDataBase.Contexto.DataBaseContexto context ) {
			context.TiposMaquina.AddOrUpdate ( t => t.Tipo_Maquina,
				new Tablas.TipoMaquina { Tipo_Maquina = "Impresora" },
				new Tablas.TipoMaquina { Tipo_Maquina = "Laminadora" },
				new Tablas.TipoMaquina { Tipo_Maquina = "Refinadora" },
				new Tablas.TipoMaquina { Tipo_Maquina = "Dobladora" },
				new Tablas.TipoMaquina { Tipo_Maquina = "Pegadora" },
				new Tablas.TipoMaquina { Tipo_Maquina = "Bolseadora" },
				new Tablas.TipoMaquina { Tipo_Maquina = "Extrusora" },
				new Tablas.TipoMaquina { Tipo_Maquina = "Saneadora" }
				);

			context.Lineas.AddOrUpdate ( t => t.Nombre,
				new Tablas.Linea { Nombre = "SCHIAVI" },
				new Tablas.Linea { Nombre = "WINDMOLLER" },
				new Tablas.Linea { Nombre = "UTECO 1" },
				new Tablas.Linea { Nombre = "UTECO 3" },
				new Tablas.Linea { Nombre = "TACHYS" },
				new Tablas.Linea { Nombre = "BOLSAS" },
				new Tablas.Linea { Nombre = "MANGAS" },
				new Tablas.Linea { Nombre = "LAMINEXT" },
				new Tablas.Linea { Nombre = "NAVE3" },
				new Tablas.Linea { Nombre = "EXTRUSION PP" },
				new Tablas.Linea { Nombre = "EXTRUSION PE" }
				);
			
			context.TiposProducto.AddOrUpdate ( t => t.NombreTipoProducto,
				new Tablas.TipoProducto { NombreTipoProducto = "Pelicula" },
				new Tablas.TipoProducto { NombreTipoProducto = "Pelicula Laminada" },
				new Tablas.TipoProducto { NombreTipoProducto = "Pelicula Trilaminada" },
				new Tablas.TipoProducto { NombreTipoProducto = "FlowPack Laminada" },
				new Tablas.TipoProducto { NombreTipoProducto = "FlowPack Trilaminada" },
				new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral no Impresa" },
				new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Impresa" },
				new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Laminada no Impresa" },
				new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Laminada Impresa" },
				new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Trilaminada" },
				new Tablas.TipoProducto { NombreTipoProducto = "Etiqueta" },
				new Tablas.TipoProducto { NombreTipoProducto = "PVC" },
				new Tablas.TipoProducto { NombreTipoProducto = "Prototipos" },
				new Tablas.TipoProducto { NombreTipoProducto = "Piezas" },
				new Tablas.TipoProducto { NombreTipoProducto = "Etiqueta Tipo Manga" }
				);
			context.FamiliasMateriales.AddOrUpdate ( t => t.NombreFamilia,
				new Tablas.FamiliaMateriales { NombreFamilia = "BOPP" },
				new Tablas.FamiliaMateriales { NombreFamilia = "PET" },
				new Tablas.FamiliaMateriales { NombreFamilia = "PE" },
				new Tablas.FamiliaMateriales { NombreFamilia = "PVC" }
				);
			context.Procesos.AddOrUpdate ( t => t.NombreProceso,
				new Tablas.Proceso { NombreProceso = "Impresion" },
				new Tablas.Proceso { NombreProceso = "Laminacion" },
				new Tablas.Proceso { NombreProceso = "Refinado" },
				new Tablas.Proceso { NombreProceso = "Doblado" },
				new Tablas.Proceso { NombreProceso = "Corte" },
				new Tablas.Proceso { NombreProceso = "Embobinado" },
				new Tablas.Proceso { NombreProceso = "Mangas" },
				new Tablas.Proceso { NombreProceso = "Sellado" },
				new Tablas.Proceso { NombreProceso = "Extrusion" }
				);

			context.Roles.AddOrUpdate ( t => t.Name,
				new ApplicationRole ( ) { Name = "Develop" },
				new ApplicationRole ( ) { Name = "Administrador" },
				new ApplicationRole ( ) { Name = "Usuario General" },
				new ApplicationRole ( ) { Name = "Trabajador" },
				new ApplicationRole ( ) { Name = "Supervisor" },
				new ApplicationRole ( ) { Name = "Recursos Humanos Admin" },
				new ApplicationRole ( ) { Name = "Recursos Humanos User" },
				new ApplicationRole ( ) { Name = "Agente Ventas" },
				new ApplicationRole ( ) { Name = "AdminProduccion" }
			);

			using (var t = new Identity.ApplicationUserManager ( new Identity.ApplicationUserStore ( context ) )) {
				if (!t.Users.Any ( HS => HS.UserName == "HSALINAS" )) {
					var usr = new ApplicationUser { Nombre = "Henoc", ApellidoPaterno = "Salinas", ApellidoMaterno = "Juarez", ClaveTrabajador = "5547", UserName = "HENOCS", Email = "hsalinas@excelnobleza.com.mx" };

					var result = t.Create ( usr, "hsj43295" );
					if (result.Succeeded) {
						t.AddToRole ( usr.Id, "Develop" );
					}
				}
			}
		}
	}
}
