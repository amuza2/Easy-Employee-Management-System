using EEMS.UI.MVVM;
using EEMS.UI.Views.Shared;
using System.Windows.Input;
using System.Windows.Media;

namespace EEMS.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand ToggleMenuCommand { get; }

        private bool _isMenuExpanded = true;
        public bool IsMenuExpanded
        {
            get => _isMenuExpanded;
            set
            {
                _isMenuExpanded = value;
                OnPropertyChanged(nameof(IsMenuExpanded));
                OnPropertyChanged(nameof(MenuWidth));
                SetColor = IsMenuExpanded ? Brushes.White : (Brush)new BrushConverter().ConvertFromString("#4880ff");
                SeparatorColor = IsMenuExpanded ? Brushes.White : (Brush)new BrushConverter().ConvertFromString("#6895ff");
            }
        }

        private Brush _setColor = Brushes.White;
        public Brush SetColor
        {
            get => _setColor;
            set
            {
                _setColor = value;
                OnPropertyChanged(nameof(SetColor));
            }
        }

        private Brush _separatorColor;

        public Brush SeparatorColor
        {
            get { return _separatorColor; }
            set
            {
                _separatorColor = value;
                OnPropertyChanged(nameof(SeparatorColor));
            }
        }


        public double MenuWidth => IsMenuExpanded ? 200 : 50;

        public MainWindowViewModel()
        {
            ToggleMenuCommand = new RelayCommand(ToggleMenu);
        }

        private void ToggleMenu()
        {
            IsMenuExpanded = !IsMenuExpanded;
        }
    }
}
