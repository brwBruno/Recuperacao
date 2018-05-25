using DonaRosangela.Domain.Features.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Features.Loans
{
    public class Loan
    {
        public long Id { get; set; }
        public string Client { get; set; }
        public Book LoanBook { get; set; }
        public DateTime Devolution { get; set; }

        public void Validate()
        {
            if (Client.Length < 4) throw new LoanClientMinCaractersException();
            if ((Devolution.Day - DateTime.Now.Day) < 1) throw new LoanInvalidDevolutionException();
            if (LoanBook.Availability == false) throw new LoanUnavailableBookException();
        }

        public double CalculateFine()
        {
            if (DateTime.Now.Day > Devolution.Day) return (DateTime.Now.Day - Devolution.Day) * 2.50;
            else return 0;
        }
    }
}
