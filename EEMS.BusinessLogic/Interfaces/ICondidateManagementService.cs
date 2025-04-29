using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.BusinessLogic.Interfaces;

public interface ICondidateManagementService
{
    ICondidateService CondidateService { get; }
    IOpenedJobService OpenedJobService { get; } 
}
