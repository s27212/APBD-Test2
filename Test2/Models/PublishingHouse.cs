using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class PublishingHouse
{
    [Key]
    public int IdPublishingHouse { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(50)]
    public string Country { get; set; } = null!;
    [MaxLength(50)]
    public string City { get; set; } = null!;

    public virtual List<Book> Books { get; set; } = [];
}