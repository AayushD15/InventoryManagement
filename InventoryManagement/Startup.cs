using InventoryManagement.Data.Repository.Master;
using InventoryManagement.Data.Sql;
using InventoryManagement.Handler.Handler.Master;
using InventoryManagement.Helpers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private AppSettings appSettings;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSetting");
            services.Configure<AppSettings>(appSettingsSection);
            appSettings = appSettingsSection.Get<AppSettings>();

            services.AddMemoryCache();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Inventory Management Api",
                    Version = "v1",
                });
            });
            services.AddDbContext<InventoryManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("InventoryManagementDbContext")));

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddMediatR(typeof(InvoiceRepository).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddInvoiceCommandHandler).GetTypeInfo().Assembly);
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddMediatR(typeof(ItemRepository).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(AddItemCommandHandler).GetTypeInfo().Assembly);
            services.AddLogging();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory Management Api v1"));
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
