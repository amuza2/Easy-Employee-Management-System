using EEMS.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
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

        // Register DbContext
        service.AddDbContext<EEMSDbContext>(options =>
        options.UseSqlServer(ConfigHelper.GetConnectionString()));

        ServiceProvider = service.BuildServiceProvider();
        base.OnStartup(e);
    }
}

