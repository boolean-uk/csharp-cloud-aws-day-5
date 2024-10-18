using cohort_backend.wwwapi.Models;

namespace cohort_backend.wwwapi.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
    }
}
