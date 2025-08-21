namespace exercise.webapi.DTOs;

public class BookDto
{
    public string Title { get; set; }
        
    public BookAuthorDto Author { get; set; }
        
    public BookPublisherDto Publisher { get; set; }
}