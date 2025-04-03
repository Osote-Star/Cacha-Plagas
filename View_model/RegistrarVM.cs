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
    public class RegistrarVM : BaseViewModel
    {
        #region VARIABLES
        string _Email;
        string _Contrasena;
        string _ContrasenaRepetida;
        private readonly INavigationService _navService;
        UsuarioServices _UsuarioServices;
        #endregion

        #region CONSTRUCTOR
        public RegistrarVM(INavigationService navService, UsuarioServices usuarioServices)
        {
            _navService = navService;
            _UsuarioServices = usuarioServices;
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
        public string ContrasenaRepetida
        {
            get { return _ContrasenaRepetida; }
            set { SetValue(ref _ContrasenaRepetida, value); }
        }
        #endregion

        #region PROCESOS
        public async Task CrearCuenta()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contrasena) || string.IsNullOrEmpty(ContrasenaRepetida))
            {
                await this.DisplayAlert("Error", "Faltan datos", "Aceptar");
                return;
            }
            else if (Contrasena != ContrasenaRepetida)
            {
                await this.DisplayAlert("Error", "Las contraseñas no coinciden", "Aceptar");
                return;
            }

            try
            {
                var usuarioDto = new CrearUsuarioDto
                {
                    email = Email,
                    contrasena = Contrasena
                };
                bool resultado = await _UsuarioServices.AgregarUsuario(usuarioDto);
                if(resultado)
                {
                    // Navegar a la siguiente página
                    await _navService.PushAsync<LoginVM>();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear la cuenta", "Aceptar");
                }
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear la cuenta", "Aceptar");
            }
        }
        public async Task VolverPagina()
        {
            await _navService.PopAsync();
        }
        public void ProcesoSimple()
        {
        }
        #endregion

        #region COMANDOS

        public ICommand Registrarse => new Command(async () => await CrearCuenta());
        public ICommand Volver => new Command(async () => await VolverPagina());

        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
