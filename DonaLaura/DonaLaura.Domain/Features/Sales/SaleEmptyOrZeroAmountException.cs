using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Sales
{
    public class SaleEmptyOrZeroAmountException : BusinessException
    {
        public SaleEmptyOrZeroAmountException() : base("A quantidade esta vazia ou e zero")
        {

        }
    }
}
