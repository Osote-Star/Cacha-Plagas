// Services/AuthService.cs
using System.Net.Http.Json;
using System.Text.Json;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private string _token;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> Login(string email, string password)
    {
        var loginDto = new LoginDto { Email = email, Contrasena = password };

        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/Login", loginDto);
            if (response.IsSuccessStatusCode)
            {
                _token = await response.Content.ReadAsStringAsync();
                return _token;
            }
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public string GetToken()
    {
        return _token;
    }

    public void AddAuthorizationHeader()
    {
        if (!string.IsNullOrEmpty(_token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
        }
    }
}

public class LoginDto
{
    public string Email { get; set; }
    public string Contrasena { get; set; }
}