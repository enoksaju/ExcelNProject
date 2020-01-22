//#define DevelopDataBase

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Tablas;
using Microsoft.AspNet.Identity.EntityFramework;
using libProduccionDataBase.Identity;
using MySql.Data.EntityFramework;

namespace libProduccionDataBase.Contexto
{
	[DbConfigurationType ( typeof ( customEFConfiguration ) )]
	public class DataBaseContexto : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
	{
		public event EventHandler SavedChanges;

#if DevelopDataBase
		public DataBaseContexto () : base ( "ProduccionConexionDebug" )
#else
		public DataBaseContexto () :  base ( "ProduccionConexion" )
#endif
		{
			this.Configuration.LazyLoadingEnabled = true;
			Database.SetInitializer<DataBaseContexto> ( null );
		}

		public DataBaseContexto ( string DataBase ) : base ( DataBase )
		{
			this.Configuration.LazyLoadingEnabled = true;
			Database.SetInitializer<DataBaseContexto> ( null );
		}

		public static DataBaseContexto Create () => new DataBaseContexto ( );
		public static DataBaseContexto Create ( string DataBase ) => new DataBaseContexto ( DataBase);
		protected override void OnModelCreating ( DbModelBuilder modelBuilder )
		{
			modelBuilder.Entity<ApplicationUserLogin> ( )
				.HasKey ( l => new { l.LoginProvider, l.ProviderKey, l.UserId } )
				.ToTable ( "Z_UserLogin" );

			modelBuilder.Entity<ApplicationUserRole> ( )
				.HasKey ( r => new { r.UserId, r.RoleId } )
				.ToTable ( "Z_UsuariosRoles" );

			modelBuilder.Entity<ApplicationUserClaim> ( ).ToTable ( "Z_UsuariosClaims" );

			modelBuilder.Entity<ApplicationRole> ( ).ToTable ( "Z_Roles" );
			modelBuilder.Entity<ApplicationRole> ( ).HasMany ( c => c.Users ).WithRequired ( ).HasForeignKey ( c => c.RoleId );

			modelBuilder.Entity<ApplicationUser> ( ).ToTable ( "Z_Usuarios" );
			modelBuilder.Entity<ApplicationUser> ( ).HasMany ( c => c.Logins ).WithOptional ( ).HasForeignKey ( c => c.UserId );
			modelBuilder.Entity<ApplicationUser> ( ).HasMany ( c => c.Claims ).WithOptional ( ).HasForeignKey ( c => c.UserId );
			modelBuilder.Entity<ApplicationUser> ( ).HasMany ( c => c.Roles ).WithOptional ( ).HasForeignKey ( c => c.UserId );


			modelBuilder.Entity<TFamiliaDefectosTDefecto> ( )
			  .HasKey ( t => t.Id );

			modelBuilder.Entity<TFamiliaDefectosTDefecto> ( )
			  .HasRequired ( t => t.Defecto )
			  .WithMany ( y => y.TFamiliaDefectosTDefecto )
			  .HasForeignKey ( c => c.TDefectoID );

			modelBuilder.Entity<TFamiliaDefectosTDefecto> ( )
			  .HasRequired ( t => t.FamiliaDefectos )
			  .WithMany ( y => y.TFamiliaDefectosTDefecto )
			  .HasForeignKey ( c => c.TFamiliaDefectosID );



			//modelBuilder.Entity<Tablas.Cotizador.Cotizacion> ( ).HasMany ( y => y ).WithOptional ( ).WillCascadeOnDelete ( false );
			//modelBuilder.Entity<Tablas.Cotizador.Cotizacion> ( ).HasRequired ( u => u.Cliente ).WithMany ( ).WillCascadeOnDelete ( false );
			//modelBuilder.Entity<Tablas.Cotizador.Cotizacion> ( ).HasRequired ( u => u.Agente ).WithMany ( ).WillCascadeOnDelete ( false );
			//modelBuilder.Entity<Tablas.Cotizador.CotizacionDetalle> ( ).HasRequired ( u => u.MaterialBase ).WithMany ( ).WillCascadeOnDelete ( false );

			//modelBuilder.Entity<Tablas.Cotizador.Cotizacion> ( ).HasMany ( y => y.Items ).WithRequired ( y => y.Cotizacion ).HasForeignKey ( u => u.Cotizacion_Id );


		}

		public override int SaveChanges ()
		{
			var t = base.SaveChanges ( );
			OnSavedChanges ( this, null );
			return t;
		}

		public int SavechangesWithSender ( object sender )
		{
			var t = base.SaveChanges ( );
			OnSavedChanges ( sender, null );
			return t;
		}

		public async Task<int> SaveChangesWithSender ( object sender )
		{

			var t = await base.SaveChangesAsync ( );

			OnSavedChanges ( sender, null );

			return t;
		}

		private void OnSavedChanges ( object sender, EventArgs e )
		{
			SavedChanges?.Invoke ( sender, e );
		}

		#region DbSets
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
		public DbSet<MovimientoPrecio> MovimientosPrecioFamiliaMateriales { get; set; }
		public DbSet<Proceso> Procesos { get; set; }
		public DbSet<TemporalOrdenTrabajo> tempOt { get; set; }
		public DbSet<TEMPCAPT> TEMPCAPT { get; set; }
		public DbSet<TempProduccion> TempProduccion { get; set; }
		public DbSet<TDefecto> TDefectos { get; set; }
		public DbSet<TFamiliaDefectos> TFamiliasDefectos { get; set; }
		public DbSet<TFamiliaDefectosTDefecto> FamiliaDefectosDefectos { get; set; }
		public DbSet<TempDesperdicios> TDesperdicios { get; set; }


		public DbSet<NaveCuatro_Tarima> NCuatro_Tarimas { get; set; }
		public DbSet<NaveCuatro_TarimaItem> NCuatro_Tarima_Items { get; set; }



		public DbSet<ProveedorTinta> ProveedoresTinta { get; set; }
		public DbSet<ArticuloTinta> ArticulosTintas { get; set; }
		public DbSet<EntradaTinta> EntradasTintas { get; set; }
		public DbSet<SalidaTinta> SalidasTintas { get; set; }
		public DbSet<TiposTinta> TiposTinta { get; set; }

		public DbSet<Tinta> Tintas { get; set; }
		public DbSet<Otro> Otros { get; set; }


		// Control de Residuos Peligrosos
		public DbSet<TipoRP> TiposRP { get; set; }
		public DbSet<Transportista> Transportistas { get; set; }
		public DbSet<Proveedor> Proveedores { get; set; }
		public DbSet<Manifiesto> Manifiestos { get; set; }
		public DbSet<ManifiestoDetalle> ManifiestosDetalle { get; set; }
		public DbSet<SalidaRP> SalidasRP { get; set; }

		/// <summary>
		/// Coleccion de etiquetas en formato zpl
		/// </summary>
		public DbSet<Etiqueta> Etiquetas { get; set; }



		// Cotizaciones
		public virtual DbSet<Tablas.Cotizador.Cotizacion> Cotizaciones { get; set; }
		public virtual DbSet<Tablas.Cotizador.CotizacionDetalle> Cotizacion_Detalle_Items { get; set; }


		#endregion
	}

}
