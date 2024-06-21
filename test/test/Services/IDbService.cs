using test.Models;

namespace test.Services;

public interface IDbService
{
    Task<bool> DoesCharacterExist(int id);
    Task<ICollection<Character>> GetCharacterInfo(int id);

}