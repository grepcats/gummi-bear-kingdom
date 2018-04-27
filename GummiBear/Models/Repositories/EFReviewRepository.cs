using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBear.Models.Repositories
{
    public class EFReviewRepository : IReviewRepository
    {
        GummiBearContext db = new GummiBearContext();

        public IQueryable<Review> Reviews
        { get { return db.Reviews;  } }

        public Review Create(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Delete(int id)
        {
            Review thisReview = db.Reviews.FirstOrDefault(Reviews => Reviews.ReviewId == id);
            db.Reviews.Remove(thisReview);
            db.SaveChanges();
        }

    }
}
