using CachaPlagas.Data;
using CachaPlagas.Data.Interfaces;
using CachaPlagas.Data.Services;
using CachaPlagas.View;
using CachaPlagas.View_model;
using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace CachaPlagas
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit MediaElement by adding the below line of code
                .UseMauiCommunityToolkitMediaElement()
                // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddHttpClient<API_Connection>(client =>
            {      
                client.BaseAddress = new Uri("https://xcdrzvgc-5086.usw3.devtunnels.ms/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<SignalRService>();
            builder.Services.AddSingleton<JwtServices>(); 
            builder.Services.AddScoped<TrampaService>();
            builder.Services.AddScoped<AuthServices>();
            builder.Services.AddScoped<UsuarioServices>();
            builder.Services.AddScoped<CapturaServices>();
            builder.Services.AddScoped<EmailService>();

            // Registrar todas las Vistas (Pages)
            builder.Services.AddTransient<AgregarTrampa>();
            builder.Services.AddTransient<CambiarContrasena>();
            builder.Services.AddTransient<CodigoContrasena>();
            builder.Services.AddTransient<HistorialCaptura>();
            builder.Services.AddTransient<ListadoTrampas>();
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<RecuperarContraseña>();
            builder.Services.AddTransient<CachaPlagas.View.Registrar>();
            builder.Services.AddTransient<VerTrampa>();

            // Registrar todos los ViewModels
            builder.Services.AddTransient<AgregarTrampaVM>();
            builder.Services.AddTransient<CambiarContrasenaVM>();
            builder.Services.AddTransient<CodigoContrasenaVM>();
            builder.Services.AddTransient<EsquemaVM>();
            builder.Services.AddTransient<HistorialCapturaVM>();
            builder.Services.AddTransient<ListadoTrampasVM>();
            builder.Services.AddTransient<LoginVM>();
            builder.Services.AddTransient<RecuperarContraseñaVM>();
            builder.Services.AddTransient<RegistrarVM>();
            builder.Services.AddTransient<VerTrampaVM>();

            // Continue initializing your .NET MAUI App here

            return builder.Build();
        }
    }
}
