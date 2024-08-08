using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Concrete
{
    public class SignalRContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=VICTUS;initial Catalog=SignalRDb;Integrated Security=True;TrustServerCertificate=True");
        }

        public DbSet<About> About { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<About>()
                .HasKey(a => a.AboutID);

            modelBuilder.Entity<Booking>()
                .HasKey(b => b.BookingID);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryID);

            modelBuilder.Entity<Contacts>()
                .HasKey(c => c.ContactID);

            modelBuilder.Entity<Discount>()
                .HasKey(d => d.DiscountID);

            modelBuilder.Entity<Feature>()
                .HasKey(f => f.FeatureID);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductID);

            modelBuilder.Entity<SocialMedia>()
                .HasKey(sm => sm.SocialMediaID);

            modelBuilder.Entity<Testimonial>()
                .HasKey(t => t.TestimonialID);
        }
    }
}
