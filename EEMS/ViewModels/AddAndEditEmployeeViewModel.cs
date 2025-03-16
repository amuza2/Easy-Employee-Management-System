using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EEMS.UI.ViewModels
{
    public class AddAndEditEmployeeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _familySituation;

        public ObservableCollection<string> FamilySituation
        {
            get { return _familySituation; }
            set
            {
                _familySituation = value;
                OnPropertyChanged();
            }
        }

        private object _selectedItem;

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private string _SelectedGender;

        public string SelectedGender
        {
            get { return _SelectedGender; }
            set
            { 
                _SelectedGender = value;
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


        public event PropertyChangedEventHandler? PropertyChanged;

        public AddAndEditEmployeeViewModel()
        {
            FamilySituation = new ObservableCollection<string>() { "Married", "Single" };
            SelectedItem = FamilySituation.FirstOrDefault();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
