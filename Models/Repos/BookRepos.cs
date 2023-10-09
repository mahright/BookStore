using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repos
{
    public class BookRepos : IBookRepository<Book>
    {
        List<Book> Books;
        public BookRepos()
        {
            Books = new List<Book>() {
            new Book{
                Id=1, Title="c# programming", Description="no data", ImageUrl="bg_2.jpg", Author=new Author{}
            },
            new Book{
                Id=2, Title="java programming", Description="no data", ImageUrl="bg_2.jpg", Author=new Author()
            },
            new Book{
                Id=3, Title="python programming", Description="no data", ImageUrl="Untitled-1.png", Author=new Author()
            }
            };
        }
        public void Add(Book entity)
        {
            entity.Id = Books.Max(b => b.Id) + 1;
            Books.Add(entity);
        }

        public void Delete(int id)
        {
            Books.Remove(Books.SingleOrDefault(b => b.Id == id));

        }

        public Book Find(int id)
        {
            return Books.SingleOrDefault(b => b.Id == id);
        }

        public IList<Book> List()
        {
            return Books;
        }

        public IList<Book> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Book entity)
        {
            var book = Books.SingleOrDefault(b => b.Id == id);
            book.Title = entity.Title;
            book.Description = entity.Description;
            book.Author = entity.Author;
            book.ImageUrl = entity.ImageUrl;
        }
    }
}
