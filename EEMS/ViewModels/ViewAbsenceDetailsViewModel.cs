using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.BusinessLogic.Interfaces;
using EEMS.Models.Models;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EEMS.UI.ViewModels;

public partial class ViewAbsenceDetailsViewModel : ObservableObject
{
    private Absence _selectedAbsence;
    private IEmployeeManagementService _employeeManagementService;

    [ObservableProperty] private string _firstName;
    [ObservableProperty] private string _lastName;
    [ObservableProperty] private string _absenceDate;
    [ObservableProperty] private string _justification;
    [ObservableProperty] private string _note;

    public ViewAbsenceDetailsViewModel(Absence absence, IEmployeeManagementService employeeManagementService)
    {
        _selectedAbsence = absence;
        _employeeManagementService = employeeManagementService;

        FirstName = _selectedAbsence.Employee.FirstName;
        LastName = _selectedAbsence.Employee.LastName;
        AbsenceDate = _selectedAbsence.Date.ToString("dd/MM/yyyy");
        Justification = _selectedAbsence.HasJustification == true ? "Yes" : "No";
        Note = _selectedAbsence.Note == null ? "" : _selectedAbsence.Note;
    }

    [RelayCommand]
    private void PrintAbsenceDetail()
    {
        var printDialog = new PrintDialog();
        if (printDialog.ShowDialog() == true)
        {
            var document = new FlowDocument();
            var paragraph = new Paragraph(new Run($"First name: {FirstName}\nLast name: {LastName}"));
            document.Blocks.Add(paragraph);

            var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
            printDialog.PrintDocument(paginator, "Employee Details");
        }
    }
}