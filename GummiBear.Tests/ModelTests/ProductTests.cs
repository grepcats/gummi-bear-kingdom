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
            Product newProduct = new Product("Code Complete by Steve McConnell", "Widely considered one of the best practical guides to programming...", (decimal)29.97);

            //Act
            string nameResult = newProduct.Name;
            string descriptionResult = newProduct.Description;
            decimal costResult = newProduct.Cost;

            //Assert
            Assert.AreEqual("Code Complete by Steve McConnell", nameResult);
            Assert.AreEqual("Widely considered one of the best practical guides to programming...", descriptionResult);
            Assert.AreEqual((decimal)29.97, costResult);
        }
    }
}
