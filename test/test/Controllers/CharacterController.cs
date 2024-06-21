using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using test.DTOs;
using test.Models;
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

    [HttpPost]
    public async Task<IActionResult> AddItems(int idCharacter, List<AddItemsDTO> itemsDtos)
    {
        if (!await _dbService.DoesCharacterExist(idCharacter))
        {
            return NotFound("character doesnt exist");
        }

        var character = await _dbService.GetItemById(idCharacter);
        var currWeight = character.CurrWeight;
        
        var items = new List<Backpack>();

        Item item = null;

        foreach (var newItem in itemsDtos)
        {
            
            if (!await _dbService.DoesItemExist(newItem.Id))
            {
                return NotFound("Item doesnt exist");
            }

            item = await _dbService.GetCharById(newItem.Id);

            if (await _dbService.DoesBackpackExisr(idCharacter, item.Id))
            {
                await _dbService.UpdateAmount(idCharacter, item.Id, newItem.Amount);
                currWeight +=item.Weight*newItem.Amount;
            }
            
            else if (currWeight <= character.MaxWeight)
            {
                items.Add(new Backpack()
                {
                    IdCharacter = idCharacter,
                    Amount = newItem.Amount,
                    IdItem = newItem.Id
                });
                currWeight += item.Weight*newItem.Amount;
            } else
            {
                return BadRequest("Items weight too much");
            }
        }
        
        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            
            await _dbService.AddItems(items);
            await _dbService.UpdateWeigt(idCharacter, currWeight);
            
            
            scope.Complete();
        }

        return Created();
    }
}