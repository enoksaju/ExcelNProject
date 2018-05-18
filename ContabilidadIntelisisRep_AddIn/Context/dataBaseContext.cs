using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadIntelisisRep_AddIn.Context {
	public class dataBaseContext : DbContext {
		public dataBaseContext ( ) : base ( "defaultConnection" ) {
			Configuration.LazyLoadingEnabled =true;
		}
		//public DbSet<Modelos.Cuentas> Cuentas { get; set; }

		//protected override void OnModelCreating ( DbModelBuilder modelBuilder ) {
		//	base.OnModelCreating ( modelBuilder );
			
		//	modelBuilder.Entity<Modelos.Cuentas> ( )
		//		.HasKey ( o => o.Cuenta )
		//		.HasMany ( o => o.SubCuentas )
		//		.WithOptional ( o => o.Cuenta_ )
		//		.HasForeignKey ( o => o.Rama );

		//	modelBuilder.Entity<Modelos.Cuentas> ( ).Map ( m => {
		//		m.ToTable ( "Cta" );
		//	} );
		//}
	}
}
