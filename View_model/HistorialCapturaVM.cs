using CachaPlagas.Modelos;
using CachaPlagas.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CachaPlagas.View_model
{
    public class HistorialCapturaVM : BaseViewModel
    {
        private string endpoint = "https://cachaplagas.azurewebsites.net";
        #region VARIABLES
        ObservableCollection<CapturaModel> _capturas;
        //string _localizacion;
        //string _animal;
        //string _modelo;
        //string _fechahora;
        #endregion

        #region CONSTRUCTOR
        public HistorialCapturaVM(INavigation navegacion)
        {
            Navigation = navegacion;
            MostrarHistorial();
        }
        #endregion

        #region OBJETOS
        public ObservableCollection<CapturaModel> Capturas 
        {
            get { return _capturas; }
            set
            {
                SetValue(ref _capturas, value);
                OnpropertyChanged();
            }
        }
        //public string Localizacion
        //{
        //    get { return _localizacion; }
        //    set { SetValue(ref _localizacion, value); }
        //}

        //public string Animal
        //{
        //    get { return _animal; }
        //    set { SetValue(ref _animal, value); }
        //}

        //public string Modelo
        //{
        //    get { return _modelo; }
        //    set { SetValue(ref _modelo, value); }
        //}

        //public string FechaHora
        //{
        //    get { return _fechahora; }
        //    set { SetValue(ref _fechahora, value); }
        //}
        #endregion

        #region PROCESOS
        public async Task MostrarHistorial()
        {
         _capturas = new ObservableCollection<CapturaModel>();

            
        }
        public async Task VolverAtras()
        {
            await Navigation.PopAsync();
        }
        public void ProcesoSimple()
        {
        }
        #endregion

        #region COMANDOS

        public ICommand Volver => new Command(async () => await VolverAtras());


        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
