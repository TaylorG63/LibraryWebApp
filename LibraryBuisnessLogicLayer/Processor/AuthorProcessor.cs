using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using LibraryDatabaseAccessLayer;

namespace LibraryBuisnessLogicLayer.Processor
{
    public static class AuthorProcessor
    {
        #region Create
        public static int CreateAuthor(string firstName, string lastName, DateTime dateOfBirth, int birthLocation, string bio)
        {
            AuthorDTO data = new AuthorDTO { FirstName = firstName, LastName = lastName, DateOfBirth = dateOfBirth, BirthLocation = birthLocation, Bio = bio };
            string _dateOfBirth = dateOfBirth.ToString();
            string sql = $@"INSERT INTO [dbo].[Author] (FirstName, LastName, DateOfBirth, BirthLocation, Bio) values (@FirstName, @LastName, '{_dateOfBirth}', @BirthLocation, @Bio)";
            SQL_DAL.CreateData(sql, data);
            AuthorDTO author = LoadAuthor(data);
            return author.AuthorId;
        }

        public static int CreateAuthor(AuthorDTO _model)
        {
            AuthorDTO data = new AuthorDTO { FirstName = _model.FirstName, LastName = _model.LastName, DateOfBirth = _model.DateOfBirth, BirthLocation = _model.BirthLocation, Bio = _model.Bio };

            string sql = $@"INSERT INTO [dbo].[Author] (FirstName, LastName, DateOfBirth, BirthLocation, Bio)
                            values (@FirstName, @LastName, @DateOfBirth, @BirthLocation, @Bio)";

            return SQL_DAL.CreateData(sql, data);
        }
        #endregion
        #region Read
        public static List<AuthorDTO> LoadAuthores()
        {
            string sql = @"SELECT AuthorId, FirstName, LastName, DateOfBirth, BirthLocation, Bio
                            FROM [dbo].[Author]";
            return SQL_DAL.LoadData<AuthorDTO>(sql);
        }

        public static AuthorDTO LoadAuthor(int id)
        {
            string sql = $@"SELECT AuthorId, FirstName, LastName, DateOfBirth, BirthLocation, Bio
                            FROM [dbo].[Author] WHERE [dbo].[Author].AuthorId = {id}";
            List<AuthorDTO> data = SQL_DAL.LoadData<AuthorDTO>(sql);
            return data[0];
        }

        public static AuthorDTO LoadAuthor(AuthorDTO author)
        {
            string sql = $@"SELECT AuthorId, FirstName, LastName, DateOfBirth, BirthLocation, Bio FROM [dbo].[Author] WHERE ([dbo].[Author].FirstName = '{author.FirstName}' AND [dbo].[Author].LastName = '{author.LastName}')";
            List<AuthorDTO> data = SQL_DAL.LoadData<AuthorDTO>(sql);
            return data[0];
        }
        public static AuthorDTO LoadAuthor(string search)
        {
            string sql = $@"SELECT AuthorId, FirstName, LastName, DateOfBirth, BirthLocation, Bio FROM [dbo].[Author] WHERE ([dbo].[Author].FirstName LIKE '%{search}%' OR [dbo].[Author].LastName LIKE '%{search}%')";
            List<AuthorDTO> data = SQL_DAL.LoadData<AuthorDTO>(sql);
            return data[0];
        }
        #endregion
        #region Update
        #endregion
        #region Delete
        #endregion
    }
}
