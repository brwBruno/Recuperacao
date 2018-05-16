using DonaLaura.Common.Tests.Base;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Infra.Base;
using DonaLaura.Infra.Data.Features.Products;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        IList<Product> _listExpectedProduct;

        [SetUp]
        public void SetUp()
        {
            _product = new Product();
            _expectedProduct = new Product();
            _repository = new ProductRepository();
            _listExpectedProduct = new List<Product>();
            ExtensionSql.SeedDbWithoutDependence();
        }

        [Test]
        public void ProductRepository_Add_ShouldBeOk()
        {
            _product = ObjectMother.GetProductSql();

            _expectedProduct = _repository.Add(_product);

            _expectedProduct.Should().NotBeNull();
            _expectedProduct.Name.Should().Be(_product.Name);
        }

        [Test]
        public void ProductRepository_AddEmptyName_ShouldFail()
        {
            _product = ObjectMother.GetProductSqlEmptyName();

            Action Act = () => _repository.Add(_product);

            Act.Should().Throw<SqlException>();
        }

        [Test]
        public void ProductRepository_Get_ShouldBeOk()
        {
            var id = 1;

            _expectedProduct = _repository.Get(id);

            _expectedProduct.Should().NotBeNull();
            _expectedProduct.Id.Should().Be(id);
        }

        [Test]
        public void ProductRepository_GetInvalidId_ShouldFail()
        {
            var id = 10;

            _expectedProduct = _repository.Get(id);

            _expectedProduct.Should().BeNull();
        }

        [Test]
        public void ProductRepository_Update_ShouldBeOk()
        {
            _product = ObjectMother.GetProductSql();
            _product.Name = "Alterado";

            _expectedProduct = _repository.Update(_product);

            _expectedProduct.Should().NotBeNull();
            _expectedProduct.Name.Should().Be("Alterado");
        }

        [Test]
        public void ProductRepository_UpdateEmptyName_ShouldFail()
        {
            _product = ObjectMother.GetProductSqlEmptyName();
            _product.Id = 1;

            Action Act = () => _repository.Update(_product);

            Act.Should().Throw<SqlException>();
        }

        [Test]
        public void ProductRepository_GetAll_ShouldBeOk()
        {
            _product = ObjectMother.GetProductSql();
            _product.Id = 1;
            _product = _repository.Get(_product.Id);

            _listExpectedProduct = _repository.GetAll();

            _listExpectedProduct.Should().NotBeNull();
            _listExpectedProduct.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void ProductRepository_Delete_ShouldBeOk()
        {
            _product = ObjectMother.GetProductSql();
            _product.Id = 1;

            _repository.Delete(_product.Id);
            _expectedProduct = _repository.Get(_product.Id);

            _expectedProduct.Should().BeNull();
        }

        [TearDown]
        public void TearDown()
        {
            _expectedProduct = null;
            _repository = null;
        }
    }
}
