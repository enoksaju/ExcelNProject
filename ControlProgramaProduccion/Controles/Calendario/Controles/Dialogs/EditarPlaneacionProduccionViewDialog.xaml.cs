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
using MaterialDesignThemes.Wpf;

namespace ControlProgramaProduccion.Controles.Calendario.Controles.Dialogs
{
	/// <summary>
	/// Lógica de interacción para EditarPlaneacionProduccionViewDialog.xaml
	/// </summary>
	public partial class EditarPlaneacionProduccionViewDialog : UserControl
	{
		private static List<libProduccionDataBase.Tablas.Maquina> Maquinas;
		public EditarPlaneacionProduccionViewDialog ()
		{
			InitializeComponent ( );
			MaquinasCMB.SelectedValuePath = "Id";
			MaquinasCMB.DisplayMemberPath = "NombreMaquina";
			if ( !System.ComponentModel.DesignerProperties.GetIsInDesignMode ( this ) )
			{
				if ( Maquinas == null )
				{
					using ( var DB = new libProduccionDataBase.Contexto.DataBaseContexto ( ) )
					{
						Maquinas = DB.Maquinas.ToList ( );

					}
				}
			}
		}

		private void UserControl_Loaded ( object sender, RoutedEventArgs e )
		{
			var u = this.DataContext as DataBaseViewModels.PlaneacionProduccionViewModel;
			MaquinasCMB.ItemsSource = Maquinas.Where ( o => o.Procesos.HasFlag ( u.Entity.TipoProceso ) );
			//MaquinasCMB.SelectedValue = u.Entity.MaquinaId;
		}

		private async void Button_Click ( object sender, RoutedEventArgs e )
		{
			var o = await MaterialDesignThemes.Wpf.DialogHost.Show ( new CommonDialogs.YesNoDialog ( ) { Title = "Guardar?", Promp = "Realmente desea guardar los cambios?" }, "EditPlaneacionProgramaDialogHost" );
			if ( (bool)o )
			{
				DialogHost.CloseDialogCommand.Execute ( o, null );
			}
		}

	}
}
