using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas
{
	[Table ( "Try_Master" )]
	public class Master
	{
		[Key, DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
		public int MasterId { get; set; }
		[Index ( IsUnique = true ), MaxLength ( 250 )]
		public string Nombre { get; set; }
		public string OtherProperty { get; set; }
		public virtual ObservableListSource<Child> Childs { get; set; } = new ObservableListSource<Child> ( );
	}
	[Table ( "Try_Child" )]
	public class Child
	{
		[Key, Column ( Order = 1 )]
		public int ChildId { get; set; }
		[Key, Column ( Order = 0 )]
		public int MasterId { get; set; }
		public string Desc { get; set; }
		public double cant { get; set; }

		[Index ( "myIndex", Order = 0 )]
		public int Region { get; set; }
		[Index ( "myIndex", Order = 1 )]
		public int Pais { get; set; }
	}
}
