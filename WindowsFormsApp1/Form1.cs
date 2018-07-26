using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {
    private libProduccionDataBase.Contexto.DataBaseContexto DB;
    public Form1()
    {
      InitializeComponent();
      DB = new libProduccionDataBase.Contexto.DataBaseContexto();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {

      await DB.tempOt.Include(i=> i.TempCapt).LoadAsync();
      TemporalOrdenTrabajoBindingSource.DataSource = DB.tempOt.Local.ToList();
      
      this.reportViewer1.RefreshReport();
    }
  }
}
