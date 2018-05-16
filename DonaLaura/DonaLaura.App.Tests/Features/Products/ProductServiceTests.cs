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
        Mock<IProductRepository> _repository;
        IProductService _service;
        IList<Product> _listProduct;

        [SetUp]
        public void SetUp()
        {
            _product = new Product();
            _repository = new Mock<IProductRepository>();
            _service = new ProductService(_repository.Object);
            _listProduct = new List<Product>();
        }

        [Test]
        public void ProductService_Add_ShouldBeOk()
        {
            _product = ObjectMother.GetProduct();

            Action Act = () => _service.Add(_product);

            Act.Should().NotThrow();
            _repository.Verify(r => r.Add(_product));
        }

        [Test]
        public void ProductService_AddInvalidName_ShouldFail()
        {
            _product = ObjectMother.GetInvalidNameProduct();

            Action Act = () => _service.Add(_product);

            Act.Should().Throw<ProductInvalidOrNullNameException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProductService_AddInvalidCostPrice_ShouldFail()
        {
            _product = ObjectMother.GetInvalidCostPriceProduct();

            Action Act = () => _service.Add(_product);

            Act.Should().Throw<ProductCostBiggerSaleException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProductService_AddInvalidExpiration_ShouldFail()
        {
            _product = ObjectMother.GetInvalidExpirationProduct();

            Action Act = () => _service.Add(_product);

            Act.Should().Throw<ProductExpirationDateSmallerFabricationDateException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProductService_Update_ShouldBeOk()
        {
            _product = ObjectMother.GetProduct();

            Action Act = () => _service.Update(_product);

            Act.Should().NotThrow();
            _repository.Verify(r => r.Update(_product));
        }

        [Test]
        public void ProductService_UpdateInvalidName_ShouldFail()
        {
            _product = ObjectMother.GetInvalidNameProduct();

            Action Act = () => _service.Update(_product);

            Act.Should().Throw<ProductInvalidOrNullNameException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProductService_UpdateInvalidCostPrice_ShouldFail()
        {
            _product = ObjectMother.GetInvalidCostPriceProduct();

            Action Act = () => _service.Update(_product);

            Act.Should().Throw<ProductCostBiggerSaleException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProductService_UpdateInvalidExpiration_ShouldFail()
        {
            _product = ObjectMother.GetInvalidExpirationProduct();

            Action Act = () => _service.Update(_product);

            Act.Should().Throw<ProductExpirationDateSmallerFabricationDateException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProductService_Get_ShouldBeOk()
        {
            _product = ObjectMother.GetProduct();

            Action Act = () => _service.Get(_product);

            Act.Should().NotThrow();
            _repository.Verify(r => r.Get(_product.Id));
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

            Action Act = () => _service.GetAll();

            Act.Should().NotThrow();
            _repository.Verify(r => r.GetAll());
        }

        [TearDown]
        public void TearDown()
        {
            _product = null;
            _repository = null;
            _service = null;
            _listProduct = null;
        }
        
    }
}
