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
using CachaPlagas.DTOs;


namespace CachaPlagas.View_model
{
    public class ListadoTrampasVM : BaseViewModel
    {
        #region VARIABLES
        private readonly TrampaService _trampaService;
        private ObservableCollection<TrampaModel> _trampas;
        private readonly INavigationService _navService;
        private readonly SignalRService _signalRService;

        #endregion

        #region CONSTRUCTOR
        public ListadoTrampasVM(INavigationService navService, TrampaService trampaServices, SignalRService signalRService)
        {
            _navService = navService;
            _trampaService = trampaServices;


            Trampas = new ObservableCollection<TrampaModel>();

            // Cargar datos cuando se inicializa
            _signalRService = signalRService;

            _ = InicializarAsync();

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

        private async Task InicializarAsync()
        {
            await CargarTrampas();
            await ConectarSignalR();
        }
        private async Task<int> ObtenerUsuarioIDAsync()
        {
            var jwtToken = await SecureStorage.GetAsync("jwt_token");
            if (string.IsNullOrEmpty(jwtToken)) return 0;

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var claimUsuarioID = token.Claims.FirstOrDefault(c =>
                c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            return claimUsuarioID != null ? int.Parse(claimUsuarioID.Value) : 0;
        }

        private async Task ConectarSignalR()
        {
            await _signalRService.ConectarAsync();

            int usuarioID = await ObtenerUsuarioIDAsync();

            _signalRService.OnTrampasActualizadas += async (idUsuario) =>
            {
                if (idUsuario == usuarioID)
                {
                    await CargarTrampas();
                }
            };
        }

        public async Task CargarTrampas()
        {
            int usuarioID = await ObtenerUsuarioIDAsync();
            var trampas = await _trampaService.GetTrampas(usuarioID);

            Trampas.Clear();

            if (trampas != null && trampas.Any())
            {
                foreach (var trampa in trampas)
                {
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
