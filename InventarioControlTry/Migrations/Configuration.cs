namespace InventarioControlTry.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<InventarioControlTry.Models.DbInventarioContexto>
	{
		public Configuration ()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed ( InventarioControlTry.Models.DbInventarioContexto context )
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.


			context.Database.ExecuteSqlCommand ( @"
DROP FUNCTION IF EXISTS `gramaje`;

CREATE DEFINER=`root`@`%` FUNCTION `gramaje`(calibre double, familiaMaterial varchar(10)) RETURNS double
    DETERMINISTIC
BEGIN

DECLARE densidad double;

case familiaMaterial
	when 'BOPP' THEN SET densidad = 0.905;
    when 'PET' THEN SET densidad = 1.38;
    when 'PEBD' OR 'PE' THEN SET densidad = 0.925;
    else set densidad= 0;
end case;


RETURN round(densidad * calibre, 3);
END

" );

			context.Rollos.AddOrUpdate ( t => t.RolloId,
				new Models.RolloMatPrima ( ) { RolloId = 1, OT = "00000", FamiliaMateriales = "BOPP", Apariencia = "Transparente", Calibre = 15, Ancho = 110, PesoBruto = 200.5, FechaRegistro = DateTime.Now, ToProcess="PI0" },
				new Models.RolloMatPrima ( ) { RolloId = 2, OT = "00001", FamiliaMateriales = "BOPP", Apariencia = "Transparente", Calibre = 20, Ancho = 115, PesoBruto = 300.5, FechaRegistro = DateTime.Now, ToProcess = "PI0" },
				new Models.RolloMatPrima ( ) { RolloId = 3, OT = "00000", FamiliaMateriales = "PET", Apariencia = "Transparente", Calibre = 12, Ancho = 110, PesoBruto = 280.5, FechaRegistro = DateTime.Now, ToProcess = "PL1" },
				new Models.RolloMatPrima ( ) { RolloId = 4, OT = "00001", FamiliaMateriales = "PET", Apariencia = "Transparente", Calibre = 12, Ancho = 120, PesoBruto = 200.5, FechaRegistro = DateTime.Now, ToProcess = "PL1" },
				new Models.RolloMatPrima ( ) { RolloId = 5, OT = "00000", FamiliaMateriales = "PE", Apariencia = "L-1200", Calibre = 50, Ancho = 110, PesoBruto = 450.5, FechaRegistro = DateTime.Now, ToProcess = "PL2" },
				new Models.RolloMatPrima ( ) { RolloId = 6, OT = "00001", FamiliaMateriales = "PE", Apariencia = "T-3000", Calibre = 76, Ancho = 105, PesoBruto = 520.5, FechaRegistro = DateTime.Now, ToProcess = "PL2" }
				);


		}
	}
}
