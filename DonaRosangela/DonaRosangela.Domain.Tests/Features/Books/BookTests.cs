using DonaRosangela.Common.Tests.Base;
using DonaRosangela.Domain.Features.Books;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaRosangela.Domain.Tests.Features.Books
{
    [TestFixture]
    public class BookTests
    {
        Book _book;
        [SetUp]
        public void Initialize()
        {
            _book = new Book();
        }

        [Test]
        public void Book_CreateValidBook_ShouldBeOk()
        {
            _book = ObjectMother.GetBook();

            _book.Validade();

            _book.Id.Should().Be(1);
            _book.Title.Should().Be("A Volta dos que nao Foram");
        }

        [Test]
        public void Book_CreateInvalidTitle_ShouldException()
        {
            _book = ObjectMother.GetBook();
            _book.Title = "abc";

            Action act = () => _book.Validade();

            act.Should().Throw<BookTitleMinCaractersException>();
        }

        [Test]
        public void Book_CreateInvalidThema_ShouldException()
        {
            _book = ObjectMother.GetBook();
            _book.Theme = "abc";

            Action act = () => _book.Validade();

            act.Should().Throw<BookThemeMinCaractersException>();
        }

        [Test]
        public void Book_CreateInvalidAuthor_ShouldException()
        {
            _book = ObjectMother.GetBook();
            _book.Author = "abc";

            Action act = () => _book.Validade();

            act.Should().Throw<BookAuthorMinCaractersException>();
        }

        [Test]
        public void Book_CreateInvalidValume_ShouldException()
        {
            _book = ObjectMother.GetBook();
            _book.Volume = 0;

            Action act = () => _book.Validade();

            act.Should().Throw<BookInvalidVolumeException>();
        }
    }
}
