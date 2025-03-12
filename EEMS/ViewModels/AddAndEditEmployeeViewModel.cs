using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EEMS.UI.ViewModels
{
    public class AddAndEditEmployeeViewModel : INotifyPropertyChanged
    {
        private List<string> _familySituation;

        public List<string> FamilySituation
        {
            get { return _familySituation; }
            set
            {
                _familySituation = value;
                OnPropertyChanged();
            }
        }


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

        public AddAndEditEmployeeViewModel()
        {
            FamilySituation = new List<string> { "Married", "Single" };
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
