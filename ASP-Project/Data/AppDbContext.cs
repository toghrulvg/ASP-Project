using ASP_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Data
{
    public class AppDbContext : IdentityDbContext<AppUser> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<TwinBlogs> TwinBlogs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Service>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<ProductImage>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<TwinBlogs>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Brand>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Contact>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Message>().HasQueryFilter(m => !m.IsDeleted);
        }

    }
}
