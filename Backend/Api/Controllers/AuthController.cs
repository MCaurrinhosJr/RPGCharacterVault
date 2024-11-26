using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> TokenAsync([FromBody] UserAccess request)
        {
            if (request == null)
                return BadRequest("Requisição inválida.");

            try
            {
                User usuario = await _userService.Valida(request);

                if (usuario == null)
                {
                    // Usuário não encontrado ou senha incorreta
                    return Unauthorized("Usuário ou senha inválidos");
                }

                // Gerar as Claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Name, usuario.Name)
                };

                // Criar a chave de segurança
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Criar o token JWT
                var token = new JwtSecurityToken(
                    issuer: _configuration["Issuer"],
                    audience: _configuration["Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddYears(1),
                    signingCredentials: creds
                );

                // Retornar o token
                return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception ex)
            {
                // Logar o erro aqui, se necessário
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    $"Ocorreu um erro interno. {ex.Message}");
            }
        }
    }
}
