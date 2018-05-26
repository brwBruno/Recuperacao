using DonaRosangela.App.Features.Loans;
using DonaRosangela.Common.Tests.Base;
using DonaRosangela.Domain.Exceptions;
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

namespace DonaRosangela.Integration.Tests.Features.Loans
{
    [TestFixture]
    public class LoanIntegrationTests
    {
        Book _book;
        Loan _loan;
        Loan _expectedLoan;
        ILoanRepository _repository;
        ILoanService _service;

        [SetUp]
        public void Initialize()
        {
            _book = new Book();
            _loan = new Loan();
            _expectedLoan = new Loan();
            _repository = new LoanRepository();
            _service = new LoanService(_repository);
            BaseSql.SeedDbTBLoan();
        }

        [Test]
        public void LoanIntegration_Add_ShouldBeOk()
        {
            _book = ObjectMother.GetBook();
            _loan = ObjectMother.GetLoanSQL(_book);

            _expectedLoan = _service.Add(_loan);

            _expectedLoan.Should().NotBeNull();
            _expectedLoan.Id.Should().Be(2);
        }

        [Test]
        public void LoanIntegration_AddInvalidClient_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _loan = ObjectMother.GetLoanInvalidClient(_book);

            Action act = () => _service.Add(_loan);

            act.Should().Throw<LoanClientMinCaractersException>();
        }

        [Test]
        public void LoanIntegration_AddInvalidDevolution_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _loan = ObjectMother.GetLoanInvalidDevolution(_book);

            Action act = () => _service.Add(_loan);

            act.Should().Throw<LoanInvalidDevolutionException>();
        }

        [Test]
        public void LoanIntegration_AddUnavailableBook_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Availability = false;
            _loan = ObjectMother.GetLoan(_book);

            Action act = () => _service.Add(_loan);

            act.Should().Throw<LoanUnavailableBookException>();
        }

        [Test]
        public void LoanIntegration_Get_ShouldBeOk()
        {
            _loan.Id = 1;

            _expectedLoan = _service.Get(_loan);

            _expectedLoan.Should().NotBeNull();
            _expectedLoan.Id.Should().Be(1);
        }

        [Test]
        public void LoanIntegration_GetInvalidId_ShouldBeException()
        {
            _loan.Id = 0;

            Action act = () => _service.Get(_loan);

            act.Should().Throw<InvalidIdException>();
        }

        [Test]
        public void LoanIntegration_GetAll_ShouldBeOk()
        {
            var listExpectedLoan = _service.GetAll();

            listExpectedLoan.Should().NotBeNull();
            listExpectedLoan.Last().Id.Should().Be(1);
        }

        [Test]
        public void LoanIntegration_Update_ShouldBeOk()
        {
            _book = ObjectMother.GetBook();
            _loan = ObjectMother.GetLoanSQL(_book);
            _loan.Client = "Alterado";
            _loan.Id = 1;

            _expectedLoan = _service.Update(_loan);

            _expectedLoan.Should().NotBeNull();
            _expectedLoan.Id.Should().Be(1);
            _expectedLoan.Client.Should().Be("Alterado");
        }

        [Test]
        public void LoanIntegration_UpdateInvalidClient_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _loan = ObjectMother.GetLoanInvalidClient(_book);

            Action act = () => _service.Update(_loan);

            act.Should().Throw<LoanClientMinCaractersException>();
        }

        [Test]
        public void LoanIntegration_UpdateInvalidDevolution_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _loan = ObjectMother.GetLoanInvalidDevolution(_book);

            Action act = () => _service.Update(_loan);

            act.Should().Throw<LoanInvalidDevolutionException>();
        }

        [Test]
        public void LoanIntegration_UpdateUnavailableBook_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Availability = false;
            _loan = ObjectMother.GetLoan(_book);

            Action act = () => _service.Update(_loan);

            act.Should().Throw<LoanUnavailableBookException>();
        }

        [Test]
        public void LoanIntegration_UpdateInvalidId_ShouldBeException()
        {
            _loan.Id = 0;

            Action act = () => _service.Update(_loan);

            act.Should().Throw<InvalidIdException>();
        }

        [Test]
        public void LoanIntegration_Delete_ShouldBeOk()
        {
            _loan.Id = 1;

            _service.Delete(_loan);
            _expectedLoan = _service.Get(_loan);

            _expectedLoan.Should().BeNull();
        }

        [Test]
        public void LoanIntegration_DeleteInvalidId_ShouldBeException()
        {
            _loan.Id = 0;

            Action act = () => _service.Delete(_loan);

            act.Should().Throw<InvalidIdException>();
        }
    }
}
