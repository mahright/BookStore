using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repos
{
    public class BookDBRepos:IBookRepository<Book>
    {
        BookStoreDBContext db;
        public BookDBRepos(BookStoreDBContext _db)
        {
            db = _db;
        }
        public void Add(Book entity)
        {
            db.Books.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Books.Remove(db.Books.SingleOrDefault(b => b.Id == id));
            db.SaveChanges();
        }

        public Book Find(int id)
        {
            return db.Books.Include(a => a.Author).SingleOrDefault(b => b.Id == id);
        }

        public IList<Book> List()
        {
            return db.Books.Include(a=>a.Author).ToList();
        }

        public IList<Book> Search(string term)
        {
            var result = db.Books.Include(a => a.Author).Where(b => b.Title.Contains(term)
                                                                || b.Description.Contains(term)
                                                                || b.Author.FullName.Contains(term)).ToList();
            return result;
        }

        public void Update(int id, Book entity)
        {
            db.Books.Update(entity);
            db.SaveChanges();
        }
    }
}

