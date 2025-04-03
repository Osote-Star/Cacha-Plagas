using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
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
        string _Email;
        private AuthServices _services;
        private INavigationService _navService;
        #endregion

        #region CONSTRUCTOR
        public RecuperarContraseñaVM(INavigationService navigationService, AuthServices services)
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
        #endregion

        #region PROCESOS

        public async Task VolverAtras()
        {
            await _navService.PopAsync();
        }
        public async Task Enviar_Correo()
        {
            await _navService.PushAsync<CodigoContrasenaVM>();
        }
        #endregion

        #region COMANDOS

        public ICommand Volver => new Command(async () => await VolverAtras());
        public ICommand EnviarCorreo => new Command(async () => await Enviar_Correo());
        //public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
