using DonaRosangela.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Books
{
    public class BookAuthorMinCaractersException : BusinessException
    {
        public BookAuthorMinCaractersException() : base("O autor deve ter 4 ou mais caracteres")
         {

        }
    }
}
