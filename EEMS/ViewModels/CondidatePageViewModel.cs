using CommunityToolkit.Mvvm.ComponentModel;
using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.UI.ViewModels;

public class CondidatePageViewModel : ObservableObject
{
    private readonly IEmployeeManagementService _employeeManagementService;
    public ObservableCollection<Employee> Employees { get; set; }
}
