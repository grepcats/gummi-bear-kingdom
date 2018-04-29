using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GummiBear.Models
{
    public class TestDbContext : GummiBearContext
    {
        public override DbSet<Product> Products { get; set; }
        public override DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=gummibear_test;uid=root;pwd=root;");
        }
    }
}
