using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto10_06
{
    public class AuthorController
    {
        private AuthorRepositor authorRepositor;
        public AuthorController() {
            authorRepositor = new AuthorRepositor();
        }

        public void Insert(Author author) {
            authorRepositor.Save(author);
        }

        public Author Get(int id) {
            return authorRepositor.Retrieve(id);
        }

        public List<Author> Get() {
            return authorRepositor.Retrieve();
        }

        public List<Author> GetByName(string name) {
            return authorRepositor.RetrieveByName(name);
        }

        public void Update(Author author) {
            authorRepositor.Update(author);
        }

        public void Delete(int id) {
            authorRepositor.Delete(id);
        }
    }
}
