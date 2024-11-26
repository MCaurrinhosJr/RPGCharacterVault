using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUserAsync();
        Task<User> FindByIdAsync(int id);
        Task<User> FindByEMailAsync(string Email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<User> Valida(UserAccess request);
    }
}
