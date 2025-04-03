using CachaPlagas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.Data.Services
{
    public class UsuarioServices
    {
        private API_Connection _Connection;

        public UsuarioServices(API_Connection connection) => _Connection = connection;
        
        public async Task<bool> AgregarUsuario(CrearUsuarioDto crearUsuarioDto)
        {
            try
            {
                var response = await _Connection.Post("/api/Usuarios/AgregarUsuario", crearUsuarioDto, false);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
