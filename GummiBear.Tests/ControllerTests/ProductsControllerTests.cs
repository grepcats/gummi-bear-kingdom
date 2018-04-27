﻿using System;
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
    public class ProductsControllerTests
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductId = 1, Name = "Code Complete by Steve McConnell", Description = "Widely considered one of the best practical guides to programming...", Cost = (decimal)29.97 },
                new Product { ProductId = 2, Name = "Clean Code by Robert C Martin", Description = "Even bad code can function...", Cost = (decimal)34.00 },
                new Product { ProductId = 3, Name = "Cracking the Coding Interview by Gayle McDowell", Description = "Cracking the Coding Interview, 6th Edition is here to help you through this process...", Cost = (decimal)37.95 }
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            //arrange
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            //arrange
            DbSetup();
            ViewResult indexView = new ProductsController(mock.Object).Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsProducts_Collection()
        {
            //arrange
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);
            Product testProduct = new Product("Sponge", "Sponges up liquids", (decimal)1.99);
            testProduct.ProductId = 4;

            //act
            controller.Create(testProduct);
            ViewResult indexView = controller.Index() as ViewResult;
            List<Product> collection = indexView.ViewData.Model as List<Product>;

            //assert
            CollectionAssert.Contains(collection, testProduct);
        }
    }
}