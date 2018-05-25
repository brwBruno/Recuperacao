using DonaRosangela.Domain.Features.Books;
using DonaRosangela.Domain.Features.Loans;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Infra.Data.Features.Loans
{
    public class LoanRepository : ILoanRepository
    {
        public Loan Add(Loan loan)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Loan Get(long id)
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

        private Dictionary<string, object> Take(Loan loan)
        {
            return new Dictionary<string, object>
            {
                { "Id", loan.Id },
                { "Client", loan.Client },
                { "Book_Id", loan.LoanBook },
                { "Devolution", loan.Devolution }
            };
        }

        private Func<IDataReader, Loan> Make => reader =>
            new Loan
            {
                Id = Convert.ToInt64(reader["Id"]),
                Client = Convert.ToString(reader["Client"]),
                LoanBook = new Book
                {
                    Id = Convert.ToInt32(reader["Book_Id"])
                },
                Devolution = Convert.ToDateTime(reader["Devolution"])
            };
    }
}
