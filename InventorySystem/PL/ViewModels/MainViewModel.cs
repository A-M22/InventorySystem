using InventorySystem.PL.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace InventorySystem.PL.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly NavigationService _navigation;

        private object? _currentView;

        public object? CurrentView
        {
            get => _currentView;

            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(
            NavigationService navigation)
        {
            _navigation = navigation;
            _navigation.CurrentViewModelChanged += OnNavigationChanged;

            _navigation.Navigate<ItemCodeViewModel>();

            CurrentView = _navigation.CurrentViewModel;


        }

        private void OnNavigationChanged()
        {
            CurrentView = _navigation.CurrentViewModel;
        }

    }
}
