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
            List<BlogPost> model = db.BlogPosts.OrderByDescending(b => b.PostDate).ToList();
            return View(model);
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

        public IActionResult Delete(int id)
        {
            var thisPost = db.BlogPosts.FirstOrDefault(BlogPosts => BlogPosts.BlogPostId == id);
            return View(thisPost);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPost = db.BlogPosts.FirstOrDefault(BlogPosts => BlogPosts.BlogPostId == id);
            db.BlogPosts.Remove(thisPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisPost = db.BlogPosts.FirstOrDefault(BlogPosts => BlogPosts.BlogPostId == id);
            return View(thisPost);
        }

        [HttpPost]
        public IActionResult Edit(BlogPost blogPost)
        {
            db.Entry(blogPost).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
