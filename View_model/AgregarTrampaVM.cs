using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
using CachaPlagas.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

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
        private AgregrarTrampaVM _services;
        private readonly INavigationService _navService;
        #endregion

        #region CONSTRUCTOR
        public AgregarTrampaVM(INavigationService navService, AgregrarTrampaVM services)
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
        public async Task ValidarTrampa()
        {
            if (string.IsNullOrWhiteSpace(Codigo))
            {
                await DisplayAlert("Error", "Por favor, ingrese un ID válido.", "OK");
                return;
            }

            if (!int.TryParse(Codigo, out int trampaId))
            {
                await DisplayAlert("Error", "El ID debe ser un número válido.", "OK");
                return;
            }

            try
            {
                // Call your API endpoint with the parsed integer ID
                TrampaModel? trampa = await _services.GetOneTrampa(trampaId);

                if (trampa is not null)
                {
                    // Log the raw JSON for debugging
                    await DisplayAlert("Respuesta del servidor", trampa.ToString(), "OK");

                   
                    // Debug the deserialized object
                    await DisplayAlert("Debug", $"ID: {trampa.IdTrampa}, Modelo: {trampa.Modelo}, Imagen: {trampa.Imagen}", "OK");

                    // Update UI with trap data
                    Id = $"ID: {trampa.IdTrampa}";
                    Modelo = $"MODELO: {trampa.Modelo}";
                    // Construct the full image URL (adjust the base URL as needed)
                    string imageBaseUrl = "https://6tcsdl1g-5086.usw3.devtunnels.ms/images/";
                    string imageUrl = $"{imageBaseUrl}{trampa.Imagen}";
                    try
                    {
                        Imagen = ImageSource.FromUri(new Uri(imageUrl));
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error", $"No se pudo cargar la imagen: {ex.Message}", "OK");
                        Imagen = null; // Fallback to no image
                    }

                    FrameVisible = true; // Show the popup with trap info
                    
                }
                else if (trampa is null)
                {
                    await DisplayAlert("Error", "No se encontró la trampa.", "OK");
                    FrameVisible = false;
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
                FrameVisible = false;
            }
        }

        public async Task VolverAtras()
        {
            await _navService.PopAsync();
        }
        #endregion

        #region COMANDOS
        public ICommand Validar => new Command(async () => await ValidarTrampa());
        public ICommand Volver => new Command(async () => await VolverAtras());
        #endregion
    }
}