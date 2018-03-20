using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace EstacionPesaje
{
    class MessagesActionsAndForms
    {
        public static bool AskConfirmation(IWin32Window  Owner, string Question= "Realmente desea continuar con la acción?" )
        {
            using (KryptonTaskDialog Dialog = new KryptonTaskDialog() {
                WindowTitle = "Confirmación de la Acción",
                MainInstruction = "Confirme...",
                Content = Question,
                Icon = MessageBoxIcon.Question,
                CommonButtons = TaskDialogButtons.Yes | TaskDialogButtons.No,
                DefaultButton = TaskDialogButtons.No,
                AllowDialogClose = false                
            })
            {
                if (Dialog.ShowDialog() == DialogResult.Yes)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
