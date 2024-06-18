namespace Test2.DTO;

public class PublishingHouseResponse
{
    public int IdPublishingHouse { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    public virtual List<BookResponse> Books { get; set; } = [];
}