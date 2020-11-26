using AtomHealth.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AtomHealth
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
            services.AddControllers()
           .AddXmlSerializerFormatters();
           
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            services.AddControllers(options =>
            {
                // requires using Microsoft.AspNetCore.Mvc.Formatters;
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            });

           

            services.AddDbContextPool<ConnectionDB>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionDetail")));
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession();

            //services.AddAuthentication().AddGoogle(options =>
            //{
            //    options.ClientId = "821809288879-qn2ehvppi31dv2gdfvm0srim6an5g4vn.apps.googleusercontent.com";
            //    options.ClientSecret = "HV3nBZX4WtxQ2XVuAn9C1aCf";
            //});
           
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["Authentication:Google:821809288879-qn2ehvppi31dv2gdfvm0srim6an5g4vn.apps.googleusercontent.com"];
                googleOptions.ClientSecret = Configuration["Authentication:Google:HV3nBZX4WtxQ2XVuAn9C1aCf"];
            });

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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
