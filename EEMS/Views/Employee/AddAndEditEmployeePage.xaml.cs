using EEMS.UI.ViewModels;
using System.Windows.Controls;

namespace EEMS.UI.Views.Employee
{
    /// <summary>
    /// Interaction logic for AddEmployeePage.xaml
    /// </summary>
    public partial class AddAndEditEmployeePage : Page
    {
        public AddAndEditEmployeePage(AddAndEditEmployeeViewModel addAndEditEmployeeViewModel)
        {
            InitializeComponent();
            DataContext = addAndEditEmployeeViewModel;
        }



    }
}
