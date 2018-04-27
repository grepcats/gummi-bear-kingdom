using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GummiBear.Models;

namespace GummiBear.Tests.ModelTests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void GetReviewProperties_ReturnCorrectData_All()
        {
            //arrange
            Review newReview = new Review { ReviewId = 1, Author = "Bob", ContentBody = "This product is great", Rating = 5 };

            //act
            string author = newReview.Author;
            string body = newReview.ContentBody;
            int rating = newReview.Rating;

            //assert
            Assert.AreEqual(author, "Bob");
            Assert.AreEqual(body, "This product is great");
            Assert.AreEqual(rating, 5);
        }

        [TestMethod]
        public void SetReviewProperties_SetThem_Void()
        {
            //arrange
            Review newReview = new Review { ReviewId = 1, Author = "Bob", ContentBody = "This product is great", Rating = 5 };

            //act
            newReview.Author = "Frank";
            newReview.ContentBody = "This product is terrible";
            newReview.Rating = 1;

            //assert
            Assert.AreEqual(newReview.Author, "Frank");
            Assert.AreEqual(newReview.ContentBody, "This product is terrible");
            Assert.AreEqual(newReview.Rating, 1);
        }
    }
}
