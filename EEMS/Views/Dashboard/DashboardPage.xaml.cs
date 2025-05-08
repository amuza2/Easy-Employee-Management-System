using EEMS.UI.ViewModels;
using System.Windows.Controls;

namespace EEMS.UI.Views.Dashboard
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public DashboardPage(DashboardViewModel dashboardViewModel)
        {
            InitializeComponent();
            DataContext = dashboardViewModel;
        }
    }
}
