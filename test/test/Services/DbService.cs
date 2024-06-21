using test.Data;

namespace test.Services;

public class DbService : IDbService
{
    private readonly DataBaseContext _context;

    public DbService(DataBaseContext context)
    {
        _context = context;
    }

    // public async Task<bool> DoesExist(int id)
    // {
    //     
    // }
}