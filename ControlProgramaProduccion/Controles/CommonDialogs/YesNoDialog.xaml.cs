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

namespace ControlProgramaProduccion.Controles.CommonDialogs
{
	/// <summary>
	/// Lógica de interacción para YesNoDialog.xaml
	/// </summary>
	public partial class YesNoDialog : UserControl
	{
		public YesNoDialog ()
		{
			InitializeComponent ( );
			RootBinding.DataContext = this;
			System.Media.SystemSounds.Question.Play ( );
		}

		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register ( "Title", typeof ( string ), typeof ( YesNoDialog ), new PropertyMetadata ( "" ) );
		public string Title
		{
			get { return (string)GetValue ( TitleProperty ); }
			set { SetValue ( TitleProperty, value ); }
		}

		public static readonly DependencyProperty PrompProperty = DependencyProperty.Register ( "Promp", typeof ( string ), typeof ( YesNoDialog ), new PropertyMetadata ( "" ) );
		public string Promp
		{
			get { return (string)GetValue ( PrompProperty ); }
			set { SetValue ( PrompProperty, value ); }
		}
	}
}
