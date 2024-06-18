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

        public bool ExportDelimited() {
            List<Book> list = bookRepositor.Retrieve();

            string fileContent = string.Empty;

            foreach(var b in list) {
                fileContent += $"{b.PrintToExportDelimited()}\n";
            }

            string fileName = $"Customer_{DateTimeOffset.Now.ToUnixTimeSeconds()}.txt";

            return ExportToFile.SaveToDelimitedTxt(fileName, fileContent);
        }

        public string ImportFromDelimited(string fileName, string delimiter) {
            bool result = true;
            string msgReturn = string.Empty;
            int lineCountSuccess = 0;
            int lineCountError = 0;
            int lineCountTotal = 0;

            try {
                if(!File.Exists(fileName)) {
                    return "ERRO: Arquivo de importação não encontrado.";

                    using(StreamReader sr = new StreamReader(fileName)) {
                        string line = string.Empty;
                        while((line = sr.ReadLine()) != null) {
                            lineCountTotal++;
                            if(!bookRepositor.Import)
                        }
                    }
                }
            }
        }
    }
}