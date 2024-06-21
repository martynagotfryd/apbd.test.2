using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data;

public class DataBaseContext : DbContext
{
    protected DataBaseContext()
    {
    }
    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
            new()
            {
                Id = 1, 
                Name = "lol", 
                Weight = 3
            },
        });
        
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new()
            {
                Id = 1, 
                Name = "elo"
            },
        });
        
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new()
            {
                Id = 1, 
                FirstName = "To", 
                LastName = "Ja",
                CurrWeight = 5,
                MaxWeight = 20
            },
        });
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
        {
            new()
            {
                IdCharacter = 1,
                IdItem = 1,
                Amount = 2
            },
        });
        
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new()
            {
                IdCharacter = 1,
                IdTitle = 1,
                AcquiredAt = DateTime.Now
            },
        });
    }
}