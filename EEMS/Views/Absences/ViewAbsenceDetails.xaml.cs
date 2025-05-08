using EEMS.UI.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace EEMS.UI.Views.Absences;

/// <summary>
/// Interaction logic for ViewAbsenceDetails.xaml
/// </summary>
public partial class ViewAbsenceDetails : Window
{
    public ViewAbsenceDetails(ViewAbsenceDetailsViewModel viewAbsenceViewModel)
    {
        DataContext = viewAbsenceViewModel;
        InitializeComponent();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left) this.DragMove();
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
}
