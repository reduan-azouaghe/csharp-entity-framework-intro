using exercise.webapi.DTOs;
using exercise.webapi.Models;
using exercise.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.webapi.Endpoints
{
    public static class BookApi
    {
        public static void MapBookEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes
                .MapGroup("/api/books")
                .WithTags("Books")
                .WithSummary("Books API")
                .WithDescription("This API allows you to manage books in the library.")
                .WithOpenApi();

            group.MapGet("/", GetBooks)
                .WithName("GetBooks")
                .WithSummary("Get all books.")
                .WithDescription("Retrieves all books.");

            group.MapGet("/{id:int}", GetBook)
                .WithName("GetBook")
                .WithSummary("Get a book by ID")
                .WithDescription("Retrieves a book by its ID.");

            group.MapPost("/{id:int}", UpdateBook)
                .WithName("UpdateBook")
                .WithSummary("Update book by ID.")
                .WithDescription("Updates the entity retrieved with ID with date from new entity.");

            group.MapDelete("/{id:int}", DeleteBook)
                .WithName("DeleteBook")
                .WithSummary("Delete a book by ID.")
                .WithDescription("Deletes a book by its ID.");

            group.MapPut("/", CreateBook)
                .WithName("CreateBook")
                .WithSummary("Create a new book.")
                .WithDescription("Creates a new book in the library.");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetBooks(IBookRepository repository)
        {
            var books = await repository.GetBooks();
            return TypedResults.Ok(books);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetBook(IBookRepository repository, int id)
        {
            var book = await repository.GetBook(id);

            if (book == null)
            {
                return TypedResults.NotFound($"Book with ID {id} not found.");
            }

            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> UpdateBook(IBookRepository repository, int id, BookDto author)
        {
            var book = await repository.UpdateBook(id, author);

            if (book == null)
            {
                return TypedResults.NotFound($"Book with ID {id} not found.");
            }

            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteBook(IBookRepository repository, int id)
        {
            var book = await repository.DeleteBook(id);

            if (book == null)
            {
                return TypedResults.NotFound($"Book with ID {id} not found.");
            }

            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> CreateBook(IBookRepository repository, BookDto book)
        {
            var createdBook = await repository.CreateBook(book);
            return TypedResults.Ok(createdBook);
        }
    }
}