using DonaLaura.Common.Tests.Base;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using DonaLaura.Infra.Base;
using DonaLaura.Infra.Data.Features.Sales;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Testes.Features.Sales
{
    [TestFixture]
    public class SaleRepositoryTests
    {
        Sale _sale;
        Sale _expectedSale;
        Mock<Product> _product;
        ISaleRepository _repository;
        IList<Sale> _expectedListSale;

        [SetUp]
        public void SetUp()
        {
            _sale = new Sale();
            _expectedSale = new Sale();
            _repository = new SaleRepository();
            _product = new Mock<Product>();
            _expectedListSale = new List<Sale>();
            ExtensionSql.SeedDb();
        }

        [Test]
        public void SaleRepository_Add_ShouldBeOk()
        {
            _product.Object.Id = 1;
            _sale = ObjectMother.GetSaleSql(_product.Object);

            _expectedSale = _repository.Add(_sale);

            _expectedSale.Should().NotBeNull();
            _expectedSale.Id.Should().Be(_sale.Id);
        }
        
        [Test]
        public void SaleRepostiory_AddEmptyClient_ShouldFail()
        {
            _product.Object.Id = 1;
            _sale = ObjectMother.GetSaleSqlEmptyClient(_product.Object);

            Action Act = () => _repository.Add(_sale);

            Act.Should().Throw<SqlException>();
        }

        [Test]
        public void SaleRepository_Get_ShouldBeOk()
        {
            _product.Object.Id = 1;
            _sale = ObjectMother.GetSaleSql(_product.Object);
            _sale.Id = 1;

            _expectedSale = _repository.Get(_sale.Id);

            _expectedSale.Should().NotBeNull();
            _expectedSale.Id.Should().Be(_sale.Id);
        }

        [Test]
        public void SaleRepository_GetInvalidId_ShouldBeFail()
        {
            var id = 10;

            _expectedSale = _repository.Get(id);

            _expectedSale.Should().BeNull();
        }

        [Test]
        public void SaleRepository_Update_ShouldBeOK()
        {
            _product.Object.Id = 1;
            _sale = ObjectMother.GetSaleSql(_product.Object);
            _sale.Id = 1;
            var alteredClient = "Renan Zapelini";
            _sale.Client = alteredClient;

            _expectedSale = _repository.Update(_sale);
            _sale = _repository.Get(_sale.Id);

            _expectedSale.Should().NotBeNull();
            _sale.Client.Should().Be(alteredClient);
        }

        [Test]
        public void SaleRepository_UpdateInvalidClient_ShouldFail()
        {
            _product.Object.Id = 1;
            _sale = ObjectMother.GetSaleSqlEmptyClient(_product.Object);
            _sale.Id = 1;

            Action Act = () => _repository.Update(_sale);

            Act.Should().Throw<SqlException>();
        }

        [Test]
        public void SaleRepository_GetAll_ShouldBeOk()
        {
            var id = 1;
            _expectedListSale = _repository.GetAll();

            _expectedListSale.Count().Should().Be(1);
            _expectedListSale.Last().Id.Should().Be(id);
        }

        [Test]
        public void SaleRepository_Delete_ShouldBeOk()
        {
            var id = 1;

            _repository.Delete(id);
            _expectedSale = _repository.Get(id);

            _expectedSale.Should().BeNull();
        }

        [TearDown]
        public void TearDown()
        {
            _sale = null;
            _expectedSale = null;
            _repository = null;
            _product = null;
            _expectedListSale = null;
        }
    }
}
