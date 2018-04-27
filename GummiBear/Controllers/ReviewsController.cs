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
            List<Review> model = reviewRepo.Reviews.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            reviewRepo.Create(review);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisReview = reviewRepo.Reviews.FirstOrDefault(Reviews => Reviews.ReviewId == id);
            return View(thisReview);
        }
    }
}
