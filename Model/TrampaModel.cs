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

        public string IDTrampa { get; set; }
        public string IDUsuario { get; set; }
        public ImageSource Imagen { get; set; }
        public string Modelo { get; set; }
        public string Localizacion { get; set; }
        public bool EstatusTrampa { get; set; }
        public bool EstatusSensor { get; set; }
        public bool Estatuspuerta { get; set; }


    }
}
