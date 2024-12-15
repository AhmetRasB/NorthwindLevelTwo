using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework.Contexts;

public class NorthwindContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=ARB;Initial Catalog=Northwind;Integrated Security=True;Trust Server Certificate = True");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}