using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EEMS.UI.Views.Shared.DocumentPrinting;

public class PrintService
{
    /// <summary>
    /// Shows a document preview window with options to print or export to PDF
    /// </summary>
    /// <param name="documentBuilder">The document builder that creates the document to preview</param>
    public void PreviewDocument(IPrintableDocumentBuilder documentBuilder)
    {
        var previewWindow = new DocumentPreviewWindow(documentBuilder);
        previewWindow.ShowDialog();
    }

    /// <summary>
    /// Prints the document directly without preview
    /// </summary>
    /// <param name="documentBuilder">The document builder that creates the document to print</param>
    public void Print(IPrintableDocumentBuilder documentBuilder)
    {
        var printDialog = new PrintDialog();
        if (printDialog.ShowDialog() == true)
        {
            var document = documentBuilder.BuilderDocument();
            var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
            printDialog.PrintDocument(paginator, "Printing Document");
        }
    }
}