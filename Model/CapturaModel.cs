using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.Modelos
{
    public class CapturaModel
    {
        public string _Id { get; set; }

        public int IDCaptura { get; set; }
        public int IDTrampa { get; set; }

        public DateTime fechahora { get; set; }
        public string localizacion { get; set; }
        public string Animal { get; set; }
    }
}