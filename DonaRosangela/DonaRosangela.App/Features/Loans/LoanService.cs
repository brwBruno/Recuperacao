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
            return _repository.Add(loan);
        }

        public void Delete(Loan loan)
        {
            _repository.Delete(loan.Id);
        }

        public Loan Get(Loan loan)
        {
            return _repository.Get(loan.Id);
        }

        public IList<Loan> GetAll()
        {
            return _repository.GetAll();
        }

        public Loan Update(Loan loan)
        {
            return _repository.Update(loan);
        }
    }
}
