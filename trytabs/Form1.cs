using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EasyTabs;

namespace trytabs
{
    public partial class Form1 : Form
    {
        protected TitleBarTabs ParentTabs { get { return (ParentForm as TitleBarTabs); } }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            var tb = new TitleBarTab(this.ParentTabs) { Content = new Form2 { Text = "Form 2" } };
            this.ParentTabs.Tabs.Add(tb);
            this.ParentTabs.SelectedTab = tb;

        }
    }
}
