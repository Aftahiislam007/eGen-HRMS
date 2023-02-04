using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.IRepository.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
