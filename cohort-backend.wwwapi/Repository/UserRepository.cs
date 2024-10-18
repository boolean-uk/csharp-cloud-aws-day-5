using cohort_backend.wwwapi.Data;
using cohort_backend.wwwapi.Models;
using Microsoft.EntityFrameworkCore;

namespace cohort_backend.wwwapi.Repository
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _databaseContext;
        
        public UserRepository (DatabaseContext db)
        {
            _databaseContext = db;
        }

        public async Task<User> GetPrimeUser(int id)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _databaseContext.Users.ToListAsync();
        }
    }
}
