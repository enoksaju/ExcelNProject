using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Tablas;

namespace libProduccionDataBase.Contexto
{
    public class DataBaseContexto : DbContext
    {
        public DbSet<FamiliaMateriales> FamiliasMateriales { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Rodillo> Rodillos { get; set; }
        public DbSet<TipoProducto> TiposProducto { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<TipoMaquina> TiposMaquina { get; set; }
        public DbSet<OrdenTrabajo> OrdenesTrabajo { get; set; }
        public DbSet<Produccion> Produccion { get; set; }
        public DbSet<Desperdicio> Despedicios { get; set; }
        public DbSet<Defecto> Defectos { get; set; }
        public DbSet<FamiliaDefectos> FamiliasDefectos { get; set; }
        public DataBaseContexto() : base("ProduccionConexion") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.ManyToManyCascadeDeleteConvention>();

           
        }
    }  
      
}
