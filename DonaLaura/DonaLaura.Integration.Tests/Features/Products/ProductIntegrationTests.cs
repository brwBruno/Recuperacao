using DonaLaura.App.Features.Products;
using DonaLaura.Common.Tests.Base;
using DonaLaura.Domain.Exceptions;
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

namespace DonaLaura.Integration.Tests.Features.Products
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
            ExtensionSql.SeedDbWithoutDependence();
        }

        [Test]
        public void ProductInegration_Add_ShouldBeOk()
        {
            _product = ObjectMother.GetProductSql();
            var id = 2;

            _expectedProduct = _service.Add(_product);

            _expectedProduct.Should().NotBeNull();
            _expectedProduct.Name.Should().Be(_product.Name);
            _expectedProduct.Id.Should().Be(id);
        }

        [Test]
        public void ProductIntegration_AddEmptyName_ShouldFail()
        {
            _product = ObjectMother.GetProductSqlEmptyName();

            Action Act = () => _service.Add(_product);

            Act.Should().Throw<ProductInvalidOrNullNameException>();
        }

        [Test]
        public void ProductIntegration_AddInvalidCost_ShouldFail()
        {
            _product = ObjectMother.GetProductSql();
            _product.CostPrice = 30;

            Action Act = () => _service.Add(_product);

            Act.Should().Throw<ProductCostBiggerSaleException>();
        }

        [Test]
        public void ProductIntegration_AddInvalidManufacture_ShouldFail()
        {
            _product = ObjectMother.GetProductSql();
            _product.Manufacture = DateTime.Now.AddDays(5);

            Action Act = () => _service.Add(_product);

            Act.Should().Throw<ProductExpirationDateSmallerFabricationDateException>();
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
        public void ProductIntegration_GetInvalidId_ShouldFail()
        {
            _product = ObjectMother.GetProductSql();

            Action Act = () => _service.Get(_product);

            Act.Should().Throw<InvalidIdException>();
        }

        [Test]
        public void ProductIntegration_Update_ShouldBeOk()
        {
            _product = ObjectMother.GetProductSql();
            _product.Id = 1;
            _product.Name = "Sabonete";

            _expectedProduct = _service.Update(_product);

            _expectedProduct.Should().NotBeNull();
            _expectedProduct.Name.Should().Be("Sabonete");
            _expectedProduct.Id.Should().Be(_product.Id);
        }

        [Test]
        public void ProductIntegration_UpdateEmptyName_ShouldFail()
        {
            _product = ObjectMother.GetProductSqlEmptyName();

            Action Act = () => _service.Update(_product);

            Act.Should().Throw<ProductInvalidOrNullNameException>();
        }

        [Test]
        public void ProductIntegration_UpdateInvalidCost_ShouldFail()
        {
            _product = ObjectMother.GetProductSql();
            _product.CostPrice = 30;

            Action Act = () => _service.Update(_product);

            Act.Should().Throw<ProductCostBiggerSaleException>();
        }

        [Test]
        public void ProductIntegration_UpdateInvalidManufacture_ShouldFail()
        {
            _product = ObjectMother.GetProductSql();
            _product.Manufacture = DateTime.Now.AddDays(5);

            Action Act = () => _service.Update(_product);

            Act.Should().Throw<ProductExpirationDateSmallerFabricationDateException>();
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

        [Test]
        public void ProductIntegration_DeleteInvalidId_ShouldFail()
        {
            _product = ObjectMother.GetProductSql();

            Action Act = () => _service.Delete(_product);

            Act.Should().Throw<InvalidIdException>();
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
