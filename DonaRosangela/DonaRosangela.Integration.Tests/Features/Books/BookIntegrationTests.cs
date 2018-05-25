using DonaRosangela.App.Features.Books;
using DonaRosangela.Common.Tests.Base;
using DonaRosangela.Domain.Exceptions;
using DonaRosangela.Domain.Features.Books;
using DonaRosangela.Infra.Data.Features.Books;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Integration.Tests.Features.Books
{
    [TestFixture]
    public class BookIntegrationTests
    {
        Book _book;
        Book _expectedBook;
        IBookService _service;
        IBookRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _book = new Book();
            _expectedBook = new Book();
            _repository = new BookRepository();
            _service = new BookService(_repository);
            BaseSql.SeedDbTBBook();
        }

        [Test]
        public void BookIntegration_Add_ShouldBeOk()
        {
            _book = ObjectMother.GetBookSQL();

            _expectedBook = _service.Add(_book);

            _expectedBook.Should().NotBeNull();
            _expectedBook.Id.Should().Be(2);
        }

        [Test]
        public void BookIntegration_AddInvalidTitle_ShouldBeException()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Title = "";

            Action act = () => _service.Add(_book);

            act.Should().Throw<BookTitleMinCaractersException>();
        }

        [Test]
        public void BookIntegration_AddInvalidAuthor_ShouldBeException()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Author = "";

            Action act = () => _service.Add(_book);

            act.Should().Throw<BookAuthorMinCaractersException>();
        }

        [Test]
        public void BookIntegration_AddInvalidTheme_ShouldBeException()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Theme = "";

            Action act = () => _service.Add(_book);

            act.Should().Throw<BookThemeMinCaractersException>();
        }

        [Test]
        public void BookIntegration_AddInvalidVolume_ShouldBeException()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Volume = 0;

            Action act = () => _service.Add(_book);

            act.Should().Throw<BookInvalidVolumeException>();
        }

        [Test]
        public void BookIntegration_Get_ShouldBeOk()
        {
            _book.Id = 1;

            _expectedBook = _service.Get(_book);

            _expectedBook.Should().NotBeNull();
            _expectedBook.Id.Should().Be(1);
        }

        [Test]
        public void BookIntegration_GetInvalidId_ShoudBeException()
        {
            _book = ObjectMother.GetBookSQL();

            Action act = () => _service.Get(_book);

            act.Should().Throw<InvalidIdException>();           
        }

        [Test]
        public void BookIntegration_GetAll_ShouldBeOk()
        {
            var listExpectedBook = _service.GetAll();

            listExpectedBook.Should().NotBeNull();
            listExpectedBook.Last().Id.Should().Be(1);
        }

        [Test]
        public void BookIntegration_Update_ShouldBeOk()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Id = 1;
            _book.Title = "Alterado";

            _expectedBook = _service.Update(_book);

            _expectedBook.Should().NotBeNull();
            _expectedBook.Id.Should().Be(1);
            _expectedBook.Title.Should().Be("Alterado");
        }

        [Test]
        public void BookIntegration_UpdateInvalidTitle_ShouldBeException()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Title = "";

            Action act = () => _service.Update(_book);

            act.Should().Throw<BookTitleMinCaractersException>();
        }

        [Test]
        public void BookIntegration_UpdateInvalidAuthor_ShouldBeException()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Author = "";

            Action act = () => _service.Update(_book);

            act.Should().Throw<BookAuthorMinCaractersException>();
        }

        [Test]
        public void BookIntegration_UpdateInvalidTheme_ShouldBeException()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Theme = "";

            Action act = () => _service.Update(_book);

            act.Should().Throw<BookThemeMinCaractersException>();
        }

        [Test]
        public void BookIntegration_UpdateInvalidVolume_ShouldBeException()
        {
            _book = ObjectMother.GetBookSQL();
            _book.Volume = 0;

            Action act = () => _service.Update(_book);

            act.Should().Throw<BookInvalidVolumeException>();
        }

        [Test]
        public void BookIntegration_Delete_ShouldBeOk()
        {
            _book.Id = 1;

            _service.Delete(_book);
            _expectedBook = _service.Get(_book);

            _expectedBook.Should().BeNull();
        }

        [Test]
        public void BookIntegration_DeleteInvalidId_ShoudBeException()
        {
            _book = ObjectMother.GetBookSQL();

            Action act = () => _service.Delete(_book);

            act.Should().Throw<InvalidIdException>();
        }
    }
}
