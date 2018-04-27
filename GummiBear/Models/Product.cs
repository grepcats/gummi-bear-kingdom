using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBear.Models
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {
            this.Reviews = new HashSet<Review>();
        }

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public Product(string name, string description, decimal cost)
        {
            Name = name;
            Description = description;
            Cost = cost;
            ProductId = 0;
        }

        public override bool Equals(object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                return this.ProductId.Equals(newProduct.ProductId);
            }
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }

        public int AverageRating()
        {
            int start = 0;
            foreach(Review review in Reviews)
            {
                start += review.Rating;
            }
            int average = (int)Math.Round((decimal)start / this.Reviews.Count);
            return average;

        }
    }

   
}
