using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows;
using ManagerSalesTestProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManagerSalesTestProject;


public partial class App : Application
{
    public IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        try
        {
            // Настройка сервисов
            var services = new ServiceCollection();

            // Регистрация DbContext
            services.AddDbContext<ManagerSalesTestProjectContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=ManagerSalesTestProject;Username=postgres; Password=admin;"));

            services.AddScoped<DataService>();
            // Регистрация других сервисов
            services.AddSingleton<MainWindow>();


           
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка!");
            Shutdown();
        }
    }

 
}
