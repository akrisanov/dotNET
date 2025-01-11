using Microsoft.EntityFrameworkCore;

using EFCoreForBeginners.Models;

namespace EFCoreForBeginners.Data;

public class PizzaContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Pizza.db");
    }
}
