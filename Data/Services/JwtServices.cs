using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CachaPlagas.DTOs;

namespace CachaPlagas.Data.Services
{
    public class JwtServices
    {
        public readonly HttpClient _httpClient;

        public JwtServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetValidTokenAsync()
        {
            var token = await SecureStorage.GetAsync("jwt_token");
            if (string.IsNullOrEmpty(token))
                return null;

            if (!IsTokenExpired(token))
                return token;
            // Token expirado, intenta renovarlo
            bool refreshed = await RefreshTokenAsync();

            if (!refreshed)
                return null;

            token = await SecureStorage.GetAsync("jwt_token");
            return token;
        }

        public async Task<bool> RefreshTokenAsync()
        {
            try
            {
                var refreshToken = await SecureStorage.GetAsync("refresh_token");
                var accesssToken = await SecureStorage.GetAsync("jwt_token");

                if (string.IsNullOrEmpty(refreshToken) || string.IsNullOrEmpty(accesssToken))
                    return false;

                var tokens = new 
                {
                    AccessToken = accesssToken,
                    RefreshToken = refreshToken
                };

                var response = await _httpClient.PostAsJsonAsync("api/Auth/Refresh", tokens);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                var json = await response.Content.ReadAsStringAsync();
                var authResponse = JsonSerializer.Deserialize<AuthTokenResponse>(json);

                if (authResponse is null)
                {
                  return false;
                }

                await SecureStorage.SetAsync("jwt_token", authResponse.AccessToken);
                await SecureStorage.SetAsync("refresh_token", authResponse.RefreshToken);
                return true;
            }
            catch
            {
                return false;
            }
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
