using DonaRosangela.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Loans
{
    public class LoanInvalidDevolutionException : BusinessException
    {
        public LoanInvalidDevolutionException() : base("A data de devolução deve serpelo menor um dia a mais que hoje")
        {

        }
    }
}
