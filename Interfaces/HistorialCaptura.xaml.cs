using CachaPlagas.Modelos;

namespace CachaPlagas.Interfaces;

public partial class HistorialCaptura : ContentPage
{
    public List<CapturaModel> Data { get; set; }

    public HistorialCaptura()
	{
		InitializeComponent();


        Data = new List<CapturaModel>()
        {
            new CapturaModel { localizacion = "Ubicación 1", fechahora = DateTime.Parse("2024-02-13 10:00"), Animal = "Perro", Modelo = "Modelo A" },
            new CapturaModel { localizacion = "Ubicación 2", fechahora = DateTime.Parse("2024-02-13 11:00"), Animal = "Gato", Modelo = "Modelo B" },
            new CapturaModel { localizacion = "Ubicación 3", fechahora = DateTime.Parse("2024-02-13 12:00"), Animal = "Ave", Modelo = "Modelo C" },
        };

        coleccioncita.ItemsSource = Data;

    }
}