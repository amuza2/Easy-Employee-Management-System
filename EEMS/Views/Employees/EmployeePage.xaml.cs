using System.Windows.Controls;

namespace EEMS.UI.Views.Employees;

/// <summary>
/// Interaction logic for EmployeePage.xaml
/// </summary>
public partial class EmployeePage : Page
{
    public EmployeePage(EmployeeViewModel employeeViewModel)
    {
        InitializeComponent();
        DataContext = employeeViewModel;
    }
}
