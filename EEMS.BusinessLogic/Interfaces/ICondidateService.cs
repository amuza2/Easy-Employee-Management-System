using EEMS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.BusinessLogic.Interfaces;

public interface ICondidateService
{
    Task<IEnumerable<Condidate>> GetAsync();
    Task<Condidate> GetAsync(int id);
    Task<int> AddAsync(Condidate condidate);
    Task<bool> DeleteAsync(int id);
    Task UpdateAsync(Condidate condidate);
}
