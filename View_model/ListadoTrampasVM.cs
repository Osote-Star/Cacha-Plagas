using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
using CachaPlagas.Model;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CachaPlagas.View_model
{
    public class ListadoTrampasVM : BaseViewModel
    {
        #region VARIABLES
        private readonly TrampaService _trampaService;
        private ObservableCollection<TrampaModel> _trampas;
        private readonly INavigationService _navService;

        #endregion

        #region CONSTRUCTOR
        public ListadoTrampasVM(INavigationService navService, TrampaService trampaServices)
        {
            _navService = navService;
            _trampaService = trampaServices;
            Trampas = new ObservableCollection<TrampaModel>();

            // Cargar datos automáticamente al iniciar
            _ = CargarTrampas(); // Reemplaza con el ID del usuario
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
        private async Task CargarTrampas()
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
                        Modelo = trampa.Modelo,
                        Imagen = trampa.Imagen,
                        EstatusSensor = trampa.EstatusSensor
                    });
                }
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
        public async Task trampa()
        {
            await _navService.PushAsync<VerTrampaVM>();
        }
        public async Task Ir_A_HistorialCapturas()
        {
            await _navService.PushAsync<HistorialCapturaVM>();
        }
        public void ProcesoSimple()
        {
        }
        #endregion

        #region COMANDOS

        public ICommand Agregar => new Command(async () => await agregar());
        public ICommand Logout => new Command(async () => await logout());
        public ICommand Trampa => new Command(async () => await trampa());
        public ICommand IrAHistorialCapturas => new Command(async () => await Ir_A_HistorialCapturas());


        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
