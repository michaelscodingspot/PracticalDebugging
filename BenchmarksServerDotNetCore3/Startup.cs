using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarksServerDotNetCore3.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Utf8Json.AspNetCoreMvcFormatter;
using Utf8Json.Resolvers;

namespace BenchmarksServerDotNetCore3
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
            services.AddControllersWithViews()

                //Uncomment for Newtonsoft
                //.AddNewtonsoftJson()

                //Uncomment for Utf8Json
                .AddMvcOptions(option =>
                {

                    option.OutputFormatters.Clear();
                    // can pass IJsonFormatterResolver for customize.
                    option.OutputFormatters.Add(new Utf8JsonOutputFormatter1(StandardResolver.Default));
                    option.InputFormatters.Clear();
                    // if does not pass, library should use JsonSerializer.DefaultResolver.
                    option.InputFormatters.Add(new Utf8JsonInputFormatter1());
                });
            ;

                //services.AddMvc();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
