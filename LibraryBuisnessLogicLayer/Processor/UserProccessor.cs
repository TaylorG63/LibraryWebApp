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
        public static int CreateUser(string firstName, string lastName, string userName, string email)
        {
            UserModel data = new UserModel { FirstName = firstName, LastName = lastName, Email = email, UserName = userName};

            string sql = @"INSERT INTO [dbo].[User] (Role, FirstName, LastName, UserName, Email)
                            values (@Role, @FirstName, @LastName, @UserName, @email)";

            return SQL_DAL.CreateData(sql, data);
        }

        public static int CreateUser(UserModel _model)
        {
            UserModel data = new UserModel { FirstName = _model.FirstName, LastName = _model.LastName, Email = _model.Email, UserName = _model.UserName, Id= _model.Id, Role= _model.Role };

            string sql = @"INSERT INTO [dbo].[User] (Role, FirstName, LastName, UserName, Email)
                            values (@Role, @FirstName, @LastName, @UserName, @email)";

            return SQL_DAL.CreateData(sql, data);
        }

        public static List<UserModel> LoadUsers()
        {
            string sql = @"SELECT Role, FirstName, LastName, UserName, Email
                            FROM [dbo].[User]";
            return SQL_DAL.LoadData<UserModel>(sql);
        }

        public static bool DeleteUser(UserModel _user)
        {
            string sql = $"DELETE FROM [dbo].[User] WHERE UserId = {_user.Id}";
            return SQL_DAL.DeleteData<UserModel>(sql);
        }
        public static bool DeleteUserTest(UserModel _user)
        {
            string sql = $"DELETE FROM [dbo].[User] WHERE [dbo].[User].Email = '{_user.Email}'";
            return SQL_DAL.DeleteData<UserModel>(sql);
        }
    }
}
