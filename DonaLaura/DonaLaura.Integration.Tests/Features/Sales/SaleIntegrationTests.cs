using DonaLaura.App.Features.Sales;
using DonaLaura.Common.Tests.Base;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using DonaLaura.Infra.Base;
using DonaLaura.Infra.Data.Features.Sales;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Integration.Tests.Features.Sales
{
    [TestFixture]
    class SaleIntegrationTests
    {
        Sale _sale;
        Sale _expectedSale;
        Product _product;
        ISaleRepository _repository;
        ISaleService _service;

        [SetUp]
        public void SetUp()
        {
            _sale = new Sale();
            _expectedSale = new Sale();
            _product = new Product();
            _repository = new SaleRepository();
            _service = new SaleService(_repository);
            ExtensionSql.SeedDb();
        }

        [Test]
        public void SaleIntegration_Add_ShouldBeOk()
        {
            _product.Id = 1;
            _product.Availability = 1;
            _sale = ObjectMother.GetSaleSql(_product);

            _expectedSale = _service.Add(_sale);

            _expectedSale.Should().NotBeNull();
            _expectedSale.Id.Should().Be(_sale.Id);
        }

        [Test]
        public void SaleIntegration_AddEmptyClient_ShouldFail()
        {
            _product.Id = 1;
            _product.Availability = 1;
            _sale = ObjectMother.GetSaleSqlEmptyClient(_product);

            Action Act = () => _service.Add(_sale);

            Act.Should().Throw<SaleEmptyClienteException>();
        }

        [Test]
        public void SaleIntegratiom_AddEmptyInvalidProduct_ShouldFail()
        {
            _sale = ObjectMother.GetSaleSql(_product);
            _sale.ProductSale = null;

            Action Act = () => _service.Add(_sale);

            Act.Should().Throw<SaleEmptyOrNullProductSaleException>();
        }

        [Test]
        public void SaleIntegration_AddZeroAmount_ShouldFail()
        {
            _product.Id = 1;
            _product.Availability = 1;
            _sale = ObjectMother.GetSaleSql(_product);
            _sale.Amount = 0;

            Action Act = () => _service.Add(_sale);

            Act.Should().Throw<SaleEmptyOrZeroAmountException>();
        }

        [Test]
        public void SaleIntegration_AddNotAvailability_ShouldFail()
        {
            _product.Id = 1;
            _product.Availability = 0;
            _sale = ObjectMother.GetSaleSql(_product);

            Action Act = () => _service.Add(_sale);

            Act.Should().Throw<SaleNotAvailabilityProductException>();
        }

        [Test]
        public void SaleIntegrations_Update_ShouldBeOk()
        {
            _product.Id = 1;
            _product.Availability = 1;
            _sale = ObjectMother.GetSaleSql(_product);
            var alteredCliente = "Vitor Nikifork";
            _sale.Client = alteredCliente;

            _expectedSale = _service.Update(_sale);

            _expectedSale.Should().NotBeNull();
            _expectedSale.Id.Should().Be(_sale.Id);
            _expectedSale.Client.Should().Be(alteredCliente);
        }

        [Test]
        public void SaleIntegration_UpdateEmptyClient_ShouldFail()
        {
            _product.Id = 1;
            _product.Availability = 1;
            _sale = ObjectMother.GetSaleSqlEmptyClient(_product);

            Action Act = () => _service.Update(_sale);

            Act.Should().Throw<SaleEmptyClienteException>();
        }

        [Test]
        public void SaleIntegratiom_UpdateEmptyInvalidProduct_ShouldFail()
        {
            _sale = ObjectMother.GetSaleSql(_product);
            _sale.ProductSale = null;

            Action Act = () => _service.Update(_sale);

            Act.Should().Throw<SaleEmptyOrNullProductSaleException>();
        }

        [Test]
        public void SaleIntegration_UpdateZeroAmount_ShouldFail()
        {
            _product.Id = 1;
            _product.Availability = 1;
            _sale = ObjectMother.GetSaleSql(_product);
            _sale.Amount = 0;

            Action Act = () => _service.Update(_sale);

            Act.Should().Throw<SaleEmptyOrZeroAmountException>();
        }

        [Test]
        public void SaleIntegration_UpdateNotAvailability_ShouldFail()
        {
            _product.Id = 1;
            _product.Availability = 0;
            _sale = ObjectMother.GetSaleSql(_product);

            Action Act = () => _service.Update(_sale);

            Act.Should().Throw<SaleNotAvailabilityProductException>();
        }

        [Test]
        public void SaleIntegration_Get_ShouldBeOk()
        {
            _sale.Id = 1;

            _expectedSale = _service.Get(_sale);

            _expectedSale.Should().NotBeNull();
            _expectedSale.Id.Should().Be(_sale.Id);
        }

        [Test]
        public void SaleIntegration_GetInvalidId_ShouldFail()
        {
            _sale.Id = 0;

            Action Act = () => _service.Get(_sale);

            Act.Should().Throw<InvalidIdException>();
        }

        [Test]
        public void SaleIntegration_GetAll_ShouldBeOk()
        {
            var _expectedListSale = _service.GetAll();

            _expectedListSale.Should().NotBeNull();
            _expectedListSale.Count().Should().BeGreaterThan(0);
            _expectedListSale.Last().Id.Should().Be(1);
        }

        [Test]
        public void SaleIntegration_Delete_ShouldBeOk()
        {
            _product.Id = 1;
            _product.Availability = 1;
            _sale = ObjectMother.GetSaleSql(_product);
            _sale.Id = 1;

            _service.Delete(_sale);
            _expectedSale = _repository.Get(_sale.Id);

            _expectedSale.Should().BeNull();
        }

        [Test]
        public void SaleIntegration_DeleteInvalidId_ShouldFail()
        {
            _sale.Id = 0;

            Action Act = () => _service.Delete(_sale);

            Act.Should().Throw<InvalidIdException>();
        }


        [TearDown]
        public void TearDown()
        {
            _sale = null;
            _expectedSale = null;
            _product = null;
            _repository = null;
            _service = null;
        }
    }
}
