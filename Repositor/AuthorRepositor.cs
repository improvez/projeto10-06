using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto10_06
{
    public class AuthorRepositor
    {
        public void Save(Author author) {
            author.Id = this.GetNextId();
            DataSet.Authors.Add(author);
        }

        public Author Retrieve(int id) {
            return DataSet.Authors.FirstOrDefault(a => a.Id == id);
        }

        public List<Author> Retrieve() {
            return DataSet.Authors;
        }

        public List<Author> RetrieveByName(string name) {
            return DataSet.Authors.Where(a => a.Name.Contains(name)).ToList();
        }

        public void Update(Author author) {
            var existingAuthor = Retrieve(author.Id);
            if (existingAuthor != null) {
                existingAuthor.Name = author.Name;
                existingAuthor.Nationality = author.Nationality;
            }
        }

        public void Delete(int id) {
            var author = Retrieve(id);
            if (author != null) {
                DataSet.Authors.Remove(author);
            }
        }

        private int GetNextId() {
            return DataSet.Authors.Any() ? DataSet.Authors.Max(a => a.Id) + 1 : 1;
        }
    }
}
