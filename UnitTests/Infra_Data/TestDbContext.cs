using Domain.Entities;
using Domain.Entities.Cart;
using Domain.Entities.Orders;
using Domain.Entities.Payments;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Entities.Products.Technology.Games;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Entities.Reviews;
using Infra_Data.Configuration;
using Infra_Data.Configuration.Orders;
using Infra_Data.Configuration.Payments;
using Infra_Data.Configuration.Products.Fashion;
using Infra_Data.Configuration.Products.Technology;
using Infra_Data.Identity;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.Infra_Data;

public class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
{
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Shirt> Shirts { get; set; }
    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Smartphone> Smartphones { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new ShoppingCartItemConfiguration().Configure(modelBuilder.Entity<ShoppingCartItem>());
        new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
        new ReviewConfiguration().Configure(modelBuilder.Entity<Review>());
        new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
        new CardConfiguration().Configure(modelBuilder.Entity<Card>());
        new ApplicationUserConfiguration().Configure(modelBuilder.Entity<ApplicationUser>());
        new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
        new OrderDetailConfiguration().Configure(modelBuilder.Entity<OrderDetail>());
        new PaymentConfiguration().Configure(modelBuilder.Entity<Payment>());
        new ShirtConfiguration().Configure(modelBuilder.Entity<Shirt>());
        new ShoesConfiguration().Configure(modelBuilder.Entity<Shoe>());
        new GameConfiguration().Configure(modelBuilder.Entity<Game>());
        new SmartphoneConfiguration().Configure(modelBuilder.Entity<Smartphone>());
    }
}
