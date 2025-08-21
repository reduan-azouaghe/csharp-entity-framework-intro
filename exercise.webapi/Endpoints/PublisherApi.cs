using exercise.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.webapi.Endpoints;

public static class PublisherApi
{
    public static void MapPublisherEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes
            .MapGroup("/api/publishers")
            .WithTags("Publishers")
            .WithSummary("Publishers API")
            .WithDescription("This API allows you to manage publishers in the library.")
            .WithOpenApi();
        
        group.MapGet("/", GetPublishers)
            .WithName("GetPublishers")
            .WithSummary("Get all publishers.")
            .WithDescription("Retrieves all publishers.");

        group.MapGet("/{id:int}", GetPublisher)
            .WithName("GetPublisher")
            .WithSummary("Get a publisher by ID")
            .WithDescription("Retrieves a publisher by its ID.");
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    private static async Task<IResult> GetPublishers(IPublisherRepository repository)
    {
        return TypedResults.Ok(await repository.GetPublishers());
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    private static async Task<IResult> GetPublisher(IPublisherRepository repository, int id)
    {
        var publisher = await repository.GetPublisher(id);

        if (publisher == null)
        {
            return TypedResults.NotFound($"Publisher with ID {id} not found.");
        }

        return TypedResults.Ok(publisher);
    }
}