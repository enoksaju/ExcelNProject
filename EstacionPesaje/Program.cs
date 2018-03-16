using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using libProduccionDataBase;
using libProduccionDataBase.Identity;
using Microsoft.AspNet.Identity;

namespace EstacionesPesaje {
	static class Program {
		public static bool IsChangingTheme = false;
		public static SplashScreen splashScreen;
		public static bool ForceCloseSpash = false;
		public static ApplicationUser User;

		static Mutex mutex = new Mutex ( true, "{fd868c3b-6a0b-43a8-8349-c550caa6599c}" );

		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
		static void Main () {

			if (mutex.WaitOne ( TimeSpan.Zero, true )) {

				Application.EnableVisualStyles ( );
				Application.SetCompatibleTextRenderingDefault ( false );

				AppContext MyAppContext = new AppContext ( );

				splashScreen = MyAppContext.MySplashScreen;

				Application.Run ( MyAppContext );

				Properties.Settings.Default.Save ( );

				mutex.ReleaseMutex ( );

			}else {

				MessageBox.Show ( "Ya se encuentra abierta la aplicacion." );

			}
		}

		public static void DoUpgrade () {
			try {

				Properties.Settings.Default.Set_OnLoad ( true );

				if (Properties.Settings.Default.UpgradeRequired) {

					Properties.Settings.Default.Upgrade ( );

					Properties.Settings.Default.UpgradeRequired = false;
					Properties.Settings.Default.Save ( );
				}

				Properties.Settings.Default.Set_OnLoad ( false );

			}
			catch (Exception ex) {
				throw ex;
			}
		}
		class AppContext : ApplicationContext {
			public Form1 MyMainForm;
			public SplashScreen MySplashScreen;
			public ApplicationUserManager UsrMan = new ApplicationUserManager ( new ApplicationUserStore ( new libProduccionDataBase.Contexto.DataBaseContexto ( ) ) );


			public AppContext () {

				//new LogInForm().ShowDialog();

				MySplashScreen = new SplashScreen ( );

				MySplashScreen.message = " ...  Bienvenido ...";

				MySplashScreen.FormClosed += MySplashScreen_FormClosed;

				MySplashScreen.Show ( );

				Task.Run ( async () => { await MySplashScreen.initialize ( ); } );



			}

			private void MyMainForm_FormClosed ( object sender, FormClosedEventArgs e ) {
				ExitThread ( );
			}

			private void MySplashScreen_FormClosed ( object sender, FormClosedEventArgs e ) {

				if (ForceCloseSpash) { ExitThread ( ); return; };

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
