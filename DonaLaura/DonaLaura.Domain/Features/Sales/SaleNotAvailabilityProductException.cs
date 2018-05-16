using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Sales
{
    public class SaleNotAvailabilityProductException : BusinessException
    {
        public SaleNotAvailabilityProductException() : base("Esse Produto nao e valido para venda")
        {

        }
    }
}
