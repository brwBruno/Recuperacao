using DonaRosangela.Common.Tests.Base;
using DonaRosangela.Domain.Features.Books;
using DonaRosangela.Domain.Features.Loans;
using DonaRosangela.Infra.Data.Features.Loans;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Infra.Data.Tests.Features.Loans
{
    [TestFixture]
    public class LoanRepositoryTests
    {
        Loan _loan;
        Loan _expectedLoan;
        Book _book;
        ILoanRepository _repository;

        [SetUp]
        public void Initialize()
        {
            _loan = new Loan();
            _expectedLoan = new Loan();
            _book = new Book();
            _repository = new LoanRepository();
            BaseSql.SeedDbTBLoan();
        }

        [Test]
        public void LoanRepository_Add_ShouldBeOk()
        {
            _book.Id = 1;
            _loan = ObjectMother.GetLoanSQL(_book);

            _expectedLoan = _repository.Add(_loan);

            _expectedLoan.Should().NotBeNull();
            _expectedLoan.Id.Should().Be(2);
        }

        [Test]
        public void LoanRepository_Get_ShouldBeOk()
        {
            _loan.Id = 1;

            _expectedLoan = _repository.Get(_loan.Id);

            _expectedLoan.Should().NotBeNull();
            _expectedLoan.Id.Should().Be(1);
            _expectedLoan.Client.Should().Be("Bruno Wagner");
        }

        [Test]
        public void LoanRepository_GetInvalidId_ShouldBeNull()
        {
            _book.Id = 3;

            _expectedLoan = _repository.Get(_loan.Id);

            _expectedLoan.Should().BeNull();
        }

        [Test]
        public void LoanRepository_GetAll_ShouldBeOk()
        {
            var listExpectedLoan = _repository.GetAll();

            listExpectedLoan.Should().NotBeNull();
            listExpectedLoan.Last().Id.Should().Be(1);
        }

        [Test]
        public void LoanRepository_Update_ShouldBeOk()
        {
            _book.Id = 1;
            _loan = ObjectMother.GetLoanSQL(_book);
            _loan.Id = 1;
            _loan.Client = "Alterado";

            _expectedLoan = _repository.Update(_loan);

            _expectedLoan.Should().NotBeNull();
            _expectedLoan.Id.Should().Be(1);
            _expectedLoan.Client.Should().Be("Alterado");
        }

        [Test]
        public void LoanRepository_UpdateInvalidId_ShouldBeNull()
        {
            _book.Id = 1;
            _loan = ObjectMother.GetLoanSQL(_book);
            _loan.Id = 2;

            _expectedLoan = _repository.Get(_loan.Id);

            _expectedLoan.Should().BeNull();
        }

        [Test]
        public void LoanRepository_Delete_ShouldBeOk()
        {
            _loan.Id = 1;

            _repository.Delete(_loan.Id);
            _expectedLoan = _repository.Get(_loan.Id);

            _expectedLoan.Should().BeNull();
        }
    }
}
