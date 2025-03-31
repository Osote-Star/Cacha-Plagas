using CachaPlagas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CachaPlagas.View_model
{
    public class CodigoContrasenaVM : BaseViewModel
    {
        #region VARIABLES
        private string[] _codigo = new string[6];
        #endregion

        #region CONSTRUCTOR
        public CodigoContrasenaVM(INavigation navegacion)
        {
            Navigation = navegacion;
        }
        #endregion

        #region OBJETOS
        public string[] Codigo
        {
            get => _codigo;
            set
            {
                SetValue(ref _codigo, value);
                OnPropertyChanged(nameof(Codigo));
            }
        }
        #endregion

        #region PROCESOS
        public async Task Ir_A_CambiarContrasena()
        {
            string codigoConcatenado = string.Join("", Codigo);

            if (string.IsNullOrEmpty(codigoConcatenado) || codigoConcatenado.Length != 6)
            {
                await DisplayAlert("Error", "Ingresa un código completo de 6 dígitos", "Aceptar");
                return;
            }

            if (codigoConcatenado == "123456")
            {
                await DisplayAlert("Todo bien", "Ahora podrá cambiar su contraseña", "Aceptar");
                await Navigation.PushAsync(new CambiarContrasena());
            }
            else
            {
                await DisplayAlert("Error", "Código inexistente", "Aceptar");
            }
        }

        public void ProcesoSimple()
        {
            // Método opcional, mantenido por si lo necesitas
        }
        #endregion

        #region COMANDOS
        public ICommand IrACambiarContrasena => new Command(async () => await Ir_A_CambiarContrasena());

        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
