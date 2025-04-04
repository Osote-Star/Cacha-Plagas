using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
using CachaPlagas.DTOs;
using CachaPlagas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CachaPlagas.View_model
{
    public class RecuperarContraseñaVM : BaseViewModel
    {
        #region VARIABLES
        private string _Email;
        private readonly AuthServices _services;
        private readonly INavigationService _navService;
        private readonly EmailService _emailService;

        #endregion

        #region CONSTRUCTOR
        public RecuperarContraseñaVM(INavigationService navigationService, AuthServices services, EmailService emailService)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _navService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }
        #endregion

        #region OBJETOS
        public string Email
        {
            get { return _Email; }
            set { SetValue(ref _Email, value); }
        }
        #endregion

        #region PROCESOS
        public async Task VolverAtras()
        {
            await _navService.PopAsync();
        }

        public async Task Enviar_Correo()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingresa un correo electrónico.", "OK");
                return;
            }

            try
            {
                var emailDto = new EmailDto
                {
                    emailReceptor = Email,
                    tema = "Recuperación de Contraseña"
                };

                bool enviado = await _emailService.EnviarCorreo(emailDto);
                if (enviado)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Se ha enviado el correo de verificación.", "OK");
                    // Usar el nuevo método para pasar el email
                    await _navService.PushAsyncWithParameter<CodigoContrasenaVM>("email", Email);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo enviar el correo. Inténtalo de nuevo.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
        #endregion

        #region COMANDOS
        public ICommand Volver => new Command(async () => await VolverAtras());
        public ICommand EnviarCorreo => new Command(async () => await Enviar_Correo());
        #endregion
    }
}