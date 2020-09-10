using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;

namespace libProduccionDataBase.Reportes
{
	public class OrdenTrabajo_ReportViewer : ReportViewer
	{
		public string OT { get; set; }
		public Models.OrdenTrabajoModel.Procesos Proceso { get; set; } = Models.OrdenTrabajoModel.Procesos.Progreso;

		[DefaultValue ( typeof ( int ), "200" )]
		public int MapWidth
		{
			get;
			set;
		} = 200;

		[DefaultValue ( typeof ( System.Windows.Forms.DockStyle ), "Fill" )]
		public override System.Windows.Forms.DockStyle Dock
		{
			get { return base.Dock; }
			set { base.Dock = value; }
		}

		public OrdenTrabajo_ReportViewer () : base ( )
		{
			base.Dock = System.Windows.Forms.DockStyle.Fill;
			//base.DocumentMapWidth = 200;			
			// Agrego control sobre eventos ReportRefresh
			this.ReportRefresh += new CancelEventHandler ( OrdenTrabajo_ReportViewer_ReportRefresh ); //OrdenTrabajo_ReportViewer_ReportRefresh;
		}



		/// <summary>
		/// Renderiza el reporte en formato PDF de manera asincronica y devuelve un array de bytes
		/// </summary>
		/// <returns></returns>
		public static async Task<byte[]> ToPDFAsync ( string OT, Models.OrdenTrabajoModel.Procesos Proceso = Models.OrdenTrabajoModel.Procesos.Progreso )
		{
			using ( Contexto.DataBaseContexto DB = new Contexto.DataBaseContexto ( ) )
			{
				using ( LocalReport lr = new LocalReport ( ) )
				{
					var OTEntity = await DB.tempOt.FirstOrDefaultAsync ( u => u.OT == OT );

					if ( OTEntity != null )
					{

						ReportDataSource reportDataSource = new ReportDataSource ( "DataSet1", Models.OrdenTrabajoModel.ProgresoList ( OTEntity, Proceso ) );

						lr.ReportEmbeddedResource = "libProduccionDataBase.Reportes.OrdenTrabajo.rdlc";
						lr.DisplayName = $"Progreso de Orden de Trabajo {OT}";
						lr.DataSources.Add ( reportDataSource );

						return lr.Render ( "PDF" );
					}
					else
					{
						return null;
					}
				}
			}
		}

		/// <summary>
		/// Renderiza el reporte en formato PDF y devuelve un array de bytes
		/// </summary>
		/// <returns></returns>
		public static byte[] ToPDF ( string OT )
		{
			return ToPDFAsync ( OT ).Result;
		}

		/// <summary>
		/// Handle para el control del refreshReport
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void OrdenTrabajo_ReportViewer_ReportRefresh ( object sender, System.ComponentModel.CancelEventArgs e )
		{
			// Actualizo los datos
			this.LocalReport.DataSources.Clear ( );
			this.LocalReport.DataSources.Add ( new ReportDataSource ( "DataSet1", await fillData ( ) ) );
			this.DocumentMapWidth = this.MapWidth;
			this.DocumentMapCollapsed = false;
		}

		/// <summary>
		/// Inicializa el report viewer con datos de la OT previamente asignada
		/// </summary>
		/// <param name="OT">Opcional: Si contiene datos se actualiza la orden mostrada</param>
		public async Task initializeReport ( string OT = "" )
		{
			try
			{
				// Asigno la definicion del reporte
				this.LocalReport.ReportEmbeddedResource = "libProduccionDataBase.Reportes.OrdenTrabajo.rdlc";


				this.LocalReport.DataSources.Clear ( );
				this.LocalReport.DataSources.Add ( new ReportDataSource ( "DataSet1", await fillData ( ) ) );

				this.DocumentMapWidth = this.MapWidth;
				this.DocumentMapCollapsed = false;
				this.RefreshReport ( );
			}
			catch ( Exception ex )
			{

				throw ex;
			}

		}

		/// <summary>
		/// Llena los daos del datasource
		/// </summary>
		/// <param name="refresh">indica si el reportViewer actualizará el reporte</param>
		/// <returns></returns>
		private async Task<List<Models.OrdenTrabajoModel>> fillData ()
		{
			try
			{
				// Creo una instancia del contexto de la BD
				using ( var DB = new Contexto.DataBaseContexto ( ) )
				{

					// Agrego filas al datasource con los datos de la BD
					return Models.OrdenTrabajoModel.ProgresoList ( await DB.tempOt.FirstOrDefaultAsync ( u => u.OT == this.OT ), Proceso );
				}

			}
			catch ( Exception ex )
			{
				throw ex;
			}
		}
	}
}
