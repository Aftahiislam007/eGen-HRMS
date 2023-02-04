using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.IRepository.Infrastructure
{
    public interface IRepositoryRegistration
    {
        void AddInfrastructure(IServiceCollection services, string identityDb, string hrDb, string olcDb, string inventoryDb);

    }
}
