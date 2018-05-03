using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libReportesContabilidadIntelisis.Context {
	public class dataBaseContext:DbContext {
		public dataBaseContext ( ) : base ( "defaultConnection" ) { }
	}
}
