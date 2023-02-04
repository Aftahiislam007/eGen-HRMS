using Egen.IRepository.Infrastructure;
using Egen.IService.Infrastructure;
using Egen.IService.Interfaces.Security;
using Egen.Repository.Infrastructure;
using Egen.Service.Services.Security;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.Service.Infrastructure
{
    public class ServiceRegistration : IServiceRegistration
    {
        public static IRepositoryRegistration Registration { get; set; } = new RepositoryRegistration();  
        public void AddInfrastructure(IServiceCollection services, string identityDb, string hrDb, string olcDb, string inventoryDb)
        {
            Registration.AddInfrastructure(services, identityDb:identityDb, hrDb:hrDb, olcDb: olcDb, inventoryDb: inventoryDb);
            services.AddTransient<IUserService, UserService>();
            /*services.AddTransient<IUnitOfWork, UnitOfWork>();*/
        }
    }
}
