using exercise.webapi.Models;

namespace exercise.webapi.DTOs;

public class AuthorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public IEnumerable<AuthorBookDto> Books { get; set; }
}