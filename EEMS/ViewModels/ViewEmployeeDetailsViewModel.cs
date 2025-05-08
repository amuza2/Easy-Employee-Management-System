using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EEMS.DataAccess.Models;
using EEMS.Utilities.Enums;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EEMS.UI.ViewModels;
                                                   
public partial class ViewEmployeeDetailsViewModel : ObservableObject
{
    [ObservableProperty] private Employee? _employee;

    public ViewEmployeeDetailsViewModel(Employee employee)
    {
        _employee = employee; 
    }

    [RelayCommand]
    private void PrintEmployeeDetail()
    {
        var printDialog = new PrintDialog();
        if (printDialog.ShowDialog() == true)
        {
            var document = new FlowDocument();
            var paragraph = new Paragraph(new Run($"First name: {_employee?.FirstName}\nLast name: {_employee?.LastName}"));
            document.Blocks.Add(paragraph);

            var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
            printDialog.PrintDocument(paginator, "Employee Details");
        }
    }
}
