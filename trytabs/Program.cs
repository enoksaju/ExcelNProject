using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using EasyTabs;

namespace trytabs
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            AppContainer container = new AppContainer();
            container.Tabs.Add(
                new TitleBarTab(container)
                {
                    Content = new Form1
                    {
                        Text = "New Tab"
                    }
                }
            );

            container.SelectedTabIndex = 0;            
            TitleBarTabsApplicationContext ApplicationContext = new TitleBarTabsApplicationContext();
            ApplicationContext.Start(container);
            Application.Run(ApplicationContext);
        }
    }
}
