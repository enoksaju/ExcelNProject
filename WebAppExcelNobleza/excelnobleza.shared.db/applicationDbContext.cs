using ExcelNobleza.Shared.Models.Tablas.Desperdicios;
using ExcelNobleza.Shared.Models.Tablas.Otros;
using ExcelNobleza.Shared.Models.Tablas.Produccion;
using ExcelNobleza.Shared.Models.Tablas.Produccion.NaveCuatro;
using ExcelNobleza.Shared.Models.Tablas.ResiduosPeligrosos;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Bases;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Parametros;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas.Procesos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace excelnobleza.shared
{
	public class ApplicationDbContextCore : DbContext
	{
#if DEBUG
		private ILoggerFactory MyLoggerFactory;
#endif
		public ApplicationDbContextCore(DbContextOptions<ApplicationDbContextCore> options) : base(options) { }
		public ApplicationDbContextCore()
		{
			
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			var confPath = System.IO.Path.GetDirectoryName(typeof(ExcelNobleza.Shared.Models.Reportes.VC_ProcesoReportData).Assembly.Location);
			var Conf = new ConfigurationBuilder()
				.SetBasePath(confPath)
				.AddJsonFile("dbSettings.json", optional: true, reloadOnChange: true)
				.Build();

#if DEBUG
			MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
			optionsBuilder
				.UseLoggerFactory(MyLoggerFactory)
				.EnableSensitiveDataLogging()
#else
			optionsBuilder
#endif
				.UseMySQL(Conf.GetConnectionString("Default"));
		}
		protected override void OnModelCreating(ModelBuilder mb)
		{
			base.OnModelCreating(mb);
			mb.Entity<Etiqueta>().HasIndex(b => b.Nombre);

			mb.Entity<NaveCuatro_TarimaItem>(o =>
			{
				o.HasKey(e => new { e.Item_Id, e.Tarima_Id });
			});

			mb.Entity<Produccion>(o =>
			{
				o.HasIndex(e => e.NUMERO);
				o.HasIndex(e => e.INDICE).IsUnique();
			});

			mb.Entity<ProcesoImpresion>();
			mb.Entity<ProcesoLaminacion>();
			mb.Entity<ProcesoRefinadoEmbobinado>();
			mb.Entity<BaseProceso>(o =>
			{
				o.ToTable("vc_procesos");
				o.HasIndex(i => new { i.ProcesoId, i.ClaveDiseño }).IsUnique().HasName("IndexProcesoDiseno");
			});


			mb.Entity<ParametrosImpresion>();
			mb.Entity<ParametrosLaminacion>();
			mb.Entity<ParametrosRefinadoEmbobinado>();
			mb.Entity<BaseParametros>(o =>
			{
				o.ToTable("vc_parametros");
				o.HasIndex(i => new { i.BaseProcesoId, i.MaquinaId }).IsUnique().HasName("IndexParametrosProcesoMaquina");
			});

			mb.Entity<DeckImpresion>(o =>
			{
				o.HasKey(i => new { i.ParametrosId, i.unidad });
			});

			mb.Entity<EstructuraItem>(o =>
			{
				o.HasKey(i => new { i.ClaveDiseño, i.Posicion });
			});
		}

		// Produccion
		public DbSet<Linea> Lineas { get; set; }
		public DbSet<Maquina> Maquinas { get; set; }
		public DbSet<TipoProducto> TiposProducto { get; set; }
		public DbSet<TipoMaquina> TiposMaquina { get; set; }
		public DbSet<OrdenTrabajo> OrdenesTrabajo { get; set; }
		public DbSet<InfoExtra> OrdenesTrabajoInfoExtra { get; set; }
		public DbSet<Produccion> Produccion { get; set; }
		public DbSet<Desperdicio> Despedicios { get; set; }
		public DbSet<TDefecto> Defectos { get; set; }
		public DbSet<TFamiliaDefectos> FamiliasDefectos { get; set; }
		public DbSet<Proceso> Procesos { get; set; }
		public DbSet<NaveCuatro_Tarima> NCuatro_Tarimas { get; set; }
		public DbSet<NaveCuatro_TarimaItem> NCuatro_Tarima_Items { get; set; }



		// Control de Residuos Peligrosos
		public DbSet<TipoRP> TiposRP { get; set; }
		public DbSet<Transportista> Transportistas { get; set; }
		public DbSet<Proveedor> Proveedores { get; set; }
		public DbSet<Manifiesto> Manifiestos { get; set; }
		public DbSet<ManifiestoDetalle> ManifiestosDetalle { get; set; }
		public DbSet<SalidaRP> SalidasRP { get; set; }


		/// <summary>
		/// Coleccion de etiquetas en formato zpl
		/// </summary>
		public DbSet<Etiqueta> Etiquetas { get; set; }

		// AVT System
		public virtual DbSet<AVTFolios> AVTFolios { get; set; }


		// VariablesCriticas
		public virtual DbSet<Diseno> VC_Diseño { get; set; }
		public virtual DbSet<BaseProceso> VC_BaseProcesos { get; set; }
		public DbSet<ProcesoImpresion> VC_ProcesosImpresion { get; set; }
		public DbSet<ProcesoLaminacion> VC_ProcesosLaminacion { get; set; }
		public DbSet<ProcesoRefinadoEmbobinado> VC_ProcesosRefinadoEmbobinado { get; set; }
		public DbSet<BaseParametros> VC_BaseParametros { get; set; }

	}
}
