using InventorySystem.DAL;
using InventorySystem.Models;

namespace InventorySystem.BLL
{
    public class ItemCodeBLL
    {

        private readonly ItemCodeDAL _itemCodeDAL;

        public  ItemCodeBLL(ItemCodeDAL itemCodeDAL)
        {
            _itemCodeDAL = itemCodeDAL;
        }


        public List<ItemCode> GetALLItemCodes()
        {


          return _itemCodeDAL.GetAllItemCodes();

        }

        public bool AddItemCode(string Code)
        {
            bool isSuccessful=false;
            if (string.IsNullOrWhiteSpace(Code))
            {
                return false;
            }

            Code=Code.Trim();

            isSuccessful = _itemCodeDAL.InsertItemCode(Code);

            return isSuccessful;
        }

        public bool EditItemCode(string Code,int ID)
        {
            bool isSuccessful = false;
            if (string.IsNullOrWhiteSpace(Code) )
            {
                return false;
            }

            Code=Code.Trim();
            //isSuccessful = _itemCodeDAL.EditItemCode(Code,ID);

            return false;
        }

        public bool deleteItemCodeByCode(string Code)
        {
            bool isSuccessful=false;




            return isSuccessful;
        }

    }
}
