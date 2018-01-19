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
using libProduccionDataBase;

namespace tryEntity
{
    public partial class frmListaImpresoras : Form, IformRibbonTab
    {
        libProduccionDataBase.Contexto.DataBaseContexto DB;
        public frmListaImpresoras()
        {
            InitializeComponent();
            DB = new libProduccionDataBase.Contexto.DataBaseContexto();
            DB.Database.Log = Console.Write;
        }
        private void frmListaMaquinas_Load(object sender, EventArgs e)
        {
            DB.Maquinas.Where(t => t.TipoMaquina_Id == 1).Include(testc => testc.Rodillos).Load();
            maquinaBindingSource.DataSource = DB.Maquinas.Local.ToBindingList();
        }

        public TiposFormulario TipoFRM { get { return TiposFormulario.Lista; } }

        public void Actualizar()
        {
            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this.DB)
                .ObjectContext
                .Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, DB.Maquinas.Where(t => t.TipoMaquina_Id == 1).Include(r => r.Rodillos));
        }

        public DialogResult AddNew()
        {
            using (var frm = new frmEditAddImpresora(DB))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        maquinaBindingSource.DataSource = DB.Maquinas.Local.ToBindingList();
                        maquinaBindingSource.Add(frm.Maquina);
                        DB.SaveChanges();
                        return DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, Auxiliares.ValidationAndErrorMessages(DB, ex), "Algo Salio mal...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        maquinaBindingSource.RemoveCurrent();
                    }
                }
                return DialogResult.Cancel;
            }
        }

        public DialogResult Delete()
        {
            try
            {
                if (maquinaBindingSource.Current != null)
                {
                    maquinaBindingSource.Remove(maquinaBindingSource.Current);
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

        public DialogResult Edit()
        {
            if (maquinaBindingSource.Current != null)
            {
                using (var frm = new frmEditAddImpresora(DB,(libProduccionDataBase.Tablas.Maquina)maquinaBindingSource.Current))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            this.maquinaBindingSource.ResetCurrentItem();
                            foreach (var Rod in DB.Rodillos.Local.ToList())
                            {
                                if (Rod.Maquina == null)
                                {
                                    DB.Rodillos.Remove(Rod);
                                }
                            }

                            DB.SaveChanges();
                            return DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, Auxiliares.ValidationAndErrorMessages(DB, ex), "Algo Salio mal...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (this.maquinaBindingSource.Current != null) DB.Entry(this.maquinaBindingSource.Current).Reload();
                    this.maquinaBindingSource.ResetCurrentItem();

                };
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

        public void Search(object param)
        {
            throw new NotImplementedException();
        }


    }
}
