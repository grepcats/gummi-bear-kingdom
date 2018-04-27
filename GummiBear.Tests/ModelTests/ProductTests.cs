using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GummiBear.Models;

namespace GummiBear.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void GetProperties_ReturnCorrectDataTypes_All()
        {
            //Arrange
            Product newProduct = new Product("Code Complete by Steve McConnell", "Widely considered one of the best practical guides to programming, Steve McConnell’s original CODE COMPLETE has been helping developers write better software for more than a decade. Now this classic book has been fully updated and revised with leading-edge practices—and hundreds of new code samples—illustrating the art and science of software construction. ", (decimal)29.97);

            //Act
            string nameResult = newProduct.Name;
            string descriptionResult = newProduct.Description;
            decimal costResult = newProduct.Cost;

            //Assert
            Assert.AreEqual("Code Complete by Steve McConnell", nameResult);
        }
    }
}
