using EEMS.UI.Views.Employee;
using EEMS.UI.Views.Shared;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Intrinsics.X86;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace EEMS;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(INavigationService navigationService)
    {
        InitializeComponent();
        navigationService.SetFrame(MainFrame);

        navigationService.NavigateTo<EmployeePage>();
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
        Application.Current.Shutdown();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
}

public class Member
{
    public string Character { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Brush BgColor { get; set; }
}