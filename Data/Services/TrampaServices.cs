using CachaPlagas.Data;
using CachaPlagas.DTOs;
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

        public async Task<List<TrampaModel>> GetTrampas(int usuarioID)
        {
            var response = await _connection.Get($"api/Trampa/Buscar-las-trampas-del-usuario/{usuarioID}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var trampas = JsonSerializer.Deserialize<List<TrampaModel>>(content); // Deserialize como lista
                return trampas ?? new List<TrampaModel>(); // Retorna una lista vacía si es nulo
            }
            return new List<TrampaModel>(); // Retorna una lista vacía en caso de error
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

        public async Task<TrampaModel?> CambiarStatusPuerta(EstatusPuertaDto estatusPuertaDto)
        {

            var response = await _connection.Put("api/Trampa/CambiarEstatusPuerta", estatusPuertaDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TrampaModel>(content);
            }
            return null;
        }
        public async Task<TrampaModel?> CambiarStatusSensor(EstatusSensorDto estatusSensorDto)
        {

            var response = await _connection.Put("api/Trampa/CambiarestatusSensor", estatusSensorDto);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TrampaModel>(content);
            }
            return null;
        }

        public async Task<TrampaModel> GetEstatusPuerta(int trampaId)
        {
            var response = await _connection.Get($"api/Trampa/ObtenerEstatusPuerta/{trampaId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TrampaModel>(content);
            }
            return null; // Retorna una lista vacía en caso de error
        }
        public async Task<TrampaModel> GetEstatusSensor(int trampaId)
        {
            var response = await _connection.Get($"api/Trampa/ObtenerEstatusSensor/{trampaId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TrampaModel>(content); 
            }
            return null; // Retorna una lista vacía en caso de error
        }

    }
}