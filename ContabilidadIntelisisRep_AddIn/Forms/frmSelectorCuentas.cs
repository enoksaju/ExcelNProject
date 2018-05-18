using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContabilidadIntelisisRep_AddIn.Forms {
	public partial class frmSelectorCuentas : Form {

		private string sqlWithoutRama = @"SELECT [Cuenta]
      ,[Rama]
      ,[Descripcion]
      ,[Tipo]
      ,[Categoria]
      ,[Familia]
      ,[Grupo]
  FROM [Cta]
  where [Rama] is null";
		private string sqlWithRama = @"SELECT [Cuenta]
      ,[Rama]
      ,[Descripcion]
      ,[Tipo]
      ,[Categoria]
      ,[Familia]
      ,[Grupo]
  FROM [Cta]
  where [Rama]= @Cuenta";

		private string sqlWithDescription = @"SELECT rt.[Cuenta]
      ,rt.[Rama]
      ,rt.[Descripcion]
      ,rt.[Tipo]
      ,rt.[Categoria]
      ,rt.[Familia]
      ,rt.[Grupo]
  FROM [Cta] cta inner join [Cta] rt on rt.Rama= cta.Cuenta
  where CTA.[Cuenta]= @Cuenta";


		public string response;

		public frmSelectorCuentas ( ) {
			InitializeComponent ( );
			this.FormClosing += FrmSelectorCuentas_FormClosing;

			using ( var db = new Context.dataBaseContext ( ) ) {
				var ctas = db.Database.SqlQuery<Modelos.Cuentas> ( sqlWithoutRama ).ToList ( );

				foreach ( var cta in ctas ) {
					TreeNode treeNode = new TreeNode ( $"{cta.Descripcion}" , 0 , 1 );//1
					treeNode.Tag = cta;
					var sbctas = db.Database.SqlQuery<Modelos.Cuentas> ( sqlWithRama , new SqlParameter ( "@Cuenta" , cta.Cuenta ) ).ToList ( );
					foreach ( var scta in sbctas ) {
						TreeNode childtreeNode = new TreeNode ( $"{scta.Descripcion}" , 0 , 1 ); //2
						childtreeNode.Tag = scta;
						if ( scta.Rama.Trim ( ) != "X" ) {
							var ssbctas = db.Database.SqlQuery<Modelos.Cuentas> ( sqlWithRama , new SqlParameter ( "@Cuenta" , scta.Cuenta ) ).ToList ( );
							foreach ( var sscta in ssbctas ) {
								TreeNode ctreeNode = new TreeNode ( $"{ sscta.Descripcion}" , 0 , 1 );//3
								ctreeNode.Tag = sscta;
								var sssbctas = db.Database.SqlQuery<Modelos.Cuentas> ( sqlWithRama , new SqlParameter ( "@Cuenta" , sscta.Cuenta ) ).ToList ( );
								foreach ( var ssscta in sssbctas ) {
									TreeNode cctreeNode = new TreeNode ( $"{ssscta.Descripcion}" , 0 , 1 );//4
									cctreeNode.Tag = ssscta;
									var ssssbctas = db.Database.SqlQuery<Modelos.Cuentas> ( sqlWithRama , new SqlParameter ( "@Cuenta" , ssscta.Cuenta ) ).ToList ( );
									foreach ( var sssscta in ssssbctas ) {
										TreeNode ccctreeNode = new TreeNode ( $"{ sssscta.Descripcion}" , 0 , 1 );//5
										ccctreeNode.Tag = sssscta;
										cctreeNode.Nodes.Add ( ccctreeNode );
									}
									ctreeNode.Nodes.Add ( cctreeNode );
								}
								childtreeNode.Nodes.Add ( ctreeNode );
							}
							treeNode.Nodes.Add ( childtreeNode );
						}
					}
					treeView1.Nodes.Add ( treeNode );
				}

			}
		}

		private void FrmSelectorCuentas_FormClosing ( object sender , FormClosingEventArgs e ) {
			//if ( this.DialogResult != DialogResult.OK )
			//	e.Cancel= true;
		}

		private void treeView1_AfterSelect ( object sender , TreeViewEventArgs e ) {
			var ctaD = ( Modelos.Cuentas ) e.Node.Tag;
			using ( var db = new Context.dataBaseContext ( ) ) {
				var sbctas = db.Database.SqlQuery<Modelos.Cuentas> ( sqlWithDescription , new SqlParameter ( "@Cuenta" , ctaD.Cuenta ) ).ToList ( );
				//listBox1.Items.Clear ( );
				//listBox1.DisplayMember = "Descripcion";
				//listBox1.ValueMember = "Cuenta";
				//listBox1 .DataSource =  sbctas;

				cuentasBindingSource.DataSource = sbctas;
			}
		}


		private void cuentasListBox_DoubleClick ( object sender , EventArgs e ) {
			response = ( ( Modelos.Cuentas ) cuentasBindingSource.Current )?.Cuenta;
			this.DialogResult = DialogResult.OK;
			this.Close ( );
		}
	}
}
