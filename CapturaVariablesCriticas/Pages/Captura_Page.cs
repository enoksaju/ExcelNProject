using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace CapturaVariablesCriticas.Pages
{
	public partial class Captura_Page : UserControl
	{
		libProduccionDataBase.Contexto.DataBaseContexto DB;
		public Captura_Page()
		{
			
			InitializeComponent();
			DB = new libProduccionDataBase.Contexto.DataBaseContexto();
			LoadDB();
		}

		private async void LoadDB()
		{			
			await DB.VariablesCriticas.LoadAsync();
			variablesCriticasRootBindingSource.DataSource = DB.VariablesCriticas.Local.ToBindingList();
		}

		private async void Captura_Page_Load(object sender, EventArgs e)
		{

		}
	}
}
