using EEMS.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EEMS.UI.Views.Condidates
{
    /// <summary>
    /// Interaction logic for CondidatePage.xaml
    /// </summary>
    public partial class CondidatePage : Page
    {
        public CondidatePage(CondidatePageViewModel condidatePageViewModel)
        {
            DataContext = condidatePageViewModel;
            InitializeComponent();
        }
    }
}
