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
        public int IdTrampa { get; set; }
        public int IdUsuario { get; set; } // Changed to int to match JSON
        [JsonPropertyName("modelo")]
        public string Modelo { get; set; }

        [JsonPropertyName("imagen")]
        public string Imagen { get; set; }
        public string Localizacion { get; set; }
        public bool EstatusTrampa { get; set; }
        [JsonPropertyName("estatusSensor")]
        public bool EstatusSensor { get; set; }
        public bool EstatusPuerta { get; set; }
        public List<object> Capturas { get; set; } // Matches "capturas" field


        public override string ToString()
        {
            return $"Id: {IdTrampa}, Modelo: {Modelo}, Localizacion: {Localizacion}";
        }
    }
}
