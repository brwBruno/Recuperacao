using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Books
{
    public interface IBookRepository
    {
        Book Add(Book book);
        Book Update(Book book);
        Book Get(long id);
        IList<Book> GetAll();
        void Delete(long id);
    }
}
