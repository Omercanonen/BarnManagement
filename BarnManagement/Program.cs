using BarnManagement.Business.Abstract;
using BarnManagement.Business.Profiles;
using BarnManagement.Business.Services;
using BarnManagement.Core.Logging;
using BarnManagement.Data;
using BarnManagement.Model;
using BarnManagement.View;
using BarnManagement.View.Pages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BarnManagement
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var builder = Host.CreateDefaultBuilder();

            builder.ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });
                services.AddAutoMapper(typeof(MappingProfile));
                services.AddSingleton<ILoggerService, FileLogger>();
                services.AddIdentityCore<ApplicationUser>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

                services.AddScoped<IAgingService, AgingService>();
                services.AddScoped<IProductionService, ProductionService>();

                services.AddTransient<Login>();
                services.AddTransient<MainForm>();
                services.AddTransient<CreateBarnForm>();
                services.AddTransient<AddUserForm>();   
                services.AddTransient<HomePage>();
                services.AddTransient<PurchasePage>();
                services.AddTransient<ProductionPage>();
                services.AddTransient<InventoryPage>();
            });

            var host = builder.Build();
            ServiceProvider = host.Services;

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                MessageBox.Show($"Beklenmedik bir hata: {((Exception)e.ExceptionObject).Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            try
            {
                var loginForm = ServiceProvider.GetRequiredService<Login>();
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Başlangıç hatası: {ex.Message}\nLütfen appsettings.json bağlantısını ve Login formunu kontrol edin.");
            }
        }
    }
}