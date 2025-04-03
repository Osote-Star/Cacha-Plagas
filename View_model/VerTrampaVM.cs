using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
using CachaPlagas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CachaPlagas.View_model
{
    public class VerTrampaVM : BaseViewModel
    {
        #region VARIABLES
        private ImageSource _buttonImageDoor;
        private Color _buttonColorDoor;
        private ImageSource _buttonImageSensor;
        private Color _buttonColorSensor;
        string _Contrasena;
        private AuthServices _services;
        private INavigationService _navService;
        #endregion

        #region CONSTRUCTOR
        public VerTrampaVM(INavigationService navigationService)
        {
            _services = null;
            _navService = navigationService;       
            ButtonImageDoor = ImageSource.FromFile("opendoor.png");
            ButtonColorDoor = Color.FromArgb("#4CAF50");
            ButtonImageSensor = ImageSource.FromFile("onsensor.png");
            ButtonColorSensor = Color.FromArgb("#4CAF50");

        }
        #endregion

        #region OBJETOS
        public ImageSource ButtonImageDoor
        {
            get { return _buttonImageDoor; }
            set { SetValue(ref _buttonImageDoor, value); }
        }
        public Color ButtonColorDoor
        {
            get { return _buttonColorDoor; }
            set { SetValue(ref _buttonColorDoor, value); }
        }
        public ImageSource ButtonImageSensor
        {
            get { return _buttonImageSensor; }
            set { SetValue(ref _buttonImageSensor, value); }
        }
        public Color ButtonColorSensor
        {
            get { return _buttonColorSensor; }
            set { SetValue(ref _buttonColorSensor, value); }
        }
        public string Contrasena
        {
            get { return _Contrasena; }
            set { SetValue(ref _Contrasena, value); }
        }
        #endregion

        #region PROCESOS
        public override async Task OnNavigatingTo(IDictionary<string, object> parameters)
        {
            await base.OnNavigatingTo(parameters);

            if (parameters != null && parameters.TryGetValue("Email", out var email))
            {
                //Email = email?.ToString() ?? string.Empty;

                // Opcional: Mostrar en consola para debug
              //  Console.WriteLine($"Email recibido: {Email}");
            }
        }
        public async Task listado()
        {
            await _navService.PopAsync();
        }
        public async Task AlterarPuerta() 
        {
            if (ButtonColorDoor.Equals(Color.FromArgb("#FF5252")))
            {
                ButtonImageDoor = ImageSource.FromFile("opendoor.png");
                ButtonColorDoor = Color.FromArgb("#4CAF50");
            }
            else
            {
                ButtonImageDoor = ImageSource.FromFile("closeddoor.png");
                ButtonColorDoor = Color.FromArgb("#FF5252");
            }
        }

        public async Task AlterarSensor()
        {
            if (ButtonColorSensor.Equals(Color.FromArgb("#FF5252")))
            {
                ButtonImageSensor = ImageSource.FromFile("onsensor.png");
                ButtonColorSensor = Color.FromArgb("#4CAF50");
            }
            else
            {
                ButtonImageSensor = ImageSource.FromFile("offsensor.png");
                ButtonColorSensor = Color.FromArgb("#FF5252");
            }
        }
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS

        public ICommand EstadoPuerta => new Command(async () => await AlterarPuerta());
        public ICommand EstadoSensor => new Command(async () => await AlterarSensor());
        public ICommand Listado => new Command(async () => await listado());
        

        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
