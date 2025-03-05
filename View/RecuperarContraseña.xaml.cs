using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class RecuperarContraseña : ContentPage
{
    public RecuperarContraseña()
    {
        InitializeComponent();
        BindingContext = new RecuperarContraseñaVM(Navigation);

    }
}