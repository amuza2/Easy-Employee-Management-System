using EEMS.BusinessLogic.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace EEMS.UI.ViewModels;

public class JobInformationViewModel : INotifyPropertyChanged
{
    private readonly IEmployeeManagementService _employeeManagementService;
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

    private DateTime? _selectedDate;

    public DateTime? SelectedDate
    {
        get { return _selectedDate; }
        set 
        { 
            _selectedDate = value;
            OnPropertyChanged(nameof(SelectedDate)); 
        }
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

    public JobInformationViewModel(IEmployeeManagementService employeeManagementService)
    {
        _employeeManagementService = employeeManagementService;
        DepartmentItems = new ObservableCollection<string>();
        JobNatureItems = new ObservableCollection<string>();

        _ = GetValuesToFillControls(); 
        SelectedDate = DateTime.Now.Date;
    }

    private async Task GetValuesToFillControls()
    {
        await SetDepartmentNamesToControl();
        await SetJobNatureNamesToControl();
    }

    private async Task SetJobNatureNamesToControl()
    {
        try
        {
            var jobNatureNames = await _employeeManagementService.GetJobNaturesAsync();
            foreach (var item in jobNatureNames)
            {
                JobNatureItems.Add(item.Name);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private async Task SetDepartmentNamesToControl()
    {
        var departments = await _employeeManagementService.GetDepartmentsAsync();
        foreach (var item in departments)
        {
            DepartmentItems.Add(item.Name);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
