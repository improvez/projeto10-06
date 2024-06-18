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

        public void Save(Book book, bool autoGenerateId = true) {
            if(autoGenerateId) book.Id = this.GetNextId();
            DataSet.Books.Add(book);
        }

        public Book Retrieve(int id) {
            Book book = new Book();
            book = new Book();
            foreach(var c in DataSet.Books) {
                if(c.Id == id) return c;
            }
            return null;
        }

        public List<Book> Retrieve() {
            return DataSet.Books;
        }

        public List<Book> RetrieveByName(string name) {
            List<Book> retorno = new List<Book>();

            foreach(var c in DataSet.Books) {
                if(c.Name.Contains(name)) {
                    retorno.Add(c);
                }
            }
            return retorno;
        }

        public List<Book> SearchByName(string name) {
            if(name.Length < 4) return new List<Book>();
            
            name = name.ToLower();
            
            return DataSet.Books.Where(c => c.Name.ToLower().Contains(name)).ToList();
        }

        public bool ImportFromTxt(string Line, string delimiter) {

            if(string.IsNullOrWhiteSpace(Line)) return false;

            string[] data = Line.Split(delimiter);

            if(data.Count() < 1) return false;

            Book b = new Book() {
                Id = Convert.ToInt32((data[0] == null ? 0 : data[0])),
                Name = (data[1] == null ? string.Empty : data[1])
            };

            Save(b, false);
            return true;
        }

        private int GetNextId() {
            int n = 0;
            foreach(var c in DataSet.Books) {
                if(c.Id > n) n = c.Id;
            }
            return ++n;
        }
    }
}