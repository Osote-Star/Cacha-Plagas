using CachaPlagas.Data.Services;
using CachaPlagas.Model;
using CachaPlagas.View_model;
using System.Security.Cryptography.X509Certificates;

namespace CachaPlagas.View;

public partial class AgregarTrampa : ContentPage
{
    public AgregarTrampa(AgregrarTrampaVM viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

    }

    ////private void OnBackClicked(object sender, EventArgs e)
    ////{
    ////    Navigation.PopAsync(); // Regresa a la pantalla anterior
    ////}

    //private void OnValidarClicked(object sender, EventArgs e)
    //{
    //    string codigoIngresado = codigoEntry.Text;

    //    // Simulación de base de datos con códigos válidos
    //    var trampas = new Dictionary<string, TrampaModel>
    //        {
    //            { "1234", new TrampaModel { Modelo = "3316", Estado = "Trampita UTS", Imagen = "https://i.ibb.co/rXny5kt/Trampa-removebg-preview.png" } }
    //        };

    //    if (trampas.ContainsKey(codigoIngresado))
    //    {
    //        var trampa = trampas[codigoIngresado];

    //        // Actualizar las etiquetas e imagen con la información de la trampa
    //        modeloLabel.Text = $"ID: {trampa.Modelo}";
    //        estadoLabel.Text = $"MODELO: {trampa.Estado}";
    //        imagenTrampa.Source = trampa.Imagen;

    //        // Mostrar el popup con la información de la trampa
    //        popupFrame.IsVisible = true;
    //    }
    //    else
    //    {
    //        DisplayAlert("Error", "Código no válido", "OK");
    //        popupFrame.IsVisible = false; // Ocultar el popup si el código no es válido
    //    }
    //}

    //private void OnAgregarClicked(object sender, EventArgs e)
    //{
    //    DisplayAlert("Éxito", "Trampa agregada correctamente", "OK");
    //    popupFrame.IsVisible = false; // Ocultar el popup después de agregar
    //}

}