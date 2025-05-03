using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.BusinessLogic.Services;
using EEMS.DataAccess.Models;
using EEMS.UI.Enums;
using EEMS.UI.Views.Condidates;
using EEMS.UI.Views.Shared.DocumentPrinting;
using EEMS.UI.Views.Shared.MessageBoxes;
using EEMS.Utilities.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace EEMS.UI.ViewModels;

public partial class CondidatePageViewModel : ObservableObject
{
    private readonly ICondidateManagementService _condidateManagementService;
    private readonly IDocumentBuilderFactory _factory;
    private readonly PrintService _printService;

    public ObservableCollection<Condidate> Condidates { get; set; }
    public ICollectionView FilteredCondidates { get; }
    public ObservableCollection<JobNatureEnum> JobNatureItems { get; set; }
    public ObservableCollection<OpenedJob> OpenedJobItems { get; set; }
    [ObservableProperty] private Condidate? _selectedCondidate;
    [ObservableProperty] private string _selectedTab = "All";
    [ObservableProperty] private string _searchCondidate;
    [ObservableProperty] private JobNatureEnum _selectedJobNature;
    [ObservableProperty] private OpenedJob _selectedOpenJob;


    public CondidatePageViewModel(ICondidateManagementService condidateManagementService, IDocumentBuilderFactory factory, PrintService printService)
    {
        _condidateManagementService = condidateManagementService;
        _factory = factory;
        _printService = printService;

        Condidates = new ObservableCollection<Condidate>();
        FilteredCondidates = CollectionViewSource.GetDefaultView(Condidates);
        FilteredCondidates.Filter = FilterCondidate;
        JobNatureItems = new ObservableCollection<JobNatureEnum>();
        OpenedJobItems = new ObservableCollection<OpenedJob>();
        _ = GetAllCondidates();
        _ = GetOpenedJobs();
        LoadJobNature();
    }

    private bool FilterCondidate(object obj)
    {
        if (obj is not Condidate cond) return false;
        bool matchesSearch = string.IsNullOrEmpty(SearchCondidate) ||
            cond.FirstName.Contains(SearchCondidate, StringComparison.OrdinalIgnoreCase) ||
            cond.LastName.Contains(SearchCondidate, StringComparison.OrdinalIgnoreCase);

        bool matchesJobNature = SelectedJobNature == JobNatureEnum.All ||
            cond.JobNatureItem == SelectedJobNature;

        bool matchesOpenedJob = SelectedOpenJob == null || SelectedOpenJob.Id == 0 ||
            cond.OpenedJobId == SelectedOpenJob.Id;

        return matchesSearch && matchesJobNature && matchesOpenedJob;
    }
    partial void OnSelectedCondidateChanged(Condidate? value)
    {
        ViewCondidateCommand.NotifyCanExecuteChanged();
        PrintCondidateCommand.NotifyCanExecuteChanged();
        DeleteCondidateCommand.NotifyCanExecuteChanged();
    }

    partial void OnSelectedOpenJobChanged(OpenedJob value)
    {
        FilteredCondidates.Refresh();
    }
    partial void OnSelectedJobNatureChanged(JobNatureEnum value)
    {
        FilteredCondidates.Refresh();
    }
    partial void OnSearchCondidateChanged(string value)
    {
        FilteredCondidates.Refresh();
    }

    // get and add opened jobs to collection
    private async Task GetOpenedJobs()
    {
        OpenedJobItems.Clear();
        OpenedJob allOpenedJob = new OpenedJob { Id = 0, Name = "All"};
        OpenedJobItems.Add(allOpenedJob);
        var openedJobs = await _condidateManagementService.OpenedJobService.GetAsync();
        foreach (var openedJob in openedJobs)
        {
            OpenedJobItems.Add(openedJob);
        }
        SelectedOpenJob = allOpenedJob;
    }

    // Load job nature items to combobox
    private void LoadJobNature()
    {
        foreach (var item in Enum.GetValues(typeof(JobNatureEnum)).Cast<JobNatureEnum>())
        {
            JobNatureItems.Add(item);
        }
    }

    private async Task GetAllCondidates()
    {
        Condidates.Clear();
        var condidates = await _condidateManagementService.CondidateService.GetAsync();
        foreach (var condidate in condidates)
        {
            Condidates.Add(condidate);
        }
    }

    // Tab selection
    [RelayCommand]
    private void SelectTab(string tabName)
    {
        SelectedTab = tabName;
        LoadDataForTab(tabName);
    }

    partial void OnSelectedTabChanged(string value)
    {
        LoadDataForTab(value);
    }

    private void LoadDataForTab(string tab)
    {
        if (tab == "All") _ = GetAllCondidates();
        else if (tab == "Archived") _ = GetArchivedCondidates();
    }

    // archived condidates
    private async Task GetArchivedCondidates()
    {
        throw new NotImplementedException();
    }

    //View Condidate
    [RelayCommand(CanExecute = nameof(CanPerformUserAction))]
    private void ViewCondidate(object obj)
    {
        if (SelectedCondidate != null)
        {
            var condidateDetailsViewModel = new CondidateDetailsViewViewModel(SelectedCondidate, new DocumentBuilderFactory(), new PrintService());
            var condidateDetailsView = new CondidateDetailsView(condidateDetailsViewModel);
            condidateDetailsView.ShowDialog();
            SelectedCondidate = null;
        }
    }

    private bool CanPerformUserAction(object obj)
    {
        return SelectedCondidate != null;
    }

    [RelayCommand(CanExecute = nameof(CanPerformUserAction))]
    private void PrintCondidate(object obj)
    {
        if (SelectedCondidate != null)
        {
            var builder = _factory.Create(DocumentType.CondidateDetails, SelectedCondidate);
            _printService.Print(builder);
        }
    }

    [RelayCommand(CanExecute = nameof(CanPerformUserAction))]
    private async void DeleteCondidate(object obj)
    {
        if (SelectedCondidate != null)
        {
            var result = await DialogService.ShowTwoButtonMessageBoxAsync(
            $"Are you sure you want to delete {SelectedCondidate.FirstName} {SelectedCondidate.LastName}?",
            "Delete Condidate",
            "Delete", "Cancel");
            if (result == CustomMessageBoxResult.Confirmed)
            {
                var success = await _condidateManagementService.CondidateService.DeleteAsync(SelectedCondidate.Id);
                if (success)
                {
                    Condidates.Remove(SelectedCondidate);
                    SelectedCondidate = null;
                }
                else
                {
                    await DialogService.ShowSingleButtonMessageBoxAsync("Failed to delete the condidate.", "Error", "Ok");
                }
            }
            else
            {
                return;
            }
            await DialogService.ShowSingleButtonMessageBoxAsync(
                $"Condidate {SelectedCondidate?.FirstName} {SelectedCondidate?.LastName} has been deleted successfully.",
                "Success",
                "OK");
        }
    }

    [RelayCommand]
    private void AddCondidate()
    {
        var addCondidateViewModel = new AddAndEditCondidateViewModel(_condidateManagementService);

        // update data gird when condidate is added or updated
        addCondidateViewModel.UpdateEmployeeDataGrid = async () =>
        {
            await GetAllCondidates();
        };

        var addCondidateView = new AddAndEditCondidateWindow(addCondidateViewModel);
        addCondidateView.ShowDialog();
    }
}