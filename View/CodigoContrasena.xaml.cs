using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class CodigoContrasena : ContentPage
{
	public CodigoContrasena()
	{
		InitializeComponent();
        BindingContext = new CodigoContrasenaVM(Navigation);
    }

    public void OnCodeTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry != null && !string.IsNullOrEmpty(entry.Text) && entry.Text.Length == 1)
        {
            switch (entry)
            {
                case var _ when entry == Code1:
                    Code2.Focus();
                    break;
                case var _ when entry == Code2:
                    Code3.Focus();
                    break;
                case var _ when entry == Code3:
                    Code4.Focus();
                    break;
                case var _ when entry == Code4:
                    Code5.Focus();
                    break;
                case var _ when entry == Code5:
                    Code6.Focus();
                    break;
                case var _ when entry == Code6:
                    // Opcional: Ejecutar verificación al completar el último cuadro
                    if (BindingContext is CachaPlagas.View_model.CodigoContrasenaVM vm)
                    {
                        vm.IrACambiarContrasena.Execute(null);
                    }
                    break;
            }
        }
    }
}