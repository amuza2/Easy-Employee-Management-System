using CommunityToolkit.Mvvm.Messaging.Messages;
using EEMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.UI.Views.Shared;

public class EmployeeSelectedMessage : ValueChangedMessage<Employee>
{
    public EmployeeSelectedMessage(Employee value) : base(value)
    {
    }
}
