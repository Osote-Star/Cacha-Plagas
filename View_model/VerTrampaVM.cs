using CachaPlagas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CachaPlagas.View_model
{
    class VerTrampaVM : BaseViewModel
    {
        #region VARIABLES
        private ImageSource _buttonImage;
        private Color _buttonColor;
        string _Contrasena;
        #endregion

        #region CONSTRUCTOR
        public VerTrampaVM(INavigation navegacion)
        {
            Navigation = navegacion;
        }
        #endregion

        #region OBJETOS
        public ImageSource ButtonImage
        {
            get { return _buttonImage; }
            set { SetValue(ref _buttonImage, value); }
        }
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set { SetValue(ref _buttonColor, value); }
        }
        public string Contrasena
        {
            get { return _Contrasena; }
            set { SetValue(ref _Contrasena, value); }
        }
        #endregion

        #region PROCESOS
        public async Task listado()
        {
            await Navigation.PushAsync(new ListadoTrampas());
        }
        public async Task AlterarPuerta() 
        {
            if (ButtonColor.Equals(Color.FromArgb("#FF5252")))
            {
                ButtonImage = ImageSource.FromFile("opendoor.png");
                ButtonColor = Color.FromArgb("#4CAF50");
            }
            else
            {
                ButtonImage = ImageSource.FromFile("closeddoor.png");
                ButtonColor = Color.FromArgb("#FF5252");
            }
        }
        public void ProcesoSimple()
        {
            if (botonpuerta.ImageSource is FileImageSource fileSource && fileSource.File == "closeddoor.png")
            {
                botonpuerta.ImageSource = ImageSource.FromFile("opendoor.png");
                botonpuerta.BackgroundColor = Color.FromArgb("#4CAF50");
            }
            else
            {
                botonpuerta.ImageSource = ImageSource.FromFile("closeddoor.png");
                botonpuerta.BackgroundColor = Color.FromArgb("#FF5252");
            }
        }
        #endregion

        #region COMANDOS

        public ICommand Listado => new Command(async () => await listado());
        

        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
