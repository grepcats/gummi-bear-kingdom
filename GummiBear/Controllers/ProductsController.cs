using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GummiBear.Models;
using GummiBear.Models.Repositories;


namespace GummiBear.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepo;

        public ProductsController(IProductRepository repo = null)
        {
            if (repo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = repo;
            }
        }
      
        public IActionResult Index()
        {
            List<Product> model = productRepo.Products.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productRepo.Create(product);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(Products => Products.ProductId == id);
            thisProduct.Reviews = productRepo.Reviews.Where(Reviews => Reviews.ProductId == id).ToList();
           

            return View(thisProduct);
        }

        public IActionResult Edit(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(Products => Products.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            productRepo.Edit(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(Products => Products.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            productRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAll()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
        public IActionResult DeleteAllProducts()
        {
            productRepo.DeleteAll();
            return RedirectToAction("Index");
        }

        public IActionResult LeaveReview(int id)
        {
            return RedirectToAction("Create", "Reviews", new { Id = id });
        }


    }
}
