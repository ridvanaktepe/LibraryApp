using System.Text.Json.Serialization;

namespace LibraryApp.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property to list of Books
        //[JsonIgnore]
        public virtual List<Book> Books { get; set; }
    }
}
