using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Services;

public class CondidateManagementService : ICondidateManagementService
{
    public ICondidateService CondidateService { get; }
    public IJobNatureService JobNatureService { get; }
    public IOpenedJobService OpenedJobService { get; }

    public CondidateManagementService(ICondidateService condidateService,
        IJobNatureService jobNatureService, IOpenedJobService openedJobService)
    {
        CondidateService = condidateService;
        JobNatureService = jobNatureService;
        OpenedJobService = openedJobService;
    }
}
