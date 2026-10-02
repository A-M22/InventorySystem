using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using System.Windows;

namespace InventorySystem.DAL
{
    public class Database
    {
        private readonly string _databasePath;
        private readonly string _connectionString;

        public Database()
        {
            
            string appFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "InventorySystem"
                );
            Directory.CreateDirectory(appFolder);

            _databasePath = Path.Combine(appFolder, "inventory.db");
            _connectionString = $"Data Source={_databasePath}";


            try
            {
                Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed To Initialize Database with error: {ex.Message}");
            }
        }
        public SqliteConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        public void Initialize()
        {
            using var connection = CreateConnection();
            connection.Open();
            CreateTables(connection);
            Seed(connection);

            connection.Close();
        }

        private void CreateTables(SqliteConnection connection)
        {
            using var command = connection.CreateCommand();
            command.CommandText = """
                                
                PRAGMA foreign_keys = ON;

                create table IF NOT EXISTS ItemCode
                (
                    ID integer primary key,
                    Code varchar(50) unique not null
                );

                create table IF NOT EXISTS ItemType
                (
                    ID integer primary key,
                    itemTypeName varchar(25)
                );

                create table IF NOT EXISTS Catalog 
                (
                    ID integer primary key,
                    ItemCodeID integer not null,
                    PartNumber varchar(50) unique null,
                    Name varchar(255) not null,
                    ItemTypeID integer,
                    Note varchar(255) null,
                    foreign key (ItemCodeID) references ItemCode(ID),
                    foreign key (ItemTypeId) references ItemType(ID)
                );

                                
                create table IF NOT EXISTS Location
                (
                    ID integer primary key,
                    Name varchar(50) unique not null,
                    Note varchar(50) null, 
                    status boolean default true 
                );

                create table IF NOT EXISTS Storage
                (
                    ID integer primary key,
                    LocationID integer not null,
                    Name varchar(50) not null,
                    Note varchar(50) null,
                    status boolean default true,
                    foreign key (LocationID) references Location(ID)
                );

                create table IF NOT EXISTS Rack
                (
                    ID integer primary key,
                    StorageID integer not null,
                    Name varchar(50) not null,
                    Note varchar(50) null,
                    status boolean default true,
                    foreign key (StorageID) references Storage(ID)
                );

                create table IF NOT EXISTS Shelf
                (
                    ID integer primary key,
                    RackID integer not null,
                    Name varchar(50) not null,
                    Note varchar(50) null,
                    status boolean default true,
                    foreign key (RackID) references Rack(ID)
                );



                create table IF NOT EXISTS Part
                (
                    ID integer primary key,
                    CatalogID integer not null,
                    SerialNumber varchar(50) unique null,
                    OptionalName varchar(50) null,
                    Note varchar(255) null,
                    Status varchar(50) null,
                    CurrentLocationID integer not null,
                    CurrentStorageID integer null,
                    CurrentRackID integer null,
                    CurrentShelfID integer null,
                    ParentPartID integer null,
                    LastInventory DateTime default current_timestamp,
                    foreign key (CurrentLocationID) references Location(ID),
                    foreign key (CurrentStorageID) references Storage(ID),
                    foreign key (CurrentRackID) references Rack(ID),
                    foreign key (CurrentShelfID) references Shelf(ID),
                    foreign key (ParentPartID) references Part(ID),
                    foreign key (CatalogID) references Catalog(ID)
                );





                create table IF NOT EXISTS Action
                (
                    ID integer primary key,
                    Name varchar(50) unique not null,
                    Note varchar(255) null
                );




                create table IF NOT EXISTS History
                (
                    ID integer primary key,
                    PartID integer not null,
                    FromLocationID integer null,
                    ToLocationID integer null,
                    FromStorageID integer null,
                    ToStorageID integer null,
                    FromRackID integer null,
                    ToRackID integer null,
                    FromShelfID integer null,
                    ToShelfID integer null,
                    ActionID integer not null,
                    FromStatus varchar(50) null,
                    ToStatus varchar(50) null,
                    Note varchar(255) null,
                    CreatedAt datetime default current_timestamp,
                    foreign key (PartID) references Part(ID),
                    foreign key (FromLocationID) references Location(ID),
                    foreign key (ToLocationID) references Location(ID),
                    foreign key (FromStorageID) references Storage(ID),
                    foreign key (ToStorageID) references Storage(ID),
                    foreign key (FromRackID) references Rack(ID),
                    foreign key (ToRackID) references Rack(ID),
                    foreign key (FromShelfID) references Shelf(ID),
                    foreign key (ToShelfID) references Shelf(ID),
                    foreign key (ActionID) references Action(ID)

                );
                
                """;
            command.ExecuteNonQuery();
        }

        private void Seed(SqliteConnection connection)
        {
            using var command = connection.CreateCommand();
            command.CommandText = """
                insert or ignore into itemcode (code) values ('TC002771');
                insert or ignore into itemcode (code) VALUES ('TC010606');
                insert or ignore into itemcode (code) VALUES ('TC010607');
                insert or ignore into itemcode (code) VALUES ('TC010618');
                insert or ignore into action(name,note) values('received', 'if the part serial number is new to the system or came from an extrnal source');   
                insert or ignore into action(name,note) values('Moved','Moving a part from inventory to another from location to location');
                insert or ignore into action(name,note) values('serial Number update','Updating a serial number from uknown to a known serial or updating an existing serial number');
                insert or ignore into action(name,note) values('Attach', 'Attach a part to a Parent part');
                insert or ignore into action(name,note) values('Deattach','Deattaching a part from a parent part');
                """;
            command.ExecuteNonQuery();
        }


    }
}
