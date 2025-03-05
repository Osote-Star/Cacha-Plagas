using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class ListadoTrampas : ContentPage
{
	public ListadoTrampas()
	{
		InitializeComponent();

        BindingContext = new ListadoTrampasVM(Navigation);
    }
}