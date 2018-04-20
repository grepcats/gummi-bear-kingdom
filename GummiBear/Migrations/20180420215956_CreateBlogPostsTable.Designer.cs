using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GummiBear.Models;

namespace GummiBear.Migrations
{
    [DbContext(typeof(GummiBearContext))]
    [Migration("20180420215956_CreateBlogPostsTable")]
    partial class CreateBlogPostsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("GummiBear.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<DateTime>("PostDate");

                    b.Property<string>("TextBody");

                    b.Property<string>("Title");

                    b.HasKey("BlogPostId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("GummiBear.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });
        }
    }
}
