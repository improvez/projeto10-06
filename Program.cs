using projeto10_06;

bool connect = true;
do
{
    Console.WriteLine("**********************");
    Console.WriteLine("BIBLIOTECA");
    Console.WriteLine("**********************");
    Console.WriteLine();

    Console.WriteLine("1 - Livro");
    Console.WriteLine("2 - Autores");
    Console.WriteLine("3 - Usuários");
    Console.WriteLine("0 - SAIR");
    Console.WriteLine();
    Console.WriteLine("Digite o que deseja acessar: ");

    int menuNumber = 0;

    try
    {
        menuNumber = Convert.ToInt32(Console.ReadLine());

        switch (menuNumber)
        {
            case 0:
                connect = false;
                break;
            case 1:
                BookView bookView = new BookView();
                break;
            case 2:
                AuthorView authorView = new AuthorView();
                break;
            case 3:
                UserView userView = new UserView();
                break;
            default:
                Console.WriteLine("Opção inválida, tente novamente");
                break;
        }
    }
    catch
    {
        Console.WriteLine("Opção inválida.");
        menuNumber = -1;
        connect = true;
    }
} while (connect);
