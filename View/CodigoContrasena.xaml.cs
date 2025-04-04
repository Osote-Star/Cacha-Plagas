using CachaPlagas.View_model;

namespace CachaPlagas.View;

public partial class CodigoContrasena : ContentPage
{
    private CodigoContrasenaVM ViewModel => (CodigoContrasenaVM)BindingContext;

    public CodigoContrasena(CodigoContrasenaVM viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCodeTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            string newText = e.NewTextValue;
            if (!string.IsNullOrEmpty(newText) && newText.Length == 1)
            {
                // Encuentra el siguiente Entry
                var entries = new[] { Code1, Code2, Code3, Code4, Code5, Code6 };
                int currentIndex = Array.IndexOf(entries, entry);

                if (currentIndex < entries.Length - 1)
                {
                    entries[currentIndex + 1].Focus();
                }

                // Construye el código completo
                string code = string.Concat(entries.Select(e => e.Text));
                ViewModel.Codigo = code;
            }
        }
    }
}