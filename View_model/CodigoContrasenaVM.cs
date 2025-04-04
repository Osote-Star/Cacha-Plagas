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
    public class CodigoContrasenaVM : BaseViewModel
    {
        #region VARIABLES
        private string _Email;
        private string _Codigo;
        private readonly EmailService _emailService;
        private readonly INavigationService _navService;

        #endregion

        #region CONSTRUCTOR
        public CodigoContrasenaVM(INavigationService navigationService, EmailService emailService)
        {
            _navService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }
        #endregion

        #region OBJETOS
        public string Codigo
        {
            get { return _Codigo; }
            set { SetValue(ref _Codigo, value); }
        }

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

        public async Task ValidarCodigo()
        {
            if (string.IsNullOrEmpty(Codigo) || Codigo.Length != 6)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingresa el código de 6 dígitos.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se recibió un correo electrónico válido.", "OK");
                return;
            }

            try
            {
                var validarCodigoDto = new ValidarCodigoDto
                {
                    EmailReceptor = Email,
                    codigo = Codigo
                };

                bool esValido = await _emailService.ValidarCodigo(validarCodigoDto);
                if (esValido)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Código válido. Puedes restablecer tu contraseña.", "OK");
                    await _navService.PushAsync<CambiarContrasenaVM>(); // Ajusta según tu flujo
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Código incorrecto o expirado. Inténtalo de nuevo.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error al validar el código: {ex.Message}", "OK");
            }
        }

        public async Task ReenviarCodigo()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se recibió un correo electrónico válido.", "OK");
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
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Se ha reenviado el código de verificación.", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo reenviar el código. Inténtalo de nuevo.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error al reenviar el código: {ex.Message}", "OK");
            }
        }
        #endregion

        #region COMANDOS
        public ICommand Volver => new Command(async () => await VolverAtras());
        public ICommand Validar => new Command(async () => await ValidarCodigo());
        //public ICommand ReenviarCodigo => new Command(async () => await ReenviarCodigo());
        #endregion

        public override async Task OnNavigatingTo(IDictionary<string, object> parameters)
        {
            if (parameters != null && parameters.ContainsKey("email"))
            {
                Email = parameters["email"] as string;
                if (string.IsNullOrEmpty(Email))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "El correo recibido es inválido.", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se recibió un correo electrónico válido.", "OK");
            }
        }
    }
}