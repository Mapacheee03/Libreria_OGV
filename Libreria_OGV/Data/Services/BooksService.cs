using Libreria_OGV.Data.ViewModels;
using Libreria_OGV.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using Libreria_OGV.Data;

namespace Libreria_OGV.Data.Sercices
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        //metodos para agregar un nuevo libro en BD
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,

                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherID

            };
            _context.Books.Add(_book);
            _context.SaveChanges();
            foreach (var id in book.AuthorIDs)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }

        }
        //Metodo que nos permite optener una lista de todos los libros
        public List<Book> GetAllBks() => _context.Books.ToList();
        //Metodo que nos permite optener el libro que estamos pidiendo de la BD
        public BookWithAuthorsVM GetBookById(int bookid)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.id == bookid).Select(book => new BookWithAuthorsVM()
            {

                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;


        }
        //metodo que nos permite modificar un libro que se encuentra en la BD



        public Book UpdateBookByID(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if (_book != null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookbyId(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();

            }
        }
    }
}
