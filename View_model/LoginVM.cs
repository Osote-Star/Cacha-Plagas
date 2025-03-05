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
        #endregion

        #region CONSTRUCTOR
        public LoginVM(INavigation navegacion)
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
        #endregion

        #region PROCESOS
        public async Task Iniciar_Sesion()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contrasena))
            {
                await this.DisplayAlert("Error", "Faltan datos", "Aceptar");
                return;
            }
            else if (Email == "angeledastorga08@gmail.com" && Contrasena == "1234")
            {
                //holamaestro
                await Navigation.PushAsync(new ListadoTrampas());
            }
            else
            {
                await this.DisplayAlert("Error", "Usuario o contraseña incorrectos", "Aceptar");
            }
        }
        public async Task Ir_a_Registrarse()
        {
            await Navigation.PushAsync(new CachaPlagas.View.Registrar());
        }
        public async Task Ir_a_RecuperarContrasena()
        {
            await Navigation.PushAsync(new RecuperarContraseña());
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
