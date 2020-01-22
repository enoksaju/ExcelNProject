using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libIntelisisReports.Controles
{
	public partial class ctlExistencias : UserControl
	{
		public string Linea { get; set; }

		[DefaultValue ( typeof ( DockStyle ), "Fill" )]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		public ctlExistencias ()
		{
			base.Dock = DockStyle.Fill;
			InitializeComponent ( );
		}

		private void button1_Click ( object sender, EventArgs e )
		{
			this.Linea = comboBox1.Text;
			if(this.Linea != "" )
			{
				this.existenciasLineasTableAdapter.Fill ( this.excelNoblezaDataSet.ExistenciasLineas, this.Linea );
				this.reportViewer1.RefreshReport ( );
			}
		}
	}
}
