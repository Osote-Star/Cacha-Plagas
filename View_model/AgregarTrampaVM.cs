using CachaPlagas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CachaPlagas.View_model
{
    public class AgregarTrampaVM : BaseViewModel
    {
        #region VARIABLES
        string _id;
        string _modelo;
        ImageSource _imagen;
        string _codigo;
        bool _frameVisible;
        #endregion

        #region CONSTRUCTOR
        public AgregarTrampaVM(INavigation navegacion)
        {
            Navigation = navegacion;
        }
        #endregion

        #region OBJETOS
        public string Codigo
        {
            get { return _codigo; }
            set { SetValue(ref _codigo, value); }
        }
        public string Id
        {
            get { return _id; }
            set { SetValue(ref _id, value); }
        }
        public string Modelo
        {
            get { return _modelo; }
            set { SetValue(ref _modelo, value); }
        }
        public ImageSource Imagen
        {
            get { return _imagen; }
            set { SetValue(ref _imagen, value); }
        }
        public bool FrameVisible
        {
            get { return _frameVisible; }
            set { SetValue(ref _frameVisible, value); }
        }

        #endregion

        #region PROCESOS
        public async Task ValidarTrampa()
        {
            Dictionary<string, TrampaModel> trampas = new Dictionary<string, TrampaModel>()    
            {
                { "1234", new TrampaModel { Modelo = "3316", Estado = "Trampita UTS", Imagen = "https://i.ibb.co/rXny5kt/Trampa-removebg-preview.png" } }
            };

            if (trampas.ContainsKey(Codigo))
            {
                var trampa = trampas[Codigo];

                // Actualizar las etiquetas e imagen con la información de la trampa
                Id = $"ID: {trampa.Modelo}";
                Modelo = $"MODELO: {trampa.Estado}";
                Imagen = trampa.Imagen;

                // Mostrar el popup con la información de la trampa
                FrameVisible = true;
            }
            else
            {
                await DisplayAlert("Error", "Código no válido", "OK");
                FrameVisible = false; // Ocultar el popup si el código no es válido
            }

        }
        public async Task AgregarTrampa() 
        {
            await DisplayAlert("Éxito", "Trampa agregada correctamente", "OK");
            FrameVisible = false; // Ocultar el popup después de agregar
        }
        public async Task VolverAtras()
        {
            await Navigation.PopAsync();
        }

        public void ProcesoSimple()
        {
        }
        #endregion

        #region COMANDOS

        public ICommand Validar => new Command(async () => await ValidarTrampa());
        public ICommand Agregar => new Command(async () => await AgregarTrampa());
        public ICommand Volver => new Command(async () => await VolverAtras());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
