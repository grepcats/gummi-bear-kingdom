using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void SetProperties_SetThem_Void()
        {
            //Arrange
            Product newProduct = new Product("Code Complete by Steve McConnell", "Widely considered one of the best practical guides to programming...", (decimal)29.97);

            //Act
            newProduct.Name = "This is a different name";
            newProduct.Description = "This is a different description";
            newProduct.Cost = (decimal)15.00;

            //Assert
            Assert.AreEqual("This is a different name", newProduct.Name);
            Assert.AreEqual("This is a different description", newProduct.Description);
            Assert.AreEqual((decimal)15.00, newProduct.Cost);
        }

        [TestMethod]
        public void ConstructNewProduct_ReturnProduct_Stuff()
        {
            //Arrange & Act
            Product newProduct = new Product("Code Complete by Steve McConnell", "Widely considered one of the best practical guides to programming...", (decimal)29.97);

            //Assert
            Assert.AreEqual("Code Complete by Steve McConnell", newProduct.Name);

        }

        [TestMethod]
        public void AverageRating_returnAverageRating_int()
        {
            //arrange
            Product newProduct = new Product("Code Complete by Steve McConnell", "Widely considered one of the best practical guides to programming...", (decimal)29.97);
            Review newReview1 = new Review { ReviewId = 1, Author = "Bob", ContentBody = "This product is great", Rating = 5 };
            Review newReview2 = new Review { ReviewId = 2, Author = "Frank", ContentBody = "This product is ok", Rating = 3 };
            newProduct.Reviews = new List<Review> { newReview1, newReview2 };


            //act
            int rating = newProduct.AverageRating();

            //assert
            Assert.AreEqual(rating, 4);
        }
    }
}
