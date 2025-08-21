using exercise.webapi.Data;
using exercise.webapi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace exercise.webapi.Repository;

public class AuthorRepository : IAuthorRepository
{
    DataContext _db;

    public AuthorRepository(DataContext db)
    {
        _db = db;
    }

    public async Task<List<AuthorDto>> GetAuthors()
    {
        var authors = await _db.Authors
            .Select(a => new AuthorDto
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                Books = a.Books.Select(b => new AuthorBookDto()
                {
                    Title = b.Title,
                    Publisher = new AuthorPublisherDto { Name = b.Publisher.Name }
                })
            })
            .ToListAsync();

        return authors;
    }

    public async Task<AuthorDto?> GetAuthor(int id)
    {
        var author = await _db.Authors
            .Where(a => a.Id == id)
            .Select(a => new AuthorDto
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                Books = a.Books.Select(b => new AuthorBookDto()
                {
                    Title = b.Title,
                    Publisher = new AuthorPublisherDto { Name = b.Publisher.Name }
                })
            })
            .FirstOrDefaultAsync();
        
        return author;
    }
}