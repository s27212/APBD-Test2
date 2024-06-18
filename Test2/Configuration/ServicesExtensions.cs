using Test2.Services;

namespace Actors.Configuration;

public static class ServicesExtensions
{
    public static void RegisterServices(this IServiceCollection app)
    {
        app.AddDbContext<MyDbContext>();
        app.AddScoped<IBooksService, BooksService>();
    }
}