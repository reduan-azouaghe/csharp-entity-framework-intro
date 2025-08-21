using exercise.webapi.DTOs;

namespace exercise.webapi.Repository;

public interface IAuthorRepository
{
    public Task<List<AuthorDto>> GetAuthors();
    
    public Task<AuthorDto?> GetAuthor(int id);
}