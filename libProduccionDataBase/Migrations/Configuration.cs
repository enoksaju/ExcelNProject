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
		public Configuration ( ) {


			DbConfiguration.SetConfiguration ( new MySqlEFConfiguration ( ) );
			AutomaticMigrationsEnabled = false;
			SetSqlGenerator ( "MySql.Data.MySqlClient" , new MySql.Data.Entity.MySqlMigrationSqlGenerator ( ) );

			//try {
			//	using ( var context = new libProduccionDataBase.Contexto.DataBaseContexto ( ) ) {
			//		using ( var writer = new System.Xml.XmlTextWriter ( System.AppDomain.CurrentDomain.BaseDirectory + @"\Model.edmx" , System.Text.Encoding.Default ) ) {
			//			System.Data.Entity.Infrastructure.EdmxWriter.WriteEdmx ( context , writer );
			//		}
			//	}
			//} catch ( Exception ) {
			//}
		}

		protected override void Seed ( libProduccionDataBase.Contexto.DataBaseContexto context ) {
			context.Database.Log = Console.Write;

			context.TiposMaquina.AddOrUpdate ( t => t.Tipo_Maquina ,
				new Tablas.TipoMaquina { Tipo_Maquina = "Impresora" } ,
				new Tablas.TipoMaquina { Tipo_Maquina = "Laminadora" } ,
				new Tablas.TipoMaquina { Tipo_Maquina = "Refinadora" } ,
				new Tablas.TipoMaquina { Tipo_Maquina = "Dobladora" } ,
				new Tablas.TipoMaquina { Tipo_Maquina = "Pegadora" } ,
				new Tablas.TipoMaquina { Tipo_Maquina = "Bolseadora" } ,
				new Tablas.TipoMaquina { Tipo_Maquina = "Extrusora" } ,
				new Tablas.TipoMaquina { Tipo_Maquina = "Saneadora" }
				);

			context.Lineas.AddOrUpdate ( t => t.Nombre ,
				new Tablas.Linea { Nombre = "SCHIAVI" } ,
				new Tablas.Linea { Nombre = "WINDMOLLER" } ,
				new Tablas.Linea { Nombre = "UTECO 1" } ,
				new Tablas.Linea { Nombre = "UTECO 3" } ,
				new Tablas.Linea { Nombre = "TACHYS" } ,
				new Tablas.Linea { Nombre = "BOLSAS" } ,
				new Tablas.Linea { Nombre = "MANGAS" } ,
				new Tablas.Linea { Nombre = "LAMINEXT" } ,
				new Tablas.Linea { Nombre = "NAVE3" } ,
				new Tablas.Linea { Nombre = "EXTRUSION PP" } ,
				new Tablas.Linea { Nombre = "EXTRUSION PE" }
				);

			context.TiposProducto.AddOrUpdate ( t => t.NombreTipoProducto ,
				new Tablas.TipoProducto { NombreTipoProducto = "Pelicula" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Pelicula Laminada" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Pelicula Trilaminada" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "FlowPack Laminada" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "FlowPack Trilaminada" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral no Impresa" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Impresa" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Laminada no Impresa" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Laminada Impresa" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Trilaminada" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Etiqueta" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "PVC" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Prototipos" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Piezas" } ,
				new Tablas.TipoProducto { NombreTipoProducto = "Etiqueta Tipo Manga" }
				);

			context.FamiliasMateriales.AddOrUpdate ( t => t.NombreFamilia ,
				new Tablas.FamiliaMateriales { NombreFamilia = "BOPP" } ,
				new Tablas.FamiliaMateriales { NombreFamilia = "PET" } ,
				new Tablas.FamiliaMateriales { NombreFamilia = "PE" } ,
				new Tablas.FamiliaMateriales { NombreFamilia = "PVC" }
				);

			context.Procesos.AddOrUpdate ( t => t.NombreProceso ,
				new Tablas.Proceso { NombreProceso = "Impresion" } ,
				new Tablas.Proceso { NombreProceso = "Laminacion" } ,
				new Tablas.Proceso { NombreProceso = "Refinado" } ,
				new Tablas.Proceso { NombreProceso = "Doblado" } ,
				new Tablas.Proceso { NombreProceso = "Corte" } ,
				new Tablas.Proceso { NombreProceso = "Embobinado" } ,
				new Tablas.Proceso { NombreProceso = "Mangas" } ,
				new Tablas.Proceso { NombreProceso = "Sellado" } ,
				new Tablas.Proceso { NombreProceso = "Extrusion" }
				);

			context.Roles.AddOrUpdate ( t => t.Name ,
				new ApplicationRole ( ) { Name = "Develop" } ,
				new ApplicationRole ( ) { Name = "Administrador" } ,
				new ApplicationRole ( ) { Name = "Usuario General" } ,
				new ApplicationRole ( ) { Name = "Trabajador" } ,
				new ApplicationRole ( ) { Name = "Supervisor" } ,
				new ApplicationRole ( ) { Name = "Recursos Humanos Admin" } ,
				new ApplicationRole ( ) { Name = "Recursos Humanos User" } ,
				new ApplicationRole ( ) { Name = "Agente Ventas" } ,
				new ApplicationRole ( ) { Name = "AdminProduccion" } ,
				new ApplicationRole ( ) { Name = "AdminTintas" } ,
				new ApplicationRole ( ) { Name = "UsuarioTintas" }
			);

			context.ProveedoresTinta.AddOrUpdate ( o => o.Nombre ,
				new Tablas.ProveedorTinta ( ) {
					Nombre = "Flint Group" ,
					TiposTinta = new Tablas.ObservableListSource<Tablas.TiposTinta> ( ) {
						new Tablas.TiposTinta ( ) {
							Nombre = "Bases" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F20964", Descripcion = "Base Rojo Laca N/C"},
								new Tablas.ArticuloTinta() {  Clave="F20971", Descripcion = "Base Rodhamina N/C"},
								new Tablas.ArticuloTinta() {  Clave="F20972", Descripcion = "Base Negro Poligloss"},
								new Tablas.ArticuloTinta() {  Clave="F27410", Descripcion = "Base Naranja Rojiso" } ,
								new Tablas.ArticuloTinta() {  Clave="F27834", Descripcion = "Base Amarillo Irgalite N/C"},
								new Tablas.ArticuloTinta() {  Clave="F27835", Descripcion = "Base Rojo 2B N/C"},
								new Tablas.ArticuloTinta() {  Clave="F27836", Descripcion = "Base Verde N/C"},
								new Tablas.ArticuloTinta() {  Clave="F27837", Descripcion = "Base Azul Verdoso N/C"},
								new Tablas.ArticuloTinta() {  Clave="F27839", Descripcion = "Base Rojo Rubi N/C"},
								new Tablas.ArticuloTinta() {  Clave="F27841", Descripcion = "Base Rojo Nafthol N/C"},
								new Tablas.ArticuloTinta() {  Clave="F27842", Descripcion = "Base Violeta Permanente" } ,
								new Tablas.ArticuloTinta() {  Clave="F27843", Descripcion = "Base Rodhamina Permanente"},
								new Tablas.ArticuloTinta() {  Clave="F27845", Descripcion = "Base Negro N/C"},
							}
						},
						new Tablas.TiposTinta ( ) {
							Nombre = "Polygloss" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F27723", Descripcion = "Amarillo Policromia Polygloss AV"},
								new Tablas.ArticuloTinta() {  Clave="F27724", Descripcion = "Magenta Policromia Polygloss AV"},
								new Tablas.ArticuloTinta() {  Clave="F27725", Descripcion = "Azul Policromia Polygloss AV"},
								new Tablas.ArticuloTinta() {  Clave="F27726", Descripcion = "Negro Policromia Polygloss AV"},
								new Tablas.ArticuloTinta() {  Clave="F20726", Descripcion = "Barniz Tecnico Polygloss"},
								new Tablas.ArticuloTinta() {  Clave="F13651", Descripcion = "Extender para Basicos Flexo"},
								new Tablas.ArticuloTinta() {  Clave="F27820", Descripcion = "Blanco Higienico Fxo Dr AV"},
								new Tablas.ArticuloTinta() {  Clave="F11688", Descripcion = "Blanco Polyglosss Frente"},
							}
						},
						new Tablas.TiposTinta ( ) {
							Nombre = "Synvatuf" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F26583", Descripcion = "Blaco Sinvatuf"},
								new Tablas.ArticuloTinta() {  Clave="F28975", Descripcion = "Barniz Tecnico Synvatuf"},
								new Tablas.ArticuloTinta() {  Clave="F28912", Descripcion = "Barniz Extender Synvatuf"},
								new Tablas.ArticuloTinta() {  Clave="F17511", Descripcion = "Base Negro NC"},
								new Tablas.ArticuloTinta() {  Clave="F28910", Descripcion = "Amarillo Synvatuf"},
							}
						} ,
						new Tablas.TiposTinta ( ) {
							Nombre = "Poliester" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F28281", Descripcion = "Amarillo Seleccion PET AV"},
								new Tablas.ArticuloTinta() {  Clave="F28282", Descripcion = "Magenta Seleccion PET AV"},
								new Tablas.ArticuloTinta() {  Clave="F28283", Descripcion = "Azul Seleccion PET AV"},
								new Tablas.ArticuloTinta() {  Clave="F28284", Descripcion = "Negro Seleccion PET AV"},
								new Tablas.ArticuloTinta() {  Clave="F21641", Descripcion = "Barniz Extender PET"},
								new Tablas.ArticuloTinta() {  Clave="F21642", Descripcion = "Barniz Tecnico PET"},
								new Tablas.ArticuloTinta() {  Clave="F29283", Descripcion = "Blanco Flexilam"},
								new Tablas.ArticuloTinta() {  Clave="F18828", Descripcion = "Extender Bas.Lam"},
							}
						} ,
						new Tablas.TiposTinta ( ) {
							Nombre = "Flexolam" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F27782", Descripcion = "Amarillo Seleccion Flexolam AV"},
								new Tablas.ArticuloTinta() {  Clave="F27783", Descripcion = "Magenta Seleccion Flexolam AV"},
								new Tablas.ArticuloTinta() {  Clave="F27784", Descripcion = "Azul Seleccion Flexolam AV"},
								new Tablas.ArticuloTinta() {  Clave="F27785", Descripcion = "Negro Seleccion Flexolam AV"},
								new Tablas.ArticuloTinta() {  Clave="F15802", Descripcion = "AZ Ref Lam"},
								new Tablas.ArticuloTinta() {  Clave="F13960", Descripcion = "Barniz Extender Lam"},
								new Tablas.ArticuloTinta() {  Clave="F20943", Descripcion = "Barniz Tecnico Flexolam"},
								new Tablas.ArticuloTinta() {  Clave="F29405", Descripcion = "Blaco Especial Flexoplastol VF7"},
								new Tablas.ArticuloTinta() {  Clave="F24021", Descripcion = "Blaco Eco BOPP Flexolam"},
							}
						} ,
						new Tablas.TiposTinta ( ) {
							Nombre = "PET Pasteurizable Flexilam FP" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F28606", Descripcion = "Amarillo Flexilam FP"},
								new Tablas.ArticuloTinta() {  Clave="F28607", Descripcion = "Magenta Flexilam FP"},
								new Tablas.ArticuloTinta() {  Clave="F28608", Descripcion = "Cyan Flexilam FP"},
								new Tablas.ArticuloTinta() {  Clave="F28609", Descripcion = "Negro Flexilam FP"},
								new Tablas.ArticuloTinta() {  Clave="F28611", Descripcion = "Barniz Tecnico Flexilam FP"},
								new Tablas.ArticuloTinta() {  Clave="F28612", Descripcion = "Barniz Extender Flexilam FP"},
								new Tablas.ArticuloTinta() {  Clave="F28610", Descripcion = "Blanco Flexilam FP"},
							}
						} ,
						new Tablas.TiposTinta ( ) {
							Nombre = "Cloro" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F22262", Descripcion = "Barniz S/Imp P/Cloro"},
								new Tablas.ArticuloTinta() {  Clave="F22295", Descripcion = "Barniz Tecnico Cloro E."},
							}
						} ,
						new Tablas.TiposTinta ( ) {
							Nombre = "Acrilico" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F27453", Descripcion = "Barniz Tecnico Flexo BOPP Acrilico"},
								new Tablas.ArticuloTinta() {  Clave="F27454", Descripcion = "Barniz Extender Flexo BOPP Acrilico"},
								new Tablas.ArticuloTinta() {  Clave="F27455", Descripcion = "Blaco Flexo BOPP Acrilico"},
							}
						} ,
						new Tablas.TiposTinta ( ) {
							Nombre = "Barniz S / Impresión" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F19322", Descripcion = "Barniz S/Impresión Etiquetas Flexo"},
								new Tablas.ArticuloTinta() {  Clave="F25882", Descripcion = "Barniz Mate PET ESP Flexo DR"},
								new Tablas.ArticuloTinta() {  Clave="F21896", Descripcion = "Barniz S/Impresion"},
								new Tablas.ArticuloTinta() {  Clave="F29227", Descripcion = "Barniz 2K Flexo"},
								new Tablas.ArticuloTinta() {  Clave="F28379", Descripcion = "Catalizador Dos Componentes"},
								new Tablas.ArticuloTinta() {  Clave="F24964", Descripcion = "Barniz S/Impresion Termo"},
							}
						} ,
						new Tablas.TiposTinta ( ) {
							Nombre = "Plata Oro Laminacion" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F15490", Descripcion = "Plata Pepsi Lam"},
								new Tablas.ArticuloTinta() {  Clave="F17790", Descripcion = "Oro Imitación"},
								new Tablas.ArticuloTinta() {  Clave="F27971", Descripcion = "Plata Conc. PET Flexolam"},
								new Tablas.ArticuloTinta() {  Clave="F22212", Descripcion = "Oro LAca Linaza PET"},
								new Tablas.ArticuloTinta() {  Clave="F27306", Descripcion = "Oro 871-C Flexo"},
							}
						} ,
						new Tablas.TiposTinta ( ) {
							Nombre = "Plata Oro Frente" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F10721", Descripcion = "Plata 877"},
								new Tablas.ArticuloTinta() {  Clave="F9750", Descripcion = "Oro 871 Fxo-Fte"},
								new Tablas.ArticuloTinta() {  Clave="F25128", Descripcion = "Plata Gatorade PE Flexo"},
							}
						} ,
						new Tablas.TiposTinta ( ) {
							Nombre = "Base Agua" ,
							Articulos = new Tablas.ObservableListSource<Tablas.ArticuloTinta> ( ) {
								new Tablas.ArticuloTinta() {  Clave="F29284", Descripcion = "Amarillo Glasil Agua"},
								new Tablas.ArticuloTinta() {  Clave="F29285", Descripcion = "Magenta Glasil Agua"},
								new Tablas.ArticuloTinta() {  Clave="F29286", Descripcion = "Cyan Glasil Agua"},
								new Tablas.ArticuloTinta() {  Clave="F29287", Descripcion = "Negro Glasil Agua"},
							}
						} ,
						new Tablas.TiposTinta ( ) { Nombre = "Retornos Pantone" }
					}
				}
				);



			using ( var t = new Identity.ApplicationUserManager ( new Identity.ApplicationUserStore ( context ) ) ) {
				if ( !t.Users.Any ( HS => HS.UserName == "HSALINAS" ) ) {
					var usr = new ApplicationUser { Nombre = "Henoc" , ApellidoPaterno = "Salinas" , ApellidoMaterno = "Juarez" , ClaveTrabajador = "5547" , UserName = "HENOCS" , Email = "hsalinas@excelnobleza.com.mx" };

					var result = t.Create ( usr , "hsj43295" );
					if ( result.Succeeded ) {
						t.AddToRole ( usr.Id , "Develop" );
					}
				}
			}
		}
	}
}
