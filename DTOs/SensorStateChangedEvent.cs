using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.DTOs
{
    internal class SensorStateChangedEvent : PubSubEvent<SensorStateChangedEvent>
    {
        public string Modelo { get; set; }
        public bool EstatusSensor { get; set; }
    }
}
