using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace test.Models;

[Table("charactertitle")]
[PrimaryKey(nameof(IdCharacter), nameof(IdTitle))]
public class CharacterTitle
{
    public int IdCharacter { get; set; }
    public int IdTitle { get; set; }
    public DateTime AcquiredAt { get; set; }

    [ForeignKey(nameof(IdCharacter))]
    public Character Character { get; set; } = null!;
    [ForeignKey(nameof(IdTitle))]
    public Title Title { get; set; } = null!;
}