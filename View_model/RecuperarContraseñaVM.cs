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
        string _Email;
        #endregion

        #region CONSTRUCTOR
        public RecuperarContraseñaVM(INavigation navegacion)
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
        #endregion

        #region PROCESOS

        public async Task VolverAtras()
        {
            await Navigation.PopAsync();
        }
        public async Task Enviar_Correo()
        {
            await this.DisplayAlert("Excelente", "Se ha enviado un codigo a su correo", "Aceptar");
        }
        #endregion

        #region COMANDOS

        public ICommand Volver => new Command(async () => await VolverAtras());
        public ICommand EnviarCorreo => new Command(async () => await Enviar_Correo());
        //public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
