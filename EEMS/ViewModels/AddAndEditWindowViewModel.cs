using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.UI.MVVM;
using EEMS.UI.Views.Shared;
using System.Windows;
using System.Windows.Input;

namespace EEMS.UI.ViewModels;

public class AddAndEditWindowViewModel : ViewModelBase
{
	private readonly IEmployeeManagementService _employeeManagementService;
    public PersonalInformationViewModel _personalInformationVM { get; }
    public JobInformationViewModel _jobInformationVM { get; }
	public Action CloseWindow { get; set; }
	public Action UpdateGridWindowData { get; set; }


    private Employee _employeeData = new Employee();

	public Employee EmployeeData
	{
		get { return _employeeData; }
		set { _employeeData = value; OnPropertyChanged(); }
	}


	private object _currentView;

	public object CurrentView
	{
		get { return _currentView; }
		set
		{ 
			_currentView = value;
			OnPropertyChanged();
            UpdateNextButtonContent();
        }
	}

	private string _nextBtnContent;

	public string NextBtnContent
    {
		get { return _nextBtnContent; }
		set
		{ 
			_nextBtnContent = value;
			OnPropertyChanged();	
		}
	}

    private void UpdateNextButtonContent()
    {
		if(CurrentView == _jobInformationVM)
		{
			NextBtnContent = "Submit";
			IsPersonalInfoActive = false;
			IsJobInfoActive = true;
        }
		else
		{
			NextBtnContent = "Save & Next";
            IsPersonalInfoActive = true;
            IsJobInfoActive = false;
        }
    }

	private bool _isPersonalInfoActive = true;

	public bool IsPersonalInfoActive
    {
		get { return _isPersonalInfoActive; }
		set { _isPersonalInfoActive = value; OnPropertyChanged(); }
	}

	private bool _isJobInfoActive = false;

	public bool IsJobInfoActive
    {
		get { return _isJobInfoActive; }
		set { _isJobInfoActive = value; OnPropertyChanged(); }
	}

    public ICommand NextBtnCommand { get; }
    public ICommand BackBtnCommand { get; }

    public AddAndEditWindowViewModel(PersonalInformationViewModel personalInfoVM, JobInformationViewModel jobInfoVM, IEmployeeManagementService employeeManagementService)
	{
		_employeeManagementService = employeeManagementService;
        _personalInformationVM = personalInfoVM;
		_jobInformationVM = jobInfoVM;

		CurrentView = _personalInformationVM;
		_nextBtnContent = "Save & Next";

		NextBtnCommand = new RelayCommand(HandleNextOrSubmit);
		BackBtnCommand = new RelayCommand(() => CurrentView = _personalInformationVM);
	}

	private async void HandleNextOrSubmit()
	{
		if (CurrentView == _personalInformationVM)
		{
			SavePersonalInformation();
			CurrentView = _jobInformationVM;
		}
		else if (CurrentView == _jobInformationVM)
		{
			await SaveJobInformation();
			_ = AddEmployeeToDatabase();
		}
	}

    private async Task AddEmployeeToDatabase()
    {
		try
		{
			var emp_id = await _employeeManagementService.AddEmployeeAsync(EmployeeData);
			var result = MessageBox.Show($"Employee with ID: {emp_id} has been added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

			if(result == MessageBoxResult.OK || result == MessageBoxResult.None)
			{
				UpdateGridWindowData?.Invoke();
				CloseWindow?.Invoke();
			}

        }
		catch (Exception ex)
		{
			throw new Exception($"Error: {ex.Message}");
        }
    }

    private void SavePersonalInformation()
    {
        EmployeeData.FirstName = _personalInformationVM.FirstName;
        EmployeeData.LastName = _personalInformationVM.LastName;
        EmployeeData.Phone = _personalInformationVM.Phone;
        EmployeeData.Email = _personalInformationVM.Email;
        EmployeeData.DateOfBirth = (DateTime)_personalInformationVM.SelectedDate;
        EmployeeData.BirthLocation = _personalInformationVM.BirthLocation;
        EmployeeData.Address = _personalInformationVM.Address;
        EmployeeData.FamilySituation = _personalInformationVM.SelectedFamilySituation?.ToString();
		EmployeeData.Gender = _personalInformationVM.SelectedGender.ToString() == "Male" ? 0 : 1;
		EmployeeData.Residence = _personalInformationVM.Residence;
    }

    private async Task SaveJobInformation()
    {
        EmployeeData.JobTitle = _jobInformationVM.JobTitle;
        EmployeeData.EssentialTraining = _jobInformationVM.EssentialTraining;
        EmployeeData.Training = _jobInformationVM.OtherTraining;
        EmployeeData.RecruitmentDate = DateTime.Now.Date;
        EmployeeData.LanguagesSpoken = _jobInformationVM.SpokenLanguages;
        EmployeeData.Experience = _jobInformationVM.Experience;
        EmployeeData.DepartmentId = await _employeeManagementService.GetDepartmentIdByName(_jobInformationVM.SelectedDeparment);
        EmployeeData.JobNatureId = await _employeeManagementService.GetJobNatureByName(_jobInformationVM.SelectedJobNature);
    }
}
