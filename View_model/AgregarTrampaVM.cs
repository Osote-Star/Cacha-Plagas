using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
using CachaPlagas.Model;
using System;
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
                TrampaModel? trampa = await _services.GetOneTrampa(trampaId);

                if (trampa != null)
                {
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
                    await DisplayAlert("Error", "No se encontró la trampa con ese ID.", "OK");
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
            // Por ahora, no hace nada
            // Puedes dejarlo vacío o agregar un mensaje temporal si quieres
            await Task.CompletedTask; // Para cumplir con la firma async
        }

        public async Task VolverAtras()
        {
            await _navService.PopAsync();
        }
        #endregion

        #region COMANDOS
        public ICommand Validar => new Command(async () => await ValidarTrampa());
        public ICommand AgregarCommand => new Command(async () => await AgregarTrampa());
        public ICommand Volver => new Command(async () => await VolverAtras());
        #endregion
    }
}