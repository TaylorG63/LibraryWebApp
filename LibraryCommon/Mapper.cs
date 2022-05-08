using LibraryCommon.DTO;
using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    internal class Mapper
    {
        public UserDTO ModelToDTO(LoginModel _model)
        {
            UserDTO userDTO = new UserDTO() { UserName = _model.Username, Password = _model.Password };
            return userDTO;
        }
        public UserDTO ModelToDTO(RegisterModel _model)
        {
            UserDTO userDTO = new UserDTO() { UserName = _model.Username, Password = _model.Password, FirstName = _model.FirstName, LastName = _model.LastName, Email = _model.Email, Id = _model.Id };
            return userDTO;
        }
    }
}
