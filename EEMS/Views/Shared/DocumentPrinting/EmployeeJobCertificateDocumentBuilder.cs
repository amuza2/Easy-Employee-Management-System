using EEMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EEMS.UI.Views.Shared.DocumentPrinting;

public class EmployeeJobCertificateDocumentBuilder : IPrintableDocumentBuilder
{
    private readonly Employee _employee;

    public EmployeeJobCertificateDocumentBuilder(Employee employee)
    {
        _employee = employee;
    }

    public FlowDocument BuilderDocument()
    {
        var document = new FlowDocument();

        document.PagePadding = new Thickness(50);
        document.FontFamily = new FontFamily("Segoe UI");
        document.FontSize = 12;
        document.ColumnWidth = 500;

        // Document Header
        // Create the logo image
        var logoImage = new Image
        {
            Source = new BitmapImage(new Uri("pack://application:,,,/EEMS.UI;component/Resources/Images/logo-expertise.png")),
            Width = 100,
            Height = 150,
            Margin = new Thickness(10)
        };

        // Wrap image in BlockUIContainer
        var logoContainer = new BlockUIContainer(logoImage);

        // Create a table with two columns
        var headerTable = new Table();
        headerTable.Columns.Add(new TableColumn { Width = new GridLength(120) }); // logo column
        headerTable.Columns.Add(new TableColumn()); // text column

        // Create a row
        var rowGroup = new TableRowGroup();
        var row = new TableRow();
        rowGroup.Rows.Add(row);
        headerTable.RowGroups.Add(rowGroup);

        // Add logo to the first cell
        var logoCell = new TableCell(logoContainer)
        {
            TextAlignment = TextAlignment.Right,
            RowSpan = 6 // span all text rows if needed
        };
        row.Cells.Add(logoCell);

        // Create a StackPanel for the centered paragraphs
        var textStack = new StackPanel();

        textStack.Children.Add(new TextBlock { Text = "الجمهورية الجزائرية الديموقراطية الشعبية", TextAlignment = TextAlignment.Center, Margin = new Thickness(0, 0, 0, 5) });
        textStack.Children.Add(new TextBlock { Text = "وزاراة التعليم العالي و البحث العلمي", TextAlignment = TextAlignment.Center, Margin = new Thickness(0, 0, 0, 5) });
        textStack.Children.Add(new TextBlock { Text = "المديرية العامة للبحث العلمي و التطور التكنولوجي", TextAlignment = TextAlignment.Center, Margin = new Thickness(0, 0, 0, 5) });
        textStack.Children.Add(new TextBlock { Text = "CRTI مركز البحث في التكنولوجيا الصناعية", TextAlignment = TextAlignment.Center, Margin = new Thickness(0, 0, 0, 5) });
        textStack.Children.Add(new TextBlock { Text = "مؤسسة الإلحام المراقبة و الخبرة الصناعية - شركة ذات أسهم", TextAlignment = TextAlignment.Center, Margin = new Thickness(0, 0, 0, 5) });
        textStack.Children.Add(new TextBlock(new Bold(new Run("EPE-C.S.C Expertise SPA subsidiary of CRTI"))) { TextAlignment = TextAlignment.Center, Margin = new Thickness(0, 0, 0, 5) });
        textStack.Children.Add(new TextBlock { Text = "رأس مال: 000 000 70 دج فرع من 100% C.R.T.I Ex CSC-MESRS", TextAlignment = TextAlignment.Center, FlowDirection = FlowDirection.RightToLeft });

        // Add the text stack to a BlockUIContainer and then to the table cell
        var textCell = new TableCell(new BlockUIContainer(textStack));
        row.Cells.Add(textCell);

        // Add the table to the document
        document.Blocks.Add(headerTable);



        var headerSection = new Section();
        //var text1 = new Paragraph(new Run("الجمهورية الجزائرية الديموقراطية الشعبية"))
        //{
        //    TextAlignment = TextAlignment.Center,
        //    Margin = new Thickness(0, 0, 0, 10)
        //};
        //var text2 = new Paragraph(new Run("وزاراة التعليم العالي و البحث العلمي"))
        //{
        //    TextAlignment = TextAlignment.Center,
        //    Margin = new Thickness(0, 0, 0, 10)
        //};
        //var text3 = new Paragraph(new Run("المديرية العامة للبحث العلمي و التطور التكنولوجي"))
        //{
        //    TextAlignment = TextAlignment.Center,
        //    Margin = new Thickness(0, 0, 0, 10)
        //};
        //var text4 = new Paragraph(new Run("CRTI مركز البحث في التكنولوجيا الصناعية"))
        //{
        //    TextAlignment = TextAlignment.Center,
        //    Margin = new Thickness(0, 0, 0, 10)
        //};
        //var text5 = new Paragraph(new Run("مؤسسة الإلحام المراقبة و الخبرة الصناعية - شركة ذات أسهم"))
        //{
        //    TextAlignment = TextAlignment.Center,
        //    Margin = new Thickness(0, 0, 0, 10)
        //};
        //var text6 = new Paragraph(new Bold(new Run("EPE-C.S.C Expertise SPA subsidiary of CRTI")))
        //{
        //    TextAlignment = TextAlignment.Center,
        //    Margin = new Thickness(0, 0, 0, 10)
        //};
        //var text7 = new Paragraph(new Run("رأس مال: 000 000 70 دج فرع من 100% C.R.T.I Ex CSC-MESRS"))
        //{
        //    TextAlignment = TextAlignment.Center,
        //    FlowDirection = FlowDirection.RightToLeft,
        //    Margin = new Thickness(0, 0, 0, 10)
        //};
        // Add horizontal line
        var separator = new Paragraph(new Run(""))
        {
            BorderBrush = Brushes.Gray,
            BorderThickness = new Thickness(0, 0, 0, 1),
            Margin = new Thickness(0, 0, 0, 20)
        };

        var date = new Paragraph
        {
            TextAlignment = TextAlignment.Left,
            Margin = new Thickness(0, 0, 0, 10)
        };
        date.Inlines.Add(new Underline(new Run($"بوسماعيل في {DateTime.Today.Date.ToShortDateString()}")));


        var title = new Paragraph(new Bold(new Run($"شهادة عمل")))
        {
            TextAlignment = TextAlignment.Center,
            FontSize = 22,
            Margin = new Thickness(0, 0, 0, 10)
        };

        var text8 = new Paragraph(new Run($"نحن الموقعون أدناه شركة EPE CSC Expertise sap/100% CRTI الفرعية الكائنة في المنطقة الصناعية رقم 30 بو إسماعيل ولاية تيبازة."))
        {
            FlowDirection = FlowDirection.RightToLeft,
        };
        var fullname = new Paragraph()
        {
            FlowDirection = FlowDirection.RightToLeft,
        };
        fullname.Inlines.Add(new Run($"نحن نشهد بأن السيدة/السيد "));
        fullname.Inlines.Add(new Bold(new Run(_employee.FirstName + " " + _employee.LastName)));
        fullname.Inlines.Add(new Run("."));


        var birthDate = new Paragraph
        {
            FlowDirection = FlowDirection.RightToLeft
        };
        birthDate.Inlines.Add(new Run("مواليد: "));
        birthDate.Inlines.Add(new Bold(new Run(_employee.DateOfBirth.ToShortDateString())));
        birthDate.Inlines.Add(new Run(" في "));
        birthDate.Inlines.Add(new Bold(new Run(_employee.BirthLocation)));
        birthDate.Inlines.Add(new Run("."));

        var birthLocation = new Paragraph
        {
            FlowDirection = FlowDirection.RightToLeft
        };
        birthLocation.Inlines.Add(new Run("الساكن في "));
        birthLocation.Inlines.Add(new Bold(new Run(_employee.Residence)));
        birthLocation.Inlines.Add(new Run("."));

        var hirePeriod = new Paragraph
        {
            FlowDirection = FlowDirection.RightToLeft
        };
        hirePeriod.Inlines.Add(new Run("تم توظيفه في شركتنا من "));
        hirePeriod.Inlines.Add(new Bold(new Run(_employee.RecruitmentDate.ToShortDateString())));
        hirePeriod.Inlines.Add(new Run(" إلى اليوم."));

        var position = new Paragraph
        {
            FlowDirection = FlowDirection.RightToLeft
        };
        position.Inlines.Add(new Run("وظيفته الحالية هي: "));
        position.Inlines.Add(new Bold(new Run(_employee.JobTitle)));
        position.Inlines.Add(new Run("."));

        var text9 = new Paragraph(new Run($"تم إصدار هذه الشهادة لتكون صالحة للاستخدام ولجميع الأغراض."))
        {
            FlowDirection = FlowDirection.RightToLeft,
        };
        
        // blank line
        var text10 = new Paragraph(new Run($""));

        var text11 = new Paragraph(new Bold(new Run($"رئيس قسم الإدارة والموارد.")))
        {
            TextAlignment = TextAlignment.Right,
            FlowDirection = FlowDirection.RightToLeft,
        };




        //headerSection.Blocks.Add(text1);
        //headerSection.Blocks.Add(text2);
        //headerSection.Blocks.Add(text3);
        //headerSection.Blocks.Add(text4);
        //headerSection.Blocks.Add(text5);
        //headerSection.Blocks.Add(text6);
        //headerSection.Blocks.Add(text7);
        headerSection.Blocks.Add(separator);
        headerSection.Blocks.Add(date);
        headerSection.Blocks.Add(title);
        headerSection.Blocks.Add(text8);
        headerSection.Blocks.Add(fullname);
        headerSection.Blocks.Add(birthDate);
        headerSection.Blocks.Add(birthLocation);
        headerSection.Blocks.Add(hirePeriod);
        headerSection.Blocks.Add(position);
        headerSection.Blocks.Add(text9);
        headerSection.Blocks.Add(text10);
        headerSection.Blocks.Add(text11);
        document.Blocks.Add(headerSection);

        return document;


    }
}
