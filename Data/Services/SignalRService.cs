using CachaPlagas.Model;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.Data.Services
{
    public class SignalRService
    {
        private HubConnection _hubConnection;

        public SignalRService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://xcdrzvgc-5086.usw3.devtunnels.ms/api/Trampa/CambiarestatusSensor") // URL de tu API donde está configurado SignalR
                .Build();
        }

        public async Task IniciarConexion()
        {
            await _hubConnection.StartAsync();
        }

        public void DetenerConexion()
        {
            _hubConnection.StopAsync();
        }

        public void SuscribirEventos(Action<TrampaModel> onTrampaStatusActualizado)
        {
            _hubConnection.On<TrampaModel>("trampaStatusActualizado", onTrampaStatusActualizado);
        }
    }
}
