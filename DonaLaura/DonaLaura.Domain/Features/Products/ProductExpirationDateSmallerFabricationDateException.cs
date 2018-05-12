using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Products
{
    public class ProductExpirationDateSmallerFabricationDateException : BusinessException
    {
        public ProductExpirationDateSmallerFabricationDateException() : base("Data de validade nao pode ser menor que data de fabricação")
        {

        }
    }
}
