using Egen.Model.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.Database.Database
{
    public class OLCDbContext : DbContext
    {
        public OLCDbContext(DbContextOptions<OLCDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
