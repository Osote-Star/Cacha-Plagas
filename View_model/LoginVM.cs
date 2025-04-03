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
    public class LoginVM : BaseViewModel
    {
        #region VARIABLES
        string _Email;
        string _Contrasena;
        AuthServices _services;
        private readonly INavigationService _navService;
        #endregion

        #region CONSTRUCTOR
        public LoginVM(INavigationService navigationService, AuthServices services)
        {
            _services = services;
            _navService = navigationService;
        }
        #endregion

        #region OBJETOS
        public string Email
        {
            get { return _Email; }
            set { SetValue(ref _Email, value); }
        }
        public string Contrasena
        {
            get { return _Contrasena; }
            set { SetValue(ref _Contrasena, value); }
        }
        #endregion

        #region PROCESOS
        public async Task Iniciar_Sesion()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contrasena))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Faltan datos", "Aceptar");
                return;
            }

            try
            {
                var loginDto = new LoginDto
                {
                    Email = Email,
                    Password = Contrasena
                };  
                bool tokenCorrecto = await _services.Login(loginDto);
                if (tokenCorrecto)
                {
                    // Navegar a la siguiente página
                    await _navService.PushAsync<ListadoTrampasVM>();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrectos", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo iniciar sesión: {ex.Message}", "Aceptar");
            }
        }

        public async Task Ir_a_Registrarse()
        {
            await _navService.PushAsync<RegistrarVM>();
        }

        public async Task Ir_a_RecuperarContrasena()
        {
            await _navService.PushAsync<RecuperarContraseñaVM>();
        }
        public void ProcesoSimple()
        {
        }
        #endregion

        #region COMANDOS

        public ICommand IniciarSesion => new Command(async () => await Iniciar_Sesion());
        public ICommand IraRegistrarse => new Command(async () => await Ir_a_Registrarse());
        public ICommand IraRecuperarContrasena => new Command(async () => await Ir_a_RecuperarContrasena());

        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}