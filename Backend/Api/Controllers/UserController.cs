using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetUserAsync()
        {
            try
            {
                var userId = int.Parse(Usuario);
                var user = await _userService.FindByIdAsync(userId);

                if (user == null)
                    return NotFound("Usuário não encontrado.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao tentar recuperar o usuário: {ex.Message}");
            }
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User user)
        {
            try
            {
                var userId = int.Parse(Usuario);
                var existingUser = await _userService.FindByIdAsync(userId);

                if (existingUser == null)
                    return NotFound("Usuário não encontrado.");

                existingUser.Name = user.Name ?? existingUser.Name;
                existingUser.Email = user.Email ?? existingUser.Email;

                await _userService.UpdateUserAsync(existingUser);

                return Ok(existingUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao tentar atualizar o usuário: {ex.Message}");
            }
        }
    }
}
