using EEMS.BusinessLogic.Interfaces;
using EEMS.BusinessLogic.Services;
using EEMS.DataAccess;
using EEMS.UI.UserControls;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Absences;
using EEMS.UI.Views.Dashboard;
using EEMS.UI.Views.Employees;
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
        //service.AddDbContext<EEMSDbContext>(options =>
        //    options.UseSqlServer(ConfigHelper.GetConnectionString()),
        //    ServiceLifetime.Transient);
        service.AddDbContextFactory<EEMSDbContext>(options =>
            options.UseSqlServer(ConfigHelper.GetConnectionString()));

        // Register services
        service.AddTransient<IEmployeeService, EmployeeService>();
        service.AddTransient<IDepartmentService, DepartmentService>();
        service.AddTransient<IJobNatureService, JobNatureService>();
        service.AddTransient<IEmployeeManagementService, EmployeeManagementService>();
        service.AddTransient<IAbsenceService, AbsenceService>();

        // Register ViewModels
        service.AddTransient<EmployeeViewModel>();
        service.AddTransient<AddAndEditWindowViewModel>();
        service.AddTransient<ViewEmployeeDetailsViewModel>();
        service.AddTransient<AbsenceWindowViewModel>();
        service.AddTransient<AbsencePageViewModel>();
        service.AddTransient<ViewAbsenceDetailsViewModel>();
        service.AddTransient<SingleButtonMessageBoxViewModel>();
        service.AddTransient<TwoButtonMessageBoxViewModel>();
        

        // Register pages
        service.AddTransient<EmployeePage>();
        service.AddTransient<DashboardPage>();
        service.AddTransient<AbsencePage>();


        //Register Views
        service.AddTransient<MainWindow>();
        service.AddTransient<AddAndEditWindow>();
        service.AddTransient<ViewEmployeeDetails>();
        service.AddTransient<AbsenceWindow>();
        service.AddTransient<ViewAbsenceDetails>();
        service.AddTransient<SingleButtonMessageBox>();
        service.AddTransient<TowButtonMessageBox>();

        // Register Navigation Service
        service.AddTransient<INavigationService, NavigationService>();

        // Resiter main window
        service.AddTransient<Func<MainWindow>>(serviceProvider =>
            () => new MainWindow(serviceProvider.GetRequiredService<INavigationService>()));

    }
}

