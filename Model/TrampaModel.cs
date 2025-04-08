using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CachaPlagas.Model
{
    public class TrampaModel
    {
        public string _Id { get; set; }
        [JsonPropertyName("idTrampa")]
        public int IdTrampa { get; set; }
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; } // Changed to int to match JSON
        [JsonPropertyName("modelo")]
        public string Modelo { get; set; }

        [JsonPropertyName("imagen")]
        public string Imagen { get; set; }
        [JsonPropertyName("localizacion")]
        public string Localizacion { get; set; }
        [JsonPropertyName("estatusTrampa")]
        public bool EstatusTrampa { get; set; }
        [JsonPropertyName("estatusSensor")]
        public bool EstatusSensor { get; set; }
        [JsonPropertyName("estatusPuerta")]
        public bool EstatusPuerta { get; set; }
        public List<object> Capturas { get; set; } // Matches "capturas" field


        public override string ToString()
        {
            return $"Id: {IdTrampa}, Modelo: {Modelo}, Localizacion: {Localizacion}";
        }
    }
}
