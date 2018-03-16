using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionesPesaje.DockContents.Utilidades
{
    public partial class IndicadorBascula : KryptonDockContentFormBase
    {

        public IndicadorBascula()
        {
            InitializeComponent();
            kryptonWrapLabel1.StateCommon.TextColor = Properties.Settings.Default.BasculaColor;

        }

        public string ValorBascula
        {
            get
            {
                return this.kryptonWrapLabel1.Text;
            }

            set
            {
                if (kryptonWrapLabel1.InvokeRequired)
                {
                    kryptonWrapLabel1.Invoke( new Action( () =>
                    {
                        this.kryptonWrapLabel1.Text = value;
                    } )
                   );

                }
                else
                {

                    this.kryptonWrapLabel1.Text = value;
                }
            }
        }

        private void kryptonContextMenuColorColumns1_SelectedColorChanged( object sender, ComponentFactory.Krypton.Toolkit.ColorEventArgs e )
        {
            kryptonWrapLabel1.StateCommon.TextColor = e.Color;
            Properties.Settings.Default.BasculaColor = e.Color;
        }
    }
}
