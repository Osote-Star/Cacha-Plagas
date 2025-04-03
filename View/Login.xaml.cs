using CachaPlagas.Data.Services;
using CachaPlagas.View_model;
namespace CachaPlagas.View;

public partial class Login : ContentPage
{ 
        public Login(LoginVM viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
   
}