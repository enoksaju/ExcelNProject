using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace libIntelisisReports.Controles
{
	public partial class TransferenciasOT : UserControl
	{
		public delegate void OnRefreshOT ( object sender, OTEventArgs e );
		public event OnRefreshOT ChangedOT;

		public delegate void OnChengeMsg ( object sender, OTEventArgs e );
		public event OnChengeMsg ChangedMsg;

		public TransferenciasOT ()
		{
			InitializeComponent ( );
			Models.CierreOrdenesItmObj.ChangeProgress += CierreOrdenesItmObj_ChangeProgress;
			this.progress_pb.ProgressBar.Style = ProgressBarStyle.Continuous;
		}

		private void CierreOrdenesItmObj_ChangeProgress ( Models.CierreOrdenesItmObj.CierreEventArgs e )
		{
			this.progress_pb.ProgressBar.Invoke ( new Action ( () =>
			{
				this.progress_pb.Value = e.Progress;
				onChangeMessage ( e.Paso );
			} ) );

			System.Diagnostics.Debug.WriteLine ( $"{e.Paso} {e.Progress}" );
		}

		private void reportViewer1_ReportRefresh ( object sender, CancelEventArgs e )
		{
			if ( this.ot_txt.Text.Trim ( ) != "" && this.ot_txt.Text.Trim ( ).Length >= 5 )
				itmCvBindingSource.DataSource = Models.CierreOrdenesItmObj.allMoves ( this.ot_txt.Text );
		}

		private async void fill_btn_Click ( object sender, EventArgs e )
		{
			this.progress_pb.Visible = true;
			this.progress_pb.Value = 0;

			await Task.Run ( () =>
		   {
			   try
			   {
				   if ( !DesignMode && this.ot_txt.Text.Trim ( ) != "" && this.ot_txt.Text.Trim ( ).Length >= 5 )
				   {
					   itmCvBindingSource.DataSource = Models.CierreOrdenesItmObj.allMoves ( this.ot_txt.Text );

				   }
			   }
			   catch ( Exception ex )
			   {
				   MessageBox.Show(ex.Message, "Algo salio mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
			   }
			   finally
			   {
				   this.Invoke ( new Action<string> ( onChangeOT ), this.ot_txt.Text );
			   }

		   } );


		}

		protected void onChangeOT ( string OT )
		{
			this.reportViewer1.LocalReport.DisplayName = "Cierre de Orden " + OT;			
			this.reportViewer1.ZoomMode = ZoomMode.Percent;//.PageWidth;
			this.reportViewer1.ZoomPercent = 100;
			this.reportViewer1.RefreshReport ( );


			this.progress_pb.Visible = false;
			ChangedOT?.Invoke ( this, new OTEventArgs ( this.ot_txt.Text ) );
		}

		protected void onChangeMessage (string message)
		{
			ChangedMsg?.Invoke ( this, new OTEventArgs ( this.ot_txt.Text, message ) );
		}

		private void ot_txt_KeyDown ( object sender, KeyEventArgs e )
		{
			if ( e.KeyCode != Keys.Return ) return;
			fill_btn_Click ( fill_btn, null );
		}


		public class OTEventArgs
		{
			public OTEventArgs ( string _OT, string _Msg = "" ) { OT = _OT; Message = _Msg; }
			public string OT { get; } // readonly
			public string Message { get; }
		}

		private void TransferenciasOT_Load ( object sender, EventArgs e )
		{
			//fill_btn_Click ( fill_btn, null );
		}
	}
}
