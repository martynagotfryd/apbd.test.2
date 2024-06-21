using Microsoft.AspNetCore.Mvc;
using test.DTOs;
using test.Services;

namespace test.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharacterController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCharacterInfoById(int id)
    {
        if (!await _dbService.DoesCharacterExist(id))
        {
            return NotFound("Character with given Id doesnt exist");
        }

        var characters = await _dbService.GetCharacterInfo(id);

        return Ok(characters.Select(e => new GetCharacterInfoDTO()
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            CurrWeight = e.CurrWeight,
            MaxWeight = e.MaxWeight,
            BackpackItems = e.Backpacks.Select(b => new GetBackpackItemsInfoDTO()
            {
                Name = b.Item.Name,
                Weight = b.Item.Weight,
                Amount = b.Amount
            }).ToList()
        }));
    }
}