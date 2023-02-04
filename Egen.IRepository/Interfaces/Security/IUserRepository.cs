using Egen.IRepository.Infrastructure;
using Egen.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.IRepository.Interfaces.Security
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAsync(int? Id = null, string? Name = null, string? Email = null, bool? IsActive = null);
    }
}
