using CachaPlagas.DTOs;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CachaPlagas.Data.Services
{
    public class EmailService
    {
        private readonly API_Connection _Connection;

        public EmailService(API_Connection connection) => _Connection = connection ?? throw new ArgumentNullException(nameof(connection));

        public async Task<bool> EnviarCorreo(EmailDto emailDto)
        {
            if (emailDto == null || string.IsNullOrEmpty(emailDto.emailReceptor))
            {
                throw new ArgumentException("El correo receptor es requerido.");
            }

            try
            {
                var response = await _Connection.Post("/api/Emails", emailDto, false);
                if (response == null)
                {
                    throw new HttpRequestException("No se pudo conectar con la API.");
                }

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    // Aquí podrías loggear o mostrar el mensaje de éxito
                    return true;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al enviar el correo: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error de red al enviar el correo: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al enviar el correo: " + ex.Message);
            }
        }

        public async Task<bool> ValidarCodigo(ValidarCodigoDto validarCodigoDto)
        {
            if(validarCodigoDto == null || string.IsNullOrEmpty(validarCodigoDto.EmailReceptor) || string.IsNullOrEmpty(validarCodigoDto.codigo))
            {
                throw new ArgumentException("El correo receptor y el código son requeridos.");
            }

            try
            {
                var response = await _Connection.Post("/api/Emails/validar", validarCodigoDto, false);
                if(response == null)
                {
                    throw new HttpRequestException("No se pudo conectar con la API.");
                }

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al validar el código: {response.StatusCode} - {errorContent}");
                }
                
            }
            catch(HttpRequestException ex)
            {
                throw new Exception("Error de red al validar el código: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al validar el código: " + ex.Message);
            }
            {

            }
        }
    }
}