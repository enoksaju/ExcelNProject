namespace libProduccionDataBase.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using System.Data.Entity.Migrations.Model;
	using System.Data.Entity.Migrations.Sql;
	using System.Data.Entity.SqlServer.Utilities;
	using System.Linq;
	using System.Text;
	using Identity;
	using Microsoft.AspNet.Identity;
	using MySql.Data.EntityFramework;

	public class myMigrationSQLGenerator : MySqlMigrationSqlGenerator
	{
		private string TrimSchemaPrefix ( string table )
		{
			if ( table.StartsWith ( "dbo." ) )
				return table.Replace ( "dbo.", "" );
			return table;
		}

		protected override MigrationStatement Generate ( CreateIndexOperation op )
		{
			StringBuilder sb = new StringBuilder ( );

			sb = sb.Append ( "CREATE " );

			if ( op.IsUnique )
			{
				sb.Append ( "UNIQUE " );
			}

			//index_col_name specification can end with ASC or DESC.
			// sort order are permitted for future extensions for specifying ascending or descending index value storage
			//Currently, they are parsed but ignored; index values are always stored in ascending order.

			object sort;
			op.AnonymousArguments.TryGetValue ( "Sort", out sort );
			var sortOrder = sort != null && sort.ToString ( ) == "Ascending" ?
							"ASC" : "DESC";

			sb.AppendFormat ( "index  `{0}` on `{1}` (", op.Name, TrimSchemaPrefix ( op.Table ) );
			sb.Append ( string.Join ( ",", op.Columns.Select ( c => "`" + c + "` " + sortOrder ) ) + ") " );

			object indexTypeDefinition;
			op.AnonymousArguments.TryGetValue ( "Type", out indexTypeDefinition );

			var indexType = indexTypeDefinition != null && string.Compare ( indexTypeDefinition.ToString ( ), "Hash", StringComparison.InvariantCultureIgnoreCase ) > 0 ?
							"HASH": "BTREE" ;

			sb.Append ( "using " + indexType );

			return new MigrationStatement ( ) { Sql = sb.ToString ( ) };
		}
	}


	internal sealed class Configuration : DbMigrationsConfiguration<libProduccionDataBase.Contexto.DataBaseContexto>
	{
		public Configuration ()
		{			
			AutomaticMigrationsEnabled = false;
			SetSqlGenerator ( "MySql.Data.MySqlClient", new myMigrationSQLGenerator ( ) );
			//SetSqlGenerator ( "MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator ( ) );
		}

		protected override void Seed ( libProduccionDataBase.Contexto.DataBaseContexto context )
		{
			context.Database.Log = Console.Write;

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
				new ApplicationRole ( )
				{
					Name = "Develop"
				},
				new ApplicationRole ( )
				{
					Name = "Administrador"
				},
				new ApplicationRole ( )
				{
					Name = "Sistemas"
				},
				new ApplicationRole ( )
				{
					Name = "Usuario"
				},
				new ApplicationRole ( )
				{
					Name = "Consultas"
				},
				new ApplicationRole ( )
				{
					Name = "Administrador Recursos Humanos"
				},
				new ApplicationRole ( )
				{
					Name = "Usuario Recursos Humanos"
				},
				new ApplicationRole ( )
				{
					Name = "Supervisor Produccion"
				},
				new ApplicationRole ( )
				{
					Name = "Administrador Produccion"
				},
				new ApplicationRole ( )
				{
					Name = "Usuario Produccion"
				},
				new ApplicationRole ( )
				{
					Name = "Administrador Tintas"
				},
				new ApplicationRole ( )
				{
					Name = "Usuario Tintas"
				},
				new ApplicationRole ( )
				{
					Name = "Administrador Ventas"
				},
				new ApplicationRole ( )
				{
					Name = "Ejecutivo Ventas"
				},
				new ApplicationRole ( )
				{
					Name = "Auxiliar Ventas"
				}
			);

			using ( var t = new ApplicationUserManager_ ( new Identity.ApplicationUserStore ( context ) ) )
			{
				if ( !t.Users.Any ( HS => HS.UserName == "hsalinas@excelnobleza.com.mx" ) )
				{
					var usr = new ApplicationUser { Nombre = "Henoc", ApellidoPaterno = "Salinas", ApellidoMaterno = "Juarez", ClaveTrabajador = "5547", UserName = "HENOCS", Email = "hsalinas@excelnobleza.com.mx" };

					var result = t.Create ( usr, "hsj43295" );
					if ( result.Succeeded )
					{
						t.AddToRole ( usr.Id, "Develop" );
					}
				}
			}
		}
	}
}
