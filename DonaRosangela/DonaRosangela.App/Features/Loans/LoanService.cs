using DonaRosangela.Domain.Features.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.App.Features.Loans
{
    public class LoanService : ILoanService
    {
        ILoanRepository _repository;
        public LoanService(ILoanRepository repository)
        {
            _repository = repository;
        }

        public Loan Add(Loan loan)
        {
            throw new NotImplementedException();
        }

        public void Delete(Loan loan)
        {
            throw new NotImplementedException();
        }

        public Loan Get(Loan loan)
        {
            throw new NotImplementedException();
        }

        public IList<Loan> GetAll()
        {
            throw new NotImplementedException();
        }

        public Loan Update(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}
