using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBear.Models;

namespace GummiBear.Controllers
{
    public class HomeController : Controller
    {
        private GummiBearContext db = new GummiBearContext();
        public IActionResult Index()
        {
            if (db.Products.Count() == 0)
            {
                List<Product> dummyData = new List<Product> { new Product("Code Complete by Steve McConnell", "Widely considered one of the best practical guides to programming, Steve McConnell’s original CODE COMPLETE has been helping developers write better software for more than a decade. Now this classic book has been fully updated and revised with leading-edge practices—and hundreds of new code samples—illustrating the art and science of software construction. ", (decimal)29.97),
                new Product("Clean Code by Robert C Martin", "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way", (decimal)34.00),
                new Product("Cracking the Coding Interview by Gayle McDowell", "Cracking the Coding Interview, 6th Edition is here to help you through this process, teaching you what you need to know and enabling you to perform at your very best. I've coached and interviewed hundreds of software engineers. The result is this book.", (decimal)37.95) };
                db.Products.AddRange(dummyData);
                db.SaveChanges();
            }
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
