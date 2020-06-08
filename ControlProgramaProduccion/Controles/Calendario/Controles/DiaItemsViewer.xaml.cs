using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ControlProgramaProduccion.Controles.DataBaseViewModels;

namespace ControlProgramaProduccion.Controles.Calendario.Controles
{
	/// <summary>
	/// Lógica de interacción para DiaItemsViewer.xaml
	/// </summary>
	public partial class DiaItemsViewer : UserControl
	{

		public DiaItemsViewer ()
		{
			InitializeComponent ( );
		}

		private void ItemsContainer_ListBox_SelectionChanged ( object sender, SelectionChangedEventArgs e )
		{
			if ( DataContext != null && e.AddedItems.Count > 0 ) ( (ViewModels.DiaViewModel)DataContext ).SetIsSelected ( (PlaneacionProduccionViewModel)e.AddedItems[ 0 ] );

			( (ListBox)sender ).UnselectAll ( );
		}

		private void Button_Click ( object sender, RoutedEventArgs e )
		{
			( (ViewModels.DiaViewModel)DataContext ).ShowEdit ( (PlaneacionProduccionViewModel)( ( (Button)sender ).Tag ) );
		}

	}
}
