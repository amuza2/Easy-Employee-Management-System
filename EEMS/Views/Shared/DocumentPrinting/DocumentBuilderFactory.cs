using model = EEMS.DataAccess.Models;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Employees;
using EEMS.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.UI.Views.Shared.DocumentPrinting;

public class DocumentBuilderFactory : IDocumentBuilderFactory
{
    public IPrintableDocumentBuilder Create(DocumentType documentType, object data)
    {
        return documentType switch
        {
            DocumentType.CondidateDetails => new CondidateDetailsDocumentBuilder((model.Condidate)data),
            DocumentType.EmployeeDetails => new EmployeeDetailsDocumentBuilder((model.Employee)data),
            DocumentType.WorkCertificate => new EmployeeJobCertificateDocumentBuilder((model.Employee)data),
            DocumentType.VacationCertificate => new VacationCertificateDocumentBuilder((model.Employee)data),
            _ => throw new NotSupportedException("Document type not supported")
        };
    }
}
