using EEMS.UI.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace EEMS.UI.Views.Employees;

/// <summary>
/// Interaction logic for AddAndEditWindow.xaml
/// </summary>
public partial class AddAndEditWindow : Window
{
    public AddAndEditWindow(AddAndEditWindowViewModel addAndEditWindowViewModel)
    {
        InitializeComponent();
        var viewModel = addAndEditWindowViewModel;
        viewModel.CloseWindow = () => this.Close();
        DataContext = addAndEditWindowViewModel;
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left) this.DragMove();
    }

    private bool IsMaximized = false;
    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            if (IsMaximized)
            {
                this.WindowState = WindowState.Normal;
                IsMaximized = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                IsMaximized = true;
            }
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


}
