using DonaLaura.App.Features.Products;
using DonaLaura.Common.Tests.Base;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Products;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.App.Tests.Features.Products
{
    [TestFixture]
    public class ProductServiceTests
    {
        Product _product;
        Product _expectedProduct;
        Mock<IProductRepository> _repository;
        IProductService _service;
        IList<Product> _listProduct;
        IList<Product> _expectedListProduct;

        [SetUp]
        public void SetUp()
        {
            _product = new Product();
            _repository = new Mock<IProductRepository>();
            _service = new ProductService(_repository.Object);
            _expectedProduct = new Product();
            _listProduct = new List<Product>();
            _expectedListProduct = new List<Product>();
        }

        [Test]
        public void ProductService_Add_ShouldBeOk()
        {
            _product = ObjectMother.GetProduct();
            _repository.Setup(r => r.Add(_product)).Returns(_product);

            _expectedProduct = _service.Add(_product);

            _expectedProduct.Should().Be(_product);
        }

        [Test]
        public void ProductService_AddInvalidName_ShouldFail()
        {
            _product = ObjectMother.GetInvalidNameProduct();

            Action Act = () => _service.Add(_product);

            Act.Should().Throw<ProductMinCharacterException>();
        }

        [Test]
        public void ProductService_AddInvalidCostPrice_ShouldFail()
        {
            _product = ObjectMother.GetInvalidCostPriceProduct();

            Action Act = () => _service.Add(_product);

            Act.Should().Throw<ProductCostBiggerSaleException>();
        }

        [Test]
        public void ProductService_AddInvalidExpiration_ShouldFail()
        {
            _product = ObjectMother.GetInvalidExpirationProduct();

            Action Act = () => _service.Add(_product);

            Act.Should().Throw<ProductExpirationDateSmallerFabricationDateException>();
        }

        [Test]
        public void ProductService_Update_ShouldBeOk()
        {
            _product = ObjectMother.GetProduct();
            _repository.Setup(r => r.Update(_product)).Returns(_product);

            _expectedProduct = _service.Update(_product);

            _expectedProduct.Should().Be(_product);
            _expectedProduct.Name.Should().Be(_product.Name);
        }

        [Test]
        public void ProductService_UpdateInvalidName_ShouldFail()
        {
            _product = ObjectMother.GetInvalidNameProduct();

            Action Act = () => _service.Update(_product);

            Act.Should().Throw<ProductMinCharacterException>();
        }

        [Test]
        public void ProductService_UpdateInvalidCostPrice_ShouldFail()
        {
            _product = ObjectMother.GetInvalidCostPriceProduct();

            Action Act = () => _service.Update(_product);

            Act.Should().Throw<ProductCostBiggerSaleException>();
        }

        [Test]
        public void ProductService_UpdateInvalidExpiration_ShouldFail()
        {
            _product = ObjectMother.GetInvalidExpirationProduct();

            Action Act = () => _service.Update(_product);

            Act.Should().Throw<ProductExpirationDateSmallerFabricationDateException>();
        }

        [Test]
        public void ProductService_Get_ShouldBeOk()
        {
            _product = ObjectMother.GetProduct();
            _repository.Setup(r => r.Get(_product.Id)).Returns(_product);

            _expectedProduct = _service.Get(_product);

            _expectedProduct.Id.Should().Be(_product.Id);
            _expectedProduct.Name.Should().Be(_product.Name);
        }

        [Test]
        public void ProductService_GetInvalidId_ShouldFail()
        {
            _product = ObjectMother.GetInvalidIdProduct();

            Action Act = () => _service.Get(_product);

            Act.Should().Throw<InvalidIdException>();
            _repository.VerifyNoOtherCalls();
        }


        [Test]
        public void ProductService_Delete_ShouldBeOk()
        {
            _product = ObjectMother.GetProduct();

            Action Act = () => _service.Delete(_product);

            Act.Should().NotThrow();
            _repository.Verify(r => r.Delete(_product.Id));
        }

        [Test]
        public void ProductService_DeleteInvalidId_ShouldFail()
        {
            _product = ObjectMother.GetInvalidIdProduct();

            Action Act = () => _service.Delete(_product);

            Act.Should().Throw<InvalidIdException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProductService_GetAll_ShouldBeOk()
        {
            _listProduct = ObjectMother.GetListPorduct();
            _repository.Setup(r => r.GetAll()).Returns(_listProduct);

            _expectedListProduct = _service.GetAll();

            _expectedListProduct.Count().Should().BeGreaterThan(0);
        }

        [TearDown]
        public void TearDown()
        {
            _product = null;
            _service = null;
        }
        
    }
}
