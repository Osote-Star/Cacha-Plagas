namespace CachaPlagas.View;

public partial class AgregarTrampa : ContentPage
{
    public AgregarTrampa()
    {
        InitializeComponent();
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync(); // Regresa a la pantalla anterior
    }

    private void OnValidarClicked(object sender, EventArgs e)
    {
        string codigoIngresado = codigoEntry.Text;

        // Simulación de base de datos con códigos válidos
        var trampas = new Dictionary<string, (string Modelo, string Estado, string Imagen)>
            {
                { "1234", ("3316", "Trampita UTS", "https://i.postimg.cc/K816Cnkt/Adobe-Express-file.png") },
                { "5678", ("Trampa Y2", "Inactiva", "trampa_y2.png") }
            };

        if (trampas.ContainsKey(codigoIngresado))
        {
            var trampa = trampas[codigoIngresado];

            // Actualizar las etiquetas e imagen con la información de la trampa
            modeloLabel.Text = $"ID: {trampa.Modelo}";
            estadoLabel.Text = $"MODELO: {trampa.Estado}";
            imagenTrampa.Source = trampa.Imagen;

            // Mostrar el popup con la información de la trampa
            popupFrame.IsVisible = true;
        }
        else
        {
            DisplayAlert("Error", "Código no válido", "OK");
            popupFrame.IsVisible = false; // Ocultar el popup si el código no es válido
        }
    }

    private void OnAgregarClicked(object sender, EventArgs e)
    {
        DisplayAlert("Éxito", "Trampa agregada correctamente", "OK");
        popupFrame.IsVisible = false; // Ocultar el popup después de agregar
    }

}