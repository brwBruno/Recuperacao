using DonaRosangela.Common.Tests.Base;
using DonaRosangela.Domain.Features.Books;
using DonaRosangela.Infra.Data.Features.Books;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Infra.Data.Tests.Features.Books
{
    [TestFixture]
    public class BookRepositoryTests
    {
        Book _book;
        Book _expectedBook;
        IBookRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _book = new Book();
            _expectedBook = new Book();
            _repository = new BookRepository();
            BaseSql.SeedDb();
        }

        [Test]
        public void BookRepository_Add_DeveSerOk()
        {
            _book = ObjectMother.GetBookSQL();

            _expectedBook = _repository.Add(_book);

            _expectedBook.Should().NotBeNull();
            _expectedBook.Id.Should().Be(2);
        }

        [Test]
        public void BookRepository_Get_ShouldBeOk()
        {
            _book.Id = 1;

            _expectedBook = _repository.Get(_book.Id);

            _expectedBook.Should().NotBeNull();
            _expectedBook.Id.Should().Be(1);
        }

        [Test]
        public void BooKRepository_GetInvaidId_ShouldBeNull()
        {
            _book.Id = 2;

            _expectedBook = _repository.Get(_book.Id);

            _expectedBook.Should().BeNull();
        }

        [Test]
        public void BookRepository_GetAll_ShouldBeOk()
        {
            var listBookExpected = _repository.GetAll();

            listBookExpected.Should().NotBeNull();
            listBookExpected.Last().Id.Should().Be(1);
        }

        [Test]
        public void BookRepository_Update_ShouldBeOk()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Id = 1;
            _book.Title = "Alterado";

            _expectedBook = _repository.Update(_book);

            _expectedBook.Should().NotBeNull();
            _expectedBook.Title.Should().Be("Alterado");
        }

        [Test]
        public void BookRepository_UpdateInvalidId_ShouldBeNull()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Id = 2;

            _expectedBook = _repository.Update(_book);

            _expectedBook.Should().BeNull();
        }

        [Test]
        public void BookRepository_Delete_ShouldBeOk()
        {
            _book.Id = 1;

            _repository.Delete(_book.Id);
            _expectedBook = _repository.Get(_book.Id);
            var listExpectedBook = _repository.GetAll();

            _expectedBook.Should().BeNull();
            listExpectedBook.Should().NotContain(_book);
        }
    }
}
