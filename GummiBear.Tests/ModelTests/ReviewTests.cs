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
        public void Equals_ReturnsTrueIfReviewsAreSame_Review()
        {
            //arrange, act
            Review firstReview = new Review("Bob", "This sponge is great", 5);
            Review secondReview = new Review("Bob", "This sponge is great", 5);

            //assert
            Assert.AreEqual(firstReview, secondReview);
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

        [TestMethod]
        public void BodyLength_ReturnTrueIfSmallerThan255_True()
        {
            //arrange
            Review newReview1 = new Review { ReviewId = 1, Author = "Bob", ContentBody = "This product is great", Rating = 5 };
            Review newReview2 = new Review { ReviewId = 2, Author = "Bob", ContentBody = "Little trees and bushes grow however makes them happy. You have to make those little noises or it won't work. Just think about these things in your mind - then bring them into your world. Only eight colors that you need. You have to make these big decisions. See. We take the corner of the brush and let it play back-and-forth. We don't have to be committed. We are just playing here. We start with a vision in our heart, and we put it on canvas. Fluff that up. Talent is a pursued interest. That is to say, anything you practice you can do. Everything's not great in life, but we can still find beauty in it. Let's put some happy little clouds in our world. Let's get wild today. It's life. It's interesting. It's fun. You can do it. Now we can begin working on lots of happy little things. We'll lay all these little funky little things in there. You can get away with a lot. We'll put some happy little leaves here and there.", Rating = 3 };

            //act
            bool result1 = newReview1.BodyLength();
            bool result2 = newReview2.BodyLength();

            //assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);

        }
    }
}
