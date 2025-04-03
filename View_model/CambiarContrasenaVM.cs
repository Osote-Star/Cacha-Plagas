//using PassKit;
using CachaPlagas.Data.Interfaces;
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
        string _contrasena;
        string _contrasenaRepetida;
        private readonly INavigationService _navService;
        #endregion

        #region CONSTRUCTOR
        public CambiarContrasenaVM(INavigationService navService)
        {
            _navService = navService;
        }
        #endregion

        #region OBJETOS

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
            if (Contrasena != ContrasenaRepetida) 
            {
                await this.DisplayAlert("Error", "Las contraseñas no coinciden", "Aceptar");
                return;
            }
            else
            {
                await this.DisplayAlert("Exito", "Contraseña actualizada", "Aceptar");
                await _navService.PopToRootAsync();

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
