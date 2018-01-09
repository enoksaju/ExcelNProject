namespace libProduccionDataBase.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<libProduccionDataBase.Contexto.DataBaseContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());

            try
            {
                using (var context = new Contexto.DataBaseContexto())
                {
                    using (var writer = new System.Xml.XmlTextWriter(Environment.CurrentDirectory + @"\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + @"\Model.edmx", System.Text.Encoding.Default))  //System.AppDomain.CurrentDomain.BaseDirectory + @"\Model.edmx", System.Text.Encoding.Default))
                    {
                        System.Data.Entity.Infrastructure.EdmxWriter.WriteEdmx(context, writer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }              
                
        }

        protected override void Seed(libProduccionDataBase.Contexto.DataBaseContexto context)
        {
            //context.Clientes.AddOrUpdate(
            //    p => p.ClaveCliente,
            //    new Tablas.Cliente { NombreCliente = "Nombre de Prueba", ClaveCliente = "0000000001" }
            //    );

            //var TipMaq = new Tablas.TipoMaquina { Tipo_Maquina = "Impresora", };
            //TipMaq.Maquinas.AddRange(new Tablas.Maquina[] {
            //            new Tablas.Maquina { NombreMaquina= "Schiavi", Velocidad=250, Decks=10},
            //            new Tablas.Maquina { NombreMaquina= "Windmoller", Velocidad=250, Decks=10}
            //        }
            //);

            //context.TiposMaquina.AddOrUpdate(
            //    t => t.Tipo_Maquina,
            //    TipMaq,
            //    new Tablas.TipoMaquina { Tipo_Maquina = "Laminadora" },
            //    new Tablas.TipoMaquina { Tipo_Maquina = "Refinadora" },
            //    new Tablas.TipoMaquina { Tipo_Maquina = "Selladora" },
            //    new Tablas.TipoMaquina { Tipo_Maquina = "Extrusora" },
            //    new Tablas.TipoMaquina { Tipo_Maquina = "Troqueladora" },
            //    new Tablas.TipoMaquina { Tipo_Maquina = "Bolseadora" },
            //    new Tablas.TipoMaquina { Tipo_Maquina = "Sanedora" }
            //    );

            //context.TiposProducto.AddOrUpdate(
            //    p => p.NombreTipoProducto,
            //    new Tablas.TipoProducto { NombreTipoProducto = "Pelicula" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Pelicula Laminada" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Pelicula Trilaminada" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "FlowPack Laminada" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "FlowPack Trilaminada" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral no Impresa" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Impresa" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Laminada no Impresa" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Laminada Impresa" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Sello Lateral Trilaminada" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Etiqueta" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "PVC" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Prototipos" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Piezas" },
            //    new Tablas.TipoProducto { NombreTipoProducto = "Etiqueta Tipo Manga" }
            //    );
            //context.SaveChanges();

            //var mat = new Tablas.FamiliaMateriales {  NombreFamilia = "BOPP" };
            //mat.Materiales.Add(new Tablas.Material { Apariencia = "Transparente", Densidad = 0.905 });

            //context.FamiliasMateriales.AddOrUpdate(t => t.NombreFamilia, mat);

            //context.SaveChanges();
            using (var writer = new System.Xml.XmlTextWriter(Environment.CurrentDirectory + @"\"+ System.Reflection.Assembly.GetExecutingAssembly().GetName().Name +  @"\Model.edmx", System.Text.Encoding.Default))  //System.AppDomain.CurrentDomain.BaseDirectory + @"\Model.edmx", System.Text.Encoding.Default))
            {
                System.Data.Entity.Infrastructure.EdmxWriter.WriteEdmx(context, writer);
            }
        }
    }
}
