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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace ControlProgramaProduccion.Controles.CommonDialogs
{
	/// <summary>
	/// Lógica de interacción para MessageWindows.xaml
	/// </summary>
	public partial class MessageWindows : MetroWindow
	{
		public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register ( "Caption", typeof ( string ), typeof ( MessageWindows ), new PropertyMetadata ( "Message" ) );
		public string Caption
		{
			get
			{
				return (string)GetValue ( CaptionProperty );
			}
			set
			{
				SetValue ( CaptionProperty, value );
			}
		}

		public static readonly DependencyProperty PrompProperty = DependencyProperty.Register ( "Promp", typeof ( string ), typeof ( MessageWindows ), new PropertyMetadata ( "" ) );
		public string Promp
		{
			get
			{
				return (string)GetValue ( PrompProperty );
			}
			set
			{
				SetValue ( PrompProperty, value );
			}
		}

		public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register ( "Buttons", typeof ( MessageBoxButton ), typeof ( MessageWindows ), new PropertyMetadata ( MessageBoxButton.OK ) );
		public MessageBoxButton Buttons
		{
			get
			{
				return (MessageBoxButton)GetValue ( ButtonsProperty );
			}
			set
			{
				SetValue ( ButtonsProperty, value );

			}
		}

		public static readonly DependencyProperty ImageProperty = DependencyProperty.Register ( "Icon", typeof ( MessageBoxImage ), typeof ( MessageWindows ), new PropertyMetadata ( MessageBoxImage.None ) );
		public MessageBoxImage Image
		{
			get { return (MessageBoxImage)GetValue ( ImageProperty ); }
			set {
				SetValue ( ImageProperty, value );

				switch ( value )
				{
					case MessageBoxImage.Error:
						this.Icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircle;
						this.Icon.Foreground = Brushes.Red;
						break;
					case MessageBoxImage.Exclamation:
						this.Icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Warning;
						this.Icon.Foreground = new SolidColorBrush ( Color.FromRgb ( 255, 180, 0 ) );  
						break;
					case MessageBoxImage.None:
						this.Icon.Visibility= Visibility.Collapsed;
						break;
					case MessageBoxImage.Question:
						this.Icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Help;
						break;
					default:
						this.Icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.InfoCircleOutline;
						break;
				}	
			}
		}

		public MessageBoxResult Result { get; set; }

		public MessageWindows ()
		{
			InitializeComponent ( );
			DataContext = this;
			this.SizeToContent = SizeToContent.WidthAndHeight;
		}

		private void OkButton_Click ( object sender, RoutedEventArgs e )
		{
			Result = MessageBoxResult.OK;
			this.Close ( );
		}
		private void CancelButton_Click ( object sender, RoutedEventArgs e )
		{
			Result = MessageBoxResult.Cancel;
			this.Close ( );
		}
		private void YesButton_Click ( object sender, RoutedEventArgs e )
		{
			Result = MessageBoxResult.Yes;
			this.Close ( );
		}
		private void NoButton_Click ( object sender, RoutedEventArgs e )
		{
			Result = MessageBoxResult.No;
			this.Close ( );
		}
	}

	public static class MaterialMessageBox
	{
		public static MessageBoxResult ShowDialog ( string promp, string caption, MessageBoxButton buttons, MessageBoxImage image )
		{
			var frm = new MessageWindows ( ) { Promp = promp, Caption = caption, Buttons = buttons, Image = image };
			frm.ShowDialog ( );
			return frm.Result;
		}
		public static MessageBoxResult ShowDialog ( object owner, string promp, string caption, MessageBoxButton buttons, MessageBoxImage image )
		{			
			var frm = new MessageWindows ( ) { Promp = promp, Caption = caption, Buttons = buttons, Image = image, Owner = getOwner ( owner ) };
			frm.ShowDialog ( );
			return frm.Result;
		}

		public static MessageBoxResult ShowDialog ( string promp, string caption, MessageBoxButton buttons )
		{
			var frm = new MessageWindows ( ) { Promp = promp, Caption = caption, Buttons = buttons, Image = MessageBoxImage.None };
			frm.ShowDialog ( );
			return frm.Result;
		}
		public static MessageBoxResult ShowDialog ( object owner, string promp, string caption, MessageBoxButton buttons )
		{
			var frm = new MessageWindows ( ) { Promp = promp, Caption = caption, Buttons = buttons, Image = MessageBoxImage.None,  Owner = getOwner ( owner ) };
			frm.ShowDialog ( );
			return frm.Result;
		}

		public static MessageBoxResult ShowDialog ( string promp, string caption )
		{
			var frm = new MessageWindows ( ) { Promp = promp, Caption = caption, Buttons = MessageBoxButton.OK, Image = MessageBoxImage.None };
			frm.ShowDialog ( );
			return frm.Result;
		}
		public static MessageBoxResult ShowDialog ( object owner, string promp, string caption )
		{
			var frm = new MessageWindows ( ) { Promp = promp, Caption = caption, Buttons = MessageBoxButton.OK, Image = MessageBoxImage.None, Owner = getOwner(owner)};
			frm.ShowDialog ( );
			return frm.Result;
		}

		private static Window getOwner (object  owner )
		{
			var dpo = owner as DependencyObject;
			var wpo = owner as Window;

			if(dpo != null )
			{
				return Window.GetWindow ( dpo );
			}else if(wpo != null )
			{
				return wpo;
			}else
			{
				throw new Exception ("No se pudo encontrar la ventana" );
			}
		}

	}
}
