using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ControlProduccion
{
    public partial class TryDocument : DockContent
    {
        public TryDocument()
        {
            InitializeComponent();
            toolStripComboBox1.ComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            toolStripComboBox1.ComboBox.DrawItem += ComboBox_DrawItem;

            toolStripComboBox1.SelectedIndexChanged += ToolStripComboBox1_SelectedIndexChanged;


            richTextBox1.DragEnter += RichTextBox1_DragEnter;
            richTextBox1.DragDrop += RichTextBox1_DragDrop;
        }

        private void RichTextBox1_DragDrop( object sender, DragEventArgs e )
        {
            //DataGridViewSelectedRowCollection rows = (DataGridViewSelectedRowCollection)e.Data.GetData(typeof(DataGridViewSelectedRowCollection));

            DataGridViewSelectedRowCollection rows = e.Data.GetData(typeof(DataGridViewSelectedRowCollection)) as  DataGridViewSelectedRowCollection;
            if(rows!= null)
            {
                foreach(DataGridViewRow r in rows)
                {
                    Console.WriteLine( r.DataBoundItem );
                    richTextBox1.Text += r.DataBoundItem;
                }
            }                    
        }

        private void RichTextBox1_DragEnter( object sender, DragEventArgs e )
        {
            if (e.Data.GetDataPresent( typeof( DataGridViewSelectedRowCollection ) ))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void ToolStripComboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            toolStripComboBox1.Font = new Font( toolStripComboBox1.Text, 8 );
            richTextBox1.SelectionFont = new Font( toolStripComboBox1.Text, float.Parse( toolStripTextBox1.Text) );
            richTextBox1.Focus();
        }



        private void TryDocument_Load( object sender, EventArgs e )
        {
            List<string> fonts = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add( font.Name );
            }

            toolStripComboBox1.Items.AddRange( fonts.ToArray() );
        }

        private void ComboBox_DrawItem( object sender, DrawItemEventArgs e )
        {
            e.DrawBackground();

            //Rectangle rectangle = new Rectangle(2, e.Bounds.Top+2, e.Bounds.Height, e.Bounds.Height-4);
            //e.Graphics.FillRectangle( new SolidBrush( Color.White ), rectangle );

            // Draw each string in the array, using a different size, color,
            // and font for each item.
            var myFont = new Font( toolStripComboBox1.Items[e.Index].ToString(), 8 );
            e.Graphics.DrawString( toolStripComboBox1.Items[e.Index].ToString(), myFont, System.Drawing.Brushes.Black, new RectangleF( e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height ) );

            // Draw the focus rectangle if the mouse hovers over an item.
            e.DrawFocusRectangle();
        }

        private void toolStripButton2_Click( object sender, EventArgs e )
        {
            toolStripTextBox1.Text = (float.Parse( toolStripTextBox1.Text )) < 120 ? (float.Parse( toolStripTextBox1.Text ) + 1).ToString() : (float.Parse( toolStripTextBox1.Text )).ToString();
        }

        private void toolStripButton1_Click( object sender, EventArgs e )
        {
            toolStripTextBox1.Text = (float.Parse( toolStripTextBox1.Text )) > 6 ? (float.Parse( toolStripTextBox1.Text ) - 1).ToString() : (float.Parse( toolStripTextBox1.Text )).ToString();

        }

        private void toolStripTextBox1_Validating( object sender, CancelEventArgs e )
        {
           
            float n;
            bool isNumeric = float.TryParse(toolStripTextBox1.Text, out n);

            if (!isNumeric)
            {
                e.Cancel = true;                
            }

        }
        private void toolStripTextBox1_Validated( object sender, EventArgs e )
        {
            richTextBox1.SelectionFont = new Font( toolStripComboBox1.Text, float.Parse( toolStripTextBox1.Text ) );
        }

        private void richTextBox1_SelectionChanged( object sender, EventArgs e )
        {
            toolStripTextBox1.Text = richTextBox1 .SelectionFont.Size.ToString();
        }
    }
}
