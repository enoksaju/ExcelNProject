using ComponentFactory.Krypton.Toolkit;
using libControlesPersonalizados.ZPLCONVERTER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstacionPesaje.Pages.tools
{
	public partial class AVTLabelGenerator_frm : KryptonForm
	{
		libProduccionDataBase.Contexto.DataBaseContexto db = new libProduccionDataBase.Contexto.DataBaseContexto();
		public AVTLabelGenerator_frm()
		{
			InitializeComponent();
			try
			{
				var last = db.AVTFolios.OrderByDescending(u => u.Id).FirstOrDefault();
				FolioActuallbl.Text = last.Id.ToString();
			}
			catch (Exception)
			{

				FolioActuallbl.Text = "0";
			}
			
		}

		private void Cancelbtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private async void printbtn_Click(object sender, EventArgs e)
		{
			if (Cantidadnbx.Value > 0 && KryptonMessageBox.Show(this, $"Desea imprimir {Cantidadnbx.Value} etiquetas?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				libProduccionDataBase.Tablas.AVT.AVTFolios temp = null;
				for (int i = 0; i < Cantidadnbx.Value; i++)
				{
					temp = db.AVTFolios.Add(new libProduccionDataBase.Tablas.AVT.AVTFolios());
					await db.SaveChangesAsync();

					libControlesPersonalizados.RAWPrinter.RawPrinter.SendStringToPrinter($"{Properties.Settings.Default.ImpresoraEtiquetas}", $@"
^XA
^FO40,30^B3N,N,80,N,N^FD{ temp.Id.ToString("00000000") }^FS
^FO460,30^B3N,N,80,N,N^FD{ temp.Id.ToString("00000000") }^FS
^FO150,115^A0N,20,20^FD{ temp.Id.ToString("00000000") }^FS
^FO570,115^A0N,20,20^FD{ temp.Id.ToString("00000000") }^FS
^FO80,145^A0N,35,20^FDOT: __________________^FS
^FO70,180^A0N,35,20^FDNum: _________________^FS
^FO500,145^A0N,35,20^FDOT: __________________^FS
^FO490,180^A0N,35,20^FDNum: _________________^FS
^XZ", $"lblAVT_{temp.Id.ToString()}.zpl");

				}

				if (temp != null)
					FolioActuallbl.Text = temp.Id.ToString();
			}

		}
	}
}
