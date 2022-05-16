using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCommon.Models;
using LibraryDatabaseAccessLayer;

namespace LibraryBuisnessLogicLayer.Processor
{
    public static class UserProccessor
    {
        #region Create
        public static int CreateUser(string firstName, string lastName, string userName, string email, string password)
        {
            string[] hashSalt = Hasher.HashSalt(password);
            UserDTO data = new UserDTO { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = hashSalt[0], Salt = hashSalt[1] };
            
            string sql = @"INSERT INTO [dbo].[User] (Role, FirstName, LastName, UserName, Email, Password, Salt)
                            values (@Role, @FirstName, @LastName, @UserName, @Email, @Password, @Salt)";

            return SQL_DAL.CreateData(sql, data);
        }

        public static int CreateUser(UserDTO _model)
        {
            string[] hashSalt = Hasher.HashSalt(_model.Password);
            UserDTO data = new UserDTO { FirstName = _model.FirstName, LastName = _model.LastName, Email = _model.Email, UserName = _model.UserName, Id = _model.Id, Role = _model.Role, Password = hashSalt[0], Salt = hashSalt[1] };

            string sql = @"INSERT INTO [dbo].[User] (Role, FirstName, LastName, UserName, Email, Password, Salt)
                            values (@Role, @FirstName, @LastName, @UserName, @Email, @Password, @Salt)";

            return SQL_DAL.CreateData(sql, data);
        }
        #endregion
        #region Read
        public static List<UserDTO> LoadUsers()
        {
            string sql = @"SELECT Role, FirstName, LastName, UserName, Email
                            FROM [dbo].[User]";
            return SQL_DAL.LoadData<UserDTO>(sql);
        }

        public static UserDTO LoadUser(string _userName)
        {
            string sql = $@"SELECT Role, FirstName, LastName, UserName, Email, Password FROM [dbo].[User] WHERE [dbo].[User].UserName = '{_userName}'";
            List<UserDTO> data = SQL_DAL.LoadData<UserDTO>(sql);
            return data[0];
        }
        #endregion
        #region Update
        #endregion
        #region Delete
        public static bool DeleteUser(UserDTO _user)
        {
            string sql = $"DELETE FROM [dbo].[User] WHERE UserId = {_user.Id}";
            return SQL_DAL.DeleteData<UserDTO>(sql);
        }
        public static bool DeleteUserTest(UserDTO _user)
        {
            string sql = $"DELETE FROM [dbo].[User] WHERE [dbo].[User].Email = '{_user.Email}'";
            return SQL_DAL.DeleteData<UserDTO>(sql);
        }
        #endregion
        public static bool CheckUserPass(string _userName, string _password)
        {
            UserDTO _login = new UserDTO {UserName = _userName, Password = _password  };
            string sql = $@"SELECT * FROM [dbo].[User] WHERE [dbo].[User].UserName = '{_userName}'";
            List<UserDTO> user = SQL_DAL.LoadData<UserDTO>(sql);
            string hashSalt = Hasher.Hash(_password, user[0].Salt);
            return hashSalt == user[0].Password;
        }

        public static List<string> GetUserNames()
        {
            string sql = @"SELECT UserName FROM [dbo].[User]";
            List<UserDTO> users = SQL_DAL.LoadData<UserDTO>(sql);
            List<string> names = new List<string>();
            for (int i = 0; i < users.Count; i++)
            {
                names.Add(users[i].UserName);
            }
            return names;
        }

    }
}
