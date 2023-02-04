using Egen.Database.Database;
using Egen.IRepository.Infrastructure;
using Egen.IRepository.Interfaces.Security;
using Egen.Repository.Repositories.Security;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Egen.Repository.Infrastructure
{
    public class RepositoryRegistration : IRepositoryRegistration
    {
        public void AddInfrastructure(IServiceCollection services, string identityDb, string hrDb, string olcDb, string inventoryDb)
        {
            // This is for HRM Database
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(hrDb);
            });
            //This is for OLC Database
            services.AddDbContext<OLCDbContext>(options =>
            {
                options.UseSqlServer(olcDb);
            });

            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
