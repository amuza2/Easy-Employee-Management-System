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
