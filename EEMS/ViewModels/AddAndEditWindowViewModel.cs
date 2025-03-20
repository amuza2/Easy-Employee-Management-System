using EEMS.UI.Views.Shared;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EEMS.UI.ViewModels;

public class AddAndEditWindowViewModel : INotifyPropertyChanged
{
    public PersonalInformationViewModel personalInformationVM { get; }
    public JobInformationViewModel jobInformationVM { get; }

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
		if(CurrentView == jobInformationVM)
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

    public AddAndEditWindowViewModel(PersonalInformationViewModel personalInfoVM, JobInformationViewModel jobInfoVM	)
	{
		personalInformationVM = personalInfoVM;
		jobInformationVM = jobInfoVM;

		CurrentView = personalInformationVM;
		_nextBtnContent = "Save & Next";

        NextBtnCommand = new RelayCommand(() => CurrentView = jobInformationVM);
		BackBtnCommand = new RelayCommand(() => CurrentView = personalInformationVM);

	}


	public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
