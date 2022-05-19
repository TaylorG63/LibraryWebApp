using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using LibraryDatabaseAccessLayer;

namespace LibraryBuisnessLogicLayer.Processor
{
    public static class GenreProcessor
    {
        #region Create
        public static int CreateGenre(string name, string description, bool isFiction)
        {
            GenreDTO data = new GenreDTO {Name = name, Description = description, IsFiction = isFiction };

            string sql = $@"INSERT INTO [dbo].[Genre] (Name, Description, IsFiction)
                            values (@Name, @Description, @IsFiction)";

            return SQL_DAL.CreateData(sql, data);
        }

        public static int CreateGenre(GenreDTO _model)
        {
            GenreDTO data = new GenreDTO { Name = _model.Name, Description = _model.Description, IsFiction = _model.IsFiction};

            string sql = $@"INSERT INTO [dbo].[Genre] (Name, Description, IsFiction)
                            values (@Name, @Description, @IsFiction)";

            return SQL_DAL.CreateData(sql, data);
        }
        #endregion
        #region Read
        public static List<GenreDTO> LoadGenrees()
        {
            string sql = @"SELECT GenreId, FirstName, LastName, DateOfBirth, BirthLocation, Bio
                            FROM [dbo].[Genre]";
            return SQL_DAL.LoadData<GenreDTO>(sql);
        }

        public static GenreDTO LoadGenre(int id)
        {
            string sql = $@"SELECT GenreId, FirstName, LastName, DateOfBirth, BirthLocation, Bio
                            FROM [dbo].[Genre] WHERE [dbo].[Genre].GenreId = {id}";
            List<GenreDTO> data = SQL_DAL.LoadData<GenreDTO>(sql);
            return data[0];
        }
        #endregion
        #region Update
        #endregion
        #region Delete
        #endregion
    }
}
