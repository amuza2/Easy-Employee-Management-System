using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.UI.MVVM;
using EEMS.UI.Views.Shared;
using System.ComponentModel;
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
			CommandManager.InvalidateRequerySuggested();
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

		_personalInformationVM.ErrorsChanged += ChildViewModel_ErrorsChanged;
		_jobInformationVM.ErrorsChanged += ChildViewModel_ErrorsChanged;
		CurrentView = _personalInformationVM;

		
		_nextBtnContent = "Save & Next";

		NextBtnCommand = new RelayCommand(HandleNextOrSubmit, CanProceed);
		BackBtnCommand = new RelayCommand(() => CurrentView = _personalInformationVM);
	}

    private void ChildViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
    {
        // Propagate the error state change to update command availability
        CommandManager.InvalidateRequerySuggested();
    }

    private async void HandleNextOrSubmit()
	{
		if (CurrentView == _personalInformationVM)
		{
            // Validate all properties in the personal information view model
            _personalInformationVM.ValidateAllProperties();

			if (_personalInformationVM.HasErrors)
				return;

            await SavePersonalInformation();
			CurrentView = _jobInformationVM;
		}
		else if (CurrentView == _jobInformationVM)
		{
			_jobInformationVM.ValidateAllProperties();

			if (_jobInformationVM.HasErrors)
				return;

			await SaveJobInformation();
			_ = AddEmployeeToDatabase();
		}
	}

    private async Task AddEmployeeToDatabase()
    {
		try
		{
			var emp_id = await _employeeManagementService.EmployeeService.AddAsync(EmployeeData);
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

    private bool CanProceed()
    {
        if (CurrentView == _personalInformationVM)
        {
            // Only check if required fields are filled and no errors
            return _personalInformationVM.AreRequiredFieldsFilled() && !_personalInformationVM.HasErrors;
        }
		else if (CurrentView == _jobInformationVM)
		{
			return _jobInformationVM.AreRequiredFieldsFilled() && !_jobInformationVM.HasErrors;
		}

		return false;
    }


    private async Task SavePersonalInformation()
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
        EmployeeData.DepartmentId = await _employeeManagementService.DepartmentService.GetDepartmentIdByNameAsync(_jobInformationVM.SelectedDeparment);
        EmployeeData.JobNatureId = await _employeeManagementService.JobNatureService.GetJobNatureIdByNameAsync(_jobInformationVM.SelectedJobNature);
    }



}
