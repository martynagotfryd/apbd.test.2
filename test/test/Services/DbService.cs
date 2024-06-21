using test.Data;
using test.Models;
using Microsoft.EntityFrameworkCore;

namespace test.Services;

public class DbService : IDbService
{
    private readonly DataBaseContext _context;

    public DbService(DataBaseContext context)
    {
        _context = context;
    }


    public async Task<bool> DoesCharacterExist(int id)
    {
        return await _context.Characters.AnyAsync(e => e.Id == id);
    }

    public async Task<ICollection<Character>> GetCharacterInfo(int id)
    {
        return await _context.Characters
            .Include(e => e.Backpacks)
            .ThenInclude(b => b.Item)
            .Where(e => e.Id == id)
            .ToListAsync();
    }
}