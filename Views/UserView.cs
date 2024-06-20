using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto10_06;

namespace projeto10_06
{
    public class UserView
    {
        private UserController userController;

        public UserView() {
            userController = new UserController();
            this.Init();
        }

        public void Init() {
            Console.WriteLine("MENU USUÁRIO");
            Console.WriteLine("*************");
            Console.WriteLine("");

            bool connect = true;
            do {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Inserir Usuário");
                Console.WriteLine("2 - Pesquisar Usuário");
                Console.WriteLine("3 - Listar Usuários");
                Console.WriteLine("4 - Atualizar Usuário");
                Console.WriteLine("5 - Deletar Usuário");
                Console.WriteLine("0 - Sair");

                int menuNumber = 0;
                try {
                    menuNumber = Convert.ToInt32(Console.ReadLine());
                    switch (menuNumber) {
                        case 0:
                            connect = false;
                            break;
                        case 1:
                            InsertUser();
                            break;
                        case 2:
                            SearchUser();
                            break;
                        case 3:
                            ListUsers();
                            break;
                        case 4:
                            UpdateUser();
                            break;
                        case 5:
                            DeleteUser();
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

        private void InsertUser() {
            Console.WriteLine("****************************");
            Console.WriteLine("INSERIR NOVO USUÁRIO");
            Console.WriteLine("****************************");

            User user = new User();

            Console.WriteLine("Nome de usuário: ");
            user.Username = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Email: ");
            user.Email = Console.ReadLine();
            Console.WriteLine("");

            try {
                userController.Insert(user);
                Console.WriteLine("Usuário inserido com sucesso!!");
            } catch {
                Console.WriteLine("Ops! Ocorreu um erro!!");
            }
        }

        private void SearchUser() {
            int connect = -1;

            do {
                Console.WriteLine("PESQUISAR USUÁRIO");
                Console.WriteLine("*********************");
                Console.WriteLine("1 - Buscar por id");
                Console.WriteLine("2 - Buscar por nome de usuário");
                Console.WriteLine("0 - Sair");

                string menuOpt = Console.ReadLine();
                connect = Convert.ToInt16(menuOpt);

                switch(connect) {
                    case 1:
                        Console.WriteLine("Informe o id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        ShowUserById(id);
                        break;

                    case 2:
                        Console.WriteLine("Informe o nome de usuário: ");
                        string username = Console.ReadLine();
                        ShowUserByUsername(username);
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

        private void ShowUserById(int id) {
            User u = userController.Get(id);

            if(u != null) {
                Console.WriteLine(u.ToString());
            } else {
                Console.WriteLine($"O Usuário de id {id} não encontrado!");
            }
        }

        private void ShowUserByUsername(string username) {
            List<User> result = userController.GetByUsername(username);

            if(result == null || result?.Count == 0) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            foreach (User u in result) {
                Console.WriteLine(u.ToString());
            }
        }

        private void ListUsers() {
            List<User> result = userController.Get();

            if(result == null || result?.Count == 0) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            foreach(User user in result) {
                Console.WriteLine(user.ToString());
            }
        }

        private void UpdateUser() {
            Console.WriteLine("****************************");
            Console.WriteLine("ATUALIZAR USUÁRIO");
            Console.WriteLine("****************************");

            Console.WriteLine("Informe o id do usuário a ser atualizado: ");
            int id = Convert.ToInt32(Console.ReadLine());

            User user = userController.Get(id);
            if(user == null) {
                Console.WriteLine($"O Usuário de id {id} não encontrado!");
                return;
            }

            Console.WriteLine($"Informe o novo nome de usuário: ");
            string newUsername = Console.ReadLine();
            if (!string.IsNullOrEmpty(newUsername)) {
                user.Username = newUsername;
            }

            Console.WriteLine($"Informe o novo email: ");
            string newEmail = Console.ReadLine();
            if (!string.IsNullOrEmpty(newEmail)) {
                user.Email = newEmail;
            }

            try {
                userController.Update(user);
                Console.WriteLine("Usuário atualizado com sucesso!!");
            } catch {
                Console.WriteLine("Ops! Ocorreu um erro!!");
            }
        }

        private void DeleteUser() {
            Console.WriteLine("****************************");
            Console.WriteLine("DELETAR USUÁRIO");
            Console.WriteLine("****************************");

            Console.WriteLine("Informe o id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            try {
                userController.Delete(id);
                Console.WriteLine("Usuário deletado com sucesso!!");
            } catch {
                Console.WriteLine("Ops! Ocorreu um erro!!");
            }
        }
    }
}
