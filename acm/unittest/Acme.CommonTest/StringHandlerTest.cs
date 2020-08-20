using System;
using Acme.Common;
//using Microsoft.VisualStudio.TestTools.Unitesting;

namespace Acme.CommonTest
{
    [TestClass]
    public class StringHandlerTest
    {   
        [TestMethod]
        public void InsertSpacesTestValid()
        {
            // Arrange
            var source = "SonicScrewdriver";
            var expected = "Sonic Screwdriver";
            var handler = new StringHandler();

            // Act
            var actual = handler.InserSpaces(source);

            // Assert
            Assert.AreEqual(expected, actual);

        }
    }
}