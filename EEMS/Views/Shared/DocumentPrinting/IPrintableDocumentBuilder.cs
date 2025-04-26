using System.Windows.Documents;

namespace EEMS.UI.Views.Shared.DocumentPrinting;

public interface IPrintableDocumentBuilder
{
    FlowDocument BuilderDocument();
}
