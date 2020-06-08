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

namespace ControlProgramaProduccion.Controles.Calendario.Controles
{
	/// <summary>
	/// Lógica de interacción para SemanaViewer.xaml
	/// </summary>
	public partial class SemanaViewer : UserControl
	{
		DateTime _lastDragOver;
		ViewModels.CalendarViewModel ModelView;

		public SemanaViewer ()
		{
			InitializeComponent ( );
		}
		private void Button_DragOver ( object sender, DragEventArgs e )
		{
			int seconds = 800;


			if ( DateTime.Now.Subtract ( _lastDragOver ).Milliseconds > seconds )
			{
				_lastDragOver = DateTime.Now;
				if ( sender == MoveNextWeekButton )
				{
					ModelView.MoveNextWeek ( );
				}
				else if ( sender == MovePreviusWeekButton )
				{
					ModelView.MovePreviusWeek ( );
				}
				else if ( sender == MoveCurrentWeekButton )
				{
					ModelView.MoveThisWeek ( );
				}
			}
		}

		private void UserControl_DataContextChanged ( object sender, DependencyPropertyChangedEventArgs e )
		{
			var y = DataContext as Calendario.ViewModels.CalendarViewModel;

			if ( y != null && ModelView == null )
			{
				ModelView = y;
			}
		}

	}
}
