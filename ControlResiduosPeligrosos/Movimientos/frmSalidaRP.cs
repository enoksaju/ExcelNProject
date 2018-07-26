using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ControlResiduosPeligrosos.Reportes.Vistas;
using libProduccionDataBase.Tablas;
using Microsoft.Reporting.WinForms;

namespace ControlResiduosPeligrosos.Movimientos
{
  public partial class frmSalidaRP : KryptonForm
  {
    public libProduccionDataBase.Contexto.DataBaseContexto DB;


    public frmSalidaRP()
    {
      InitializeComponent();
      DB = new libProduccionDataBase.Contexto.DataBaseContexto();
      this.Load += FrmSalidaRP_Load;

#if DEBUG
      DB.Database.Log = Console.Write;
#endif

    }

    private async void FrmSalidaRP_Load(object sender, EventArgs e)
    {
      await DB.Lineas.LoadAsync();
      await DB.TiposRP.LoadAsync();

      this.tipoRPBindingSource.DataSource = DB.TiposRP.Local.ToBindingList();
      this.lineaBindingSource.DataSource = DB.Lineas.Local.ToBindingList();
      this.salidaRPBindingSource.DataSource = DB.SalidasRP.Local.ToBindingList();
      this.salidaRPBindingSource.AddNew();

      SalidaRP curr = (SalidaRP)salidaRPBindingSource.Current;
      curr.FechaEnvasado = DateTime.Now.Date;
      curr.FechaIngreso = DateTime.Now.Date;

      salidaRPBindingSource.ResetCurrentItem();
    }

    private async void kryptonButton1_Click(object sender, EventArgs e)
    {
      try
      {
        this.salidaRPBindingSource.EndEdit();
        await this.DB.SaveChangesAsync();

        using (var repView = new ReportViewer())
        {
          using (var vstSalidaRPBindingSource = new System.Windows.Forms.BindingSource())
          {
            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "dsVstSalidaRP";
            reportDataSource1.Value = vstSalidaRPBindingSource;
            repView.LocalReport.DataSources.Add(reportDataSource1);
            repView.LocalReport.ReportEmbeddedResource = "ControlResiduosPeligrosos.Reportes.repSalidaRP.rdlc";
            SalidaRP curr = (SalidaRP)salidaRPBindingSource.Current;

            var y = new List<VstSalidaRP>();
            y.Add(new VstSalidaRP
            {
              Linea = curr.Linea.Nombre,
              ResponsableLinea = curr.Linea.Responsable,
              TipoRP = curr.TipoRP.Descripcion,

              RiesgoRP = curr.TipoRP.Riesgo.ToString(),
              UnidadRP = curr.TipoRP.Unidad.ToString(),
              FechaEnvasado = curr.FechaEnvasado,
              FechaIngreso = curr.FechaIngreso,
              Cantidad = curr.Cantidad,
              FolioRP = curr.FolioRP,
              valRiesgoRP = (int)curr.TipoRP.Riesgo
            });

            vstSalidaRPBindingSource.DataSource = y;
            Stream pdf = new MemoryStream(repView.LocalReport.Render("pdf"));
            var ct = new ContentType(MediaTypeNames.Application.Pdf);
            var attach = new Attachment(pdf, ct) { ContentType = new ContentType(MediaTypeNames.Application.Pdf) };
            attach.ContentType.Name = $"{curr.Linea.Nombre.Replace(" ", "")}_{curr.TipoRP.Descripcion}_{curr.FolioRP}.pdf";

            var email = new System.Net.Mail.MailMessage((
              curr.Linea.EmailResponsable ?? Properties.Settings.Default.CorreoReceptorSalidas) + Properties.Settings.Default.DominioCorreo,
              Properties.Settings.Default.CorreoReceptorSalidas + Properties.Settings.Default.DominioCorreo)
            {
              IsBodyHtml = true,
              Body = $"Linea:{curr.Linea.Nombre}, Tipo de Residuo:{curr.TipoRP.Descripcion}, Peso:{curr.Cantidad} Kg, Fecha de Ingreso: {curr.FechaIngreso.ToString("dd/MMMM/yyyy")}",
              Subject = "Salida Residuo Peligroso"
            };

            email.Attachments.Add(attach);

            var mailClient = new SmtpClient("mail.excelnobleza.com.mx", 26);
            var credentials = new System.Net.NetworkCredential("hsalinas@excelnobleza.com.mx", "hsj43295");
            mailClient.UseDefaultCredentials = false;
            mailClient.Credentials = credentials;
            mailClient.Send(email);

            using (var frm = new KryptonForm() { ClientSize = new Size(400, 400), Text = "Vista previa de Formato", ShowIcon = false, MinimizeBox = false, MaximizeBox = false })
            {
              repView.Dock = DockStyle.Fill;
              frm.Controls.Add(repView);
              repView.RefreshReport();
              frm.ShowDialog();
            }
          }
        }

        KryptonTaskDialog.Show("Muy bien...", "Correcto", "El elemento se guardo correctamente!!", MessageBoxIcon.Information, TaskDialogButtons.OK);
        this.Close();
      }
      catch (Exception ex)
      {
        KryptonTaskDialog.Show("Algo va mal...", "Error", ex.Message, MessageBoxIcon.Error, TaskDialogButtons.OK);
      }
    }

    private void kryptonButton2_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmSalidaRP_FormClosing(object sender, FormClosingEventArgs e)
    {

    }

    private void frmSalidaRP_Load_1(object sender, EventArgs e)
    {

    }
  }
}
