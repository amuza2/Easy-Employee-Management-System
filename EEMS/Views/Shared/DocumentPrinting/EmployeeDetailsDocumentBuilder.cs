using EEMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EEMS.UI.Views.Shared.DocumentPrinting;

public class EmployeeDetailsDocumentBuilder : IPrintableDocumentBuilder
{
    private readonly Employee _employee; 

    public EmployeeDetailsDocumentBuilder(Employee employee)
    {
        _employee = employee;
    }

    public FlowDocument BuilderDocument()
    {
        throw new NotImplementedException();
    }
}
