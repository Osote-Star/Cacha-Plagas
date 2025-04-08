using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
using CachaPlagas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Events;
using CachaPlagas.DTOs;
using CachaPlagas.Model;


namespace CachaPlagas.View_model
{
    public class VerTrampaVM : BaseViewModel
    {
        #region VARIABLES
        private TrampaModel _trampaSeleccionada; // Campo privado para backing store
        private ImageSource _buttonImageDoor;
        private Color _buttonColorDoor;
        private ImageSource _buttonImageSensor;
        private Color _buttonColorSensor;
        string _Contrasena;
        private AuthServices _services;
        private INavigationService _navService;
        private readonly IEventAggregator _eventAggregator;
        private readonly ListadoTrampasVM _listadoTrampasVM;
        private TrampaService _trampaService;

        private bool _estatusSensor;
        #endregion

        #region CONSTRUCTOR
        public VerTrampaVM(INavigationService navigationService, IEventAggregator eventAggregator, ListadoTrampasVM listadoTrampasVM, TrampaService trampaService)
        {
            _services = null;
            _navService = navigationService;       
            ButtonImageDoor = ImageSource.FromFile("opendoor.png");
            ButtonColorDoor = Color.FromArgb("#4CAF50");
            ButtonImageSensor = ImageSource.FromFile("onsensor.png");
            ButtonColorSensor = Color.FromArgb("#4CAF50");
            _trampaService = trampaService;

            _eventAggregator = eventAggregator;
            _estatusSensor = true;
            _listadoTrampasVM = listadoTrampasVM;

        }
        #endregion

        #region OBJETOS
        public TrampaModel TrampaSeleccionada
        {
            get => _trampaSeleccionada;
            set => SetProperty(ref _trampaSeleccionada, value);
        }

        public ImageSource ButtonImageDoor
        {
            get => _buttonImageDoor;
            set => SetProperty(ref _buttonImageDoor, value);
        }

        public Color ButtonColorDoor
        {
            get => _buttonColorDoor;
            set => SetProperty(ref _buttonColorDoor, value);
        }

        public ImageSource ButtonImageSensor
        {
            get => _buttonImageSensor;
            set => SetProperty(ref _buttonImageSensor, value);
        }

        public Color ButtonColorSensor
        {
            get => _buttonColorSensor;
            set => SetProperty(ref _buttonColorSensor, value);
        }

        public string Contrasena
        {
            get => _Contrasena;
            set => SetProperty(ref _Contrasena, value);
        }
        #endregion

        #region PROCESOS
        public override Task OnNavigatingTo(IDictionary<string, object>? parameters)
        {
            if (parameters != null && parameters.TryGetValue("TrampaSeleccionada", out var trampa))
            {
                TrampaSeleccionada = trampa as TrampaModel;
            }
            return Task.CompletedTask;
        }

        public async Task listado()
        {
            await _navService.PopAsync();
        }
        public async Task AlterarPuerta() 
        {
            var trampa = await _trampaService.GetEstatusPuerta(TrampaSeleccionada.IdTrampa);
            if (trampa == null)
            {
                await DisplayAlert("Error", "No se pudo obtener el estado de la puerta.", "OK");
                return;
            }
           
            var parametros = new EstatusPuertaDto
            {
                IDtrampa = TrampaSeleccionada.IdTrampa,
                estatusPuerta = !trampa.EstatusPuerta
            };

            await _trampaService.CambiarStatusPuerta(parametros);

            if (trampa.EstatusPuerta)
            {
                ButtonImageDoor = ImageSource.FromFile("opendoor.png");
                ButtonColorDoor = Color.FromArgb("#4CAF50");
            }
            else
            {
                ButtonImageDoor = ImageSource.FromFile("closeddoor.png");
                ButtonColorDoor = Color.FromArgb("#FF5252");
            }
        }

        public async Task AlterarSensor()
        {
            var trampa = await _trampaService.GetEstatusSensor(TrampaSeleccionada.IdTrampa);
            if (trampa == null)
            {
                await DisplayAlert("Error", "No se pudo obtener el estado del sensor.", "OK");
                return;
            }

            var parametros = new EstatusSensorDto
            {
                IDtrampa = TrampaSeleccionada.IdTrampa,
                estatusSensor = !trampa.EstatusSensor
            };

            await _trampaService.CambiarStatusSensor(parametros);

            if (trampa.EstatusSensor)
            {
                ButtonImageDoor = ImageSource.FromFile("onsensor.png");
                ButtonColorDoor = Color.FromArgb("#4CAF50");
            }
            else
            {
                ButtonImageDoor = ImageSource.FromFile("offsensor.png");
                ButtonColorDoor = Color.FromArgb("#FF5252");
            }
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS

        public ICommand EstadoPuerta => new Command(async () => await AlterarPuerta());
        public ICommand EstadoSensor => new Command(async () => await AlterarSensor());
        public ICommand Listado => new Command(async () => await listado());
        

        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
