using DonaRosangela.Domain.Exceptions;
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
            loan.Validate();
            return _repository.Add(loan);
        }

        public void Delete(Loan loan)
        {
            if (loan.Id == 0) throw new InvalidIdException();
            _repository.Delete(loan.Id);
        }

        public Loan Get(Loan loan)
        {
            if (loan.Id == 0) throw new InvalidIdException();
            return _repository.Get(loan.Id);
        }

        public IList<Loan> GetAll()
        {
            return _repository.GetAll();
        }

        public Loan Update(Loan loan)
        {
            if (loan.Id == 0) throw new InvalidIdException();
            loan.Validate();
            return _repository.Update(loan);
        }
    }
}
