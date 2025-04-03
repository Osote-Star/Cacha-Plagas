using CachaPlagas.View_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.Data.Interfaces
{
    public interface INavigationService
    {
        Task PushAsync(Page page);
        Task PushAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task PushAsync<TViewModel>(IDictionary<string, object> parameters) where TViewModel : BaseViewModel;

        Task PopAsync();
        Task PopToRootAsync();

        // Opcional: Puedes agregar más métodos si los necesitas
        Task PushModalAsync(Page page);
        Task PushModalAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task PopModalAsync();
    }
}
