using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repos
{
    public class AuthorRepos : IBookRepository<Author>
    {
        List<Author> authors;
        public AuthorRepos()
        {
            authors = new List<Author>()
            {
                new Author(){ Id=1, FullName="mahmoud"},
                new Author(){ Id=2, FullName="samer"},
                new Author(){ Id=3,FullName="nader"}
            };
        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(b => b.Id) + 1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public IList<Author> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Author entity)
        {
            var author = Find(id);
            author.FullName = entity.FullName;
        }
    }
}
