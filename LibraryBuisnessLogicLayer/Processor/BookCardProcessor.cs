using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using LibraryDatabaseAccessLayer;

namespace LibraryBuisnessLogicLayer.Processor
{
    public static class BookCardProcessor
    {
        #region Read
        public static List<BookCardDTO> LoadBookCards()
        {
            string sql = @"SELECT Title, [dbo].[Books].Description, PublishDate, FirstName, LastName, [dbo].[Genre].Name FROM Books LEFT JOIN Author ON [dbo].[Books].Author = [dbo].[Author].AuthorId LEFT JOIN Genre ON [dbo].[Books].Genre = [dbo].[Genre].GenreId";
            return SQL_DAL.LoadData<BookCardDTO>(sql);
        }
        #endregion
    }
}
