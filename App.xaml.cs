using System.Configuration;
using System.Data;
using System.Windows;

namespace ManagerSalesTestProject;


public  class App : Application
{
    public IConfiguration configuration {  get; set; }
    public IServiceProvider serviceProvider { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // 2. Настройка сервисов
        var services = new ServiceCollection();

        // Добавляем контекст БД
        services.AddDbContext<ManagerSalesTestProjectContext>(options => 
                    options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
            
                // Добавляем необходимые сервисы
                services.AddTransient<IDataService, DataService>();
                services.AddTransient<MainViewModel>();
                services.AddSingleton<MainWindow>();

                // 3. Создаем провайдер сервисов
                var serviceProvider = services.BuildServiceProvider();

        // 4. Автоматически создаем БД (если не существует)
        var dbContext = serviceProvider.GetService<ManagerSalesTestProjectContext>();
        dbContext.Database.EnsureCreated();

                // 5. Запускаем главное окно
                var mainWindow = serviceProvider.GetService<MainWindow>();
        mainWindow.Show();
            }
}

