namespace Test2.DTO;

public class NewBookForm
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int PublishingHouseID { get; set; }
    public List<int> AuthorIds { get; set; }
    public List<(int genreID, string genreName)> Genres { get; set; }
}