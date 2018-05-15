using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Sales
{
    public class SaleEmptyClienteException : BusinessException
    {
        public SaleEmptyClienteException() : base("O nome do cliente esta vazio")
        {

        }
    }
}
