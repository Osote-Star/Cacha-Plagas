using CachaPlagas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CachaPlagas.Data.Services
{
    public class AgregrarTrampaVM
    {
        public API_Connection _connection;
        public AgregrarTrampaVM(API_Connection connection) => _connection = connection;

        public async Task<TrampaModel?> GetOneTrampa(int trampaId)
        {
            var response = await _connection.Get($"api/Trampa/Buscar-trampa/{trampaId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TrampaModel>(content);
            }
            return null;
        }
    }
}
