using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.Models.Models;

public class Department
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
