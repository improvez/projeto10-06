using System;
using System.Collections.Generic;
using System.Linq;
using projeto10_06;

namespace projeto10_06
{
    public class BookView
    {
        private BookController bookController;

        public BookView() {
            bookController = new BookController();
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
                Console.WriteLine("6 - Livros mais bem avaliados");
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
                            ListTopRatedBooks(); // Nova funcionalidade
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            connect = true;
                            break;
                    }
                } catch {
                    Console.WriteLine("Opção inválida, tente novamente");
                    menuNumber = -1;
                }
            } while (connect);
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

            Console.WriteLine("Gênero: ");
            book.Genre = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Avaliação (0 a 5): ");
            book.Rated = Convert.ToDouble(Console.ReadLine());
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
                Console.WriteLine("*********************");
                Console.WriteLine("Digite o número desejado: ");

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

            if(result == null || result?.Count == 0) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            foreach (Book b in result) {
                Console.WriteLine(b.ToString());
            }
        }

        private void ListBooks() {
            List<Book> result = bookController.Get();

            if(result == null || result?.Count == 0) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            foreach(Book book in result) {
                Console.WriteLine(book.ToString());
            }
        }

        private void UpdateBook() {
            Console.WriteLine("****************************");
            Console.WriteLine("ATUALIZAR LIVRO");
            Console.WriteLine("****************************");

            Console.WriteLine("Informe o id do livro a ser atualizado: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Book book = bookController.Get(id);
            if(book == null) {
                Console.WriteLine($"O Livro de id {id} não encontrado!");
                return;
            }

            Console.WriteLine($"Informe o novo nome: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName)) {
                book.Name = newName;
            }

            Console.WriteLine($"Informe o novo autor: ");
            string newAuthor = Console.ReadLine();
            if (!string.IsNullOrEmpty(newAuthor)) {
                book.Author = newAuthor;
            }

            Console.WriteLine($"Informe o novo gênero: ");
            string newGenre = Console.ReadLine();
            if (!string.IsNullOrEmpty(newGenre)) {
                book.Genre = newGenre;
            }

            Console.WriteLine($"Informe a nova avaliação: ");
            string newRatedStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(newRatedStr)) {
                book.Rated = Convert.ToDouble(newRatedStr);
            }

            try {
                bookController.Update(book);
                Console.WriteLine("Livro atualizado com sucesso!!");
            } catch {
                Console.WriteLine("Ops! Ocorreu um erro!!");
            }
        }

        private void DeleteBook() {
            Console.WriteLine("****************************");
            Console.WriteLine("DELETAR LIVRO");
            Console.WriteLine("****************************");

            Console.WriteLine("Informe o id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            try {
                bookController.Delete(id);
                Console.WriteLine("Livro deletado com sucesso!!");
            } catch {
                Console.WriteLine("Ops! Ocorreu um erro!!");
            }
        }

        private void ListTopRatedBooks() {
            Console.WriteLine("****************************");
            Console.WriteLine("LISTA DOS LIVROS MAIS BEM AVALIADOS");
            Console.WriteLine("****************************");

            List<Book> topRatedBooks = bookController.Get()
                                                .OrderByDescending(b => b.Rated)
                                                .ToList();

            if(topRatedBooks == null || topRatedBooks.Count == 0) {
                Console.WriteLine("Nenhum livro encontrado!");
                return;
            }

            foreach(Book book in topRatedBooks) {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
