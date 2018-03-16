using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionesPesaje
{

    public partial class SplashScreen : Form
    {
        public delegate void _ChangeMessage( string value );

        public string message
        {
            set
            {
                setTextMessage( value );
            }
        }

        public void setTextMessage( string value )
        {
            if (messageText.InvokeRequired)
            {
                messageText.Invoke( new _ChangeMessage( setTextMessage ), value );
                return;
            }
            messageText.Text = String.Format( "Cargando {0} ...", value );
        }
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            Program.ForceCloseSpash = true;
            Close();
        }

        private async void SplashScreen_Load( object sender, EventArgs e )
        {

        }

        public async Task initialize()
        {
            await Task.Run( () =>
            {
                Program.DoUpgrade();
                this.ShowMain();
            } );
        }

        private void ShowMain()
        {

            if (this.InvokeRequired)
            {
                this.Invoke( new Action( ShowMain ) );
                return;
            }

            this.setTextMessage( " Formulario Inicial, Por favor Espere" );

            this.Close();
        }

    }
}
