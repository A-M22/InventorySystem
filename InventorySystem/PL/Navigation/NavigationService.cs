using Microsoft.Extensions.DependencyInjection;


namespace InventorySystem.PL.Navigation
{
    public class NavigationService
    {
        private readonly IServiceProvider _ServiceProvider;
        public object? CurrentViewModel { get; private set; }

        public event Action? CurrentViewModelChanged;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _ServiceProvider = serviceProvider;
        }

        public void Navigate<TViewModel>()
            where TViewModel : class
        {
            CurrentViewModel = _ServiceProvider.GetRequiredService<TViewModel>();
            CurrentViewModelChanged?.Invoke();
        }


    }
}
