using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hangfire;
using StoreManagement.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Foundation.Abstraction.Repository;
using StoreManagement.Infrastructure.Repository;
using StoreManagement.Business.Service;
using OVM.Jobs.Schedules;
using Foundation.Abstraction;
using Foundation.Abstraction.Service;
using AutoMapper;
using StoreManagement.Business.Profiles;
using Foundation.Common;

namespace StoreManagement.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")), ServiceLifetime.Scoped);
            services.AddHangfire(config => {
                config.UseSqlServerStorage(Configuration.GetConnectionString("ConnectionString"));
            });

            //startup
            //GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 1 });
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            var mapper = config.CreateMapper();
            // dependency
            services.AddSingleton<IMapper>(mapper);
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IMailingService, MailingService>();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseHangfireServer();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            //proje açýlýnca /storehangfire ile hangfire dashboard sayfasýna giiyoruz.
            app.UseHangfireDashboard("/storehangfire",new DashboardOptions
            {
                DashboardTitle = "Store Management Background Jobs", // dashboard baþlýðý
                AppPath ="",                                         // back to site butonuna verilecek path
                //Authorization -> güvenlik ayarlamalarýda buradan yapýlýyor.
            });

            RecurringJobs.Start();

        }
    }
}
