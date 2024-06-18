using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Book
{
    [Key]
    public int IdBook { get; set; }
    public string Name { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public int IdPublishingHouse { get; set; }
    public virtual PublishingHouse PublishingHouse { get; set; } = null!;
    public virtual List<Author> Authors { get; set; } = [];
    public virtual List<Genre> Genres { get; set; } = [];
}