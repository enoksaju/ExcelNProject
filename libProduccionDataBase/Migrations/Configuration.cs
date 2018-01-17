namespace libProduccionDataBase.Migrations
{
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<libProduccionDataBase.Contexto.DataBaseContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(libProduccionDataBase.Contexto.DataBaseContexto context)
        {
            context.TiposMaquina.AddOrUpdate(t => t.Tipo_Maquina,
                new Tablas.TipoMaquina { Tipo_Maquina = "Impresora" },
                new Tablas.TipoMaquina { Tipo_Maquina = "Laminadora" },
                new Tablas.TipoMaquina { Tipo_Maquina = "Refinadora" },
                new Tablas.TipoMaquina { Tipo_Maquina = "Dobladora" },
                new Tablas.TipoMaquina { Tipo_Maquina = "Pegadora" },
                new Tablas.TipoMaquina { Tipo_Maquina = "Bolseadora" },
                new Tablas.TipoMaquina { Tipo_Maquina = "Extrusora" },
                new Tablas.TipoMaquina { Tipo_Maquina = "Saneadora" }
                );

            context.TiposProducto.AddOrUpdate(t => t.NombreTipoProducto,
                new Tablas.TipoProducto { NombreTipoProducto="Pelicula"},
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
            context.FamiliasMateriales.AddOrUpdate(t => t.NombreFamilia,
                new Tablas.FamiliaMateriales { NombreFamilia="BOPP"},
                new Tablas.FamiliaMateriales { NombreFamilia = "PET" },
                new Tablas.FamiliaMateriales { NombreFamilia = "PE" },
                new Tablas.FamiliaMateriales { NombreFamilia = "PVC" }
                );
            context.Procesos.AddOrUpdate(t => t.NombreProceso,
                new Tablas.Proceso { NombreProceso= "Impresion"},
                new Tablas.Proceso { NombreProceso = "Laminacion" },
                new Tablas.Proceso { NombreProceso = "Refinado" },
                new Tablas.Proceso { NombreProceso = "Doblado" },
                new Tablas.Proceso { NombreProceso = "Corte" },
                new Tablas.Proceso { NombreProceso = "Embobinado" },
                new Tablas.Proceso { NombreProceso = "Mangas" },
                new Tablas.Proceso { NombreProceso = "Sellado" },
                new Tablas.Proceso { NombreProceso = "Extrusion" }
                );
        }
    }
}
