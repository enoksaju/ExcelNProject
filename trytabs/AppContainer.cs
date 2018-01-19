using System;
using EasyTabs;
namespace trytabs
{
    public partial class AppContainer : TitleBarTabs
    {
        public AppContainer()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new EasyTabs.ChromeTabRenderer(this);           
        }

        public override  TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new Form1 { Text = "New Tab" }
            };
        }
        
        private void AppContainer_Load(object sender, EventArgs e)
        {

        }
    }
}
