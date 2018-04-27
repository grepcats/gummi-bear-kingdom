using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBear.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Author { get; set; }
        [StringLength(255)]
        public string ContentBody { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public override bool Equals(object otherReview)
        {
            if (!(otherReview is Review))
            {
                return false;
            }
            else
            {
                Review newReview = (Review)otherReview;
                return this.ReviewId.Equals(newReview.ReviewId);
            }
        }

        public override int GetHashCode()
        {
            return this.ReviewId.GetHashCode();
        }

        public bool RatingRange()
        {
            if (Rating <= 0 || Rating > 5)
            {
                return false;
            }
            else
            {
                return true;
            }   
        }

        public bool BodyLength()
        {
            if (ContentBody.Length > 255)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
