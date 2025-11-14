using System.ComponentModel.DataAnnotations;

namespace FlashCardsPc.Models;
public class Card
{
    public Guid Id { get; set; }

    [Required]
    public string Recto { get; set; } = string.Empty;

    [Required]
    public string Verso { get; set; } = string.Empty;

    public DateTime NextAppareance { get; set; }
    public int Strike { get; set; } = 1;
    public bool IsRectoSide { get; set; }
}
