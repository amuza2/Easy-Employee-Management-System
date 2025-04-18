using EEMS.DataAccess.Models;

namespace EEMS.BusinessLogic.Interfaces;

public interface IEmployeeManagementService
{
    IDepartmentService DepartmentService { get; }
    IJobNatureService JobNatureService { get; }
    IEmployeeService EmployeeService { get; }
    IAbsenceService AbsenceService { get; }


    //Task<int> GetDepartmentIdByName(string deparmtentName);
    //Task<Department> GetAsync(int id);
    //Task<int> GetJobNatureByName(string jobNatureName);
    //Task<IEnumerable<Department>> GetDepartmentsAsync();
    //Task<IEnumerable<JobNature>> GetJobNaturesAsync();
    //Task<int> AddEmployeeAsync(Employee employee);
    //Task<IEnumerable<Employee>> GetAsync();
    //Task<bool> DeleteEmployeeByIdAsync(int id);
}