using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task AddUserAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "O usuário não pode ser nulo.");

            await _userRepository.AddUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<User> FindByEMailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("O e-mail não pode ser nulo ou vazio.", nameof(email));

            var user = await _userRepository.FindByEMailAsync(email);
            if (user == null)
                throw new KeyNotFoundException("Usuário com o e-mail fornecido não encontrado.");

            return user;
        }

        public async Task<User> FindByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            return user;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _userRepository.GetAllUserAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "O usuário não pode ser nulo.");

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task<User> Valida(UserAccess request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "A solicitação de validação não pode ser nula.");

            var user = await _userRepository.FindByEMailAsync(request.Email);
            if (user == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            return user;
        }
    }
}
