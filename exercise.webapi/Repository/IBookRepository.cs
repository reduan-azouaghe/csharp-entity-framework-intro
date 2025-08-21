using exercise.webapi.DTOs;
using exercise.webapi.Models;

namespace exercise.webapi.Repository
{
    public interface IBookRepository
    {
        public Task<BookDto> CreateBook(BookDto book);
        public Task<IEnumerable<BookDto>> GetBooks();
        public Task<BookDto?> GetBook(int id);
        public Task<BookDto?> UpdateBook(int id, BookDto book);
        public Task<BookDto?> DeleteBook(int id);
    }
}
