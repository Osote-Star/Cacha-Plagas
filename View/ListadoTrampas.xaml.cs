using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class ListadoTrampas : ContentPage
{
	public ListadoTrampas(ListadoTrampasVM viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}