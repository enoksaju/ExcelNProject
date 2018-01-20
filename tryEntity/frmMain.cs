using libProduccionDataBase;
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

namespace tryEntity
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Add(new frmListaClientes(this.tabControl1));
            ((Form)this.tabControl1.SelectedForm).FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.resetContextRibbon);
        }
        private void rbnbtnCatFamiliaMateriales_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Add(new frmListaImpresoras());
            ((Form)this.tabControl1.SelectedForm).FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.resetContextRibbon);
        }
        private void ribbonButton1_Click_1(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Add(new frmListaMateriales());
            ((Form)this.tabControl1.SelectedForm).FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.resetContextRibbon);
        }

        private void resetContextRibbon(object obj, EventArgs e)
        {
            ribbon1.Contexts.ForEach(ctx => { ctx.Visible = false; });
            var frm = this.tabControl1.SelectedForm;
            if (frm != null)
            {
                switch (((IformRibbonTab)frm).TipoFRM)
                {
                    case TiposFormulario.Lista:
                        ribbonContextListas.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void tabControl1_SelectedTabChanged(object sender, EventArgs e)
        {
            resetContextRibbon(null, null);
        }

        #region ControlesListas

        private void rbnbtnListaRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ((IformRibbonTab)tabControl1.SelectedForm).Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, Auxiliares.GetInnerException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rbnbtnListaEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (((IformRibbonTab)tabControl1.SelectedForm).Edit() == DialogResult.OK) MessageBox.Show(this, "Se actualizo la informacion correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, Auxiliares.GetInnerException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbbtnListaAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (((IformRibbonTab)tabControl1.SelectedForm).AddNew() == DialogResult.OK) MessageBox.Show(this, "Se inserto la informacion correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, Auxiliares.GetInnerException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ribbtnListaDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(
                    this, "Realmente desea Borrar el Elemento seleccionado?",
                    "Confirme...",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    ((IformRibbonTab)tabControl1.SelectedForm).Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, Auxiliares.GetInnerException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ribbtnListaSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ((IformRibbonTab)tabControl1.SelectedForm).Search(ribtxtListaSearch.TextBoxText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, Auxiliares.GetInnerException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            try
            {
                ((IformRibbonTab)tabControl1.SelectedForm).Export(TipoExport.Excel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, Auxiliares.GetInnerException(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}
