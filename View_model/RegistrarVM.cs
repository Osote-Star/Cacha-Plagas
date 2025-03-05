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
        #endregion

        #region CONSTRUCTOR
        public RegistrarVM(INavigation navegacion)
        {
            Navigation = navegacion;
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
            else
            {
                await this.DisplayAlert("Excelente", "Su cuenta ha sido creada", "Aceptar");
            }
        }
        public async Task VolverPagina()
        {
            await Navigation.PopAsync();
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
