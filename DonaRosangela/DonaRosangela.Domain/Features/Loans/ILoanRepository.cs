using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Loans
{
    public interface ILoanRepository
    {
        Loan Add(Loan loan);
        Loan Update(Loan loan);
        Loan Get(long id);
        IList<Loan> GetAll();
        void Delete(long id);
    }
}
