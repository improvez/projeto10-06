using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto10_06.Controller;

namespace projeto10_06
{
    public class BookView
    {
        private BookController bookController;

        public BookView() {
            BookController = new BookController();
            this.Init();
        }

        public void Init() {
            Console.WriteLine("MENU LIVRO");
            Console.WriteLine("*************");
            Console.WriteLine("");

            bool connect = true;
            do {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Inserir Livro");
                Console.WriteLine("2 - Pesquisar Livro");
                Console.WriteLine("3 - Listar Livros");
                Console.WriteLine("4 - Atualizar Livro");
                Console.WriteLine("5 - Deletar Livro");
                Console.WriteLine("6 - Exportar dados delimitados");
                Console.WriteLine("7 - Importar dados delimitados");
                Console.WriteLine("0 - Sair");

                int menuNumber = 0;
                try {
                    menuNumber = Convert.ToInt32(Console.ReadLine());
                    switch (menuNumber) {
                        case 0:
                            connect = false;
                        break;
                        case 1:
                            InsertBook();
                        break;
                        case 2:
                            SearchBook();
                        break;
                        case 3:
                            ListBooks();
                        break;
                        case 4: 
                            UpdateBook();
                        break;
                        case 5:
                            DeleteBook();
                        break;
                        case 6:
                            if(bookController.Exp)

                        default:
                            Console.WriteLine("Opção inválida");
                            connect = true;
                        break;
                    }
                } catch {
                    Console.WriteLine("Opção inválida, tente denovo");
                    menuNumber = -1;
                }
            } while(connect);
        }

        private void InsertBook() {
            Console.WriteLine("****************************");
            Console.WriteLine("INSERIR NOVO LIVRO");
            Console.WriteLine("****************************");

            Book book = new Book();

            Console.WriteLine("Nome: ");
            book.Name = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Autor: ");
            book.Author = Console.ReadLine();
            Console.WriteLine("");

            try {
                bookController.Insert(book);
                Console.WriteLine("Livro inserido com sucesso!!");
            } catch {
                Console.WriteLine("Ops! Ocorreu um erro!!");
            }
        }

        private void SearchBook() {

            int connect = -1;

            do {
                Console.WriteLine("PESQUISAR LIVRO");
                Console.WriteLine("*********************");
                Console.WriteLine("1 - Buscar por id");
                Console.WriteLine("2 - Buscar por nome");
                Console.WriteLine("0 - Sair");

                string menuOpt = Console.ReadLine();
                connect = Convert.ToInt16(menuOpt);

                switch(connect) {
                    case 1:
                        Console.WriteLine("Informe o id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        ShowBookById(id);
                    break;
                    
                    case 2: 
                        Console.WriteLine("Informe o nome: ");
                        string name = Console.ReadLine();
                        ShowBookByName(name);
                    break;
                    
                    case 0:
                    break;

                    default:
                        connect = -1;
                        Console.WriteLine("Opção inválida!");
                    break;
                }
            } while(connect != 0);
        }

        private void ShowBookById(int id) {
            Book b = bookController.Get(id);

            if(b != null) {
                Console.WriteLine(b.ToString());
            } else {
                Console.WriteLine($"O Livro de id {id} não encontrado!");
            }
        }

        private void ShowBookByName(string name) {
            List<Book> result = bookController.GetByName(name);

            if(result == null || result?.Count == 0 && (result?.Count < 3)) {
                Console.WriteLine("Não encontrado!");
                return;
            }
            
            foreach (Book b in result) {
                Console.WriteLine(b.ToString());
            }
        }

        private void ListBooks() {
            List<Book> result = bookController.Get();

            if(result == null || result?.Count == 0 && (result?.Count < 3)) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            foreach(Book book in result) {
                Console.WriteLine(book.ToString());
            }
        }
    }
}