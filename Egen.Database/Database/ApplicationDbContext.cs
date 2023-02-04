using Egen.Model.ModelConfiguration.Security;
using Egen.Model.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.Database.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Users
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleDbConfig).Assembly);*/
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbConfig).Assembly);
            /*modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserAccountDbConfig).Assembly);*/
        }
    }
}
