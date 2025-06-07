using EEMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EEMS.UI.Views.Shared.DocumentPrinting;

public class WorkCertificateDocumentBuilder : IPrintableDocumentBuilder
{
    private readonly Employee _employee;

    public WorkCertificateDocumentBuilder(Employee employee)
    {
        _employee = employee;
    }

    public FlowDocument BuilderDocument()
    {
        throw new NotImplementedException();
    }
}
