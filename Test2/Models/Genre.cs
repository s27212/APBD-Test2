using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Genre
{
    [Key]
    public int IdGenre { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    public virtual List<Book> Books { get; set; } = [];
}