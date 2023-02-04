using Dapper;
using Egen.Database.Database;
using Egen.IRepository.Interfaces.Security;
using Egen.Model.Security;
using Egen.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace Egen.Repository.Repositories.Security
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<ICollection<User>> GetAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public Task<IEnumerable<User>> GetAsync(int? Id = null, string? Name = null, string? Email = null, bool? IsActive = null)
        {
            throw new NotImplementedException();
        }
    }
}
