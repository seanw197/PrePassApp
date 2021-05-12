using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrePass.Data;
using Microsoft.Data.SqlClient;

namespace PrePass
{
     public class Startup
    {
        private readonly IConfiguration _configuration;

        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;

            _env = env;
        }

        //public Startup(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        private string BuildConnectionString()
        {
            // string connectionString = _configuration.GetConnectionString("AzureConnection");

            string connString = _configuration.GetConnectionString("AzureConnection");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connString);

            if (_env.IsDevelopment())
            {
                builder.Password = _configuration["Password"];
            }

            return builder.ToString();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<PrePassContext>(options => options.UseSqlServer(BuildConnectionString()));
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // lines below allow dates in d/M/yyyy format to be used on azure

            var supportedCultures = new[] { "en-GB", "en-US" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
