using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(string id);
    }
}

