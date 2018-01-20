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
using libProduccionDataBase.Tablas;

namespace tryEntity
{
    public partial class frmListaMateriales : Form, IformRibbonTab
    {
        public libProduccionDataBase.Contexto.DataBaseContexto DB;
        public frmListaMateriales()
        {
            InitializeComponent();
            DB = new libProduccionDataBase.Contexto.DataBaseContexto();
            DB.Database.Log = Console.Write;
        }
        private void frmListaMateriales_Load(object sender, EventArgs e)
        {
            DB.FamiliasMateriales.Include(r => r.Materiales).Load();
            familiaMaterialesBindingSource.DataSource = DB.FamiliasMateriales.Local.ToBindingList();
        }

        public TiposFormulario TipoFRM { get { return TiposFormulario.Lista; } }

        public void Actualizar()
        {
            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this.DB)
              .ObjectContext
              .Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, DB.FamiliasMateriales.Include(r => r.Materiales));
        }

        public DialogResult AddNew()
        {
            using (var frm = new frmEditAddMaterial((libProduccionDataBase.Tablas.FamiliaMateriales)familiaMaterialesBindingSource.Current))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        familiaMaterialesBindingSource.ResetCurrentItem();
                        DB.SaveChanges();
                        return DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, Auxiliares.ValidationAndErrorMessages(DB, ex), "Algo Salio mal...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        materialesBindingSource.RemoveCurrent();
                    }
                }
                return DialogResult.Cancel;
            }
        }

        public DialogResult Delete()
        {
            try
            {
                if (materialesBindingSource.Current != null)
                {
                    materialesBindingSource.RemoveCurrent();
                    foreach (var Rod in DB.Materiales.Local.ToList())
                    {
                        if (Rod.FamiliaMateriales == null)
                        {
                            DB.Materiales.Remove(Rod);
                        }
                    }
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
            if (materialesBindingSource.Current != null)
            {
                using (var frm = new frmEditAddMaterial((libProduccionDataBase.Tablas.FamiliaMateriales)familiaMaterialesBindingSource.Current, (libProduccionDataBase.Tablas.Material)materialesBindingSource.Current))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            familiaMaterialesBindingSource.ResetCurrentItem();
                            DB.SaveChanges();
                            return DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, Auxiliares.ValidationAndErrorMessages(DB, ex), "Algo Salio mal...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            materialesBindingSource.RemoveCurrent();
                        }
                    }
                    if (this.materialesBindingSource.Current != null) DB.Entry(this.familiaMaterialesBindingSource.Current).Reload();
                    this.familiaMaterialesBindingSource.ResetCurrentItem();
                }
            }
            return DialogResult.Cancel;
        }

        public void Export(TipoExport Tipo)
        {
            throw new Exception("La tabla Actual no permite Exportar los Datos.");
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public void Search(object param)
        {
            throw new Exception("La tabla actual no permite busquedas.");
        }

        private void btnAddFam_Click(object sender, EventArgs e)
        {
            var t = InputBox.ShowDialog(this,"Ingrese el nombre de la Familia", "Agregar una Familia");
            if (t.DialogResult == DialogResult.OK &&
                MessageBox.Show(this,
                    "Realmente desea agregar la Familia de Materiales " + t.StringResult + "?",
                    "Confirme",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes
                    )
            {
                familiaMaterialesBindingSource.Add(new FamiliaMateriales { NombreFamilia = t.StringResult });
                DB.SaveChanges();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (familiaMaterialesBindingSource.Current != null)
            {
                var t = InputBox.ShowDialog(this,"Ingrese el nuevo nombre de la Familia", "Editar una Familia", ((FamiliaMateriales)familiaMaterialesBindingSource.Current).NombreFamilia);
                if (t.DialogResult == DialogResult.OK &&
                    MessageBox.Show(this,
                        "Realmente desea modificar la Familia de Materiales?",
                        "Confirme",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes
                        )
                {
                    ((FamiliaMateriales)familiaMaterialesBindingSource.Current).NombreFamilia = t.StringResult;
                    familiaMaterialesBindingSource.ResetCurrentItem();
                    DB.SaveChanges();
                }
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                "Realmente desea eliminar la Familia de Materiales ?",
                "Confirme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes
                )
            {
                familiaMaterialesBindingSource.RemoveCurrent();
                DB.SaveChanges();
            }
        }
    }
}
