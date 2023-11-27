
namespace Libreria_OGV.Data.Models
{
    public class Book_Author
    {
        public int id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
