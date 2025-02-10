using CachaPlagas.Modelos;

namespace CachaPlagas.InterfacesLogin;

public partial class VerTrampa : ContentPage
{
    public List<CapturaModel> Data { get; set; }

    public VerTrampa()
    {
        InitializeComponent();

        Data = new List<CapturaModel>()
        {
            new CapturaModel { hora = "David", cantidad = 170 },
            new CapturaModel { hora = "Michael", cantidad = 96 },
            new CapturaModel { hora = "Steve", cantidad = 65 },
            new CapturaModel { hora = "Joel", cantidad = 182 },
            new CapturaModel { hora = "Bob", cantidad = 134 }
        };

        datitos.ItemsSource = Data;

    }


    private void accionarpuerta(object sender, EventArgs e)
    {


        if (botonpuerta.ImageSource is FileImageSource fileSource && fileSource.File == "closeddoor.png")
        {
            botonpuerta.ImageSource = ImageSource.FromFile("opendoor.png");
            botonpuerta.BackgroundColor = Color.FromArgb("#4CAF50");
        }
        else
        {
            botonpuerta.ImageSource = ImageSource.FromFile("closeddoor.png");
            botonpuerta.BackgroundColor = Color.FromArgb("#FF5252");
        }

    }

    private void accionarsensor(object sender, EventArgs e)
    {
        
        if (botonsensor.ImageSource is FileImageSource fileSource && fileSource.File == "offsensor.png")
        {
            botonsensor.ImageSource = ImageSource.FromFile("onsensor.png");
            botonsensor.BackgroundColor = Color.FromArgb("#4CAF50"); // Verde cuando está activo
        }
        else
        {
            botonsensor.ImageSource = ImageSource.FromFile("offsensor.png");
            botonsensor.BackgroundColor = Color.FromArgb("#FF5252"); // Rojo cuando está apagado
        }

    }
}