using AspNetCore.Reporting;
using ExcelNobleza.Shared.Models.Reportes;
using ExcelNobleza.Shared.Models.Tablas.Produccion;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Procesos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WappExcelNobleza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly excelnobleza.shared.ApplicationDbContextCore db;
        private readonly HttpClient _httpClient;
        public ReportsController(IWebHostEnvironment webHostEnvironment, HttpClient client)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._httpClient = client;


            DbContextOptionsBuilder<excelnobleza.shared.ApplicationDbContextCore> ob = new DbContextOptionsBuilder<excelnobleza.shared.ApplicationDbContextCore>();
            ob.UseLazyLoadingProxies();

            this.db = new excelnobleza.shared.ApplicationDbContextCore(ob.Options);

            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [HttpGet]
        [Route("vcReport/{_OT}.pdf")]
        public async Task<IActionResult> VariablesCriticasReport(string _OT)
        {
            // Busco la informacion en la base de datos
            // -OT
            OrdenTrabajo Ot = await db.OrdenesTrabajo
                .FirstOrDefaultAsync(o => o.OT == _OT);

            // Indico la ubicación del reporte
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\VariablesCriticas.rdlc";

#if DEBUG

            // Leo el recurso incrustado con la definicion del reporte en el Dll
            var assembly = Assembly.LoadFile(typeof(ExcelNobleza.Shared.Models.Reportes.VC_ProcesoReportData).Assembly.Location);
            Stream stream = assembly.GetManifestResourceStream("ExcelNobleza.Shared.Reportes.Prueba.rdlc");

            if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
            // Guardo la definicion del reporte en el directorio indicado
            using (var fileStream = new FileStream(path, FileMode.CreateNew))
            {
                await stream.CopyToAsync(fileStream);
                Console.WriteLine("File copied.");
            }

#endif

            // Creo la instancia del reporte
            LocalReport report = new LocalReport(path);
            // Agrego los datos al datasource el reporte
            report.AddDataSource("DataSet1", VC_ProcesoReportData.GetData(Ot));
            // Renderizo el reporte
            var result = report.Execute(RenderType.Pdf, 1, null, "");

            // Devuelvo el reporte como un PDF
            return File(result.MainStream.Stream, "application/pdf");
        }
    }
}
