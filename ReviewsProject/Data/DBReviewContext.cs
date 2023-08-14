using ReviewsProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReviewsProject.Data
{
    public class DBReviewContext : DbContext
    {
        public DBReviewContext() : base("DefaultConnection")
        {
        }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ReviewPhoto> Photos{get;set;}
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorPhoto> VendorPhotos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>()
                .HasMany(t => t.VendorPhotos);
        }
    }
}