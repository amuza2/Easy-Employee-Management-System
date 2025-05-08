using EEMS.UI.ViewModels;
using System.Windows.Controls;

namespace EEMS.UI.UserControls
{
    /// <summary>
    /// Interaction logic for JobInformationUserControl.xaml
    /// </summary>
    public partial class JobInformationUserControl : UserControl
    {
        public JobInformationUserControl(JobInformationViewModel jobInformationViewModel)
        {
            DataContext = jobInformationViewModel;
        }
        public JobInformationUserControl()
        {
            InitializeComponent();
        }
    }
}
