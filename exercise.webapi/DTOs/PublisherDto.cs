namespace exercise.webapi.DTOs;

public class PublisherDto
{
    public string Name { get; set; }
    public IEnumerable<PublisherBookDto> Books { get; set; } = new List<PublisherBookDto>();
}