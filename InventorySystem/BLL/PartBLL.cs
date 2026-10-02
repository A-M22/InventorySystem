using InventorySystem.DAL;


namespace InventorySystem.BLL
{
    public class PartBLL
    {



        private PartDAL partDal=new PartDAL();




        public bool MovePart(int PartID,
                             int FromLocationID, int ToLocationID,
                             int? FromStorageID, int? ToStorageID,
                             int? FromRackID, int? ToRackID,
                             int? FromShelfID, int? ToShelfID,
                             int ActionID
            )
        {
            bool isSuccess = false;

            if (FromLocationID <= 0 || ToLocationID <= 0 || PartID<=0)
                return false;


            isSuccess = partDal.MovePart(PartID,
                                         FromLocationID, ToLocationID,
                                         FromStorageID, ToStorageID,
                                         FromRackID, ToRackID,
                                         FromShelfID, ToShelfID,
                                         ActionID
                                         );



            return isSuccess;
        }

        public bool ReceivePart(int PartID,      int FromLocationID,
                                int ToLocationID, int?ToStorageID,
                                int? ToRackID,    int?ToShelfID,
                                int ActionID

            )
        {

            bool isSuccess = false;



            return isSuccess;
        }

        public bool ChangeSerialNumber(int PartID,  string newSerialNumber,
                                       int ActionID
            )
        {
            bool isSuccess = false;


            return isSuccess;
        }

        public bool Attach(int ChildPartID, int ParentPartID,
                           int ActionID)
        {
            bool isSuccess = false;

            return isSuccess;
        }

    }
}
