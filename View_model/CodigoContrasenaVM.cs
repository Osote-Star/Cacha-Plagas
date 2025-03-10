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
            get { return _codigo; }
            set { SetValue(ref _codigo, value);
                OnPropertyChanged();
            }
        }
       
        #endregion

        #region PROCESOS
        public async Task Ir_A_CambiarContrasena()
        {
            string codigoConcatenado = string.Join("", Codigo);

            if (codigoConcatenado == "123456")
            {
                await this.DisplayAlert("Todo bien", "Ahora podra cambiar su contrasena", "Aceptar");
                await Navigation.PushAsync(new CambiarContrasena());
            }
            else
                await this.DisplayAlert("Error", "Codigo Inexistente", "Aceptar");
        }

        public void ProcesoSimple()
        {
        }
        #endregion

        #region COMANDOS

        public ICommand IrACambiarContrasena => new Command(async () => await Ir_A_CambiarContrasena());


        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
