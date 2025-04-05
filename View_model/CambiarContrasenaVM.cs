//using PassKit;
using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
using CachaPlagas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CachaPlagas.View_model
{
    public class CambiarContrasenaVM : BaseViewModel
    {
        #region VARIABLES
        
        private string _email;
        private string _contrasena;
        private string _contrasenaRepetida;
        private readonly INavigationService _navService;
        private readonly UsuarioServices _usuarioServices;
        #endregion

        #region CONSTRUCTOR
        public CambiarContrasenaVM(INavigationService navService, UsuarioServices usuarioServices)
        {
            _navService = navService;
            _usuarioServices = usuarioServices;
        }
        #endregion

        #region OBJETOS

        public string Email
        {
            get { return _email; }
            set { SetValue(ref _email, value); }
        }

        public string Contrasena
        {
            get { return _contrasena; }
            set { SetValue(ref _contrasena, value); }
        }
        public string ContrasenaRepetida
        {
            get { return _contrasenaRepetida; }
            set { SetValue(ref _contrasenaRepetida, value); }
        }
        #endregion

        #region PROCESOS
        public async Task Actualizar_Contrasena()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Contrasena) || string.IsNullOrWhiteSpace(ContrasenaRepetida))
            {
                await this.DisplayAlert("Error", "Todos los campos son obligatorios.", "Aceptar");
                return;
            }

            if (Contrasena != ContrasenaRepetida)
            {
                await this.DisplayAlert("Error", "Las contraseñas no coinciden.", "Aceptar");
                return;
            }

            var cambiarContrasenaDto = new CambiarContrasenaDto
            {
                Email = Email,
                Contrasena = Contrasena
            };

            bool exito = await _usuarioServices.CambiarContrasena(cambiarContrasenaDto);

            if (exito)
            {
                await this.DisplayAlert("Éxito", "Contraseña actualizada correctamente.", "Aceptar");
                await _navService.PopToRootAsync();
            }
            else
            {
                await this.DisplayAlert("Error", "No se pudo actualizar la contraseña. Verifica tus datos o intenta de nuevo.", "Aceptar");
            }
        }

        public void ProcesoSimple()
        {
        }
        #endregion

        #region COMANDOS

        public ICommand ActualizarContrasena => new Command(async () => await Actualizar_Contrasena());


        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
