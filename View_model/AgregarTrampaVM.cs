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
        private readonly HttpClient _httpClient;
        #endregion

        #region CONSTRUCTOR
        public AgregarTrampaVM(INavigation navegacion)
        {
            Navigation = navegacion;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://6tcsdl1g-5086.usw3.devtunnels.ms/");

            // Add authentication token
            string authToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjciLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJwcnVlYmEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJ1c3VhcmlvIiwiZXhwIjoxNzQzNzAwMDQ0fQ.7NlM_cE6fLdan95l2Zne_3hGNk2uUohpStddMnBtRBA";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
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
                var response = await _httpClient.GetAsync($"api/Trampa/Buscar-trampa/{trampaId}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    // Log the raw JSON for debugging
                    await DisplayAlert("Respuesta del servidor", jsonString, "OK");

                    var trampa = JsonSerializer.Deserialize<TrampaModel>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Handle case differences if needed
                    });

                    if (trampa != null)
                    {
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
                    else
                    {
                        await DisplayAlert("Error", "No se encontró la trampa.", "OK");
                        FrameVisible = false;
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await DisplayAlert("Error", "No se encontró la trampa con ese ID.", "OK");
                    FrameVisible = false;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await DisplayAlert("Error", "No autorizado. Verifique su token.", "OK");
                    FrameVisible = false;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Error del servidor", $"Código: {response.StatusCode}\nContenido: {errorContent}", "OK");
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
            await Navigation.PopAsync();
        }
        #endregion

        #region COMANDOS
        public ICommand Validar => new Command(async () => await ValidarTrampa());
        public ICommand Volver => new Command(async () => await VolverAtras());
        #endregion
    }
}