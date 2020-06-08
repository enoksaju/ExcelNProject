using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlProgramaProduccion.ViewModels
{
	internal class MainWindowModelView
	{
		private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem> ( );
		private static readonly ObservableCollection<MenuItem> AppOptionsMenu = new ObservableCollection<MenuItem> ( );
		public static Controles.Calendario.ViewModels.CalendarViewModel CalendarioModelView { get; private set; }

		public ObservableCollection<MenuItem> Menu => AppMenu;
		public ObservableCollection<MenuItem> OptionsMenu => AppOptionsMenu;
		
		
		public MainWindowModelView ()
		{
			CalendarioModelView = new Controles.Calendario.ViewModels.CalendarViewModel ( );

			this.Menu.Add ( new MenuItem ( ) { Icon = new MaterialDesignThemes.Wpf.PackIcon ( ) { Kind = MaterialDesignThemes.Wpf.PackIconKind.Home }, Text = "Inicio", NavigationDestination = new Uri ( "Views/HomePage.xaml", UriKind.RelativeOrAbsolute ) } );

			this.Menu.Add ( new MenuItem ( ) { Icon = new MaterialDesignThemes.Wpf.PackIcon ( ) { Kind = MaterialDesignThemes.Wpf.PackIconKind.CalendarToday }, Text = "Calendario Semanal", NavigationDestination = new Uri ( "Views/CalendarioSemanalPage.xaml", UriKind.RelativeOrAbsolute ) } );

		}
		public object GetItem ( object uri )
		{
			return null == uri ? null : this.Menu.FirstOrDefault ( m => m.NavigationDestination.Equals ( uri ) );

		}

		public object GetOptionsItem ( object uri )
		{
			return null == uri ? null : this.OptionsMenu.FirstOrDefault ( m => m.NavigationDestination.Equals ( uri ) );
		}

	}
}
