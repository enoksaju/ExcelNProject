using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlaneacionExcel
{
	/// <summary>
	/// Lógica de interacción para PlanSemanal.xaml
	/// </summary>
	public partial class PlanSemanal : UserControl
	{
		public PlanSemanal ()
		{
			InitializeComponent ( );
		}

	}

	public class TodoItem
	{
		public string OT { get; set; }
		public string Cliente { get; set; }
		public string Producto { get; set; }
		public int MetrosLineales { get; set; }
		public string Maquina { get; set; }
		public string Material_1 { get; set; }
		public string Material_2 { get; set; }
		public string Material_3 { get; set; }
		public string Material_4 { get; set; }
		public string TipoTrabajo { get; set; }
		public string Comentarios { get; set; }

	}
}
