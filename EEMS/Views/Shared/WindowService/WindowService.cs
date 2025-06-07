using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace EEMS.UI.Views.Shared.WindowService;

public class WindowService : IWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public WindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void ShowWindow<TWindow>() where TWindow : Window
    {
        var window = _serviceProvider.GetRequiredService<TWindow>();
        window.Show();
    }

    public void ShowWindow<TWindow, TViewModel>(TViewModel viewModel) where TWindow : Window where TViewModel : class
    {
        var window = _serviceProvider.GetRequiredService<TWindow>();

        if (window.DataContext is null)
            window.DataContext = viewModel;

        window.Show();
    }

    public void CloseWindow(Window window)
    {
        window.Close();
    }

    public void SwitchWindow<TWindow>(Window current) where TWindow : Window
    {
        var window = _serviceProvider.GetRequiredService<TWindow>();
        window.Show();
        current.Close();
    }

    public void SwitchWindow<TWindow, TViewModel>(Window current, TViewModel viewModel) where TWindow : Window where TViewModel : class
    {
        var window = _serviceProvider.GetRequiredService<TWindow>();

        if (window.DataContext is null)
            window.DataContext = viewModel;

        window.Show();
        current.Close();
    }
}