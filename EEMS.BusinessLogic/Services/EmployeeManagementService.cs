using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Services;

public class EmployeeManagementService : IEmployeeManagementService
{
    public IDepartmentService DepartmentService { get; }
    public IEmployeeService EmployeeService { get; }
    public IAbsenceService AbsenceService { get; }

    public EmployeeManagementService(IDepartmentService departmentService,
                                     IEmployeeService employeeService,
                                     IAbsenceService absenceService)
    {
        DepartmentService = departmentService;
        EmployeeService = employeeService;
        AbsenceService = absenceService;
    }
}
