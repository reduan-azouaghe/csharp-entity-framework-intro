using exercise.webapi.Data;
using exercise.webapi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace exercise.webapi.Repository;

public class PublisherRepository : IPublisherRepository
{
    DataContext _db;

    public PublisherRepository(DataContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<PublisherDto>> GetPublishers()
    {
        var publishers = await _db.Publishers
            .Select(p => new PublisherDto
            {
                Name = p.Name,
                Books = p.Books.Select(b => new PublisherBookDto()
                {
                    Title = b.Title,
                    Author = new PublisherAuthorDto
                    {
                        FirstName = b.Author.FirstName,
                        LastName = b.Author.LastName,
                        Email = b.Author.Email
                    }
                })
            })
            .ToListAsync();

        return publishers;
    }

    public async Task<PublisherDto?> GetPublisher(int id)
    {
        var publisher = await _db.Publishers.Include(p => p.Books)
            .Where(p => p.Id == id)
            .Select(p => new PublisherDto
            {
                Name = p.Name,
                Books = p.Books.Select(b => new PublisherBookDto()
                {
                    Title = b.Title,
                    Author = new PublisherAuthorDto
                    {
                        FirstName = b.Author.FirstName,
                        LastName = b.Author.LastName,
                        Email = b.Author.Email
                    }
                })
            })
            .FirstOrDefaultAsync();

        return publisher;
    }
}