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
     
    }
}
