using DonaRosangela.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Loans
{
    public class LoanClientMinCaractersException : BusinessException
    {
        public LoanClientMinCaractersException() : base("O cliente deve ter mais que 4 caracteres")
        {

        }
    }
}
