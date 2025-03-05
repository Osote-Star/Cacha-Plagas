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

        // Simulaci�n de base de datos con c�digos v�lidos
        var trampas = new Dictionary<string, (string Modelo, string Estado, string Imagen)>
            {
                { "1234", ("3316", "Trampita UTS", "https://i.postimg.cc/K816Cnkt/Adobe-Express-file.png") },
                { "5678", ("Trampa Y2", "Inactiva", "trampa_y2.png") }
            };

        if (trampas.ContainsKey(codigoIngresado))
        {
            var trampa = trampas[codigoIngresado];

            // Actualizar las etiquetas e imagen con la informaci�n de la trampa
            modeloLabel.Text = $"ID: {trampa.Modelo}";
            estadoLabel.Text = $"MODELO: {trampa.Estado}";
            imagenTrampa.Source = trampa.Imagen;

            // Mostrar el popup con la informaci�n de la trampa
            popupFrame.IsVisible = true;
        }
        else
        {
            DisplayAlert("Error", "C�digo no v�lido", "OK");
            popupFrame.IsVisible = false; // Ocultar el popup si el c�digo no es v�lido
        }
    }

    private void OnAgregarClicked(object sender, EventArgs e)
    {
        DisplayAlert("�xito", "Trampa agregada correctamente", "OK");
        popupFrame.IsVisible = false; // Ocultar el popup despu�s de agregar
    }

}