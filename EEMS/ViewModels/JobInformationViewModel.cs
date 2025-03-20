using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.UI.ViewModels;

public class JobInformationViewModel : INotifyPropertyChanged
{
    private string _jobTitle;

    public string JobTitle
    {
        get { return _jobTitle; }
        set { _jobTitle = value; OnPropertyChanged(); }
    }

    private string _essentialTraining;

    public string EssentialTraining
    {
        get { return _essentialTraining; }
        set { _essentialTraining = value; OnPropertyChanged(); }
    }

    private string _spokenLanguages;

    public string SpokenLanguages
    {
        get { return _spokenLanguages; }
        set { _spokenLanguages = value; OnPropertyChanged(); }
    }

    private int _experience;

    public int Experience
    {
        get { return _experience; }
        set { _experience = value; OnPropertyChanged(); }
    }

    private DateTime _selectedDate;

    public DateTime SelectedDate
    {
        get { return _selectedDate; }
        set { _selectedDate = value; OnPropertyChanged(); }
    }

    private ObservableCollection<string> _departmentItems;

    public ObservableCollection<string> DepartmentItems
    {
        get { return _departmentItems; }
        set { _departmentItems = value; OnPropertyChanged(); }
    }

    private string _selectedDeparment;

    public string SelectedDeparment
    {
        get { return _selectedDeparment; }
        set { _selectedDeparment = value; OnPropertyChanged(); }
    }

    private ObservableCollection<string> _jobNatureItems;

    public ObservableCollection<string> JobNatureItems
    {
        get { return _jobNatureItems; }
        set { _jobNatureItems = value; OnPropertyChanged(); }
    }

    private string _selectedJobNature;

    public string SelectedJobNature
    {
        get { return _selectedJobNature; }
        set { _selectedJobNature = value; OnPropertyChanged(); }
    }

    private string _selectedStatus;

    public string SelectedStatus
    {
        get { return _selectedStatus; }
        set { _selectedStatus = value; OnPropertyChanged(); }
    }

    private string _residence;

    public string Residence
    {
        get { return _residence; }
        set { _residence = value; OnPropertyChanged(); }
    }

    public JobInformationViewModel()
    {
        DepartmentItems = new ObservableCollection<string> { "Accounting", "Sales" };
        JobNatureItems = new ObservableCollection<string> { "Full-time", "Part-time" };


    }




    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
