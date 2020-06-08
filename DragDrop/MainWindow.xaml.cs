using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
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
using System.Windows.Threading;
using MahApps.Metro.Controls;

namespace DragDrop
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		static string Token;
		public MainWindow ()
		{
			InitializeComponent ( );

		}



		static async Task<T> Get<T> ( string path )
		{
			T ret = default ( T );
			using ( HttpClientHandler handler = new HttpClientHandler ( ) { SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls } )
			{
				using ( HttpClient client = new HttpClient ( handler ) )
				{
					client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue ( "Bearer", Token );
					try
					{
						HttpResponseMessage response = await client.GetAsync ( path );
						response.EnsureSuccessStatusCode ( );
						ret = await response.Content.ReadAsAsync<T> ( );
					}
					catch ( HttpRequestException e )
					{
						Console.WriteLine ( "\nException Caught!" );
						Console.WriteLine ( "Message :{0} ", e.Message );
					}

					return ret;
				}
			}
		}



		private async void Button_Click ( object sender, RoutedEventArgs e )
		{
			Token = "61BYm_uJN3XppYPpliEionNf-ZdBDJiBR7qaDnW95y-ob0Spfgkdrt-ZAQuCgYicYbJo_FirMcWlRB1Uc9_ACgFGsgWUcJsgHyapXBVIt2BhVOB6DzLp-bZxMVRIxm6NsnpE1ibBavwk8M9y_VK291MwHtDp8d7XQXYBH1qCKNO1meBBEBN8XnMwRAw_BWhJDkf-4XGT5WGDlQuxSjCoFw6qmgXioUX31VswRg1z20HcPlxIb49lTfJi9Avvjufj6DxnXWuhzTkt3pSytyPH_b_8sLS7x59aje4XzIyatrFZLV_cac6f-jWkvwCIywUv1ocW6Dxm9TTHIkNJM7zXD45AqJ5BEYeDkw2swcbFSFMc40_jCpC3PrtG18P-0ZGPpfu2HDo_1r0H_947BS_w2uh54WFfKuFIw76s1EBa5kRoGRl5fauEvnL0MP_oGKRejhKWZnxZ3Y-mEtlJzrbEWYq9rOZksCvj_3NOSZgkzrw";
			string[] t = await Get<string[]> ( "http://localhost:52350/api/Values" );
		}
	}
}
