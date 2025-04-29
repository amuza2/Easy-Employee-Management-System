using model = EEMS.DataAccess.Models;
using EEMS.Utilities.Enums;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace EEMS.UI.Views.Shared.DocumentPrinting;

public class CondidateDetailsDocumentBuilder : IPrintableDocumentBuilder
{
    private readonly model.Condidate _condidate;

    public CondidateDetailsDocumentBuilder(model.Condidate condidate)
    {
        _condidate = condidate;
    }

    public FlowDocument BuilderDocument()
    {
        var document = new FlowDocument();
        // Add content to the document here

        document.PagePadding = new Thickness(50);
        document.FontFamily = new FontFamily("Segoe UI");
        document.FontSize = 12;
        document.ColumnWidth = 500;

        // Document Title
        var titleSection = new Section();
        var titleParagraph = new Paragraph(new Bold(new Run("CANDIDATE DETAILS")))
        {
            TextAlignment = TextAlignment.Center,
            FontSize = 20,
            Margin = new Thickness(0, 0, 0, 10)
        };
        titleSection.Blocks.Add(titleParagraph);
        document.Blocks.Add(titleSection);

        // Add horizontal line
        var separator = new Paragraph(new Run(""))
        {
            BorderBrush = Brushes.Gray,
            BorderThickness = new Thickness(0, 0, 0, 1),
            Margin = new Thickness(0, 0, 0, 20)
        };
        document.Blocks.Add(separator);

        // Personal Information Section
        AddSectionTitle(document, "Personal Information");

        // Create a Table for personal information
        var personalInfoTable = CreateInfoTable();

        // Row 1: Name
        var row1 = new TableRow();
        row1.Cells.Add(CreateTableCell("First Name:", true));
        row1.Cells.Add(CreateTableCell(_condidate.FirstName));
        row1.Cells.Add(CreateTableCell("Last Name:", true));
        row1.Cells.Add(CreateTableCell(_condidate.LastName));
        personalInfoTable.RowGroups[0].Rows.Add(row1);

        // Row 2: Contact
        var row2 = new TableRow();
        row2.Cells.Add(CreateTableCell("Phone:", true));
        row2.Cells.Add(CreateTableCell(_condidate.Phone));
        row2.Cells.Add(CreateTableCell("Email:", true));
        row2.Cells.Add(CreateTableCell(_condidate.Email));
        personalInfoTable.RowGroups[0].Rows.Add(row2);

        // Row 3: Birth Information
        var row3 = new TableRow();
        row3.Cells.Add(CreateTableCell("Date of Birth:", true));
        row3.Cells.Add(CreateTableCell(_condidate.DateOfBirth.ToString("yyyy-MM-dd")));
        row3.Cells.Add(CreateTableCell("Birth Location:", true));
        row3.Cells.Add(CreateTableCell(_condidate.BirthLocation));
        personalInfoTable.RowGroups[0].Rows.Add(row3);

        // Row 4: Address
        var row4 = new TableRow();
        row4.Cells.Add(CreateTableCell("Address:", true));
        row4.Cells.Add(CreateTableCell(_condidate.Address));
        row4.Cells.Add(CreateTableCell("Residence:", true));
        row4.Cells.Add(CreateTableCell(_condidate.Residence));
        personalInfoTable.RowGroups[0].Rows.Add(row4);

        // Row 5: Other Personal Info
        var row5 = new TableRow();
        row5.Cells.Add(CreateTableCell("Family Situation:", true));
        row5.Cells.Add(CreateTableCell(_condidate.FamilySituation.ToString()));
        row5.Cells.Add(CreateTableCell("Gender:", true));
        row5.Cells.Add(CreateTableCell(_condidate.Gender.ToString()));
        personalInfoTable.RowGroups[0].Rows.Add(row5);

        document.Blocks.Add(personalInfoTable);

        // Qualifications & Skills Section
        AddSectionTitle(document, "Qualifications & Skills");

        var qualificationsTable = CreateInfoTable();

        // Row 1: Training
        var qRow1 = new TableRow();
        qRow1.Cells.Add(CreateTableCell("Training:", true));
        qRow1.Cells.Add(CreateTableCell(_condidate.Training));
        qRow1.Cells.Add(CreateTableCell("Essential Training:", true));
        qRow1.Cells.Add(CreateTableCell(_condidate.EssentialTraining));
        qualificationsTable.RowGroups[0].Rows.Add(qRow1);

        // Row 2: Languages & Experience
        var qRow2 = new TableRow();
        qRow2.Cells.Add(CreateTableCell("Languages Spoken:", true));
        qRow2.Cells.Add(CreateTableCell(_condidate.LanguagesSpoken));
        qRow2.Cells.Add(CreateTableCell("Experience:", true));
        qRow2.Cells.Add(CreateTableCell(_condidate.Experience.ToString()));
        qualificationsTable.RowGroups[0].Rows.Add(qRow2);

        document.Blocks.Add(qualificationsTable);

        // Additional Information Section
        AddSectionTitle(document, "Additional Information");

        var additionalInfoTable = CreateInfoTable();

        // Row 1: Additional capabilities
        var aRow1 = new TableRow();
        aRow1.Cells.Add(CreateTableCell("Has Driving License:", true));
        aRow1.Cells.Add(CreateTableCell(_condidate.HasDrivingLicense == DrivingLicense.Have ? "Yes" : "No"));
        aRow1.Cells.Add(CreateTableCell("MS Office Skills:", true));
        aRow1.Cells.Add(CreateTableCell(_condidate.KnowMicrosoftOfficeSoftware ? "Yes" : "No"));
        additionalInfoTable.RowGroups[0].Rows.Add(aRow1);

        // Row 2: Interview and status
        var aRow2 = new TableRow();
        aRow2.Cells.Add(CreateTableCell("Interview Date:", true));
        aRow2.Cells.Add(CreateTableCell(_condidate.InterviewDate.ToString("yyyy-MM-dd")));
        aRow2.Cells.Add(CreateTableCell("Is Archived:", true));
        aRow2.Cells.Add(CreateTableCell(_condidate.IsArchived ? "Yes" : "No"));
        additionalInfoTable.RowGroups[0].Rows.Add(aRow2);

        document.Blocks.Add(additionalInfoTable);

        // Footer with print date
        var footerSection = new Section();
        var footerParagraph = new Paragraph(new Run($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm}"))
        {
            FontSize = 9,
            Foreground = Brushes.Gray,
            TextAlignment = TextAlignment.Right,
            Margin = new Thickness(0, 30, 0, 0)
        };
        footerSection.Blocks.Add(footerParagraph);
        document.Blocks.Add(footerSection);

        return document;
    }

    // Helper method to create a section title
    private void AddSectionTitle(FlowDocument document, string title)
    {
        var sectionTitlePara = new Paragraph(new Bold(new Run(title)))
        {
            FontSize = 16,
            Foreground = Brushes.DarkBlue,
            Margin = new Thickness(0, 15, 0, 5)
        };
        document.Blocks.Add(sectionTitlePara);
    }

    // Helper method to create a structured table for information display
    private Table CreateInfoTable()
    {
        var table = new Table();

        // Set up table properties
        table.CellSpacing = 5;
        table.Margin = new Thickness(0, 0, 0, 10);

        // Add columns
        table.Columns.Add(new TableColumn { Width = new GridLength(125) });  // Label column 1
        table.Columns.Add(new TableColumn { Width = new GridLength(150) });  // Value column 1
        table.Columns.Add(new TableColumn { Width = new GridLength(125) });  // Label column 2
        table.Columns.Add(new TableColumn { Width = new GridLength(150) });  // Value column 2

        // Add a row group
        table.RowGroups.Add(new TableRowGroup());

        return table;
    }

    // Helper method to create a table cell with content
    private TableCell CreateTableCell(string content, bool isLabel = false)
    {
        var cell = new TableCell();

        var para = new Paragraph(new Run(content))
        {
            Margin = new Thickness(3)
        };

        if (isLabel)
        {
            para.FontWeight = FontWeights.SemiBold;
        }

        cell.Blocks.Add(para);
        return cell;
    }
}