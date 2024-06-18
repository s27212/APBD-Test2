using Microsoft.EntityFrameworkCore;
using Test2.DTO;
using Test2.Models;

namespace Test2.Services;

public class BooksService : IBooksService
{
    private readonly MyDbContext _context;

    public BooksService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<PublishingHouseResponse>> GetPublishingHousesInfo(string? city, string? country)
    {
        var pubHousesQuery = _context.PublishingHouses.AsQueryable();
        if (city != null)
        {
            pubHousesQuery = pubHousesQuery.Where(e => e.City == city);
        }

        if (country != null)
        {
            pubHousesQuery = pubHousesQuery.Where(e => e.Country == country);
        }

        var pubHouses = await pubHousesQuery.OrderBy(e => e.Country).ThenBy(e => e.Name)
            .Select(e => new PublishingHouseResponse()
            {
                IdPublishingHouse = e.IdPublishingHouse,
                City = e.City,
                Name = e.Name,
                Country = e.Country,
                Books = e.Books.Select(b => new BookResponse()
                {
                    IdBook = b.IdBook,
                    Name = b.Name,
                    ReleaseDate = b.ReleaseDate,
                    Authors = b.Authors.Select(a => new AuthorResponse()
                    {
                        IdAuthor = a.IdAuthor,
                        FirstName = a.FirstName,
                        LastName = a.LastName
                    }).ToList(),
                    Genres = b.Genres.Select(g => new GenreResponse()
                    {
                        IdGenre = g.IdGenre,
                        Name = g.Name
                    }).ToList()

                }).ToList()
            }).ToListAsync();
        return pubHouses;
    }

    public async Task AddBook(NewBookForm form)
    {
        if (!await _context.PublishingHouses.AnyAsync(e => e.IdPublishingHouse == form.PublishingHouseID))
        {
            throw new ArgumentException("Publishing house does not exist");
        }
        
        foreach (var authorId in form.AuthorIds)
        {
            if (!await _context.Authors.AnyAsync(e => e.IdAuthor == authorId))
            {
                throw new ArgumentException();
            }
        }

        var authors = await _context.Authors.Where(e => form.AuthorIds.Contains(e.IdAuthor))
            .ToListAsync();

        foreach (var genre in form.Genres)
        {
            if (!await _context.Genres.AnyAsync(e => e.IdGenre == genre.genreID))
            {
                await _context.Genres.AddAsync(new Genre() { Name = genre.genreName });
            }
            await _context.SaveChangesAsync();
        }

        var genres = await _context.Genres.Where(e => form.Genres.Select(fg => fg.genreID)
            .Contains(e.IdGenre)).ToListAsync();

        var book = new Book()
        {
            Name = form.Name,
            ReleaseDate = form.ReleaseDate,
            Authors = authors,
            Genres = genres,
            IdPublishingHouse = form.PublishingHouseID
        };

        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }
}