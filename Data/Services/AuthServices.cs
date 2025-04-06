using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using CachaPlagas.DTOs;

namespace CachaPlagas.Data.Services
{
    public class AuthServices
    {
        public API_Connection _connection;
        public AuthServices(API_Connection connection) => _connection = connection;
        public async Task<bool> Login(LoginDto loginDto)
        {
            try
            {
                var response = await _connection.Post("api/Auth/Login", loginDto, false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var authResponse = JsonSerializer.Deserialize<AuthTokenResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (authResponse != null)
                    {
                        await SecureStorage.SetAsync("jwt_token", authResponse.AccessToken);
                        await SecureStorage.SetAsync("refresh_token", authResponse.RefreshToken);
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> Logout()
        {
            try
            {
                var response = await _connection.Get("api/Auth/Logout");
                if (!response.IsSuccessStatusCode)
                    return false;
                await SecureStorage.SetAsync("jwt_token", string.Empty);
                await SecureStorage.SetAsync("refresh_token", string.Empty);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }   
 
    }
}
