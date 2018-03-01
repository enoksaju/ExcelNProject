using libProduccionDataBase.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelNoblezaControlProduccion.DockContents.Catalogos
{
    public class CatalogoEtiquetas: BaseForm.BaseFormCatalogos
    {
        private ComponentFactory.Krypton.Toolkit.KryptonListBox EtiquetasListBox;
        private System.Windows.Forms.BindingSource etiquetaBindingSource;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EtiquetasListBox = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.etiquetaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.etiquetaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // EtiquetasListBox
            // 
            this.EtiquetasListBox.DataSource = this.etiquetaBindingSource;
            this.EtiquetasListBox.DisplayMember = "Nombre";
            this.EtiquetasListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EtiquetasListBox.Location = new System.Drawing.Point(1, 51);
            this.EtiquetasListBox.Name = "EtiquetasListBox";
            this.EtiquetasListBox.Size = new System.Drawing.Size(197, 429);
            this.EtiquetasListBox.TabIndex = 5;
            this.EtiquetasListBox.ValueMember = "Id";
            // 
            // etiquetaBindingSource
            // 
            this.etiquetaBindingSource.DataSource = typeof(libProduccionDataBase.Tablas.Etiqueta);
            // 
            // CatalogoEtiquetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(199, 481);
            this.Controls.Add(this.EtiquetasListBox);
            this.Name = "CatalogoEtiquetas";
            this.TabText = "Catalogo Etiquetas";
            this.Text = "Catalogo Etiquetas";
            this.Load += new System.EventHandler(this.CatalogoEtiquetas_Load);
            this.Controls.SetChildIndex(this.EtiquetasListBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.etiquetaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public CatalogoEtiquetas(DataBaseContexto DB) : base( DB )
        {
            InitializeComponent();
        }
        private async void CatalogoEtiquetas_Load(object sender, EventArgs e)
        {
            
            OnStatusStringChanged(new ChangeStatusMessageEventArgs { Title = "Cargando..", Message = "Cargando Etiquetas..." });
            
            if (!Program.IsChangingTheme) await DB.Etiquetas.LoadAsync();
            
            etiquetaBindingSource.DataSource = this.DB.Etiquetas.Local.ToBindingList();
           
            OnStatusStringChanged(new ChangeStatusMessageEventArgs { Title = "Listo", Message = "Listo" });
        }
        public override void Agregar(object sender, EventArgs e)
        {
            var frm = new CatalogosAddEdit.AgregarEditarEtiqueta(this);

            MainForm mainfrm = this.DockPanel.FindForm() as MainForm;
            frm.StatusStringChanged += mainfrm.CambioEstadoFormCatalog;

            frm.Show(this.DockPanel);
        }
        public override void Editar(object sender, EventArgs e)
        {
            var frm = new CatalogosAddEdit.AgregarEditarEtiqueta(this,(libProduccionDataBase.Tablas.Etiqueta) EtiquetasListBox.SelectedItem);

            MainForm mainfrm = this.DockPanel.FindForm() as MainForm;
            frm.StatusStringChanged += mainfrm.CambioEstadoFormCatalog;

            frm.Show(this.DockPanel);
        }
        public override void Eliminar(object sender, EventArgs e)
        {
            try
            {
                if (etiquetaBindingSource.Current != null && MessagesActionsAndForms.AskConfirmation(this))
                {
                    this.etiquetaBindingSource.RemoveCurrent();
                    DB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                HandledException(new Exception(libProduccionDataBase.Auxiliares.GetInnerException(ex)));
            }
        }
        public async override void Actualizar(object sender, EventArgs e)
        {
            EtiquetasListBox.Enabled = false;            
            
            OnStatusStringChanged(new ChangeStatusMessageEventArgs { Title = "Cargando..", Message = "Cargando Clientes..." });

            await DB.Etiquetas.LoadAsync();

            etiquetaBindingSource.DataSource = DB.Etiquetas.Local.ToBindingList();
            etiquetaBindingSource.ResetBindings(false);
            EtiquetasListBox.Invalidate();
            EtiquetasListBox.Enabled = true;

            OnStatusStringChanged(new ChangeStatusMessageEventArgs { Title = "Listo", Message = "Listo" });
        }
        public override void Buscar(object sender, string SearchString)
        {
            var filter = DB.Etiquetas.Local
                 .Where(x => x.Nombre.ToLower().Contains(SearchString.ToLower()));

            etiquetaBindingSource.DataSource = filter;
        }

    }
}
