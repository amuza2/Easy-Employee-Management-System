using EEMS.BusinessLogic.Interfaces;
using EEMS.BusinessLogic.Services;
using EEMS.DataAccess;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Absences;
using EEMS.UI.Views.Account;
using EEMS.UI.Views.Condidates;
using EEMS.UI.Views.Dashboard;
using EEMS.UI.Views.Employees;
using EEMS.UI.Views.Shared;
using EEMS.UI.Views.Shared.DocumentPrinting;
using EEMS.UI.Views.Shared.PageNativation;
using EEMS.UI.Views.Shared.WindowService;
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
        var service = new ServiceCollection();
        ConfigureServices(service);

        // Build the service provider
        ServiceProvider = service.BuildServiceProvider();

        // Show the main window
        var loginWindow = ServiceProvider.GetRequiredService<Func<LoginWindow>>()();
        loginWindow.Show();

        base.OnStartup(e);
    }

    private void ConfigureServices(IServiceCollection service)
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
        service.AddTransient<IEmployeeManagementService, EmployeeManagementService>();
        service.AddTransient<IAbsenceService, AbsenceService>();
        service.AddTransient<ICondidateService, CondidateService>();
        service.AddTransient<ICondidateManagementService, CondidateManagementService>();
        service.AddTransient<IOpenedJobService, OpenedJobService>();
        service.AddSingleton<IWindowService, WindowService>();
        service.AddTransient<IUserService, UserService>();
        service.AddTransient<IAuthService, AuthService>();
        service.AddTransient<IPasswordHasher, PasswordHasher>();

        // Register ViewModels
        service.AddTransient<EmployeeViewModel>();
        service.AddTransient<AddAndEditWindowViewModel>();
        service.AddTransient<ViewEmployeeDetailsViewModel>();
        service.AddTransient<AbsenceWindowViewModel>();
        service.AddTransient<AbsencePageViewModel>();
        service.AddTransient<ViewAbsenceDetailsViewModel>();
        service.AddTransient<SingleButtonMessageBoxViewModel>();
        service.AddTransient<TwoButtonMessageBoxViewModel>();
        service.AddTransient<CondidatePageViewModel>();
        service.AddTransient<AddAndEditCondidateViewModel>();
        service.AddTransient<DashboardViewModel>();
        service.AddTransient<EmployeeSearchWindowViewModel>();
        service.AddTransient<LoginWindowViewModel>();
        service.AddTransient<SignUpWindowViewModel>();


        // Register pages
        service.AddTransient<EmployeePage>();
        service.AddTransient<DashboardPage>();
        service.AddTransient<AbsencePage>();
        service.AddTransient<CondidatePage>();
        service.AddTransient<DashboardPage>();
        service.AddTransient<EmployeeSearchWindow>();


        //Register Views
        service.AddTransient<MainWindow>();
        service.AddTransient<AddAndEditWindow>();
        service.AddTransient<ViewEmployeeDetails>();
        service.AddTransient<AbsenceWindow>();
        service.AddTransient<ViewAbsenceDetails>();
        service.AddTransient<SingleButtonMessageBox>();
        service.AddTransient<TowButtonMessageBox>();
        service.AddTransient<AddAndEditCondidateWindow>();
        service.AddTransient<LoginWindow>();
        service.AddTransient<SignUpWindow>();

        // Document printing
        service.AddTransient<IDocumentBuilderFactory, DocumentBuilderFactory>();
        service.AddTransient<PrintService>();

        // Register Navigation Service
        service.AddTransient<INavigationService, NavigationService>();

        // Register main window
        service.AddTransient<Func<MainWindow>>(serviceProvider =>
            () => new MainWindow(serviceProvider.GetRequiredService<INavigationService>()));

        // Register login window
        service.AddTransient<Func<LoginWindow>>(serviceProvider =>
            () => serviceProvider.GetRequiredService<LoginWindow>());

        //Register Windows with their view models
        service.AddTransient(provider =>
        {
            var window = new LoginWindow();
            window.DataContext = provider.GetRequiredService<LoginWindowViewModel>();
            return window;
        });

        service.AddTransient(provider =>
        {
            var window = new SignUpWindow();
            window.DataContext = provider.GetRequiredService<SignUpWindowViewModel>();
            return window;
        });
    }
}

