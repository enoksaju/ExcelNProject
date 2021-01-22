using Blazored.LocalStorage;
using ExcelNobleza.Shared.Models.Tablas.Produccion;
using ExcelNobleza.Shared.Models.Tablas.VariablesCriticas;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Net.Http;
using WappExcelNobleza.Areas.Identity;
using WappExcelNobleza.Data;
using WappExcelNobleza.Data.Models.Identity;
using WappExcelNobleza.Services;

namespace WappExcelNobleza
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options
                .UseMySQL(Configuration.GetConnectionString("MySQLDefaultConnection")));

            services.AddDbContext<excelnobleza.shared.ApplicationDbContextCore>();

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.ClaimsIdentity.RoleClaimType = System.Security.Claims.ClaimTypes.Role;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IClaimsTransformation, CustomClaims>();

            services.AddAuthorization(configure =>
            {
                configure.AddPolicy("IsRoot", policy => policy.RequireRole("Admin", "Developer", "Systems"));
            });

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>();


            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
            services.AddSingleton<MainStateContainer>();

            services.AddBlazoredLocalStorage();

            services.AddTransient<IOperationsDataBase<Maquina>, OperationsDataBase<Maquina>>();
            services.AddTransient<IOperationsDataBase<Linea>, OperationsDataBase<Linea>>();
            services.AddTransient<IOperationsDataBase<Diseno>, OperationsDataBase<Diseno>>();
            services.AddTransient<IOperationsDataBase<OrdenTrabajo>, OperationsDataBase<OrdenTrabajo>>();

            services.AddTransient<IOperationsDataBase<TipoMaquina>, OperationsDataBase<TipoMaquina>>();

            services.AddTransient<IMessageService, MessageService>();


            services.AddSingleton<HttpClient>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();


            var provider = new FileExtensionContentTypeProvider();

            // Add new MIME type mappings

            provider.Mappings[".properties"] = "application/octet-stream";

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                ContentTypeProvider = provider
            });

            // app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
