using InventorySystem.Models;
using System.Windows;

namespace InventorySystem.DAL
{
    public class ItemCodeDAL
    {

        private Database _database;
        public ItemCodeDAL(Database database)
        {
            this._database = database;
        }

        public List<ItemCode> GetAllItemCodes()
        {
            List<ItemCode> ItemCodes = new List<ItemCode>();
         
            using var connection = _database.CreateConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();

            command.CommandText = """ Select ID, Code from ItemCode""";
            
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {



                var itemCode = new ItemCode
                {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    Code = reader.GetString(reader.GetOrdinal("Code"))
                };

                ItemCodes.Add(itemCode);
            }



            return ItemCodes;
        }


        public bool InsertItemCode(string ItemCode)
        {
            using var connection = _database.CreateConnection();
            connection.Open();
            try
            {
                using var command = connection.CreateCommand();
                command.CommandText = """ insert into ItemCode (Code) values ($ItemCode); """;
                command.Parameters.AddWithValue("$ItemCode", ItemCode);
                command.ExecuteNonQuery();
                connection.Close();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            } 
        }


        public bool DeleteItemCodeByID(int ID)
        {
            bool isSuccessfull = false;

            using var connection = _database.CreateConnection();
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText=""" delete from ItemCode where $ID=ID; """;
            command.Parameters.AddWithValue("$ID", ID);
            int value=command.ExecuteNonQuery();
            if (value > 0)
            {
                isSuccessfull = true;
            }
            else
                isSuccessfull = false;


                return isSuccessfull;
        }

        


    }
    }
