using E_CommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace E_CommerceApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
           new Customer
           {
               Id = 1,
               CustomerName = "John Doe",
               Email = "vaibhavvd887331@gmail.com",
               Password = "password",
               Phone = "123-456-7890",
               BillingAddress = "123 Main St, New York, NY"
           },
           new Customer
           {
               Id = 2,
               CustomerName = "Vaibhav D",
               Email = "jane@example.com",
               Password = "password",
               Phone = "987-654-3210",
               BillingAddress = "456 Elm St, Los Angeles, CA"
           },
           new Customer
           {
               Id = 3,
               CustomerName = "Admin",
               Email = "jane@example.com",
               Password = "password",
               Phone = "987-654-3210",
               BillingAddress = "456 Elm St, Los Angeles, CA"
           });

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                ProductName = "iPhone 15",
                Description = "Latest Apple iPhone with A16 chip",
                Category = "Electronics",
                UnitPrice = 999.99m
            },
            new Product
            {
                Id = 2,
                ProductName = "Samsung Galaxy S24",
                Description = "Flagship Android phone with Snapdragon processor",
                Category = "Electronics",
                UnitPrice = 899.99m
            },
            new Product
            {
                Id = 3,
                ProductName = "Nike Air Max",
                Description = "Comfortable running shoes",
                Category = "Footwear",
                UnitPrice = 149.99m
            });           
        }

        public DbSet<Product> Products { get; set; }

         public DbSet<Customer> Customers { get; set; }

        public DbSet<Template> Templates { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Payment> Payment { get; set; }


    }
}
