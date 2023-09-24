using LibraryApp.Data.Configurations;
using LibraryApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.Concrete
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Library> Libraries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=libraryDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
               .HasMany(author => author.Books)
               .WithOne(book => book.Author)
               .HasForeignKey(book => book.AuthorId);

            modelBuilder.Entity<Book>()
               .HasKey(book => book.Id);

            modelBuilder.Entity<Library>()      
               .HasKey(library => library.Id); 

            modelBuilder.Seed();
        }
    }  
}
