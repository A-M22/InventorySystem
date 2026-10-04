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
        private int _id = -1;

        public string NewCode
        {
            get => _newCode;
            set
            {
                _newCode = value;
                OnPropertyChanged();
            }

        }

        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }

        public ItemCodeViewModel(ItemCodeBLL itemCodeBLL)
        {
            _itemCodeBLL = itemCodeBLL;
            AddCommand = new RelayCommand(AddItemCode);
            EditCommand = new RelayCommand(EditItemCode);
            LoadItemCodes();
        }

        private void LoadItemCodes()
        {
            List<ItemCode> codes = _itemCodeBLL.GetALLItemCodes();

            ItemCodes.Clear();

            foreach (ItemCode code in codes)
            {
                ItemCodes.Add(code);
            }
        }

        private void AddItemCode()
        {
            bool success =
                _itemCodeBLL.AddItemCode(NewCode);

            if (!success)
            {
                MessageBox.Show(
                    "Could Not Add Item Code!.");
                return;
            }
            NewCode = string.Empty;
            LoadItemCodes();

        }

        private void EditItemCode()
        {
            bool success =
                _itemCodeBLL.EditItemCode(NewCode, ID);

            if (!success)
            {
                {
                    MessageBox.Show
                        ("Could Not Eidt Item Code!.");
                    return;
                }
                NewCode = string.Empty;
                LoadItemCodes();
            }



        }
    }
}
