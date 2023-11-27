using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;
using Libreria_OGV.Data.Models;


namespace Libreria_OGV.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Propiedades de navegacion
        public List<Book> Books { get; set; }




    }
}