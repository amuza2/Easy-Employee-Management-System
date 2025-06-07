using CommunityToolkit.Mvvm.Messaging;
using EEMS.Models.Models;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Shared;
using System.Windows;
using System.Windows.Input;

namespace EEMS.UI.Views.Dashboard;

/// <summary>
/// Interaction logic for EmployeeSearchWindow.xaml
/// </summary>
public partial class EmployeeSearchWindow : Window
{
    public EmployeeSearchWindow(EmployeeSearchWindowViewModel employeeSearchWindowViewModel)
    {
        InitializeComponent();
        DataContext = employeeSearchWindowViewModel;
    }

    private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if(DataContext is EmployeeSearchWindowViewModel vm && vm.SelectedEmployee != null)
        {
            WeakReferenceMessenger.Default.Send(new EmployeeSelectedMessage(vm.SelectedEmployee));
            Close();
        }
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left) this.DragMove();
    }
}
