using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.Data.Services
{
    public class JwtServices
    {

        public async Task<string?> GetValidTokenAsync()
        {
            var token = await SecureStorage.GetAsync("jwt_token");
            //var refreshToken = await SecureStorage.GetAsync("refresh_token");

            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedAccessException("No hay token disponible");

            if (!IsTokenExpired(token))
                return token;

            return null;

            // return await RefreshTokenAsync(refreshToken);
        }

        public bool IsTokenExpired(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return true;

            try
            {
                var jwt = new JwtSecurityToken(token);
                var safetyMargin = TimeSpan.FromMinutes(1);
                return jwt.ValidTo < (DateTime.UtcNow - safetyMargin);
            }
            catch
            {
                return true; // Token inválido o corrupto
            }
        }
    }
}
