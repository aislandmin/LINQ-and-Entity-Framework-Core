

using System.ComponentModel.DataAnnotations;

public class Book
{
    [Key]
    public string? ISBN {  get; set; }
    public string? Title { get; set; }
    public int EditionNumber { get; set; }
    public string? Copyright { get; set; }
}
