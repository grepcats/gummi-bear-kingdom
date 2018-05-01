using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBear.Controllers;
//using GummiBear.Models.Repositories;
using GummiBear.Models;
using Microsoft.AspNetCore.Mvc;
//using Moq;
using System.Linq;

namespace GummiBear.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void HomeController_ReturnView_View()
        {
            //arrange
            HomeController controller = new HomeController();

            //act
            var indexView = new HomeController().Index();

            //assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        //[TestMethod]
        //public void HomeController_ReturnCorrectModel_Dictionary()
        //{
        //    //arrange
        //    HomeController controller = new HomeController();

        //    //act
        //    //Product newProduct = 
        //    var resultView = controller.Index() as ViewResult;
        //    var model = resultView.ViewData.Model as Review;

        //    //assert
        //    Assert.IsInstanceOfType(model, typeof(Dictionary<Product, int>));
        //}
     
    }
}
