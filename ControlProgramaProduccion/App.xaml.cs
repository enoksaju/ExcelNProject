using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace ControlProgramaProduccion
{
	/// <summary>
	/// Lógica de interacción para App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup ( object sender, StartupEventArgs e )
		{
			FrameworkElement.LanguageProperty.OverrideMetadata (
				   typeof ( FrameworkElement ),
				   new FrameworkPropertyMetadata ( XmlLanguage.GetLanguage ( CultureInfo.CurrentCulture.IetfLanguageTag ) ) );

			Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
		}

		private async void Current_DispatcherUnhandledException ( object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e )
		{
			e.Handled = true;
#if DEBUG
			System.Diagnostics.Debug.WriteLine ( e.Exception.StackTrace, "Unhandled error" );
#endif
			var view = new Controles.CommonDialogs.ErrorDialog ( ) { Promp = $"{e.Exception.Message}", Title = "Excepcion no controlada, algo va mal!"};			
			var t = (bool)await MaterialDesignThemes.Wpf.DialogHost.Show ( view, "RootDialog" );


		}
	}
}
