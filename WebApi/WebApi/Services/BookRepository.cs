using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public class BookRepository : Interfaces.IBookRepository
    {
        private readonly DataContext _dataContext;
        public BookRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Delete(int id)
        {
            Models.Book book = Get(id);
            _dataContext.Books.Remove(book);
            _dataContext.SaveChanges();
        }

        public Book Get(int id)
        {
            return _dataContext.Books.Find(id);
        }

        public Book Insert(Book book)
        {
            _dataContext.Books.Add(book);
            _dataContext.SaveChanges();

            return book;
        }

        public List<Book> List()
        {
            return _dataContext.Books.ToList();
        }

        public Book Update(Book book)
        {
            _dataContext.Books.Update(book);
            _dataContext.SaveChanges();

            return book;
        }
    }
}
