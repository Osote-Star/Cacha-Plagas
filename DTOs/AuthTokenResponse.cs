using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.DTOs
{
    internal class AuthTokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
