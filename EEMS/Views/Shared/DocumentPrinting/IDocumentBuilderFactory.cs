using EEMS.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EEMS.UI.Views.Shared.DocumentPrinting;

public interface IDocumentBuilderFactory
{
    IPrintableDocumentBuilder Create(DocumentType documentType, object data);
}
