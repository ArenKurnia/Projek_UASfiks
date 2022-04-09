using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projek_UTSAren.Helper
{
    public static class DapatkanIdentitas
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(
                                        bebas =>
                                        bebas.Type == "Nama_Lengkap"
                                        )?
                                        .Value ?? string.Empty;
            }
            return string.Empty;
        }
        public static string GetRole(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(
                                        bebas =>
                                        bebas.Type == "Role"
                                        )?
                                        .Value ?? string.Empty;
            }
            return string.Empty;
        }
    }
}
