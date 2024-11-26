using System.Security.Claims;
using System.Security.Principal;

namespace Api.Helper
{
    public static class Extensions
    {
        public static string GetIdFromUser(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.PrimarySid);
            return claim?.Value ?? string.Empty;
        }
    }
}
