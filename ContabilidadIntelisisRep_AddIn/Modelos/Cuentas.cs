using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContabilidadIntelisisRep_AddIn.Modelos {
	public class Cuentas {
		private ObservableCollection<Cuentas> _SubCuentas;
		public Cuentas ( ) {
			this._SubCuentas = new ObservableCollection<Cuentas> ( );
		}
		public string Cuenta { get; set; }
		public string Rama { get; set; }
		public string Descripcion { get; set; }
		public string Tipo { get; set; }
		public virtual Cuentas Cuenta_ { get; set; }
		public virtual ObservableCollection<Cuentas> SubCuentas {			get; set;		}
		//get {
		//	if ( Rama?.Trim ( ) == "X" )
		//		_SubCuentas.Clear ( );
		//	return _SubCuentas;
		//}
		//set {
		//	_SubCuentas = value;
		//	if ( Rama?.Trim ( ) == "X" )
		//		_SubCuentas.Clear ( );
		//}
		//}
	}

	public class ObservableListSource<T> : ObservableCollection<T>, IListSource where T : class {
		private IBindingList _bindingList;
		bool IListSource.ContainsListCollection => false;
		IList IListSource.GetList ( ) => _bindingList ?? ( _bindingList = this.ToBindingList ( ) );
	}
}
