using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryMySQLTransactions.Model
{
	[DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
	public class DataBaseContext : DbContext
	{
		public virtual DbSet<Car> Cars { get; set; }
		public DataBaseContext () : base ( "tryMySQLTransactions.Properties.Settings.defaultConnection" ) { }
		public DataBaseContext ( DbConnection existingConnection, bool contextOwnsConnection ) : base ( existingConnection, contextOwnsConnection ) { }
		protected override void OnModelCreating ( DbModelBuilder modelBuilder )
		{
			base.OnModelCreating ( modelBuilder );
		}

	}

	public class Car
	{
		public int CarId { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public string Manufacturer { get; set; }
		public int numberOfDoors { get; set; }
	}
}
