using System.Text.Json.Serialization;

namespace LibraryApp.Entity
{
    public class Library
    {
        public int Id { get; set; }

        // Navigation property to list of Books
        //[JsonIgnore]
        public virtual  List<Book> Books { get; set; }
      
    }
}
