using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.UI.MVVM;
using EEMS.UI.Views.Dashboard;
using EEMS.UI.Views.Employees;
using EEMS.UI.Views.Shared;
using System.Windows.Media;

namespace EEMS.UI.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private bool _isMenuExpanded = true;
    
    [ObservableProperty]
    private Brush _setColor = Brushes.White;

    [ObservableProperty]
    private Brush _separatorColor;


    public double MenuWidth => IsMenuExpanded ? 200 : 50;

    public MainWindowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        NavigateToDashboardPage();
    }

    [RelayCommand]
    private void ToggleMenu()
    {
        IsMenuExpanded = !IsMenuExpanded;
        UpdateColors();
    }

    private void UpdateColors()
    {
        SetColor = IsMenuExpanded ? Brushes.White : (Brush)new BrushConverter().ConvertFromString("#4880ff");
        SeparatorColor = IsMenuExpanded ? Brushes.White : (Brush)new BrushConverter().ConvertFromString("#6895ff");

    }

    [RelayCommand]
    private void NavigateToEmployeePage()
    {
        _navigationService.NavigateTo<EmployeePage>();
    }

    [RelayCommand]
    private void NavigateToDashboardPage()
    {
        _navigationService.NavigateTo<DashboardPage>();
    }
}
