using CachaPlagas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CachaPlagas.View_model
{
    class VerTrampaVM : BaseViewModel
    {
        #region VARIABLES
        string _Email;
        string _Contrasena;
        #endregion

        #region CONSTRUCTOR
        public VerTrampaVM(INavigation navegacion)
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
        public async Task listado()
        {
            await Navigation.PushAsync(new ListadoTrampas());
        }
        
        public void ProcesoSimple()
        {
        }
        #endregion

        #region COMANDOS

        public ICommand Listado => new Command(async () => await listado());
        

        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
