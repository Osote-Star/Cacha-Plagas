using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
using CachaPlagas.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IdentityModel.Tokens.Jwt; // Para JwtSecurityTokenHandler
using Microsoft.Maui.Storage; // Para SecureStorage

namespace CachaPlagas.View_model
{
    public class AgregarTrampaVM : BaseViewModel
    {
        #region VARIABLES
        private string _id;
        private string _modelo;
        private ImageSource _imagen;
        private string _codigo;
        private bool _frameVisible;
        private int _trampaId; // ID de la trampa encontrada
        private readonly TrampaService _services;
        private readonly INavigationService _navService;
        #endregion

        #region CONSTRUCTOR
        public AgregarTrampaVM(INavigationService navService, TrampaService services)
        {
            _navService = navService;
            _services = services;
        }
        #endregion

        #region OBJETOS
        public string Codigo
        {
            get => _codigo;
            set => SetValue(ref _codigo, value);
        }

        public string Id
        {
            get => _id;
            set => SetValue(ref _id, value);
        }

        public string Modelo
        {
            get => _modelo;
            set => SetValue(ref _modelo, value);
        }

        public ImageSource Imagen
        {
            get => _imagen;
            set => SetValue(ref _imagen, value);
        }

        public bool FrameVisible
        {
            get => _frameVisible;
            set => SetValue(ref _frameVisible, value);
        }
        #endregion

        #region PROCESOS
        public async Task BuscarTrampa()
        {
            if (string.IsNullOrWhiteSpace(Codigo))
            {
                await DisplayAlert("Error", "Por favor, ingrese un codigo válido.", "OK");
                return;
            }

            if (!int.TryParse(Codigo, out int trampaId))
            {
                await DisplayAlert("Error", "El codigo debe ser un número válido.", "OK");
                return;
            }

            try
            {
                TrampaModel? trampa = await _services.GetOneTrampa(trampaId);

                if (trampa != null)
                {
                    _trampaId = trampaId; // Guardar el ID de la trampa encontrada
                    Id = $"ID: {trampa.IdTrampa}";
                    Modelo = $"MODELO: {trampa.Modelo}";
                    string imageBaseUrl = "https://szd264mf-5086.usw3.devtunnels.ms/images/";
                    string imageFileName = trampa.Imagen; // Should be "trampa.png"
                    try
                    {
                        Imagen = ImageSource.FromFile(imageFileName); // Load the local image
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error", $"No se pudo cargar la imagen: {ex.Message}", "OK");
                        Imagen = null;
                    }

                    FrameVisible = true; // Mostrar el popup con la información
                }
                else
                {
                    await DisplayAlert("Error", "No se encontró la trampa con ese codigo o ya está vinculada.", "OK");
                    FrameVisible = false;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al buscar la trampa: {ex.Message}", "OK");
                FrameVisible = false;
            }
        }

        public async Task AgregarTrampa()
        {
            if (_trampaId == 0) // Verificar que haya una trampa válida seleccionada
            {
                await DisplayAlert("Error", "Primero debe buscar una trampa válida.", "OK");
                return;
            }

            try
            {
                int usuarioId = await ObtenerUsuarioID(); // Obtener el ID del usuario autenticado
                if (usuarioId == 0)
                {
                    await DisplayAlert("Error", "No se pudo obtener el ID del usuario. Por favor, inicie sesión nuevamente.", "OK");
                    return;
                }

                // Vincular la trampa al usuario
                TrampaModel? trampaVinculada = await _services.VincularTrampa(_trampaId, usuarioId);

                if (trampaVinculada != null)
                {
                    await DisplayAlert("Éxito", $"Trampa agregada con exito", "OK");
                    FrameVisible = false; // Ocultar el popup
                    Codigo = string.Empty; // Limpiar el campo de entrada
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo vincular la trampa.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al vincular la trampa: {ex.Message}", "OK");
            }
        }

        public async Task VolverAtras()
        {
            await _navService.PopAsync();
        }

        private async Task<int> ObtenerUsuarioID()
        {
            try
            {
                var jwtToken = await SecureStorage.GetAsync("jwt_token");
                if (string.IsNullOrEmpty(jwtToken)) return 0;

                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwtToken);

                var claimUsuarioID = token.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

                return claimUsuarioID != null ? int.Parse(claimUsuarioID.Value) : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el ID del usuario: {ex.Message}");
                return 0;
            }
        }
        #endregion

        #region COMANDOS
        public ICommand Validar => new Command(async () => await BuscarTrampa());
        public ICommand AgregarCommand => new Command(async () => await AgregarTrampa());
        public ICommand Volver => new Command(async () => await VolverAtras());
        #endregion
    }
}