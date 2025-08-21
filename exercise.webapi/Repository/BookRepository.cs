using exercise.webapi.Data;
using exercise.webapi.DTOs;
using exercise.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.webapi.Repository
{
    public class BookRepository : IBookRepository
    {
        DataContext _db;

        public BookRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            var books = await _db.Books
                .Select(b => new BookDto
                {
                    Title = b.Title,
                    Author = new BookAuthorDto
                    {
                        FirstName = b.Author.FirstName,
                        LastName = b.Author.LastName,
                        Email = b.Author.Email
                    },
                    Publisher = new BookPublisherDto
                    {
                        Name = b.Publisher.Name
                    }
                })
                .ToListAsync();
            
            return books;
        }

        public async Task<BookDto?> GetBook(int id)
        {
            var book = await _db.Books
                .Where(b => b.Id == id)
                .Select(b => new BookDto
                {
                    Title = b.Title,
                    Author = new BookAuthorDto
                    {
                        FirstName = b.Author.FirstName,
                        LastName = b.Author.LastName,
                        Email = b.Author.Email
                    },
                    Publisher = new BookPublisherDto
                    {
                        Name = b.Publisher.Name
                    }
                })
                .FirstOrDefaultAsync();
            
            return book;
        }

        public async Task<BookDto?> UpdateBook(int id, BookDto model)
        {
            var target = await _db.Books
                .Where(b => b.Id == id)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync();
            
            if (target == null)
            {
                return null;
            }
            
            target.Title = model.Title;
            target.Author.FirstName = model.Author.FirstName;
            target.Author.LastName = model.Author.LastName;
            target.Author.Email = model.Author.Email;
            target.Publisher.Name = model.Publisher.Name;
            
            await _db.SaveChangesAsync();
            
            return new BookDto
            {
                Title = target.Title,
                Author = new BookAuthorDto
                {
                    FirstName = target.Author.FirstName,
                    LastName = target.Author.LastName,
                    Email = target.Author.Email
                },
                Publisher = new BookPublisherDto
                {
                    Name = target.Publisher.Name
                }
            };
        }

        public async Task<BookDto?> DeleteBook(int id)
        {
            var target = await _db.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            
            if (target is null) return null;

            _db.Books.Remove(target);
            await _db.SaveChangesAsync();

            return new BookDto
            {
                Title = target.Title,
                Author = new BookAuthorDto
                {
                    FirstName = target.Author.FirstName,
                    LastName = target.Author.LastName,
                    Email = target.Author.Email
                },
                Publisher = new BookPublisherDto
                {
                    Name = target.Publisher.Name
                }
            };
        }

        public async Task<BookDto> CreateBook(BookDto book)
        {
            var target = new Book
            {
                Title = book.Title,
                Author = new Author
                {
                    FirstName = book.Author.FirstName,
                    LastName = book.Author.LastName,
                    Email = book.Author.Email
                }
            };

            _db.Books.Add(target);
            await _db.SaveChangesAsync();

            return new BookDto
            {
                Title = target.Title,
                Author = new BookAuthorDto
                {
                    FirstName = target.Author.FirstName,
                    LastName = target.Author.LastName,
                    Email = target.Author.Email
                },
                Publisher = new BookPublisherDto
                {
                    Name = target.Publisher.Name
                }
            };
        }
    }
}