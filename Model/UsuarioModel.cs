using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.Model
{
    public class UsuarioModel
    {
        public string _id { get; set; }
        public string IdUsuario { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
        public string rol { get; set; }
        public List<TrampaModel> trampa { get; set; } = []; // Changed to List<TrampaModel> to match JSON
    }
}
