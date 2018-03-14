using ComponentFactory.Krypton.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryKryptonDocking.Pages.Base
{
    public class EnterPageEventArgs : EventArgs
    {
        public KryptonPage Item { get; set; }
        public string ContextNames { get; set; }
    }
    public class LeavePageEventArgs : EventArgs
    {
        public KryptonPage Item { get; set; }
        public string ContextNames { get; set; }
    }

}
