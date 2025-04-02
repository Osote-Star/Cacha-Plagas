using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.Model
{
    public class TrampaModel
    {
        public string _Id { get; set; }
        public int IdTrampa { get; set; }
        public int IdUsuario { get; set; } // Changed to int to match JSON
        public string Imagen { get; set; }
        public string Modelo { get; set; }
        public string Localizacion { get; set; }
        public bool EstatusTrampa { get; set; }
        public bool EstatusSensor { get; set; }
        public bool EstatusPuerta { get; set; }
        public List<object> Capturas { get; set; } // Matches "capturas" field
    }
}
