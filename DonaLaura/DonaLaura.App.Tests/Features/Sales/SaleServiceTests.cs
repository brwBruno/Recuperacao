using DonaLaura.App.Features.Sales;
using DonaLaura.Common.Tests.Base;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.App.Tests.Features.Sales
{
    [TestFixture]
    public class SaleServiceTests
    {
        Sale _sale;
        ISaleService _service;
        Mock<ISaleRepository> _repository;
        Mock<Product> _product;
        IList<Sale> _listSale;

        [SetUp]
        public void SetUp()
        {
            _sale = new Sale();
            _repository = new Mock<ISaleRepository>();
            _service = new SaleService(_repository.Object);
            _product = new Mock<Product>();
            _listSale = new List<Sale>();
        }

        [Test]
        public void SaleService_Add_ShouldBeOk()
        {
            _product.Object.Availability = 1;
            _sale = ObjectMother.GetSale(_product.Object);

            Action Act = () => _service.Add(_sale);

            Act.Should().NotThrow();
            _repository.Verify(r => r.Add(_sale));
        }

        [Test]
        public void SaleService_AddEmptyClient_ShouldFail()
        {
            _sale = ObjectMother.GetSaleEmptyClient(_product.Object);

            Action Act = () => _service.Add(_sale);

            Act.Should().Throw<SaleEmptyClienteException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void SaleSeervice_AddEmptyProduct_ShouldFail()
        {
            _sale = ObjectMother.GetSaleEmptyProductSale();

            Action Act = () => _service.Add(_sale);

            Act.Should().Throw<SaleEmptyOrNullProductSaleException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void SaleService_AddEmptyAmount_ShouldFail()
        {
            _sale = ObjectMother.GetSaleEmptyAmount(_product.Object);

            Action Act = () => _service.Add(_sale);

            Act.Should().Throw<SaleEmptyOrZeroAmountException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void SaleService_Update_ShoudlBeOk()
        {
            _product.Object.Availability = 1;
            _sale = ObjectMother.GetSale(_product.Object);
            _sale.Client = "Renan Zapelini";

            Action Act = () => _service.Update(_sale);

            Act.Should().NotThrow();
            _repository.Verify(r => r.Update(_sale));
        }

        [Test]
        public void SaleService_UpdateEmptyClient_ShouldFail()
        {
            _sale = ObjectMother.GetSaleEmptyClient(_product.Object);

            Action Act = () => _service.Update(_sale);

            Act.Should().Throw<SaleEmptyClienteException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void SaleSeervice_UpdateEmptyProduct_ShouldFail()
        {
            _sale = ObjectMother.GetSaleEmptyProductSale();

            Action Act = () => _service.Update(_sale);

            Act.Should().Throw<SaleEmptyOrNullProductSaleException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void SaleService_UpdateEmptyAmount_ShouldFail()
        {
            _sale = ObjectMother.GetSaleEmptyAmount(_product.Object);

            Action Act = () => _service.Update(_sale);

            Act.Should().Throw<SaleEmptyOrZeroAmountException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void SaleService_Get_ShouldBeOk()
        {
            _sale = ObjectMother.GetSale(_product.Object);

            Action Act = () => _service.Get(_sale);

            Act.Should().NotThrow();
            _repository.Verify(r => r.Get(_sale.Id));
        }

        [Test]
        public void SaleService_GetInvalidId_ShouldFail()
        {
            _sale = ObjectMother.GetInvalidIdSale(_product.Object);

            Action Act = () => _service.Get(_sale);

            Act.Should().Throw<InvalidIdException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void SaleService_GetAll_ShouldBeOk()
        {
            _listSale.Add(ObjectMother.GetSale(_product.Object));

            Action Act = () => _service.GetAll();

            Act.Should().NotThrow();
            _repository.Verify(r => r.GetAll());
        }

        [Test]
        public void SaleService_Delete_ShouldBeOk()
        {
            _sale = ObjectMother.GetSale(_product.Object);

            Action Act = () => _service.Delete(_sale);

            Act.Should().NotThrow();
            _repository.Verify(r => r.Delete(_sale.Id));
        }

        [Test]
        public void SaleService_DeleteInvalidId_ShouldFail()
        {
            _sale = ObjectMother.GetInvalidIdSale(_product.Object);

            Action Act = () => _service.Delete(_sale);

            Act.Should().Throw<InvalidIdException>();
            _repository.VerifyNoOtherCalls();
        }

        [TearDown]
        public void TearDown()
        {
            _sale = null;
            _repository = null;
            _service = null;
            _product = null;
        }
    }
}
