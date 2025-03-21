﻿using EEMS.BusinessLogic.DTOs;
using EEMS.BusinessLogic.Interfaces;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Shared;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EEMS.UI.Views.Employee
{
    public class EmployeeViewModel
    {
        private readonly IEmployeeService _employeeService;
        public ObservableCollection<EmployeeDTO> Employees { get; set; }
        
        public ICommand AddEmployeeCommand { get; }

        
        public EmployeeViewModel(IEmployeeService employeeService, PersonalInformationViewModel personalInformationViewModel)
        {
            _employeeService = employeeService;
            Employees = new ObservableCollection<EmployeeDTO>();
            AddEmployeeCommand = new RelayCommand(OpenAddEmployeeForm);
            LoadMembers();
        }

        private void OpenAddEmployeeForm()
        {
            var viewModel = new AddAndEditWindowViewModel(new PersonalInformationViewModel(), new JobInformationViewModel());
            var AddAndEditWindow = new AddAndEditWindow(viewModel);
            AddAndEditWindow.ShowDialog();
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
