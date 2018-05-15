using DonaLaura.App.Features.Products;
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

namespace DonaLaura.Integration.Tests
{
    [TestFixture]
    public class ProductIntegrationTests
    {
        Product _product;
        Product _expectedProduct;
        ProductService _service;
        IProductRepository _repository;
        IList<Product> _listExpectedProduct;

        [SetUp]
        public void SetUp()
        {
            _repository = new ProductRepository();
            _service = new ProductService(_repository);
            _product = new Product();
            _expectedProduct = new Product();
            _listExpectedProduct = new List<Product>();
            ExtensionSql.SeedDb();
        }

        [Test]
        public void ProductInegration_Add_ShouldBeOk()
        {
            _product = ObjectMother.GetProductSql();

            _expectedProduct = _service.Add(_product);

            _expectedProduct.Should().NotBeNull();
            _expectedProduct.Name.Should().Be(_product.Name);
        }

        [Test]
        public void ProductIntegration_Get_ShouldBeOK()
        {
            _product = ObjectMother.GetProductSql();
            _product.Id = 1;

            _expectedProduct = _service.Get(_product);

            _expectedProduct.Should().NotBeNull();
            _expectedProduct.Id.Should().Be(_product.Id);
            _expectedProduct.Name.Should().Be(_product.Name);
        }

        [Test]
        public void ProductIntegration_GetAll_ShouldBeOk()
        {
            _listExpectedProduct = _service.GetAll();

            _listExpectedProduct.Should().NotBeNull();
            _listExpectedProduct.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void ProductIntegration_Delete_ShouldBeOk()
        {
            _product = ObjectMother.GetProductSql();
            _product.Id = 1;

            _service.Delete(_product);
            _expectedProduct = _service.Get(_product);

            _expectedProduct.Should().BeNull();
        }

        [TearDown]
        public void TearDown()
        {
            _repository = null;
            _service = null;
            _product = null;
            _expectedProduct = null;
            _listExpectedProduct = null;
        }
    }
}
