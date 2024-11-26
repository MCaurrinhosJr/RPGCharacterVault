using Api.Helper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    public class BaseController : Controller
    {

        public string Usuario => User.Identity?.GetIdFromUser() ?? string.Empty;

        public string Token
        {
            get
            {
                string token = HttpContext.Request?.Headers["Authorization"];

                if (!string.IsNullOrEmpty(token) && token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    return token.Substring(7); // Remove "Bearer " e retorna o token
                }

                return string.Empty;
            }
        }
    }
}
