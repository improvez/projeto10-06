using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace projeto10_06
{
        public class BookRepositor
    {
        public void Save(Book book) {
            book.Id = this.GetNextId();
            DataSet.Books.Add(book);
        }

        public Book Retrieve(int id) {
            return DataSet.Books.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> Retrieve() {
            return DataSet.Books;
        }

        public List<Book> RetrieveByName(string name) {
            return DataSet.Books.Where(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Update(Book book) {
            var existingBook = Retrieve(book.Id);
            if (existingBook != null) {
                existingBook.Name = book.Name;
                existingBook.Author = book.Author;
            }
        }

        public void Delete(int id) {
            var book = Retrieve(id);
            if (book != null) {
                DataSet.Books.Remove(book);
            }
        }

        private int GetNextId() {
            return DataSet.Books.Any() ? DataSet.Books.Max(b => b.Id) + 1 : 1;
        }
    }

}