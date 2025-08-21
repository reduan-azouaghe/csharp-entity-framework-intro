using exercise.webapi.DTOs;
using exercise.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.webapi.Endpoints;

public static class AuthorApi
{
    public static void MapAuthorEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes
            .MapGroup("/api/authors")
            .WithTags("Authors")
            .WithSummary("Authors API")
            .WithDescription("This API allows you to manage authors in the library.")
            .WithOpenApi();

        group.MapGet("/", GetAuthors)
            .WithName("GetAuthors")
            .WithSummary("Get all authors.")
            .WithDescription("Retrieves all authors.");

        group.MapGet("/{id:int}", GetAuthor)
            .WithName("GetAuthor")
            .WithSummary("Get an author by ID")
            .WithDescription("Retrieves an author by their ID.");
    }

    [ProducesResponseType(typeof(IEnumerable<AuthorDto>),StatusCodes.Status200OK)]
    private static async Task<IResult> GetAuthors(IAuthorRepository authorRepository)
    {
        var authors = await authorRepository.GetAuthors();
        return TypedResults.Ok(authors);
    }

    [ProducesResponseType(typeof(AuthorDto),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    private static async Task<IResult> GetAuthor(IAuthorRepository authorRepository, int id)
    {
        var author = await authorRepository.GetAuthor(id);
        if (author == null)
        {
            return TypedResults.NotFound($"No author with {id} found");
        }

        return TypedResults.Ok(author);
    }
}