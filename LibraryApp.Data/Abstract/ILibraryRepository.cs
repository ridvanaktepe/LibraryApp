using LibraryApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.Abstract
{
    public interface ILibraryRepository
    {
        List<Book> GetBooksByAuthor(string authorName);
        List<Book> GetAllCheckedOutBooks();
        Task<bool> CheckOutBookAsync(string isbn);

    }
}
