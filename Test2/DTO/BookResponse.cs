namespace Test2.DTO;

public class BookResponse
{
    public int IdBook { get; set; }
    public string Name { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public virtual List<AuthorResponse> Authors { get; set; } = [];
    public virtual List<GenreResponse> Genres { get; set; } = [];
}