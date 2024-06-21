namespace test.DTOs;

public class GetCharacterInfoDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int CurrWeight { get; set; }
    public int MaxWeight { get; set; }
    public ICollection<GetBackpackItemsInfoDTO> BackpackItems { get; set; } = null!;

}

public class GetBackpackItemsInfoDTO
{
    public string Name { get; set; } = string.Empty;
    public int Weight { get; set; }
    public int Amount { get; set; }
}
