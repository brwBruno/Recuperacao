using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Loans
{
    public interface ILoanService
    {
        Loan Add(Loan loan);
        Loan Update(Loan loan);
        Loan Get(Loan loan);
        IList<Loan> GetAll();
        void Delete(Loan loan);
    }
}
