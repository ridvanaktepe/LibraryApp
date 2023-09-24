using System.Text.Json.Serialization;

namespace LibraryApp.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public bool CheckedOut { get; set; }

        // Foreign Key
        public int AuthorId { get; set; }
        public int LibraryId { get; set; }

        // Navigation property to Author
        //[JsonIgnore]
        public virtual Author Author { get; set; }
    }
}
