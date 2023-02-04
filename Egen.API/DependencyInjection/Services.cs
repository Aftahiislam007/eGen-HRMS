using Egen.IService.Infrastructure;
using Egen.Service.Infrastructure;

namespace Egen.API.DependencyInjection
{
    public static class Services
    {
        public static IServiceRegistration Service { get; set; } = new ServiceRegistration();
        public static void RegisterDependencies(IServiceCollection services, string identityDb, string hrDb, string olcDb, string inventoryDb)
        {
            Service.AddInfrastructure(services, identityDb: identityDb, hrDb: hrDb, olcDb: olcDb, inventoryDb: inventoryDb);
        }
    }
}
