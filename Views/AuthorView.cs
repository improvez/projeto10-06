using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto10_06;

namespace projeto10_06
{
    public class AuthorView
    {
        private AuthorController authorController;

        public AuthorView() {
            authorController = new AuthorController();
            this.Init();
        }

        public void Init() {
            Console.WriteLine("MENU AUTOR");
            Console.WriteLine("*************");
            Console.WriteLine("");

            bool connect = true;
            do {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Inserir Autor");
                Console.WriteLine("2 - Pesquisar Autor");
                Console.WriteLine("3 - Listar Autores");
                Console.WriteLine("4 - Atualizar Autor");
                Console.WriteLine("5 - Deletar Autor");
                Console.WriteLine("0 - Sair");

                int menuNumber = 0;
                try {
                    menuNumber = Convert.ToInt32(Console.ReadLine());
                    switch (menuNumber) {
                        case 0:
                            connect = false;
                            break;
                        case 1:
                            InsertAuthor();
                            break;
                        case 2:
                            SearchAuthor();
                            break;
                        case 3:
                            ListAuthors();
                            break;
                        case 4:
                            UpdateAuthor();
                            break;
                        case 5:
                            DeleteAuthor();
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

        private void InsertAuthor() {
            Console.WriteLine("****************************");
            Console.WriteLine("INSERIR NOVO AUTOR");
            Console.WriteLine("****************************");

            Author author = new Author();

            Console.WriteLine("Nome: ");
            author.Name = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Nacionalidade: ");
            author.Nationality = Console.ReadLine();
            Console.WriteLine("");

            try {
                authorController.Insert(author);
                Console.WriteLine("Autor inserido com sucesso!!");
            } catch {
                Console.WriteLine("Ops! Ocorreu um erro!!");
            }
        }

        private void SearchAuthor() {
            int connect = -1;

            do {
                Console.WriteLine("PESQUISAR AUTOR");
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
                        ShowAuthorById(id);
                        break;

                    case 2:
                        Console.WriteLine("Informe o nome: ");
                        string name = Console.ReadLine();
                        ShowAuthorByName(name);
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

        private void ShowAuthorById(int id) {
            Author a = authorController.Get(id);

            if(a != null) {
                Console.WriteLine(a.ToString());
            } else {
                Console.WriteLine($"O Autor de id {id} não encontrado!");
            }
        }

        private void ShowAuthorByName(string name) {
            List<Author> result = authorController.GetByName(name);

            if(result == null || result?.Count == 0) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            foreach (Author a in result) {
                Console.WriteLine(a.ToString());
            }
        }

        private void ListAuthors() {
            List<Author> result = authorController.Get();

            if(result == null || result?.Count == 0) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            foreach(Author author in result) {
                Console.WriteLine(author.ToString());
            }
        }

        private void UpdateAuthor() {
            Console.WriteLine("****************************");
            Console.WriteLine("ATUALIZAR AUTOR");
            Console.WriteLine("****************************");

            Console.WriteLine("Informe o id do autor a ser atualizado: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Author author = authorController.Get(id);
            if(author == null) {
                Console.WriteLine($"O Autor de id {id} não encontrado!");
                return;
            }

            Console.WriteLine($"Informe o novo nome: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName)) {
                author.Name = newName;
            }

            Console.WriteLine($"Informe a nova nacionalidade: ");
            string newNationality = Console.ReadLine();
            if (!string.IsNullOrEmpty(newNationality)) {
                author.Nationality = newNationality;
            }

            try {
                authorController.Update(author);
                Console.WriteLine("Autor atualizado com sucesso!!");
            } catch {
                Console.WriteLine("Ops! Ocorreu um erro!!");
            }
        }

        private void DeleteAuthor() {
            Console.WriteLine("****************************");
            Console.WriteLine("DELETAR AUTOR");
            Console.WriteLine("****************************");

            Console.WriteLine("Informe o id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            try {
                authorController.Delete(id);
                Console.WriteLine("Autor deletado com sucesso!!");
            } catch {
                Console.WriteLine("Ops! Ocorreu um erro!!");
            }
        }
    }
}
