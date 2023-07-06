using anbardari.domain;
using anbardari.domain.Repository.UserRepository;
using anbardari.window;
using anbardari.windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace anbardari
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? appHost { get; private set; }

        protected override async void OnStartup(StartupEventArgs e)
        {
            appHost = CreateHostBuilder(e.Args).Build();
            await appHost!.StartAsync();

            MigrateDbContext(appHost);

            //LoginWindow loginWindow = appHost.Services.GetRequiredService<LoginWindow>();
            var startupWindow = appHost.Services.GetRequiredService<MainWindow>();
            startupWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await appHost!.StopAsync();

            base.OnExit(e);
        }

        #region - Methods -

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) => { })
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddSingleton<MainWindow>();
                 services.AddSingleton<LoginWindow>();
                 services.AddSingleton<UsersWindows>();
                 services.AddScoped<IUserRepository, UserRepository>();

                 services.AddSingleton<Dispatcher>(_ => Current.Dispatcher);
                 services.AddDbContext<MyDbContext>(
                     options =>
                     {
                         options.UseSqlServer("Server=.;Database=anbardaridb;User Id=sa;Password=Kaveh1!@;TrustServerCertificate=true;");
                         options.UseLazyLoadingProxies();
                     });
             });

        private static void MigrateDbContext(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            using (var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>())
            {
                dbContext.Database.Migrate();

                ILogger<MyDbContextSeed> logger = scope.ServiceProvider.GetRequiredService<ILogger<MyDbContextSeed>>();

                MyDbContextSeed.SeedAsync(dbContext, logger).Wait();
            }
        }

        #endregion
    }
}
