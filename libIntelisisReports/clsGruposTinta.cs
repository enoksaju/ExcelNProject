using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libIntelisisReports
{
	public class GruposTinta
	{
		public class tintaItem
		{
			public string clave { get; set; }
			public int grupo { get; set; }
			public double factor { get; set; }
			public tintaItem ( string clave, int grupo, double factor )
			{
				this.clave = clave;
				this.grupo = grupo;
				this.factor = factor;
			}
		}

		public static List<tintaItem> getTintas ()
		{
			List<tintaItem> _list = new List<tintaItem> ( );

			DataTable table = new DataTable ( "item" );
			try
			{
				DataSet lstNode = new DataSet ( );
				lstNode.ReadXml ( "GruposTinta.xml" );
				table = lstNode.Tables[ "item" ];

				foreach ( DataRow row in table.Rows )
				{
					_list.Add ( new tintaItem (
						row[ "clave" ].ToString ( ),
						int.Parse ( row[ "grupo" ].ToString ( ) ),
						double.Parse ( row[ "factor" ].ToString ( ) )
						) );
				}

				return _list;
			}
			catch ( Exception e )
			{
				throw e;
			}

		}	
	}
}
