using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESourcingProducts.Data;
using ESourcingProducts.Data.interfaces;
using ESourcingProducts.Repositories;
using ESourcingProducts.Repositories.Ýnterfaces;
using ESourcingProducts.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace ESourcingProducts
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
            services.AddControllersWithViews();
            services.Configure<ProductDataBaseSettings>(Configuration.GetSection(nameof(ProductDataBaseSettings)));
            services.AddSingleton<IProductDataBaseSettings>(sp=>sp.GetRequiredService<IOptions<ProductDataBaseSettings>>().Value);
            services.AddTransient<IProductContext, ProductContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            #region Swagger Dependencies
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "ESourcing.Products",
                        Version = "v1"
                    });
                }); 
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.Json", "ESourcing.Products v1"));
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
