using CachaPlagas.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CachaPlagas.Data
{
    public class API_Connection
    {
        public  readonly HttpClient _httpClient;
        private readonly JwtServices _JwtServices;

        public API_Connection(HttpClient httpClient, JwtServices JwtServices)
        {
            _JwtServices = JwtServices;
            _httpClient = httpClient;
        }
        private async Task SetAuthorizationHeader()
        {
            var token = await _JwtServices.GetValidTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
        public async Task<HttpResponseMessage> Get(string endpoint)
        {
            await SetAuthorizationHeader();
            return await _httpClient.GetAsync(endpoint);
        }

        /// <summary>
        /// Este metodo es para mandar datos con el endpoint y los datos a enviar, si el metodo que se va a usar requiere autenticacion
        /// entonces el parametro RequiresAuthentication se pone en true, si no se pone en false
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <param name="RequiresAuthentication"></param>
        /// <returns>La respuesta http</returns>
        public async Task<HttpResponseMessage> Post(string endpoint, object data, bool RequiresAuthentication)
        {
            try
            {
                if(RequiresAuthentication)
                {
                    await SetAuthorizationHeader();
                }
                return await _httpClient.PostAsJsonAsync(endpoint, data);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> Put(string endpoint, object data)
        {
            await SetAuthorizationHeader();
            return await _httpClient.PutAsJsonAsync(endpoint, data);
        }
    }
}
