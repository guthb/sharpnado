using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests

    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {

            WriteLogDelegate log = ReturnMessage;

            //log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            //Assert.Equal("Hello!", result);
            //name setter set private will cause test to fail
            Assert.Equal(3, count);


        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "jackass";
            var upper = MakeUpperCase(name);

            Assert.Equal("JACKASS", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValuePassedByRefernce()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }


        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }


        // [Fact]
        // public void Test1()
        // {
        //     var x = GetInt();

        //     Assert.Equal(3, x);
        // }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharepCanPassRef()
        {
            //Given
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            //When

            //Then
            Assert.Equal("New Name", book1.Name);

        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CSharepIsPassByValue()
        {
            //Given
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            //When

            //Then
            Assert.Equal("Book 1", book1.Name);

        }


        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            //book.Name = name;
        }



        [Fact]
        public void CanSetNameFromRefernce()
        {
            //Given
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            //When


            //Then
            Assert.Equal("New Name", book1.Name);

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void TwoVarsCanRefernceSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;


            //assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            //act



            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}