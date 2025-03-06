using System.ComponentModel;

namespace EEMS.UI.ViewModels
{
    public class AddAndEditEmployeeViewModel : INotifyPropertyChanged
    {
        private DateTime? _selectDate;

        public DateTime? SelectedDate
        {
            get { return _selectDate; }
            set
            {
                _selectDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }


        private bool _isMaleSelected;
        private bool _isFemaleSelected;

        public bool IsMaleSelected
        {
            get => _isMaleSelected;
            set
            {
                _isMaleSelected = value;
                OnPropertyChanged(nameof(IsMaleSelected));
                if (value) _isFemaleSelected = false;
            }
        }

        public bool IsFemaleSelected
        {
            get => _isFemaleSelected;
            set
            {
                _isFemaleSelected = value;
                OnPropertyChanged(nameof(IsFemaleSelected));
                if (value) _isMaleSelected = false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
