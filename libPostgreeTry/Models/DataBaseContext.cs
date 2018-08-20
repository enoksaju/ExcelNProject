using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libPostgreeTry.Models
{
	public class DataBaseContext : DbContext
	{
		public DataBaseContext () : base ( "defaultConnection" ) { }
		protected override void OnModelCreating ( DbModelBuilder modelBuilder )
		{
			modelBuilder.HasDefaultSchema ( "public" );
			base.OnModelCreating ( modelBuilder );
		}

		public virtual DbSet<Master> Masters { get; set; }
		public virtual DbSet<Child> Childs { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
	}

	public class Master
	{
		public int MasterId { get; set; }
		public string Nombre { get; set; }
		public virtual ICollection<Child> Childs { get; set; }
		public int? CustomerId { get; set; }
	}

	public class Child
	{
		public int ChildId { get; set; }
		public int MasterId { get; set; }
		public double Amount { get; set; }
	}

	[Table("customers", Schema ="admin")]
	public class Customer
	{
		public int Id { get; set; }
		[MaxLength(100)]
		public string Nombre { get; set; }
		public virtual ICollection<Master> Masters { get; set; }
	}
}
