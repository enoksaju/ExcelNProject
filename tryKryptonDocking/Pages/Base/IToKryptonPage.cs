using ComponentFactory.Krypton.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesPesaje.Pages.Base
{
    interface IToKryptonPage 
    {
        KryptonPage KP { get; set; }
        KryptonPage GetKryptonPage();
        bool IsAssignedEnterPage { get;  }
        bool IsAssignedLeavePage { get; }
        bool IsAssignedStatusStringChanged { get; }
        event EventHandler<EnterPageEventArgs> EnterPage;
        event EventHandler<LeavePageEventArgs> LeavePage;
        event EventHandler<ChangeStatusMessageEventArgs> StatusStringChanged;
    }
}
