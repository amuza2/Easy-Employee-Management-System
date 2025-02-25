using EEMS.BusinessLogic.DTOs;
using EEMS.BusinessLogic.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace EEMS.UI.Views.Employee
{
    public class EmployeeViewModel
    {
        private IEmployeeService _employeeService;
        public ObservableCollection<EmployeeDTO> Employees { get; set; }
        BrushConverter converter;
        public ICommand AddEmployeeCommand { get; }

        public EmployeeViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            converter = new BrushConverter();
            Employees = new ObservableCollection<EmployeeDTO>();
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            LoadMembers();
        }

        private void AddEmployee()
        {
            MessageBox.Show("Add Employee Form");
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
