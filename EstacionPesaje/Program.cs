using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using libProduccionDataBase;
using libProduccionDataBase.Identity;
using Microsoft.AspNet.Identity;

namespace EstacionPesaje {
	static class Program {

		//[DllImport ( "gdi32.dll" , EntryPoint = "AddFontResourceW" , SetLastError = true )]
		//public static extern int AddFontResource ( [In][MarshalAs ( UnmanagedType.LPWStr )] string lpFileName );

		//[DllImport ( "gdi32.dll" , EntryPoint = "RemoveFontResourceW" , SetLastError = true )]
		//public static extern int RemoveFontResource ( [In][MarshalAs ( UnmanagedType.LPWStr )] string lpFileName );


		public static bool IsChangingTheme = false;
		public static SplashScreen splashScreen;
		public static bool ForceCloseSpash = false;
		//public static ApplicationUser User;

		static Mutex mutex = new Mutex ( true , "{fd868c3b-6a0b-43a8-8349-c550caa6599c}" );

		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
		static void Main ( ) {
			//int result = -1;
			//int error = 0;
			string y = System.IO.Path.Combine ( AppDomain.CurrentDomain.BaseDirectory , @"Resources\fre3of9x.ttf" );

			//// Try remove the font.
			//result = RemoveFontResource ( y );
			//error = Marshal.GetLastWin32Error ( );
			//if ( error != 0 ) {
			//	Console.WriteLine ( new Win32Exception ( error ).Message );
			//} else {
			//	Console.WriteLine ( ( result == 0 ) ? "Font was not found." :
			//									  "Font removed successfully." );
			//}


			// Try install the font.

			//result = AddFontResource ( y ); // @"C:\MY_FONT_LOCATION\MY_NEW_FONT.TTF" );
			//error = Marshal.GetLastWin32Error ( );
			//if ( error != 0 ) {
			//	Console.WriteLine ( new Win32Exception ( error ).Message );
			//} else {
			//	Console.WriteLine ( ( result == 0 ) ? "Font is already installed." : "Font installed successfully." );
			//}


			if ( mutex.WaitOne ( TimeSpan.Zero , true ) ) {

				Application.EnableVisualStyles ( );
				Application.SetCompatibleTextRenderingDefault ( false );

				AppContext MyAppContext = new AppContext ( );

				splashScreen = MyAppContext.MySplashScreen;

				Application.Run ( MyAppContext );

				Properties.Settings.Default.Save ( );

				mutex.ReleaseMutex ( );

			} else {

				MessageBox.Show ( "Ya se encuentra abierta la aplicacion." );

			}
		}

		public static void DoUpgrade ( ) {
			try {

				Console.WriteLine ( ConfigurationManager.OpenExeConfiguration ( ConfigurationUserLevel.PerUserRoamingAndLocal ).FilePath );

				Console.WriteLine ( Application.ProductVersion );

				Properties.Settings.Default.Set_OnLoad ( true );

				if ( Properties.Settings.Default.UpgradeRequired ) {

					Properties.Settings.Default.Upgrade ( );

					Properties.Settings.Default.UpgradeRequired = false;
					Properties.Settings.Default.Save ( );
				}

				Properties.Settings.Default.Set_OnLoad ( false );

			} catch {
				throw;
			}
		}
		class AppContext : ApplicationContext {
			public Form1 MyMainForm;
			public SplashScreen MySplashScreen;
			public ApplicationUserManager UsrMan = new ApplicationUserManager ( new ApplicationUserStore ( new libProduccionDataBase.Contexto.DataBaseContexto ( ) ) );


			public AppContext ( ) {

				//new LogInForm().ShowDialog();

				MySplashScreen = new SplashScreen ( );

				MySplashScreen.message = " ...  Bienvenido ...";

				MySplashScreen.FormClosed += MySplashScreen_FormClosed;

				MySplashScreen.Show ( );

				Task.Run ( async ( ) => { await MySplashScreen.initialize ( ); } );



			}

			private void MyMainForm_FormClosed ( object sender , FormClosedEventArgs e ) {
				ExitThread ( );
			}

			private void MySplashScreen_FormClosed ( object sender , FormClosedEventArgs e ) {

				if ( ForceCloseSpash ) { ExitThread ( ); return; };

				CheckLogin ( );
				//if (User != null) {
				MyMainForm = new Form1 ( );
				MyMainForm.FormClosed += MyMainForm_FormClosed;
				MyMainForm.Show ( );
				//}
			}

			public void CheckLogin ( bool change = false ) {
				//using (var loginfrm = new LogInForm ( )) {
				//	if (loginfrm.ShowDialog ( ) == DialogResult.OK) {

				//		var t = Auxiliares.Validate ( loginfrm.Response );


				//		if (t.isValid &&
				//			UsrMan.FindByName ( loginfrm.Response.UserName ) != null &&
				//			UsrMan.CheckPassword ( UsrMan.FindByName ( loginfrm.Response.UserName ), loginfrm.Response.Password )
				//		) {
				//			Program.User = UsrMan.FindByName ( loginfrm.Response.UserName );
				//		} else {
				//			if (!t.isValid) {
				//				var str = new System.Text.StringBuilder ( );
				//				t.Result.ToList ( ).ForEach ( err => {
				//					str.AppendFormat ( "• {0}\n", err.ErrorMessage );
				//				} );
				//				MessageBox.Show ( str.ToString ( ), "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error );

				//			}
				//			CheckLogin ( );
				//		}

				//	} else {
				//		if (!change) ExitThread ( );
				//	}
			}
		}

	}



}
