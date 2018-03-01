using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelNoblezaControlProduccion.DockContents.Utilidades
{
    public partial class EditorZPL : KryptonDockContentFormBase
    {
        public EditorZPL()
        {
            InitializeComponent();
            this.DataBindings.Add("TabText", zplCodeEditor1, "FileName", false, DataSourceUpdateMode.OnPropertyChanged);
            zplCodeEditor1.ChangedFileName += ZplCodeEditor1_ChangedFileName;
        }

        private void ZplCodeEditor1_ChangedFileName(object sender, EventArgs e)
        {
            this.TabText = zplCodeEditor1.FileName;
        }
    }
}
