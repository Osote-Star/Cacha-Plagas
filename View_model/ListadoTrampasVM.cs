using CachaPlagas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CachaPlagas.View_model
{
    class ListadoTrampasVM : BaseViewModel
    {
        #region VARIABLES
        string _Email;
        string _Contrasena;
        #endregion

        #region CONSTRUCTOR
        public ListadoTrampasVM(INavigation navegacion)
        {
            Navigation = navegacion;
        }
        #endregion

        #region OBJETOS
        public string algo
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
        public async Task agregar()
        {
            await Navigation.PushAsync(new AgregarTrampa());
        }
        public async Task logout()
        {
            await Navigation.PushAsync(new Login());
        }
        public async Task trampa()
        {
            await Navigation.PushAsync(new VerTrampa());
        }
        public void ProcesoSimple()
        {
        }
        #endregion

        #region COMANDOS

        public ICommand Agregar => new Command(async () => await agregar());
        public ICommand Logout => new Command(async () => await logout());
        public ICommand Trampa => new Command(async () => await trampa());

        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
