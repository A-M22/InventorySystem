using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace InventorySystem.PL.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? PropertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(PropertyName));
        }


    }
}
