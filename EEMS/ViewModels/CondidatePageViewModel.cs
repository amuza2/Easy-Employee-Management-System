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

namespace EEMS.UI.ViewModels;

public partial class CondidatePageViewModel : ObservableObject
{
    private readonly ICondidateManagementService _condidateManagementService;
    private readonly IDocumentBuilderFactory _factory;
    private readonly PrintService _printService;

    public ObservableCollection<Condidate> Condidates { get; set; }
    public ObservableCollection<JobNatureEnum> JobNatures { get; set; }
    public ObservableCollection<OpenedJob> OpenedJobs { get; set; }
    [ObservableProperty] private Condidate _selectedCondidate;
    [ObservableProperty] private string _selectedTab = "All";
    [ObservableProperty] private string _searchCondidate;


    public CondidatePageViewModel(ICondidateManagementService condidateManagementService, IDocumentBuilderFactory factory, PrintService printService)
    {
        _condidateManagementService = condidateManagementService;
        _factory = factory;
        _printService = printService;

        Condidates = new ObservableCollection<Condidate>();
        JobNatures = new ObservableCollection<JobNatureEnum>();
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

    [RelayCommand]
    private void PrintCondidate()
    {
        if (SelectedCondidate != null)
        {
            var builder = _factory.Create(DocumentType.CondidateDetails, SelectedCondidate);
            _printService.Print(builder);
        }
    }

    [RelayCommand]
    private async void DeleteCondidate()
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


    partial void OnSearchCondidateChanged(string value)
    {
        if (string.IsNullOrEmpty(SearchCondidate))
        {
            _ = GetAllCondidates();
        }
        else
        {
            var filteredCondidates = Condidates.Where(c => c.FirstName.Contains(SearchCondidate, StringComparison.OrdinalIgnoreCase) ||
                                                          c.LastName.Contains(SearchCondidate, StringComparison.OrdinalIgnoreCase));
            Condidates.Clear();
            foreach (var condidate in filteredCondidates)
            {
                Condidates.Add(condidate);
            }
        }
    } 
}