using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.PL.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;

            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(
            ItemCodeViewModel itemCodeViewModel)
        {
            CurrentView = itemCodeViewModel;
        }


    }
}
