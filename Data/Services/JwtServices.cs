using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CachaPlagas.DTOs;

namespace CachaPlagas.Data.Services
{
    public class JwtServices
    {

        public JwtServices()
        {
           
        }

        public async Task<string?> GetValidTokenAsync()
        {
            var token = await SecureStorage.GetAsync("jwt_token");
            if (string.IsNullOrEmpty(token))
                return null;

            if (!IsTokenExpired(token))
                return token;

            //// Token expirado, intenta renovarlo
            //bool refreshed = await _authServices.RefreshTokenAsync();
            //if (refreshed)
            //{
            //    token = await SecureStorage.GetAsync("jwt_token");
            //    return token;
            //}

            return null;
        }

        public bool IsTokenExpired(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var expiration = jwtToken.ValidTo;

                // Margen de seguridad de 1 minuto
                return expiration < DateTime.UtcNow.AddMinutes(-1);
            }
            catch
            {
                return true; // Token inválido o malformado
            }
        }

    }
}
