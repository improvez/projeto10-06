Console.WriteLine("Hello Olá!");

bool connect = true;
do {
    Console.WriteLine("**********************");
    Console.WriteLine("PROGRAMA DE CADASTRO");
    Console.WriteLine("**********************");
    Console.WriteLine();

    Console.WriteLine("1 - Livro");
    Console.WriteLine("2 - Autores");
    Console.WriteLine("3 - Usuários");
    Console.WriteLine("0 - SAIR");
    Console.WriteLine();
    Console.WriteLine("Digite o que deseja acessar: ");

    int menuNumber = 0;

    menuNumber = Convert.ToInt32(Console.ReadLine());
    
    switch(menuNumber) {
        case 0:
            connect = false;
        break;
        case 1:
            Console.WriteLine("Opção 1");
        break;
        case 2:
            Console.WriteLine("Opção 2");
        break;
        case 3:
            Console.WriteLine("Opção 3");
        break;

        default:
            Console.WriteLine("Opção inválida, tente novamente");
        break;
    }
} while(connect);