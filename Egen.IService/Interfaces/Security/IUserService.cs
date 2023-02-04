using Egen.Dto.Security;
using Egen.IService.Infrastructure;
using Egen.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.IService.Interfaces.Security
{
    public interface IUserService : IGenericService<User>
    {
        /*Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Int32 Id);
        Task<int> AddAsync(UserDto userDto);
        Task<int> UpdateAsync(UserDto userDto);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<UserDto>> GetAsync(int? Id = null, string? Name = null, string? Email = null, bool? IsActive = null);*/
    }
}
