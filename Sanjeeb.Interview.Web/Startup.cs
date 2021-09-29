using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sanjeeb.Interview.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sanjeeb.Interview.Web
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
            //services.AddDbContext<GroundDBContext>(cfg =>
            //{
            //    cfg.UseSqlServer(Configuration.GetConnectionString("GroundControlConnectionString"));

            //});
            services.AddRazorPages();
            services.AddMvc();
            services.AddControllersWithViews();

            services.AddHttpClient<IGarageServices, GarageServices>(
                                        client => client.BaseAddress =
                                            new Uri(Configuration.GetConnectionString("APIConnection"))
                                        );
            services.AddCors(options => {
                options.AddPolicy("open", builder => builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("PUT", "GET", "DELETE"));
            });
            services.AddControllersWithViews()
               .AddJsonOptions(
                       options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
               .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
            
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

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("Open");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default","/{controller}/{action}/{id?}",
                    new { controller = "Booking", action = "Index" });
                endpoints.MapRazorPages();
            });

        }
    }
}
