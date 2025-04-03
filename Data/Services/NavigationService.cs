using CachaPlagas.Data.Interfaces;
using CachaPlagas.View_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachaPlagas.Data.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _services;

        public NavigationService(IServiceProvider services)
        {
            _services = services;
        }

        protected INavigation Navigation
        {
            get
            {
                INavigation? navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is null)
                    throw new Exception("Navigation is not available");
                return navigation;
            }
        }

        // Implementación explícita para páginas
        public async Task PushAsync(Page page)
        {
            if (page.BindingContext is BaseViewModel viewModel)
            {
                await viewModel.OnNavigatingTo(null);
            }

            await Navigation.PushAsync(page);

            if (page.BindingContext is BaseViewModel viewModelAfterNavigation)
            {
                await viewModelAfterNavigation.OnNavigatedTo();
            }
        }

        // Implementación para ViewModels
        public Task PushAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return PushAsync<TViewModel>(null);
        }

        public async Task PushAsync<TViewModel>(IDictionary<string, object> parameters) where TViewModel : BaseViewModel
        {
            var page = ResolvePage(typeof(TViewModel));

            if (page.BindingContext is BaseViewModel viewModel)
            {
                await viewModel.OnNavigatingTo(parameters);
            }

            await Navigation.PushAsync(page);

            if (page.BindingContext is BaseViewModel viewModelAfterNavigation)
            {
                await viewModelAfterNavigation.OnNavigatedTo();
            }
        }

        public async Task PopAsync()
        {
            if (Navigation.NavigationStack.Count > 1)
            {
                var currentPage = Navigation.NavigationStack.Last();
                if (currentPage.BindingContext is BaseViewModel currentViewModel)
                {
                    await currentViewModel.OnNavigatedFrom();
                }

                await Navigation.PopAsync();
            }
        }

        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();

            if (Navigation.NavigationStack.Count > 0)
            {
                var rootPage = Navigation.NavigationStack.First();
                if (rootPage.BindingContext is BaseViewModel rootViewModel)
                {
                    await rootViewModel.OnNavigatedTo();
                }
            }
        }

        // Métodos modales (opcionales)
        public async Task PushModalAsync(Page page)
        {
            await Navigation.PushModalAsync(page);
        }

        public async Task PushModalAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            var page = ResolvePage(typeof(TViewModel));
            await Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            await Navigation.PopModalAsync();
        }

        // Métodos auxiliares
        private Page ResolvePage(Type viewModelType)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType is null)
                throw new Exception($"No page type found for view model {viewModelType}");

            var page = _services.GetService(pageType) as Page;
            if (page is null)
                throw new Exception($"Unable to resolve page {pageType}");

            return page;
        }

        private Type? GetPageTypeForViewModel(Type viewModelType)
        {
            // Opción 1: Si usas "VM" como sufijo en ViewModels
            var viewName = viewModelType.FullName?
                .Replace("VM", "") // Elimina solo "VM" si usas ese sufijo
                .Replace("View_model", "View"); // Ajusta namespace si es necesario

            // Opción 2: Si usas "ViewModel" como sufijo
            // var viewName = viewModelType.FullName?
            //    .Replace("ViewModel", ""); // Elimina "ViewModel" completamente

            if (string.IsNullOrEmpty(viewName))
                return null;

            // Busca el tipo en todos los assemblies cargados
            var viewType = Type.GetType(viewName) ??
                          AppDomain.CurrentDomain.GetAssemblies()
                              .Select(a => a.GetType(viewName))
                              .FirstOrDefault(t => t != null);

            return viewType;
        }
    }
}
