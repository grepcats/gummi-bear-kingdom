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

    }
}
