using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBear.Models.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        GummiBearContext db = new GummiBearContext();

        public IQueryable<Product> Products
        {  get { return db.Products; } }

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public Product Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        public Product Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(Products => Products.ProductId == id);
            db.Products.Remove(thisProduct);
            db.SaveChanges();
        }


        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Products;");
        }

    }
}
