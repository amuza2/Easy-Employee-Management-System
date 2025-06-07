using System.Windows;

namespace EEMS.UI.Views.Shared.WindowService;

public interface IWindowService
{
    void ShowWindow<TWindow>() where TWindow : Window;
    void ShowWindow<TWindow, TViewModel>(TViewModel viewModel) where TWindow : Window where TViewModel : class;
    void CloseWindow(Window window);
    void SwitchWindow<TWindow>(Window current) where TWindow : Window;
    void SwitchWindow<TWindow, TViewModel>(Window current, TViewModel viewModel) where TWindow : Window where TViewModel : class;
}