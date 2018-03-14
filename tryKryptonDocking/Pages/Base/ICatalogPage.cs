using ComponentFactory.Krypton.Docking;
using ComponentFactory.Krypton.Workspace;
using libProduccionDataBase.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryKryptonDocking.Pages.Base
{
    interface ICatalogPage: IToKryptonPage
    {
        DataBaseContexto DB { get; set; }
        FlagActiveFormFunctions ActiveFunctions { get; set; }

        void addNew();
        void editCurrent();
        void deleteCurrent();
        void viewDetailsOfCurrent();
        void searchElement(string SearchString, params string[] Columns);
        void refreshCatalog();       
        void ShowCatalog(FlagActiveFormFunctions Functions, KryptonDockingManager kryptonDockingManager, KryptonWorkspaceCell kryptonWorkspaceCell);
    }
}
