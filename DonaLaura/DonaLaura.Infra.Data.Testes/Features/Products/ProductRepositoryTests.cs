using DonaLaura.Common.Tests.Base;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Infra.Base;
using DonaLaura.Infra.Data.Features.Products;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Testes.Features.Products
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        IProductRepository _repository;
        Product _product;
        Product _expectedProduct;

        [SetUp]
        public void SetUp()
        {
            _product = new Product();
            _expectedProduct = new Product();
            _repository = new ProductRepository();
        }

        [Test]
        public void ProductRepository_Add_ShouldBeOk()
        {
            _product = ObjectMother.GetProductSql();

            _expectedProduct = _repository.Add(_product);

            _expectedProduct.Should().NotBeNull();
            _expectedProduct.Name.Should().Be(_product.Name);
        }

        [TearDown]
        public void TearDown()
        {
            _expectedProduct = null;
            _repository = null;
        }
    }
}
