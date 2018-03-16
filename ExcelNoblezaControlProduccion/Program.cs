using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using libProduccionDataBase;
using libProduccionDataBase.Identity;
using Microsoft.AspNet.Identity;

namespace EstacionesPesaje
{
    static class Program
    {
        public static bool IsChangingTheme = false;
        public static SplashScreen splashScreen;
        public static bool ForceCloseSpash = false;
        public static ApplicationUser User;


        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo( "es-MX" );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );

            AppContext MyAppContext= new AppContext();

            splashScreen = MyAppContext.MySplashScreen;

            Application.Run( MyAppContext );

            Properties.Settings.Default.Save();
        }


        public static void DoUpgrade()
        {
            try
            {

                Properties.Settings.Default.Set_OnLoad( true );

                if (Properties.Settings.Default.UpgradeRequired)
                {

                    Properties.Settings.Default.Upgrade();

                  

                    Properties.Settings.Default.UpgradeRequired = false;
                    Properties.Settings.Default.Save();
                }

                Properties.Settings.Default.Set_OnLoad( false );

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        class AppContext : ApplicationContext
        {
            public MainForm MyMainForm;
            public SplashScreen MySplashScreen;
            public ApplicationUserManager UsrMan = new ApplicationUserManager(new ApplicationUserStore(new libProduccionDataBase.Contexto.DataBaseContexto()));


            public AppContext()
            {

                //new LogInForm().ShowDialog();

                MySplashScreen = new SplashScreen();

                MySplashScreen.message = " ...  Bienvenido ...";

                MySplashScreen.FormClosed += MySplashScreen_FormClosed;

                MySplashScreen.Show();

                Task.Run( async () => { await MySplashScreen.initialize(); } );



            }

            private void MyMainForm_FormClosed( object sender, FormClosedEventArgs e )
            {
                ExitThread();
            }

            private void MySplashScreen_FormClosed( object sender, FormClosedEventArgs e )
            {

                if (ForceCloseSpash) { ExitThread(); return; };

                CheckLogin();
                if (User != null)
                {
                    MyMainForm = new MainForm();
                    MyMainForm.FormClosed += MyMainForm_FormClosed;
                    MyMainForm.Show();
                }
            }

            public void CheckLogin( bool change = false )
            {
                using (var loginfrm = new LogInForm())
                {
                    if (loginfrm.ShowDialog() == DialogResult.OK)
                    {
                        var t = Auxiliares.Validate(loginfrm.Response);


                        if (t.isValid &&
                            UsrMan.FindByName( loginfrm.Response.UserName ) != null &&
                            UsrMan.CheckPassword( UsrMan.FindByName( loginfrm.Response.UserName ), loginfrm.Response.Password )
                        )
                        {
                            Program.User = UsrMan.FindByName( loginfrm.Response.UserName );                            
                        }
                        else
                        {
                            if (!t.isValid)
                            {
                                var str = new System.Text.StringBuilder();
                                t.Result.ToList().ForEach( err =>
                                {
                                    str.AppendFormat( "• {0}\n", err.ErrorMessage );
                                } );
                                MessageBox.Show( str.ToString(), "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error );

                            }
                            CheckLogin();
                        }

                    }
                    else
                    {
                        if (!change) ExitThread();
                    }
                }
            }

        }
    }

}
