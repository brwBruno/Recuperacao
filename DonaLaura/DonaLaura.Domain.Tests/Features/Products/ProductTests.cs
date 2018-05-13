using DonaLaura.Common.Tests.Base;
using DonaLaura.Domain.Features.Products;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Tests.Features.Products
{
    [TestFixture]
    public class ProductTests
    {
        Product _product;
        [SetUp]
        public void SetUp()
        {
            _product = new Product();
        }

        [Test]
        public void Product_ValidProduct_ShouldBeOk()
        {
            _product = ObjectMother.GetProduct();
            _product.Validate();

            _product.Id.Should().Be(_product.Id);
            _product.Name.Should().Be(_product.Name);
        }

        [Test]
        public void Product_InvalidName_ShouldFail()
        {
            _product = ObjectMother.GetInvalidNameProduct();

            Action Act = () => _product.Validate();

            Act.Should().Throw<ProductMinCharacterException>();
        }

        [Test]
        public void Product_InvalidCostPrice_ShouldFail()
        {
            _product = ObjectMother.GetInvalidCostPriceProduct();

            Action Act = () => _product.Validate();

            Act.Should().Throw<ProductCostBiggerSaleException>();
        }

        [Test]
        public void Product_InvalidExpiration_ShouldFail()
        {
            _product = ObjectMother.GetInvalidExpirationProduct();

            Action Act = () => _product.Validate();

            Act.Should().Throw<ProductExpirationDateSmallerFabricationDateException>();
        }

        [TearDown]
        public void TearDown()
        {
            _product = null;
        }
    }
}
