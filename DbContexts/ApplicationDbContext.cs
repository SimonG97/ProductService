using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
}
