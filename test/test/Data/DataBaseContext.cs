using Microsoft.EntityFrameworkCore;

namespace test.Data;

public class DataBaseContext : DbContext
{
    protected DataBaseContext()
    {
    }
    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Author>().HasData(new List<Author>()
        // {
        //     new() { Id = 1, FirstName = "John", LastName = "Doe"},
        // });
    }
}