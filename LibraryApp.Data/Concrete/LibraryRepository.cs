using LibraryApp.Data.Abstract;
using LibraryApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.Concrete
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryContext _dbcontext;

        public LibraryRepository(LibraryContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Book> GetBooksByAuthor(string authorName)
        {
            return _dbcontext.Authors
                    .Where(author => author.Name == authorName)
                    .Join(
                        _dbcontext.Books,
                        author => author.Id,
                        book => book.AuthorId,
                        (author, book) => book)
                    .Select(result => new Book
                    {
                        Id = result.Id,
                        Title = result.Title,
                        ISBN = result.ISBN,
                        CheckedOut = result.CheckedOut,
                        AuthorId = result.Author.Id,
                        Author = result.Author 
                    })
                    .ToList();
        }

        public List<Book> GetAllCheckedOutBooks()
        {
            return _dbcontext.Books
                .Where(book => book.CheckedOut)
                .Join(
                    _dbcontext.Authors,
                    book => book.AuthorId,
                    author => author.Id,
                    (book, author) => new
                    {
                        Book = book,
                        Author = author
                    })
                .Select(result => new Book
                {
                    Id = result.Book.Id,
                    Title = result.Book.Title,
                    ISBN = result.Book.ISBN,
                    CheckedOut = result.Book.CheckedOut,
                    AuthorId = result.Author.Id,
                    Author = result.Author 
                })
                .ToList();
        }

        public async Task<bool> CheckOutBookAsync(string isbn)
        {
            var book = _dbcontext.Books.SingleOrDefault(b => b.ISBN == isbn);

            // Simulate a long-running operation
            await Task.Delay(2000);

            if (book == null)
                return false;      

            book.CheckedOut = !book.CheckedOut;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
