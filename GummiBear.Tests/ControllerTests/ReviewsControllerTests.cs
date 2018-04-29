using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBear.Controllers;
using GummiBear.Models.Repositories;
using GummiBear.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;

namespace GummiBear.Tests.ControllerTests
{
    [TestClass]
    public class ReviewsControllerTests
    {
        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
        EFReviewRepository db = new EFReviewRepository(new TestDbContext());

        private void DbSetup()
        {
            mock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review { ReviewId = 1, Author = "Bob", ContentBody = "This product is great", Rating = 5 },
                new Review { ReviewId = 2, Author = "Joe", ContentBody = "This product is terrible", Rating = 1 },
                new Review { ReviewId = 3, Author = "Frank", ContentBody = "This product is ok", Rating = 3 }
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetReviewViewResultIndex_ActionResult()
        {
            //arrange
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_ReviewIndexModelContainsProducts_Collection()
        {
            //arrange
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);
            Review testReview = new Review { ReviewId = 1, Author = "Bob", ContentBody = "This product is great", Rating = 5 };

            //act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Review> collection = indexView.ViewData.Model as List<Review>;

            //assert
            CollectionAssert.Contains(collection, testReview);
        }

        [TestMethod]
        public void Mock_ReviewPostViewResultCreate_ViewResult()
        {
            //arrange
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);
            Review testReview = new Review { ReviewId = 1, Author = "Bob", ContentBody = "This product is great", Rating = 5 };

            //act
            var resultView = controller.Create(testReview);


            //assert
            Assert.IsInstanceOfType(resultView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_ReviewGetDetails_ReturnsView()
        {
            //arrange
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);
            Review testReview = new Review { ReviewId = 1, Author = "Bob", ContentBody = "This product is great", Rating = 5 };

            //act
            var resultView = controller.Details(testReview.ReviewId) as ViewResult;
            var model = resultView.ViewData.Model as Review;

            //assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Review));
        }

        [TestMethod]
        public void DB_CreatesNewReviews_Collection()
        {
            //arrange
            ReviewsController controller = new ReviewsController(db);
            Review testReview = new Review("bob", "this is a great sponge", 5);

            //act
            controller.Create(testReview);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Review>;

            //assert
            CollectionAssert.Contains(collection, testReview);
        }

        [TestMethod]
        public void DB_IndexListsReviews_Collection()
        {
            //arrange
            ReviewsController controller = new ReviewsController(db);
            Review testReview1 = new Review("bob", "this is a great sponge", 5);
            Review testReview2 = new Review("frank", "this is a bad sponge", 1);

            //act
            controller.Create(testReview1);
            controller.Create(testReview2);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Review>;
            List<Review> result = new List<Review> { testReview1, testReview2 };

            //assert
            CollectionAssert.AreEqual(result, collection);


        }
    }
}
