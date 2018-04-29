using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBear.Models.Repositories
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        IQueryable<Product> Products { get; }
        Review Create(Review review);
        Review Edit(Review review);
        void Delete(int id);
        void DeleteAll();
    }
}
