using CommunityToolkit.Mvvm.Messaging;
using EEMS.DataAccess.Models;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Shared;
using System.Windows;

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
}
