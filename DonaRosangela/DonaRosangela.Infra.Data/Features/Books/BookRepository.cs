using DonaRosangela.Domain.Features.Books;
using DonaRosangela.Infra.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Infra.Data.Features.Books
{
    public class BookRepository : IBookRepository
    {
        public Book Add(Book obj)
        {
            const string sqlAdd = @"INSERT INTO TBBook (Title, Theme, Author, Volume, Publication, Availability)
                                    VALUES ({0}Title, {0}Theme, {0}Author, {0}Volume, {0}Publication, {0}Availability)";
            obj.Id = Db.Add(sqlAdd, Take(obj));
            return obj;
        }

        public void Delete(long id)
        {
            const string sqlDelete = @"DELETE FROM TBBook WHERE Id = {0}Id";
            var parms = new Dictionary<string, object> { { "Id", id } };
            Db.Delete(sqlDelete, parms);
        }

        public Book Get(long id)
        {
            const string sqlGet = @"SELECT * FROM TBBook WHERE Id = {0}Id";
            var parms = new Dictionary<string,object> { { "Id", id} };
            return Db.Get(sqlGet, Make, parms);
        }

        public IList<Book> GetAll()
        {
            const string sqlGetAll = @"SELECT * FROM TBBook";
            return Db.GetAll(sqlGetAll, Make);
        }

        public Book Update(Book obj)
        {
            const string sqlUpdate = @"UPDATE TBBook SET Title = {0}Title, Theme = {0}Theme, Author = {0}Author,
                                        Volume = {0}Volume, Publication = {0}Publication, Availability = {0}Availability";
            Db.Update(sqlUpdate, Take(obj));
            return Get(obj.Id);
        }

        private Dictionary<string, object> Take(Book obj)
        {
            return new Dictionary<string, object>
            {
                { "Id", obj.Id },
                { "Title", obj.Title },
                { "Author", obj.Author },
                { "Theme", obj.Theme },
                { "Volume", obj.Volume },
                { "Publication", obj.Publication },
                { "Availability", obj.Availability }
            };
        }

        private static Func<IDataReader, Book> Make => reader =>
            new Book
            {
                Id = Convert.ToInt32(reader["Id"]),
                Title = Convert.ToString(reader["Title"]),
                Author = Convert.ToString(reader["Author"]),
                Theme = Convert.ToString(reader["Theme"]),
                Volume = Convert.ToInt32(reader["Volume"]),
                Publication = Convert.ToDateTime(reader["Publication"]),
                Availability = Convert.ToBoolean(reader["Availability"])
            };
    }
}
