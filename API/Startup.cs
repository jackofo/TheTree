using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure;
using System;
using Core.Interfaces;
using Core.Services;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ProjectContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TreeDatabase")));
            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});
            services.AddControllers();
			services.AddCors();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //if (!env.IsDevelopment())
            //{
            //    app.UseSpaStaticFiles();
            //}

            app.UseRouting();

            app.UseCors(options =>
            {
                options
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
			
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });


        }
        public void ConfigurationDependencyInjection(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddAutoMapper();
            services.AddScoped<Core.Services.IPersonService, Core.Services.IPersonService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IDeckService, DeckService>();
            services.AddScoped<IRevisionService, RevisionService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IDrawingService, DrawingService>();
            services.AddScoped<IDrawingGroupService, DrawingGroupService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<INetService, NetService>();
            services.AddScoped<ITrayNetworkService, TrayNetworkService>();
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddScoped<IAuditSessionService, AuditSessionService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<ICircuitService, CircuitService>();
            services.AddScoped<IAuditSessionDeviceService, AuditSessionDeviceService>();
            services.AddScoped<IAuditSessionDeckService, AuditSessionDeckService>();
            services.AddScoped<IAuditSessionCircuitService, AuditSessionCircuitService>();
            services.AddScoped<IAuditSessionRoomService, AuditSessionRoomService>();
            services.AddScoped<IAuditSessionDrawingService, AuditSessionDrawingService>();
            services.AddScoped<IAuditSessionTrayNetworkService, AuditSessionTrayNetworkService>();
            services.AddScoped<IReferenceTablesService, ReferenceService>();
        }
    }
}
