using CachaPlagas.Data;
using CachaPlagas.Model;
using System.Text.Json;
using System.Threading.Tasks;

namespace CachaPlagas.Data.Services
{
    public class TrampaService
    {
        private readonly API_Connection _connection;

        public TrampaService(API_Connection connection)
        {
            _connection = connection;
        }

        // Obtener una trampa por ID
        public async Task<TrampaModel?> GetOneTrampa(int trampaId)
        {
            var response = await _connection.Get($"api/Trampa/Buscar-trampa/{trampaId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TrampaModel>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            return null;
        }

        // Vincular una trampa a un usuario
        public async Task<TrampaModel?> VincularTrampa(int trampaId, int usuarioId)
        {
            var vincularTrampaDto = new
            {
                TrampaID = trampaId,
                UsuarioID = usuarioId
            };

            var response = await _connection.Put("api/Trampa/VincularTrampa", vincularTrampaDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TrampaModel>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            return null;
        }
    }
}