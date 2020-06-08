using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlProgramaProduccion.ViewModels;
using MahApps.Metro.Controls;

namespace ControlProgramaProduccion
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow ()
		{
			DataContext = new MainWindowModelView ( );
			InitializeComponent ( );



			Navigation.Frame = new Frame ( ) { NavigationUIVisibility = NavigationUIVisibility.Hidden };
			Navigation.Frame.Navigated += SplitViewFrame_OnNavigated;
			this.HamburgerMenuControl.Content = Navigation.Frame;

			// Navigate to the home page.
			this.Loaded += ( sender, args ) => Navigation.Navigate ( new Uri ( "Views/HomePage.xaml", UriKind.RelativeOrAbsolute ) );


		}
		private void SplitViewFrame_OnNavigated ( object sender, NavigationEventArgs e )
		{
			//            this.HamburgerMenuControl.Content = e.Content;
			this.HamburgerMenuControl.SelectedItem = e.ExtraData ?? ( (MainWindowModelView)this.DataContext ).GetItem ( e.Uri );
			this.HamburgerMenuControl.SelectedOptionsItem = e.ExtraData ?? ( (MainWindowModelView)this.DataContext ).GetOptionsItem ( e.Uri );
			GoBackButton.Visibility = Navigation.Frame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
		}
		private void GoBack_OnClick ( object sender, RoutedEventArgs e )
		{
			Navigation.GoBack ( );
			
		}

		private void HamburgerMenuControl_OnItemInvoked ( object sender, HamburgerMenuItemInvokedEventArgs e )
		{
			var menuItem = e.InvokedItem as ViewModels.MenuItem;
			if ( menuItem != null && menuItem.IsNavigation )
			{
				Navigation.Navigate ( menuItem.NavigationDestination, menuItem );
			}
		}
	}
}
