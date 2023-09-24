using LibraryApp.Data.Abstract;
using LibraryApp.Entity;
using LibraryApp.Service.Controllers;
using Moq;
using Xunit;

namespace LibraryApp.Service.UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void GetBooksByAuthor_Returns_Books_By_Author()
        {
            // Arrange
            var authorName = "Fyodor Dostoyevski"; // Replace with a valid author name
            var expectedBooks = new List<Book>
            {           
                new Book() { Id = 2, Title = "Crime and Punishment", ISBN = "978-0140449136", CheckedOut = true, AuthorId = 2, LibraryId = 1, Author = new Author { Name = "Fyodor Dostoyevski" } },
                new Book() { Id = 3, Title = "The Brothers Karamazov", ISBN = "978-0140449242", CheckedOut = true, AuthorId = 2, LibraryId = 2, Author = new Author { Name = "Fyodor Dostoyevski" } },
                new Book() { Id = 4, Title = "White Nights", ISBN = "978-0241252086", CheckedOut = false, AuthorId = 2, LibraryId = 1, Author = new Author { Name = "Fyodor Dostoyevski" } }
   
                // Add more books as needed
            };

            var mockRepository = new Mock<ILibraryRepository>();
            mockRepository.Setup(repo => repo.GetBooksByAuthor(authorName)).Returns(expectedBooks);
            var controller = new LibraryController(mockRepository.Object);

            // Act
            var result = controller.GetBooksByAuthor(authorName);

            // Assert
            var actualBooks = Assert.IsType<List<Book>>(result);
            Assert.Equal(expectedBooks, actualBooks);
        }

        [Fact]
        public void GetBooksByAuthor_Returns_NoBooks_For_InvalidAuthor()
        {
            // Arrange
            var authorName = "InvalidAuthorName"; // An author name that doesn't exist in your data
            var expectedBooks = new List<Book>(); // No expected books because the author is invalid

            var mockRepository = new Mock<ILibraryRepository>();
            mockRepository.Setup(repo => repo.GetBooksByAuthor(authorName)).Returns(expectedBooks);
            var controller = new LibraryController(mockRepository.Object);

            // Act
            var result = controller.GetBooksByAuthor(authorName);

            // Assert
            var actualBooks = Assert.IsType<List<Book>>(result);
            Assert.Empty(actualBooks); // Assert that no books were found for the invalid author
        }

        [Fact]
        public void GetAllCheckedOutBooks_Returns_CheckedOut_Books()
        {
            // Arrange
            var expectedBooks = new List<Book>
            {
                new Book() { Id = 1, Title = "Prince", ISBN = "978-1514649312", CheckedOut = true, AuthorId=1, LibraryId=1, Author = new Author { Name = "Niccolo Machiavelli" } },
                new Book() { Id = 2, Title = "Crime and Punishment", ISBN = "978-0140449136", CheckedOut = true, AuthorId = 2, LibraryId = 1, Author = new Author { Name = "Fyodor Dostoyevski" } },
                new Book() { Id = 3, Title = "The Brothers Karamazov", ISBN = "978-0140449242", CheckedOut = true, AuthorId = 2, LibraryId = 2, Author = new Author { Name = "Fyodor Dostoyevski" } },
                new Book() { Id = 4, Title = "White Nights", ISBN = "978-0241252086", CheckedOut = true, AuthorId = 2, LibraryId = 1, Author = new Author { Name = "Fyodor Dostoyevski" } }
            };

            var mockRepository = new Mock<ILibraryRepository>();
            mockRepository.Setup(repo => repo.GetAllCheckedOutBooks()).Returns(expectedBooks);
            var controller = new LibraryController(mockRepository.Object);

            // Act
            var result = controller.GetAllCheckedOutBooks();

            // Assert
            var actualBooks = Assert.IsType<List<Book>>(result);
            Assert.Equal(expectedBooks, actualBooks);
        }

        [Fact]
        public async Task CheckOutBookAsync_Returns_True_For_Valid_ISBN()
        {
            // Arrange
            var isbnToCheckOut = "978-1514649312"; // Replace with a valid ISBN

            var expectedBooks = new List<Book>
            {
                new Book() { Id = 1, Title = "Prince", ISBN = "978-1514649312", CheckedOut = false, AuthorId=1, LibraryId=1, Author = new Author { Name = "Niccolo Machiavelli" } },
                new Book() { Id = 2, Title = "Crime and Punishment", ISBN = "978-0140449136", CheckedOut = true, AuthorId = 2, LibraryId = 1, Author = new Author { Name = "Fyodor Dostoyevski" } },
                new Book() { Id = 3, Title = "The Brothers Karamazov", ISBN = "978-0140449242", CheckedOut = true, AuthorId = 2, LibraryId = 2, Author = new Author { Name = "Fyodor Dostoyevski" } },
                new Book() { Id = 4, Title = "White Nights", ISBN = "978-0241252086", CheckedOut = false, AuthorId = 2, LibraryId = 1, Author = new Author { Name = "Fyodor Dostoyevski" } }
           
                // Add more books as needed
            };

            var mockRepository = new Mock<ILibraryRepository>();
            mockRepository.Setup(repo => repo.CheckOutBookAsync(isbnToCheckOut)).ReturnsAsync(true);
            var controller = new LibraryController(mockRepository.Object);

            // Act
            var result = await controller.CheckOutBookAsync(isbnToCheckOut);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CheckOutBookAsync_Returns_False_For_Invalid_ISBN()
        {
            // Arrange
            var invalidIsbnToCheckOut = "InvalidISBN"; // Replace with an invalid ISBN

            var mockRepository = new Mock<ILibraryRepository>();
            mockRepository.Setup(repo => repo.CheckOutBookAsync(invalidIsbnToCheckOut)).ReturnsAsync(false);
            var controller = new LibraryController(mockRepository.Object);

            // Act
            var result = await controller.CheckOutBookAsync(invalidIsbnToCheckOut);

            // Assert
            Assert.False(result); // Assert that the result is false for an invalid ISBN
        }

    }
}
