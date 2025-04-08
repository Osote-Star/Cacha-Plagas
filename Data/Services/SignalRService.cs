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

        public event Action<int> OnTrampasActualizadas;

        public async Task ConectarAsync()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://xcdrzvgc-5086.usw3.devtunnels.ms/signalrHub") // reemplaza con tu URL real
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<int>("ActualizarTrampas", (usuarioId) =>
            {
                Console.WriteLine($"Recibido usuarioId: {usuarioId}");
                OnTrampasActualizadas?.Invoke(usuarioId);
            });

            await _hubConnection.StartAsync();
        }

        public async Task DesconectarAsync()
        {
            if (_hubConnection != null)
                await _hubConnection.StopAsync();
        }
    }
}
