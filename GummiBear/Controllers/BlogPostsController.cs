using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GummiBear.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GummiBear.Controllers
{
    public class BlogPostsController : Controller
    {
        private GummiBearContext db = new GummiBearContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPost blogPost)
        {
            blogPost.PostDate = DateTime.Now;
            db.BlogPosts.Add(blogPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
