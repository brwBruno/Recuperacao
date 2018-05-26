using DonaRosangela.App.Features.Books;
using DonaRosangela.Common.Tests.Base;
using DonaRosangela.Domain.Exceptions;
using DonaRosangela.Domain.Features.Books;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.App.Tests.Features.Books
{
    [TestFixture]
    public class BookServiceTests
    {
        Book _book;
        Book _expectedBook;
        Mock<IBookRepository> _repository;
        IBookService _service;

        [SetUp]
        public void Initialize()
        {
            _book = new Book();
            _expectedBook = new Book();
            _repository = new Mock<IBookRepository>();
            _service = new BookService(_repository.Object);
        }

        [Test]
        public void BookService_Add_ShouldBeOk()
        {
            _book = ObjectMother.GetBook();
            _repository.Setup(r => r.Add(_book)).Returns(_book);

            _expectedBook = _service.Add(_book);

            _expectedBook.Should().NotBeNull();
            _expectedBook.Id.Should().Be(1);
            _repository.Verify(r => r.Add(_book));
        }

        [Test]
        public void BookService_AddInvalidTitle_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Title = "";

            Action act = () => _service.Add(_book);

            act.Should().Throw<BookTitleMinCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_AddInvalidAuthor_ShouldBeEception()
        {
            _book = ObjectMother.GetBook();
            _book.Author = "";

            Action act = () => _service.Add(_book);

            act.Should().Throw<BookAuthorMinCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_AddInvalidTheme_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Theme = "";

            Action act = () => _service.Add(_book);

            act.Should().Throw<BookThemeMinCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_AddInvalidVolume_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Volume = 0;

            Action act = () => _service.Add(_book);

            act.Should().Throw<BookInvalidVolumeException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_Get_ShouldBeOk()
        {
            _book = ObjectMother.GetBook();
            _repository.Setup(r => r.Get(_book.Id)).Returns(_book);

            _expectedBook = _service.Get(_book);

            _expectedBook.Should().NotBeNull();
            _expectedBook.Id.Should().Be(1);
            _repository.Verify(r => r.Get(_book.Id));
        }

        [Test]
        public void BookService_GetInvalidId_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Id = 0;

            Action act = () => _service.Get(_book);

            act.Should().Throw<InvalidIdException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_Update_ShouldBeOk()
        {
            _book = ObjectMother.GetBook();
            _repository.Setup(r => r.Update(_book)).Returns(_book);
            _book.Title = "Senhor dos Aneis";

            _expectedBook = _service.Update(_book);

            _expectedBook.Should().NotBeNull();
            _expectedBook.Id.Should().Be(1);
            _expectedBook.Title.Should().Be("Senhor dos Aneis");
            _repository.Verify(r => r.Update(_book));
        }

        [Test]
        public void BookService_UpdateInvalidTitle_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Title = "";

            Action act = () => _service.Update(_book);

            act.Should().Throw<BookTitleMinCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_UpdateInvalidAuthor_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Author = "";

            Action act = () => _service.Update(_book);

            act.Should().Throw<BookAuthorMinCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_UpdateInvalidTheme_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Theme = "";

            Action act = () => _service.Update(_book);

            act.Should().Throw<BookThemeMinCaractersException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_UpdateInvalidVolume_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Volume = 0;

            Action act = () => _service.Update(_book);

            act.Should().Throw<BookInvalidVolumeException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void BookService_GetAll_ShouldBeOk()
        {
            _book = ObjectMother.GetBook();
            var list = new List<Book>();
            list.Add(_book);
            _repository.Setup(r => r.GetAll()).Returns(list);

            var expectedBookList = _service.GetAll();

            expectedBookList.Count().Should().BeGreaterThan(0);
            expectedBookList.Last().Id.Should().Be(1);
            _repository.Verify(r => r.GetAll());
        }

        [Test]
        public void BookService_Delete_ShouldBeOk()
        {
            _book.Id = 1;
            _repository.Setup(r => r.Get(_book.Id));

            _service.Delete(_book);
            _expectedBook = _service.Get(_book);

            _expectedBook.Should().BeNull();
            _repository.Verify(r => r.Delete(_book.Id));
        }

        [Test]
        public void BookService_DeleteInvalidId_ShouldBeException()
        {
            _book = ObjectMother.GetBook();
            _book.Id = 0;

            Action act = () => _service.Delete(_book);

            act.Should().Throw<InvalidIdException>();
            _repository.VerifyNoOtherCalls();
        }
    }
}
