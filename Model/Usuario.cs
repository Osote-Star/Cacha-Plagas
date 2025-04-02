using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.Model
{
    public class Usuario
    {
        public string _id { get; set; }

        public int IDUsuario { get; set; }

        public string Email { get; set; }

        public string Contrasena { get; set; }

        public string rol { get; set; }

        public List<TrampaModel> Trampas { get; set; } = [];
    }
}
