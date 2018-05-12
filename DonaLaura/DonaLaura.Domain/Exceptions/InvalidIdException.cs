using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException() : base("O Id é invalido ou esta vazio")
        {

        }
    }
}
