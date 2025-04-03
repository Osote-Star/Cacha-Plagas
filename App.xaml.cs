using CachaPlagas.View;

namespace CachaPlagas
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            // Obtiene la página desde el contenedor DI
            var loginPage = serviceProvider.GetRequiredService<Login>();

            // Configura la MainPage con NavigationPage
            MainPage = new NavigationPage(loginPage);
        }
    }
}
