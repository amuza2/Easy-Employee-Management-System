using EEMS.BusinessLogic.Interfaces;
using EEMS.BusinessLogic.Services;
using EEMS.DataAccess;
using EEMS.UI.Views.Employee;
using EEMS.UI.Views.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace EEMS;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var service = new ServiceCollection();
        ConfigureServices(service);

        // Build the service provider
        ServiceProvider = service.BuildServiceProvider();

        // Show the main window
        var mainWindow = ServiceProvider.GetRequiredService<Func<MainWindow>>()();
        mainWindow.Show();
    }

    private void ConfigureServices(ServiceCollection service)
    {
        // Register DbContext
        service.AddDbContext<EEMSDbContext>(options =>
            options.UseSqlServer(ConfigHelper.GetConnectionString()));

        // Register services
        service.AddTransient<IEmployeeService, EmployeeService>();

        // Register ViewModels
        service.AddTransient<EmployeeViewModel>();

        // Register pages
        service.AddTransient<EmployeePage>();

        //Register Views
        service.AddTransient<MainWindow>();

        // Register Navigation Service
        service.AddTransient<INavigationService, NavigationService>();

        // Resiter main window
        service.AddTransient<Func<MainWindow>>(serviceProvider =>
            () => new MainWindow(serviceProvider.GetRequiredService<INavigationService>()));

    }
}

