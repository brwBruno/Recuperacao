using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Products
{
    public class ProductMinCharacterException : BusinessException
    {
        public ProductMinCharacterException() : base("O Nome deve ter no minimo 4 caracteres")
        {
            
        }
    }
}
