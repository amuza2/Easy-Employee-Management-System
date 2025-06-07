using EEMS.Models.Models;

namespace EEMS.BusinessLogic.Interfaces;

public interface IEmployeeManagementService
{
    IDepartmentService DepartmentService { get; }
    IEmployeeService EmployeeService { get; }
    IAbsenceService AbsenceService { get; }
}