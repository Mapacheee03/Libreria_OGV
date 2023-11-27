using System.Collections.Generic;

namespace Libreria_OGV.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //propiedades de navegacion
        public List<Book_Author> Books_Authors { get; set; }
    }
}
