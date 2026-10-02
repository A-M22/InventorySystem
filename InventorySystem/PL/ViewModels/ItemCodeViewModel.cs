using InventorySystem.BLL;
using InventorySystem.Models;
using System.Collections.ObjectModel;
using System.Windows;


namespace InventorySystem.PL.ViewModels
{
    public class ItemCodeViewModel : ViewModelBase
    {

        private readonly ItemCodeBLL _itemCodeBLL;
        public ObservableCollection<ItemCode> ItemCodes { get; } = new();

        private string _newCode = string.Empty;

        public string NewCode
        {
            get => _newCode;
            set
            {
                _newCode = value;
                OnPropertyChanged();
            }
              
        }

        public RelayCommand AddCommand { get; }
           

        public ItemCodeViewModel(ItemCodeBLL itemCodeBLL)
        {
            _itemCodeBLL = itemCodeBLL;
            AddCommand = new RelayCommand(AddItemCode);
            LoadItemCodes();
        }

        private void LoadItemCodes()
        {
            List<ItemCode> codes = _itemCodeBLL.GetALLItemCodes();

            ItemCodes.Clear();

            foreach(ItemCode code in codes)
            {
                ItemCodes.Add(code);
            }
        }

        private void AddItemCode()
        {
            bool success =
                _itemCodeBLL.AddItemCode(NewCode);

            if(!success)
            {
                MessageBox.Show(
                    "Could Not Add Item Code!.");
                return;
            }
            NewCode = string.Empty;
            LoadItemCodes();    

        }



    }
}
