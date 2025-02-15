using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.DataAccess.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
