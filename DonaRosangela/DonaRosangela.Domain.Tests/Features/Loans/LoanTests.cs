using DonaRosangela.Common.Tests.Base;
using DonaRosangela.Domain.Features.Books;
using DonaRosangela.Domain.Features.Loans;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Tests.Features.Loans
{
    [TestFixture]
    public class LoanTests
    {
        Loan _loan;
        Loan _expectedLoan;
        Mock<Book> _book;

        [SetUp]
        public void Inicialize()
        {
            _loan = new Loan();
            _expectedLoan = new Loan();
            _book = new Mock<Book>();
        }

        [Test]
        public void Loan_CreateValid_ShouldBeOk()
        {
            _book.Object.Id = 1;
            _loan = ObjectMother.GetLoan(_book.Object);

            _loan.Validate();

            _loan.Id.Should().Be(1);
            _loan.LoanBook.Should().NotBeNull();
        }
    }
}
