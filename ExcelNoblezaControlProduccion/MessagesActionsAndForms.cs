using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelNoblezaControlProduccion
{
    class MessagesActionsAndForms
    {
        public static bool AskConfirmation(IWin32Window  Owner, string Question= "Realmente desea continuar con la acción?" )
        {
            if (MessageBox.Show( Owner, Question , "Confirmar...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 ) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
    }
}
