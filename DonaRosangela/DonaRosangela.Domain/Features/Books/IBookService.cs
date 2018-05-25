using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Books
{
    public interface IBookService
    {
        Book Add(Book book);
        Book Update(Book book);
        Book Get(Book book);
        IList<Book> GetAll();
        void Delete(Book book);
    }
}
