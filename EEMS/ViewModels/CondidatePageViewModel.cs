using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using EEMS.UI.Views.Condidates;
using EEMS.UI.Views.Shared.DocumentPrinting;
using System.Collections.ObjectModel;

namespace EEMS.UI.ViewModels;

public partial class CondidatePageViewModel : ObservableObject
{
    private readonly ICondidateManagementService _condidateManagementService;
    public ObservableCollection<Condidate> Condidates { get; set; }

    public ObservableCollection<JobNature> JobNatures { get; set; }
    public ObservableCollection<OpenedJob> OpenedJobs { get; set; }
    [ObservableProperty] private Condidate _selectedCondidate;
    [ObservableProperty] private string _selectedTab = "All";
    [ObservableProperty] private string _searchCondidate;


    public CondidatePageViewModel(ICondidateManagementService condidateManagementService)
    {
        _condidateManagementService = condidateManagementService;
        Condidates = new ObservableCollection<Condidate>();
        JobNatures = new ObservableCollection<JobNature>();
        OpenedJobs = new ObservableCollection<OpenedJob>();
        _ = GetAllCondidates();
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
    private async void ViewCondidate(object obj)
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
}
