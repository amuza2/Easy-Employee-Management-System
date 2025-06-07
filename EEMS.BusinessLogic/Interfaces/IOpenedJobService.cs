using EEMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.BusinessLogic.Interfaces;

public interface IOpenedJobService
{
    Task<int> AddAsync(OpenedJob opendJob);
    Task DeleteAsync(int id);
    Task<IEnumerable<OpenedJob>> GetAsync();
    Task<OpenedJob> GetAsync(int id);
    Task UpdateAsync(OpenedJob opendJob);
}
