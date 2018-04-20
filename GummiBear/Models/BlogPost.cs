using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBear.Models
{
    [Table("BlogPosts")]
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string TextBody { get; set; }
        public DateTime PostDate { get; set; }
    }
}
