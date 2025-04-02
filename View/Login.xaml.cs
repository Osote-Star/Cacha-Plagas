using CachaPlagas.View_model;
namespace CachaPlagas.View;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
        BindingContext = new LoginVM(Navigation, new AuthService(new HttpClient()));

    }
}