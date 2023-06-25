// See https://aka.ms/new-console-template for more information

using ByteBank;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

static void Main(string[] args)
{
    AccountManager accountManager = new AccountManager();
    Random rnd = new Random();

    Client defaultClient1 = new("Pedro", "P. P.", "123.123.123-54", "Advogado");
    Client defaultClient2 = new("Otávio", "D. B.", "153.183.635-90", "1 / 6 médico");
    Client defaultClient3 = new("Gabriel", "K. L.", "654.824.133-74", "Investidor");
    Client defaultClient4 = new("Vitor", "L.", "497.135.035-72", "Empresário");


    BankAccount account1 = new(defaultClient1, rnd.Next(5001), 5000.23);
    BankAccount account2 = new(defaultClient2, rnd.Next(5001), 3065.52);
    BankAccount account3 = new(defaultClient3, rnd.Next(5001), 16000.28);
    BankAccount account4 = new(defaultClient4, rnd.Next(5001), 150);
    accountManager.AddAccount(account1);
    accountManager.AddAccount(account2);
    accountManager.AddAccount(account3);
    accountManager.AddAccount(account4);


    bool IsRunning = true;
    while (IsRunning)
    {
        Console.Clear();
        Console.WriteLine("ByteBank");
        Console.WriteLine("");
        Console.WriteLine("Pressione 1 para criar uma conta.");
        Console.WriteLine("Pressione 2 para acessar os dados de uma conta");
        Console.WriteLine("Pressione 3 para realizar um saque");
        Console.WriteLine("Pressione 4 para realizar uma transferência");
        Console.WriteLine("Pressione 5 para remover uma conta");
        Console.WriteLine("pressione 6 para sair do aplicativo");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                accountManager.CreateAccount();
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("Deseja acessar as informações de que conta?");
                accountManager.ShowAccounts();
                break;
            case "3":
                Console.Clear();
                Console.WriteLine("Deseja realizar um saque em que conta?");
                accountManager.ShowAccounts(true);
                break;
            case "4":
                Console.Clear();
                accountManager.HandleTransfer();
                break;
            case "5":
                Console.Clear();
                accountManager.RemoveAccount();
                break;
            case "6":
                IsRunning = false;
                break;
        }
    }
}


Main(args);