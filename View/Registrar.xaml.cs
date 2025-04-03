using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class Registrar : ContentPage
{
	public Registrar(RegistrarVM viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}