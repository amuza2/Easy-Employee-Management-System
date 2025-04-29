using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Services;

public class CondidateManagementService : ICondidateManagementService
{
    public ICondidateService CondidateService { get; }
    public IOpenedJobService OpenedJobService { get; }

    public CondidateManagementService(ICondidateService condidateService,
         IOpenedJobService openedJobService)
    {
        CondidateService = condidateService;
        OpenedJobService = openedJobService;
    }
}
