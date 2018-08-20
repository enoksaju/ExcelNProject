namespace libPostgreeTry.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using Models;

	internal sealed class Configuration : DbMigrationsConfiguration<DataBaseContext>
	{
		public Configuration ()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed ( DataBaseContext context )
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.

			context.Masters.AddOrUpdate ( o => o.Nombre, new Master ( )
			{
				Nombre = "Henoc",
				Childs = new Child[] {
					new Child ( ) { Amount= 12.5},
					new Child ( ) { Amount= 24.5},
					new Child ( ) { Amount= 16.8}
				}
			} );
		}
	}
}
