using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Identity;
using libProduccionDataBase.Identity.Model;
using static libProduccionDataBase.Auxiliares;

namespace ExcelNoblezaControlProduccion
{
    public partial class LogInForm : KryptonForm
    {
        private const string rsa_key= "ExcelNoblezaHSJ43295";
        public LoginModel Response { get; set; }
        private List<UsuarioBasicInfo> Usuarios { get; set; }

        public LogInForm()
        {
            InitializeComponent();
            userNameKryptonTextBox.Leave += UserNameKryptonTextBox_Leave;
            loginModelBindingSource.DataSource = new List<LoginModel>();

            kryptonButton1.Click += KryptonButton1_Click;


            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            Console.WriteLine( "Local user config path: {0}", config.FilePath );

        }

        private void KryptonButton1_Click( object sender, EventArgs e )
        {
            loginModelBindingSource.EndEdit();
        }

        private void UserNameKryptonTextBox_Leave( object sender, EventArgs e )
        {

            var user= Usuarios.FirstOrDefault(t=> t.UserName.ToUpper().Trim() == userNameKryptonTextBox.Text.ToUpper().Trim() );

            if (user == null) { BasicInfoLayout.Visible = false; return; }

            BasicInfoLayout.Visible = true;
            usuarioBasicInfoBindingSource.Position = Usuarios.IndexOf( user );


        }

        private async void LogInForm_Load( object sender, EventArgs e )
        {

            Usuarios = await UsuarioBasicInfo.GetUsersBasicInfo();
            usuarioBasicInfoBindingSource.DataSource = Usuarios;
            BasicInfoLayout.Visible = false;

            loginModelBindingSource.AddNew();
            Response = (LoginModel)loginModelBindingSource.Current;

            if (Properties.Settings.Default.RememberMe)
            {
                var u= StringKript.Decrypt( Properties.Settings.Default.Usuario, rsa_key );
                var p= StringKript.Decrypt( Properties.Settings.Default.Password, rsa_key );

                ((LoginModel)loginModelBindingSource.Current).UserName= u;
                ((LoginModel)loginModelBindingSource.Current).Password= p;
                loginModelBindingSource.ResetCurrentItem();
                UserNameKryptonTextBox_Leave( sender, e );
            }

        }

        private void LogInForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (Properties.Settings.Default.RememberMe)
            {
                Properties.Settings.Default.Usuario = StringKript.Encrypt( userNameKryptonTextBox.Text, rsa_key );
                Properties.Settings.Default.Password = StringKript.Encrypt( passwordKryptonTextBox.Text, rsa_key );
            }
        }
    }
}
