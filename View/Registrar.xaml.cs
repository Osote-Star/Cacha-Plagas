using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class Registrar : ContentPage
{
	public Registrar()
	{
		InitializeComponent();
        BindingContext = new RegistrarVM(Navigation);
    }
}