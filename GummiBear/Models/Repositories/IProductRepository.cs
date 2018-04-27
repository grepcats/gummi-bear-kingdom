using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBear.Models.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Review> Reviews { get; }
        IQueryable<Product> Products { get; }
        Product Create(Product product);
        Product Edit(Product product);
        void Delete(int id);
        void DeleteAll();
    }
}
