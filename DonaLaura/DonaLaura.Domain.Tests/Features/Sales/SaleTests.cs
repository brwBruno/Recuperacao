using DonaLaura.Common.Tests.Base;
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

namespace DonaLaura.Domain.Tests.Features.Sales
{
    [TestFixture]
    public class SaleTests
    {
        Sale _sale;
        Mock<Product> _productSale;

        [SetUp]
        public void SetUp()
        {
            _sale = new Sale();
            _productSale = new Mock<Product>();
        }

        [Test]
        public void Sale_ValidSale_ShouldBeOk()
        {
            _productSale.Object.Id = 1;
            _productSale.Object.CostPrice = 2;
            _productSale.Object.SalePrice = 5;
            _productSale.Object.Availability = 1;
            _sale = ObjectMother.GetSale(_productSale.Object);
            var profit = 9;
            _sale.Validate();

            _sale.Profit.Should().Be(profit);
            _sale.Client.Should().Be("Bruno Ribeiro");
            _sale.ProductSale.Should().Be(_productSale.Object);
        }

        [Test]
        public void Sale_InvalidClient_ShouldFail()
        {
            _sale = ObjectMother.GetSaleEmptyClient(_productSale.Object);

            Action Act = () => _sale.Validate();

            Act.Should().Throw<SaleEmptyClienteException>();
        }

        [Test]
        public void Sale_InvalidAmount_ShouldFail()
        {
            _sale = ObjectMother.GetSaleEmptyAmount(_productSale.Object);

            Action Act = () => _sale.Validate();

            Act.Should().Throw<SaleEmptyOrZeroAmountException>();
        }

        [Test]
        public void Sale_InvalidProductSale_ShouldFail()
        {
            _sale = ObjectMother.GetSaleEmptyProductSale();

            Action Act = () => _sale.Validate();

            Act.Should().Throw<SaleEmptyOrNullProductSaleException>();
        }

        [Test]
        public void Sale_UnavailableSale_ShouldFail()
        {
            _sale = ObjectMother.GetSale(_productSale.Object);
            _productSale.Object.Availability = 0;

            Action Act = () => _sale.Validate();

            Act.Should().Throw<SaleNotAvailabilityProductException>();
        }

        [TearDown]
        public void TearDonw()
        {
            _sale = null;
            _productSale = null;
        }

    }
}
