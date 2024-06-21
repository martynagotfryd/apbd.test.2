using test.Models;

namespace test.Services;

public interface IDbService
{
    Task<bool> DoesCharacterExist(int id);
    Task<ICollection<Character>> GetCharacterInfo(int id);
    Task AddItems(IEnumerable<Backpack> backpacks);
    Task<bool> DoesItemExist(int id);
    Task<Character> GetItemById(int id);
    Task<Item> GetCharById(int id);
    // Task UpdateWeigt(int id, int newWeight);
    // Task<Backpack?> DoesBackpackExisr(int idChar, int idItem);
    // Task UpdateAmount(int idChar, int idItem, int amount);

}