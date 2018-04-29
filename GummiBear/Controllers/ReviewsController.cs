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
    public class ReviewsController : Controller
    {
        private IReviewRepository reviewRepo;

        public ReviewsController(IReviewRepository repo = null)
        {
            if (repo == null)
            {
                this.reviewRepo = new EFReviewRepository();
            }
            else
            {
                this.reviewRepo = repo;
            }
        }

        public IActionResult Index()
        {
            List<Review> model = reviewRepo.Reviews.Include(reviews => reviews.Product).ToList();
            //List<Review> model = reviewRepo.Reviews.ToList();
            return View(model);
        }

        public IActionResult Create(int id)
        {
            Product thisProduct = reviewRepo.Products.FirstOrDefault(Products => Products.ProductId == id);
            ViewBag.Product = thisProduct;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            if (review.RatingRange() && review.BodyLength())
            {
                reviewRepo.Create(review);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
            
        }

        public IActionResult Details(int id)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(Reviews => Reviews.ReviewId == id);
            return View(thisReview);
        }

        public IActionResult Edit(int id)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(Reviews => Reviews.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            reviewRepo.Edit(review);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(Reviews => Reviews.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            reviewRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
