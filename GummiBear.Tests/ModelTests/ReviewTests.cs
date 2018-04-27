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

        [TestMethod]
        public void RatingRange_ReturnTrueIfRange_True()
        {
            //arrange
            Review newReview1 = new Review { ReviewId = 1, Author = "Bob", ContentBody = "This product is great", Rating = 5 };
            Review newReview2 = new Review { ReviewId = 3, Author = "Bob", ContentBody = "This product is great", Rating = 100 };

            //act
            bool result1 = newReview1.RatingRange();
            bool result2 = newReview2.RatingRange();

            //assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);

        }
    }
}
