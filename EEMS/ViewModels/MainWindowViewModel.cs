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

    [ObservableProperty]
    private string _activePage;


    public double MenuWidth => IsMenuExpanded ? 200 : 50;

    public MainWindowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        ActivePage = "Dashboard";
        NavigateToDashboardPage();
    }

    [RelayCommand]
    private void ToggleMenu()
    {
        IsMenuExpanded = !IsMenuExpanded;
        UpdateColors();
        OnPropertyChanged(nameof(MenuWidth));
    }

    private void UpdateColors()
    {
        SetColor = IsMenuExpanded ? Brushes.White : (Brush)new BrushConverter().ConvertFromString("#4880ff");
        SeparatorColor = IsMenuExpanded ? Brushes.White : (Brush)new BrushConverter().ConvertFromString("#6895ff");
    }

    [RelayCommand]
    private void NavigateToDashboardPage()
    {
        ActivePage = "Dashboard";
        _navigationService.NavigateTo<DashboardPage>();
    }

    [RelayCommand]
    private void NavigateToEmployeePage()
    {
        ActivePage = "Employee";
        _navigationService.NavigateTo<EmployeePage>();
    }

}
