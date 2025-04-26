using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.BusinessLogic.Interfaces;

public class ICondidateManagementService
{
    IJobNatureService JobNatureService { get; }
    ICondidateService CondidateService { get; }
    
}
