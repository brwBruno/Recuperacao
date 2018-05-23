using DonaRosangela.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Books
{
    public class BookThemeMinCaractersException : BusinessException
    {
        public BookThemeMinCaractersException() : base("O tema deve ter 4 ou mais caracteres")
        {

        }
    }
}
