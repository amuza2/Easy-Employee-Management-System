using EEMS.UI.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace EEMS.UI.Views.Condidates
{
    /// <summary>
    /// Interaction logic for CondidateDetailsView.xaml
    /// </summary>
    public partial class CondidateDetailsView : Window
    {
        public CondidateDetailsView(CondidateDetailsViewViewModel condidateDetailsViewView)
        {
            DataContext = condidateDetailsViewView;
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
    }
}
