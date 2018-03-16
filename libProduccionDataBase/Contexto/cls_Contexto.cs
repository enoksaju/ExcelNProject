using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Tablas;
using Microsoft.AspNet.Identity.EntityFramework;
using libProduccionDataBase.Identity;

namespace libProduccionDataBase.Contexto
{
    [DbConfigurationType( typeof( MySql.Data.Entity.MySqlEFConfiguration ) )]
    public class DataBaseContexto : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public event EventHandler SavedChanges;

        public DbSet<FamiliaMateriales> FamiliasMateriales { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Rodillo> Rodillos { get; set; }
        public DbSet<TipoProducto> TiposProducto { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<TipoMaquina> TiposMaquina { get; set; }
        public DbSet<OrdenTrabajo> OrdenesTrabajo { get; set; }
        public DbSet<Produccion> Produccion { get; set; }
        public DbSet<Desperdicio> Despedicios { get; set; }
        public DbSet<Defecto> Defectos { get; set; }
        public DbSet<FamiliaDefectos> FamiliasDefectos { get; set; }
        public DbSet<Proceso> Procesos { get; set; }

		public DbSet<TemporalOrdenTrabajo> tempOt { get; set; }
		public DbSet<TEMPCAPT> TEMPCAPT { get; set; }
		public DbSet <TempProduccion > TempProduccion { get; set; }

		/// <summary>
		/// Coleccion de etiquetas en formato zpl
		/// </summary>
		public DbSet<Etiqueta> Etiquetas { get; set; }

#if DEBUG
		public DataBaseContexto() : base( "ProduccionConexionDebug" )
        {
            this.Configuration.LazyLoadingEnabled = true;		
        }
#else
		public DataBaseContexto() : base( "ProduccionConexion" )
        {
            this.Configuration.LazyLoadingEnabled = true;		
        }
#endif

		public static DataBaseContexto Create() { return new DataBaseContexto(); }
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            //  modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();
            //  modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.ManyToManyCascadeDeleteConvention>();       

            modelBuilder.Entity<ApplicationUserLogin>()
                .HasKey( l => new { l.LoginProvider, l.ProviderKey, l.UserId } )
                .ToTable( "Z_UserLogin" );

            modelBuilder.Entity<ApplicationUserRole>()
                .HasKey( r => new { r.UserId, r.RoleId } )
                .ToTable( "Z_UsuariosRoles" );

            modelBuilder.Entity<ApplicationUserClaim>().ToTable( "Z_UsuariosClaims" );

            modelBuilder.Entity<ApplicationRole>().ToTable( "Z_Roles" );
            modelBuilder.Entity<ApplicationRole>().HasMany( c => c.Users ).WithRequired().HasForeignKey( c => c.RoleId );

            modelBuilder.Entity<ApplicationUser>().ToTable( "Z_Usuarios" );
            modelBuilder.Entity<ApplicationUser>().HasMany( c => c.Logins ).WithOptional().HasForeignKey( c => c.UserId );
            modelBuilder.Entity<ApplicationUser>().HasMany( c => c.Claims ).WithOptional().HasForeignKey( c => c.UserId );
            modelBuilder.Entity<ApplicationUser>().HasMany( c => c.Roles ).WithOptional().HasForeignKey( c => c.UserId );
        }

        public override int SaveChanges()
        {
            var t= base.SaveChanges();
            OnSavedChanges( this, null );
            return t;
        }

        public int SavechangesWithSender( object sender )
        {
            var t= base.SaveChanges();
            OnSavedChanges( sender, null );
            return t;
        }

        public async Task<int> SaveChangesWithSender( object sender ) {

            var t= await base.SaveChangesAsync();

            OnSavedChanges( sender, null );

            return t;
        }

        private void OnSavedChanges( object sender, EventArgs e )
        {
            SavedChanges?.Invoke( sender, e );
        }
    }

}
