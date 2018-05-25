using DonaRosangela.App.Features.Loans;
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

namespace DonaRosangela.App.Tests.Features.Loans
{
    [TestFixture]
    public class LoanServiceTest
    {
        Loan _loan;
        Loan _expectedLoan;
        Mock<Book> _book;
        Mock<ILoanRepository> _repository;
        ILoanService _service;

        [SetUp]
        public void Initialize()
        {
            _loan = new Loan();
            _expectedLoan = new Loan();
            _book = new Mock<Book>();
            _repository = new Mock<ILoanRepository>();
            _service = new LoanService(_repository.Object);
        }

        [Test]
        public void LoanService_Add_ShouldBeOk()
        {
            _book.Object.Id = 1;
            _book.Object.Availability = true;
            _loan = ObjectMother.GetLoan(_book.Object);
            _repository.Setup(rp => rp.Add(_loan)).Returns(_loan);

            _expectedLoan = _service.Add(_loan);

            _expectedLoan.Should().NotBeNull();
            _expectedLoan.Id.Should().Be(1);
            _repository.Verify(rp => rp.Add(_loan));
        }

        [Test]
        public void LoanService_Get_ShouldBeOk()
        {
            _loan = ObjectMother.GetLoan(_book.Object);
            _repository.Setup(rp => rp.Get(_loan.Id)).Returns(_loan);

            _expectedLoan = _service.Get(_loan);

            _expectedLoan.Should().NotBeNull();
            _expectedLoan.Id.Should().Be(1);
            _repository.Verify(rp => rp.Get(_loan.Id));
        }

        [Test]
        public void LoanSerivce_GetAll_ShouldBeOk()
        {
            var listLoan = new List<Loan>();
            listLoan.Add(ObjectMother.GetLoan(_book.Object));
            _loan = ObjectMother.GetLoan(_book.Object);
            _repository.Setup(rp => rp.GetAll()).Returns(listLoan);

            var listExpectedLoan = _service.GetAll();

            listExpectedLoan.Should().NotBeNull();
            listExpectedLoan.Last().Id.Should().Be(1);
            _repository.Verify(rp => rp.GetAll());
        }

        [Test]
        public void LoanSevice_Update_ShouldBeOk()
        {
            _book.Object.Id = 1;
            _book.Object.Availability = true;
            _loan = ObjectMother.GetLoan(_book.Object);
            _loan.Client = "Carol Arruda";
            _repository.Setup(rp => rp.Update(_loan)).Returns(_loan);

            _expectedLoan = _service.Update(_loan);

            _expectedLoan.Should().NotBeNull();
            _expectedLoan.Id.Should().Be(1);
            _expectedLoan.Client.Should().Be("Carol Arruda");
            _repository.Verify(rp => rp.Update(_loan));
        }

        [Test]
        public void LoanService_Delete_ShouldBeOk()
        {
            _book.Object.Id = 1;
            _book.Object.Availability = true;
            _loan = ObjectMother.GetLoan(_book.Object);
            _repository.Setup(rp => rp.Delete(_loan.Id));
            _repository.Setup(rp => rp.Get(_loan.Id));

            _service.Delete(_loan);
            _expectedLoan = _service.Get(_loan);

            _expectedLoan.Should().BeNull();
            _repository.Verify(rp => rp.Delete(_loan.Id));
        }
    }
}
