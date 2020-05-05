using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTest

    {
        [Fact]
        public void Test1()
        {
            // arrange
            var book1 = GetBook("Book 1");
            //var book2 = GetBook("Book 2");
            //act
            var book2 = book1;


            //assert
            // Assert.Equal("Book 1", book1.Name);
            // Assert.Equal("Book 2", book2.Name);
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}