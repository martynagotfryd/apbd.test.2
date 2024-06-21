using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace test.Models;

[Table("backpack")]
[PrimaryKey(nameof(IdCharacter), nameof(IdItem))]
public class Backpack
{
    public int IdCharacter { get; set; }
    public int IdItem { get; set; }
    public int Amount { get; set; }

    [ForeignKey(nameof(IdCharacter))]
    public Character Character { get; set; } = null!;
    [ForeignKey(nameof(IdItem))]
    public Item Item { get; set; } = null!;
}