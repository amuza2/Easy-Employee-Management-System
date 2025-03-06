using EEMS.BusinessLogic.DTOs;
using EEMS.BusinessLogic.Interfaces;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Shared;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace EEMS.UI.Views.Employee
{
    public class EmployeeViewModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly AddAndEditEmployeeViewModel _addAndEditEmployeeViewModel;
        public ObservableCollection<EmployeeDTO> Employees { get; set; }
        
        public ICommand AddEmployeeCommand { get; }

        
        public EmployeeViewModel(IEmployeeService employeeService, AddAndEditEmployeeViewModel addAndEditEmployeeViewModel)
        {
            _addAndEditEmployeeViewModel = addAndEditEmployeeViewModel;
            _employeeService = employeeService;
            
            Employees = new ObservableCollection<EmployeeDTO>();
            AddEmployeeCommand = new RelayCommand(OpenAddEmployeeForm);
            LoadMembers();
        }


        private void OpenAddEmployeeForm()
        {
            var addEmployeePage = new AddAndEditEmployeePage(_addAndEditEmployeeViewModel);
            var sharedWindow = new sharedWindow(addEmployeePage);
            sharedWindow.ShowDialog();
        }

        private async void LoadMembers()
        {
            var employees = await _employeeService.GetAsync();

            foreach (var employee in employees)
            {
                Employees.Add(new EmployeeDTO
                {
                    Id = employee.Id,
                    FullName = $"{employee.FirstName} {employee.LastName}",
                    JobTitle = employee.JobTitle,
                    Email = employee.Email,
                    Phone = employee.Phone
                });
            }

        }

        
    }
}
