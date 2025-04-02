using CachaPlagas.View;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CachaPlagas.View_model
{
    public class LoginVM : BaseViewModel
    {
        #region VARIABLES
        private string _Email;
        private string _Contrasena;
        private readonly AuthService _authService;
        private readonly INavigation _navigation;
        #endregion

        #region CONSTRUCTOR
        public LoginVM(INavigation navigation, AuthService authService)
        {
            _navigation = navigation;
            _authService = authService;

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://szd264mf-5086.usw3.devtunnels.ms/")
            };
            _authService = new AuthService(httpClient);
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
                string token = await _authService.Login(Email, Contrasena);
                if (!string.IsNullOrEmpty(token))
                {
                    // Guardar token (puedes almacenarlo en Preferences o SecureStorage para persistencia)
                    Preferences.Set("AuthToken", token);

                    // Navegar a la siguiente página
                    await _navigation.PushAsync(new ListadoTrampas());
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
            await _navigation.PushAsync(new CachaPlagas.View.Registrar());
        }

        public async Task Ir_a_RecuperarContrasena()
        {
            await _navigation.PushAsync(new RecuperarContraseña());
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

        // Método para obtener el token si lo necesitas en otras partes
        public string GetToken()
        {
            return _authService.GetToken();
        }
    }
}


//var token = _authService.GetToken(); // Obtener el token
//_authService.AddAuthorizationHeader(); // Agregar al encabezado de HttpClient para otras solicitudes