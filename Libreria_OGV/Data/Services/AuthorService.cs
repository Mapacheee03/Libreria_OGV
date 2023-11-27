using Libreria_OGV.Data.Models;
using Libreria_OGV.Data.ViewModels;
using System;
using System.Linq;

namespace Libreria_OGV.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        //metodos para agregar un nuevo Author en BD
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
        public AuthorWithBooksVM GetAuthorWithBooksVM(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Books_Authors.Select(n => n.Book.Titulo).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}
