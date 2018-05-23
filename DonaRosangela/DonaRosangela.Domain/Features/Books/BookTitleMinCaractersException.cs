using DonaRosangela.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Books
{
    public class BookTitleMinCaractersException : BusinessException
    {
        public BookTitleMinCaractersException() : base("O titulo deve ter mais que 4 caracteres")
        {

        }
    }
}
