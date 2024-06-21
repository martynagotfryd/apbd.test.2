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

    public async Task AddItems(IEnumerable<Backpack> backpacks)
    {
        await _context.AddRangeAsync(backpacks);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesItemExist(int id)
    {
        return await _context.Items.AnyAsync(e => e.Id == id);

    }

    public async Task<Character> GetItemById(int id)
    {
        return await _context.Characters.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Item> GetCharById(int id)
    {
        return await _context.Items.FirstOrDefaultAsync(e => e.Id == id);

    }
    //
    // public async Task UpdateWeigt(int id, int newWeigt)
    // {
    //     var character = await _context.Characters.FirstOrDefaultAsync(e => e.Id == id);
    //     if (character != null)
    //     {
    //         character.CurrWeight = newWeigt;
    //         _context.Characters.Update(character);
    //         await _context.SaveChangesAsync();
    //     }
    // }
    //
    // public async Task<Backpack?> DoesBackpackExisr(int idChar, int idItem)
    // {
    //     return await _context.Backpacks.FirstOrDefaultAsync(e => e.IdCharacter == idChar && e.IdItem == idItem);
    // }
    //
    // public async Task UpdateAmount(int idChar, int idItem, int amount)
    // {
    //     throw new NotImplementedException();
    // }
}