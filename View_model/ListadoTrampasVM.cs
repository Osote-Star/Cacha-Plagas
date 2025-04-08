using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
using CachaPlagas.Model;
using CachaPlagas.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Events;
using CachaPlagas.DTOs;

namespace CachaPlagas.View_model
{
    public class ListadoTrampasVM : BaseViewModel
    {
        #region VARIABLES
        private readonly TrampaService _trampaService;
        private ObservableCollection<TrampaModel> _trampas;
        private readonly INavigationService _navService;
        private readonly IEventAggregator _eventAggregator;
        #endregion
        
        #region CONSTRUCTOR
        public ListadoTrampasVM(INavigationService navService, TrampaService trampaServices, IEventAggregator eventAggregator)
        {
            _navService = navService;
            _trampaService = trampaServices;
            _eventAggregator = eventAggregator;
            Trampas = new ObservableCollection<TrampaModel>();

            // Suscripción al evento de cambio de estado del sensor
            _eventAggregator.GetEvent<SensorStateChangedEvent>().Subscribe(OnSensorStateChanged);

            // Cargar datos cuando se inicializa
        }
        #endregion

        #region OBJETOS
        public ObservableCollection<TrampaModel> Trampas
        {
            get => _trampas;
            set => SetProperty(ref _trampas, value);
        }
        #endregion

        #region PROCESOS
        private int ObtenerUsuarioID()
        {
            var jwtToken = SecureStorage.GetAsync("jwt_token").Result;
            if (string.IsNullOrEmpty(jwtToken)) return 0;

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var claimUsuarioID = token.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            return claimUsuarioID != null ? int.Parse(claimUsuarioID.Value) : 0;
        }
        public override async Task OnNavigatedTo()
        {
            await CargarTrampas(); // Llamar aquí y esperar
        }

        public async Task CargarTrampas()
          {
            int usuarioID = ObtenerUsuarioID(); // Método para obtener el ID del usuario
            var trampas = await _trampaService.GetTrampas(usuarioID); // Obtener todas las trampas

            if (trampas != null && trampas.Any()) // Verifica que haya trampas
            {
                Trampas.Clear();
                foreach (var trampa in trampas)
                {
                    // Solo asignamos los tres valores necesarios
                    Trampas.Add(new TrampaModel
                    {
                        IdTrampa = trampa.IdTrampa,
                        Modelo = trampa.Modelo,
                        Imagen = trampa.Imagen,
                        EstatusSensor = trampa.EstatusSensor,
                    });
                }
                OnPropertyChanged(nameof(Trampas));
            }
        }

        private void OnSensorStateChanged(SensorStateChangedEvent eventData)
        {
            // Lógica para actualizar la lista de trampas
            var trampa = Trampas.FirstOrDefault(t => t.Modelo == eventData.Modelo);
            if (trampa != null)
            {
                trampa.EstatusSensor = eventData.EstatusSensor;
                OnPropertyChanged(nameof(Trampas));  // Notifica que la colección ha cambiado
            }
        }
         
        public async Task agregar()
        {
            await _navService.PushAsync<AgregarTrampaVM>();
        }

        public async Task logout()
        {
            await _navService.PopAsync();
        }

        public async Task trampaViajar(TrampaModel trampa)
        {
            int idTrampa = trampa.IdTrampa;
            // Usa el método PushAsyncWithParameter para pasar la trampa
            await _navService.PushAsyncWithParameter<VerTrampaVM>("TrampaSeleccionada", trampa);
        }

        public async Task Ir_A_HistorialCapturas()
        {
            await _navService.PushAsync<HistorialCapturaVM>();
        }

        public void ProcesoSimple() { }
        #endregion

        #region COMANDOS
        public ICommand Agregar => new Command(async () => await agregar());
        public ICommand Logout => new Command(async () => await logout());
        public ICommand Trampa => new Command<TrampaModel>(async (trampa) => await trampaViajar(trampa));
        public ICommand IrAHistorialCapturas => new Command(async () => await Ir_A_HistorialCapturas());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);

        #endregion
    }
}
