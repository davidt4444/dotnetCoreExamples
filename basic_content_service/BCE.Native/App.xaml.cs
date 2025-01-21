using System;
using System.IO;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using BCS.Api.Services; // Assuming IPostService and PostService are here
using BCS.Api.Data; // Assuming YourDbContext is here
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace BCE.Native
{
    public partial class App : Application
    {
        public IServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            Services = serviceCollection.BuildServiceProvider();

            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            StreamReader sr = new StreamReader("../../../aws-resources/localhost-mac-dotnet.txt");
            services.AddDbContext<YourDbContext>(options =>
                // options.UseMySql("YourConnectionString", sr.ReadToEnd()));
                options.UseMySQL(sr.ReadToEnd()));
            services.AddScoped<IPostService, PostService>();
            services.AddSingleton<MainWindow>();
            // Add other services as needed
        }
    }
}