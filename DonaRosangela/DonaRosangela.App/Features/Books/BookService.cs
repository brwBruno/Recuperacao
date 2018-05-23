using DonaRosangela.Domain.Exceptions;
using DonaRosangela.Domain.Features.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.App.Features.Books
{
    public class BookService : IBookService
    {
        IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Add(Book obj)
        {
            obj.Validade();
            return _repository.Add(obj);
        }

        public void Delete(Book obj)
        {
            if (obj.Id == 0) throw new InvalidIdException();
            _repository.Delete(obj.Id);
        }

        public Book Get(Book obj)
        {
            if (obj.Id == 0) throw new InvalidIdException();
            return _repository.Get(obj.Id);
        }

        public IList<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public Book Update(Book obj)
        {
            obj.Validade();
            return _repository.Update(obj);
        }
    }
}
