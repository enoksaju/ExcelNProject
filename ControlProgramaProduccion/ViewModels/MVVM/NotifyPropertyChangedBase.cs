using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlProgramaProduccion.ViewModels
{

		public class NotifyPropertyChangedBase : INotifyPropertyChanged
		{
			#region Imprement PropertyChanged

			public event PropertyChangedEventHandler PropertyChanged;
			protected void OnPropertyChange ( [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "" )
			{
				PropertyChanged?.Invoke ( this, new PropertyChangedEventArgs ( propertyName ) );
			}

			#endregion
		}
	
}
