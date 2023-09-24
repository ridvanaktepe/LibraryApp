using Microsoft.EntityFrameworkCore;
using LibraryApp.Entity;

namespace LibraryApp.Data.Configurations
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(
                new Author() { Id = 1, Name = "Niccolo Machiavelli" },
                new Author() { Id = 2, Name = "Fyodor Dostoyevski" },
                new Author() { Id = 3, Name = "William Shakespeare" }
            );

            builder.Entity<Book>().HasData(
                new Book() { Id = 1, Title = "Prince", ISBN = "978-1514649312", CheckedOut = false, AuthorId=1, LibraryId=1 },
                new Book() { Id = 2, Title = "Crime and Punishment", ISBN = "978-0140449136", CheckedOut = true, AuthorId = 2, LibraryId = 1 },
                new Book() { Id = 3, Title = "The Brothers Karamazov", ISBN = "978-0140449242", CheckedOut = true, AuthorId = 2, LibraryId = 2 },
                new Book() { Id = 4, Title = "White Nights", ISBN = "978-0241252086", CheckedOut = false, AuthorId = 2, LibraryId = 1 },
                new Book() { Id = 5, Title = "Macbeth ", ISBN = "978-0743477109", CheckedOut = true, AuthorId = 3, LibraryId = 2 },
                new Book() { Id = 6, Title = "Hamlet", ISBN = "979-8630242716", CheckedOut = false, AuthorId = 3, LibraryId = 1 }
            );

            builder.Entity<Library>().HasData(
                new Library() { Id = 1 },
                new Library() { Id = 2 }
           );
        }

    }
}
