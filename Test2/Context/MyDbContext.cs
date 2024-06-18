using Microsoft.EntityFrameworkCore;
using Test2.Models;

public class MyDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }
    public DbSet<Genre> Genres { get; set; }
    private readonly string? _connectionString;

    public MyDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<PublishingHouse> pubHouses =
        [
            new PublishingHouse() { IdPublishingHouse = 1, Name = "Pub1", City = "Warsaw", Country = "Poland" },
            new PublishingHouse() { IdPublishingHouse = 2, Name = "Pub2", City = "Warsaw", Country = "Poland" },
            new PublishingHouse() { IdPublishingHouse = 3, Name = "Pub3", City = "Kharkiv", Country = "Ukraine" }
        ];
        modelBuilder.Entity<PublishingHouse>().HasData(pubHouses);
        // List<Book> books =
        // [
        //     new Book() {IdBook = 1, Name = "Book1", IdPublishingHouse = 1, ReleaseDate = DateTime.Today, PublishingHouse = pubHouses[1]},
        //     new Book() {IdBook = 2, Name = "Book2", IdPublishingHouse = 1, ReleaseDate = DateTime.Today, PublishingHouse = pubHouses[1] },
        //     new Book() {IdBook = 3, Name = "Book3", IdPublishingHouse = 1, ReleaseDate = DateTime.Today,PublishingHouse = pubHouses[1] }
        // ];
        // modelBuilder.Entity<Book>().HasData(books);
        //
        
        // modelBuilder.Entity<Genre>().HasData(
        //     new Author() { IdAuthor = 1, FirstName = "FirstName1", LastName = "LasName1", Books = books }
        // );
        //
        // modelBuilder.Entity<Genre>().HasData(
        //     new Genre() { IdGenre = 1, Name = "Genre1", Books = books}
        // );        
    }
}