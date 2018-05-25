using DonaRosangela.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Loans
{
    public class LoanUnavailableBookException : BusinessException
    {
        public LoanUnavailableBookException() : base("Esse livro esta indisponivel para emprestimo")
        {

        }
    }
}
