using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using LibraryDatabaseAccessLayer;

namespace LibraryBuisnessLogicLayer.Processor
{
    public static class BookProcessor
    {
        #region Create
        public static int CreateBook(string title, string description, bool isPaperBack, DateOnly publishDate, int author, int genre)
        {
            BookDTO data = new BookDTO { Title = title, Description = description, IsPaperBack = isPaperBack, PublishDate = publishDate, Author = author, Genre = genre };

            string sql = @"INSERT INTO [dbo].[Book] (Title, Description, IsPaperBack, PublishDate, Genre)
                            values (@Title, @Description, @IsPaperBack, @PublishDate, @Author, @Genre)";

            return SQL_DAL.CreateData(sql, data);
        }

        public static int CreateBook(BookDTO _model)
        {
            BookDTO data = new BookDTO { Title = _model.Title, Description = _model.Description, IsPaperBack = _model.IsPaperBack, PublishDate = _model.PublishDate, Author = _model.Author, Genre = _model.Genre };

            string sql = @"INSERT INTO [dbo].[Book] (Title, Description, IsPaperBack, PublishDate, Genre)
                            values (@Title, @Description, @IsPaperBack, @PublishDate, @Author, @Genre)";

            return SQL_DAL.CreateData(sql, data);
        }
        #endregion
        #region Read
        public static List<BookDTO> LoadBookes()
        {
            string sql = @"SELECT BookId, Title, Description, IsPaperBack, PublishDate, Author
                            FROM [dbo].[Book]";
            return SQL_DAL.LoadData<BookDTO>(sql);
        }

        public static BookDTO LoadBook(int id)
        {
            string sql = $@"SELECT BookId, Title, Description, IsPaperBack, PublishDate, Author
                            FROM [dbo].[Book] WHERE [dbo].[Book].BookId = {id}";
            List<BookDTO> data = SQL_DAL.LoadData<BookDTO>(sql);
            return data[0];
        }
        #endregion
        #region Update
        #endregion
        #region Delete
        #endregion
    }
}
