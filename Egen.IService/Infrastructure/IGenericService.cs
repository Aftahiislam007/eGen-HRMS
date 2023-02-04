using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.IService.Infrastructure
{
    public interface IGenericService<T> where T : class
    {
        Task<int> AddAsync(T Entity);
        Task<int> UpdateAsync(T Entity);
        Task<int> DeleteAsync(T Entity);
        Task<ICollection<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
    }
}
