using LibraryApp.Data.Abstract;
using LibraryApp.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]   
    public class LibraryController : ControllerBase
    {
        private ILibraryRepository _libraryRepository;

        public LibraryController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet(Name = "GetBooksByAuthor")]
        public List<Book> GetBooksByAuthor(string authorName)
        {
            return _libraryRepository.GetBooksByAuthor(authorName);  
               
        }

        [HttpGet(Name = "GetAllCheckedOutBooks")]
        public List<Book> GetAllCheckedOutBooks()
        {
            return _libraryRepository.GetAllCheckedOutBooks();
        }

        [HttpGet(Name = "CheckOutBookAsync")]
        public async Task<bool> CheckOutBookAsync(string isbn)
        {         
            return await _libraryRepository.CheckOutBookAsync(isbn);
        }

    }
}
