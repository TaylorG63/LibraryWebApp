using LibraryDatabaseAccessLayer;
using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBuisnessLogicLayer.Processor
{
    public static class AddressProcessor
    {
        #region Create
        public static int CreateAddressWithIDReturn(string address, string city, string country, string state, string zip)
        {
            if (LoadAddress(address, city, country, state, zip) == 0)
            {
                AddressDTO data = new AddressDTO { Address = address, City = city, Country = country, State = state, Zip = zip };

                string sql = @"INSERT INTO [dbo].[Address] (Address, City, Country, State, Zip)
                            values (@Address, @City, @Country, @State, @Zip)";
                SQL_DAL.CreateData(sql, data);
                return LoadAddress(data);
            }
            else
            {
                return LoadAddress(address, city, country, state, zip);
            }
        }

        public static int CreateAddress(AddressDTO _model)
        {
            AddressDTO data = new AddressDTO { Address = _model.Address, City = _model.City, Country = _model.Country, State = _model.State, Zip = _model.Zip };

            string sql = @"INSERT INTO [dbo].[Address] (Address, City, Country, State, Zip)
                            values (@Address, @City, @Country, @State, @Zip)";

            return SQL_DAL.CreateData(sql, data);
        }
        #endregion
        #region Read
        public static List<AddressDTO> LoadAddresses()
        {
            string sql = @"SELECT AddressId, Address, City, Country, State, Zip
                            FROM [dbo].[Address]";
            return SQL_DAL.LoadData<AddressDTO>(sql);
        }

        public static AddressDTO LoadAddress(int id)
        {
            string sql = $@"SELECT AddressId, Address, City, Country, State, Zip
                            FROM [dbo].[Address] WHERE [dbo].[Address].AddressId = {id}";
            List<AddressDTO> data = SQL_DAL.LoadData<AddressDTO>(sql);
            return data[0];
        }

        public static int LoadAddress(AddressDTO address)
        {
            string sql = $@"SELECT AddressId, Address, City, Country, State, Zip
                            FROM [dbo].[Address] WHERE 
                            [dbo].[Address].Address = '{address.Address}' AND
                            [dbo].[Address].City = '{address.City}' AND
                            [dbo].[Address].Country = '{address.Country}' AND
                            [dbo].[Address].State = '{address.State}' AND
                            [dbo].[Address].Zip = '{address.Zip}'";
            List<AddressDTO> data = SQL_DAL.LoadData<AddressDTO>(sql);
            return data[0].AddressId;
        }
        public static int LoadAddress(string address, string city, string country, string state, string zip)
        {
            string sql = $@"SELECT AddressId, Address, City, Country, State, Zip
                            FROM [dbo].[Address] WHERE 
                            [dbo].[Address].Address = '{address}' AND
                            [dbo].[Address].City = '{city}' AND
                            [dbo].[Address].Country = '{country}' AND
                            [dbo].[Address].State = '{state}' AND
                            [dbo].[Address].Zip = '{zip}'";
            List<AddressDTO> data = SQL_DAL.LoadData<AddressDTO>(sql);
            return data[0].AddressId;
        }
        #endregion
        #region Update
        #endregion
        #region Delete
        #endregion
    }
}
