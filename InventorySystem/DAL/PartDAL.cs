using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DAL
{
    public class PartDAL
    {

        public bool MovePart(int PartID,
                             int FromLocationID, int ToLocationID,
                             int? FromStorageID, int? ToStorageID,
                             int? FromRackID, int? ToRackID,
                             int? FromShelfID, int? ToShelfID,
                             int ActionID)
        {
            bool isSuccess = false;





            return isSuccess;
        }


        public bool receivePart(int PartID, int FromLocationID,
                                int ToLocaionID, int? ToStorageID,
                                int? ToRackID, int? ToShelfID,
                                int? ActionID)
        {
            bool isSuccess = false;





            return isSuccess;
        }


    }
}
