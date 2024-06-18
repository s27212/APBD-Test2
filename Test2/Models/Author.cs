using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Author
{
    [Key]
    public int IdAuthor { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }

    public List<Book> Books { get; set; } = [];

}