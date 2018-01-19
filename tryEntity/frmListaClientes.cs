using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using libProduccionDataBase.Tablas;
using System.Diagnostics;
using libProduccionDataBase;

namespace tryEntity
{
    public partial class frmListaClientes : Form, IformRibbonTab
    {
        MdiTabControl.TabControl tab;
        private libProduccionDataBase.Contexto.DataBaseContexto DB;

        public TiposFormulario TipoFRM { get { return TiposFormulario.Lista; } }

        public frmListaClientes(MdiTabControl.TabControl tab = null) { this.tab = tab; InitializeComponent(); }

        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            DB = new libProduccionDataBase.Contexto.DataBaseContexto();
            DB.Database.Log = Console.Write;
            DB.Clientes.Load();
            clienteBindingSource.DataSource = DB.Clientes.Local.ToBindingList();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            refreshBinding();
        }

        /// <summary>
        /// Refresca los datos del binding
        /// </summary>
        private void refreshBinding()
        {
            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this.DB)
               .ObjectContext
               .Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, DB.Clientes);
        }
        public void Actualizar()
        {
            refreshBinding();
        }

        public DialogResult Edit()
        {
            if (clienteBindingSource.Current != null)
            {
                using (var frm = new frmEditAddClientes((libProduccionDataBase.Tablas.Cliente)clienteBindingSource.Current))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            this.clienteBindingSource.ResetCurrentItem();
                            DB.SaveChanges();
                            return DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, Auxiliares.ValidationAndErrorMessages(DB, ex), "Algo Salio mal...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    DB.Entry(this.clienteBindingSource.Current).Reload();
                    this.clienteBindingSource.ResetCurrentItem();
                };
            }
            return DialogResult.Cancel;
        }

        public DialogResult AddNew()
        {
            using (var frm = new frmEditAddClientes())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        clienteBindingSource.DataSource = DB.Clientes.Local.ToBindingList();
                        clienteBindingSource.Add(frm.Cliente);
                        DB.SaveChanges();
                        return DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, Auxiliares.ValidationAndErrorMessages(DB, ex), "Algo Salio mal...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return DialogResult.Cancel;
            }
        }

        public void Search(object param)
        {
            string tosearch = param.GetType() == typeof(string) ? (string)param : param.ToString();
            var filter = DB.Clientes.Local
                 .Where(x => x.NombreCliente.ToLower().Contains(tosearch.ToLower()) || x.ClaveCliente.ToLower().Contains(tosearch.ToLower()));
            clienteBindingSource.DataSource = filter;
        }

        public DialogResult Delete()
        {
            try
            {
                if (clienteBindingSource.Current != null)
                {
                    this.clienteBindingSource.RemoveCurrent();
                    DB.SaveChanges();
                    return DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(libProduccionDataBase.Auxiliares.GetInnerException(ex));
            }
            return DialogResult.Cancel;
        }

        public void Export(TipoExport Tipo)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }
    }
}
