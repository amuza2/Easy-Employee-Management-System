using EEMS.UI.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace EEMS.UI.Views.Employees
{
    /// <summary>
    /// Interaction logic for ViewEmployeeDetails.xaml
    /// </summary>
    public partial class ViewEmployeeDetails : Window
    {
        public ViewEmployeeDetails(ViewEmployeeDetailsViewModel viewEmployeeDetailsViewModel)
        {
            DataContext = viewEmployeeDetailsViewModel;
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
}
