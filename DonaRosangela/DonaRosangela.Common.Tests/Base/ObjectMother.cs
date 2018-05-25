using DonaRosangela.Domain.Features.Books;
using DonaRosangela.Domain.Features.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Book GetBook()
        {
            return new Book
            {
                Id = 1,
                Title = "A Volta dos que nao Foram",
                Theme = "Ficção",
                Author = "Renan Zapelini",
                Volume = 1,
                Publication = DateTime.Now.AddYears(-30),
                Availability = true
            };
        }

        public static Book GetBookSQL()
        {
            return new Book
            {
                Title = "A Volta dos que nao Foram",
                Theme = "Ficção",
                Author = "Renan Zapelini",
                Volume = 1,
                Publication = DateTime.Now.AddYears(-30),
                Availability = true
            };
        }

        public static Loan GetLoan(Book book)
        {
            return new Loan
            {
                Id = 1,
                Client = "Bruno Ribeiro",
                LoanBook = book,
                Devolution = DateTime.Now.AddDays(3)
            };
        }

        public static Loan GetLoanSQL(Book book)
        {
            return new Loan
            {
                Client = "Bruno Ribeiro",
                LoanBook = book,
                Devolution = DateTime.Now.AddDays(3)
            };
        }
    }
}
