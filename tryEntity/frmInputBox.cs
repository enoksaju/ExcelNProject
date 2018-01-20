using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryEntity
{
    public partial class InputBox : Form
    {
        private string Dflt;
        private InputBox(string Append, string Title, string DefaultResponse, string AcceptText, string CancelText, IWin32Window owner= null)
        {
            InitializeComponent();
            lblAppend.Text = Append;
            this.Text = Title;
            btnAceptar.Text = AcceptText;
            btnCancelar.Text = CancelText;
            inputTxt.Text = DefaultResponse;
            Dflt = DefaultResponse;
            this.Owner = (Form)owner;
        }

        public static ResultInputBox ShowDialog(string Append, string Title, string DefaultResponse="", string AcceptText="Aceptar", string CancelText="Cancelar")
        {
            using (var t= new InputBox(Append, Title, DefaultResponse, AcceptText, CancelText) { })
            {
                return t.ShowDialog() == DialogResult.OK ? new ResultInputBox(DialogResult.OK, t.inputTxt.Text) : new ResultInputBox(DialogResult.Cancel, t.Dflt);
            }
        }
        public static ResultInputBox ShowDialog(IWin32Window owner,string Append, string Title, string DefaultResponse = "", string AcceptText = "Aceptar", string CancelText = "Cancelar")
        {
            using (var t = new InputBox(Append, Title, DefaultResponse, AcceptText, CancelText, owner) { })
            {
                return t.ShowDialog() == DialogResult.OK ? new ResultInputBox(DialogResult.OK, t.inputTxt.Text) : new ResultInputBox(DialogResult.Cancel, t.Dflt);
            }           
        }

        private void InputBox_Load(object sender, EventArgs e)
        {

        }
    }
    public class ResultInputBox
    {
        public DialogResult DialogResult { get; set; }
        public string StringResult { get; set; }
        public ResultInputBox(DialogResult DialogResult, string StringResult)
        {
            this.DialogResult = DialogResult;
            this.StringResult = StringResult;
        }
    }
}
