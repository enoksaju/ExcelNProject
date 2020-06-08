using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ControlProgramaProduccion;
using MahApps.Metro.Controls;

namespace ControlProgramaProduccion.ViewModels
{
	internal class MenuItem : HamburgerMenuItem, INotifyPropertyChanged
	{
		private object _icon;
		private string _text;
		private bool _isEnabled = true;
		private CommandHandler _command;
		private Uri _navigationDestination;

		public object Icon
		{
			get { return this._icon; }
			set { this.SetProperty ( ref this._icon, value ); }
		}

		public string Text
		{
			get { return this._text; }
			set { this.SetProperty ( ref this._text, value ); }
		}

		public new bool IsEnabled
		{
			get { return this._isEnabled; }
			set { this.SetProperty ( ref this._isEnabled, value ); }
		}

		public new ICommand Command
		{
			get { return this._command; }
			set { this.SetProperty ( ref this._command, (CommandHandler)value ); }
		}

		public Uri NavigationDestination
		{
			get { return this._navigationDestination; }
			set { this.SetProperty ( ref this._navigationDestination, value ); }
		}

		public bool IsNavigation => this._navigationDestination != null;

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged ( [CallerMemberName] string propertyName = null )
		{
			PropertyChanged?.Invoke ( this, new PropertyChangedEventArgs ( propertyName ) );
		}

		protected bool SetProperty<T> ( ref T storage, T value, [CallerMemberName] string propertyName = null )
		{
			if ( Equals ( storage, value ) ) return false;
			storage = value;
			this.OnPropertyChanged ( propertyName );
			return true;
		}
	}
}
