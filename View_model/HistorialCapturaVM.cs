using CachaPlagas.Data.Interfaces;
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
        #region VARIABLES
        private readonly INavigationService _navService;
        ObservableCollection<CapturaModel> _capturas;
        //string _localizacion;
        //string _animal;
        //string _modelo;
        //string _fechahora;
        #endregion

        #region CONSTRUCTOR
        public HistorialCapturaVM(INavigationService navService)
        {
            _navService = navService;
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
            List<CapturaModel> Data = new List<CapturaModel>()
            {
                new CapturaModel { localizacion = "Ubicación 1", fechahora = DateTime.Parse("2024-02-13 10:00"), Animal = "Perro", Modelo = "Modelo A" },
                new CapturaModel { localizacion = "Ubicación 2", fechahora = DateTime.Parse("2024-02-13 11:00"), Animal = "Gato", Modelo = "Modelo B" },
                new CapturaModel { localizacion = "Ubicación 3", fechahora = DateTime.Parse("2024-02-13 12:00"), Animal = "Ave", Modelo = "Modelo C" },
            };

            Capturas = new ObservableCollection<CapturaModel>(Data);
        }
        public async Task VolverAtras()
        {
            await _navService.PopAsync();
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
