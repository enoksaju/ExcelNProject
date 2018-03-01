using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace libControlesPersonalizados
{
    public partial class importZPLImageForm : KryptonForm
    {
        public importZPLImageForm()
        {
            InitializeComponent();
        }

        public string ZPLResult;
        private async void openFileSpectButton_Click( object sender, EventArgs e )
        {
            if (ofdImage.ShowDialog() != DialogResult.OK) return;

            await Task.Run( () =>
            {
                ChangeImages( ofdImage.FileName );
            } );
        }

        public void ChangeImages( string FileName )
        {
            if (this.InvokeRequired)
            {
                this.Invoke( new Action<string>( ChangeImages ), FileName );
                return;
            }
            else
            {
                kryptonTextBox1.Text = FileName;
                Image img= Image.FromFile(FileName);

                if (img != null)
                {
                    try
                    {
                        pictureBox1.SizeMode = (
                        img.Height < pictureBox1.Height &
                        img.Width < pictureBox1.Width
                        ) ? PictureBoxSizeMode.CenterImage : pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                        pictureBox1.Image = img;
                        zplImageConverter1.Image = img;
                        zplImageConverter1.BlacknessLimitPercentage = (int)kryptonNumericUpDown1.Value;

                        ResultCodeRichTextBox.Text = zplImageConverter1.zplValue;
                        ZPLResult= zplImageConverter1.zplValue;
                        pictureBox2.SizeMode = (
                            zplImageConverter1.ImageResult?.Height < pictureBox2.Height &
                            zplImageConverter1.ImageResult?.Width < pictureBox2.Width
                            ) ? PictureBoxSizeMode.CenterImage : pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                        pictureBox2.Image = zplImageConverter1.ImageResult;
                        AddCodeButton.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        KryptonTaskDialog.Show( "Algo va mal...", "Error", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK );
                    }
                }
            }
        }
        private async void Darknes_ValueChanged( object sender, EventArgs e )
        {
            await Task.Run( () =>
            {
                this.Invoke( new Action( () =>
                {                    
                    zplImageConverter1.BlacknessLimitPercentage =(int) kryptonNumericUpDown1.Value;

                    Task.Run(()=> {
                        pictureBox2.Image = zplImageConverter1.ImageResult;
                    });



                    ResultCodeRichTextBox.Text = zplImageConverter1.zplValue;
                    ZPLResult = zplImageConverter1.zplValue;                
                    AddCodeButton.Enabled = true;
                } ) );
            }
            );
        }

        private void LargoLinea_ValueChanged( object sender, EventArgs e )
        {
            zplImageConverter1.LengToSplit = (int)LargoLinea.Value;
            ResultCodeRichTextBox.Text = zplImageConverter1.zplValue;
            ZPLResult = zplImageConverter1.zplValue;
        }
    }
}
