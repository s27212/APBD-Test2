using Test2.DTO;

namespace Test2.Services;

public interface IBooksService
{
    Task<List<PublishingHouseResponse>> GetPublishingHousesInfo(string? city, string? country);
    Task AddBook(NewBookForm form);
}