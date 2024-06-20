using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto10_06;

namespace projeto10_06
{
    public class BookController
    {
        private BookRepositor bookRepositor;
        public BookController() {
            bookRepositor = new BookRepositor();
        }

        public void Insert(Book book) {
            bookRepositor.Save(book);
        }

        public Book Get(int id) {
            return bookRepositor.Retrieve(id);
        }

        public List<Book> Get() {
            return bookRepositor.Retrieve();
        }

        public List<Book> GetByName(string name) {
            return bookRepositor.RetrieveByName(name);
        }

        public void Update(Book book) {
            bookRepositor.Update(book);
        }

        public void Delete(int id) {
            bookRepositor.Delete(id);
        }
    }

}