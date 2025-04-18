using EEMS.UI.ViewModels;
using System.Windows;

namespace EEMS.UI.Views.Absences;

/// <summary>
/// Interaction logic for Absence.xaml
/// </summary>
public partial class AbsenceWindow : Window
{
    public AbsenceWindow(EmployeeAbsenceViewModel employeeAbsenceViewModel)
    {
        DataContext = employeeAbsenceViewModel;
        InitializeComponent();
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
