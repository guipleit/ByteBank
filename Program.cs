// See https://aka.ms/new-console-template for more information

using ByteBank;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

static void Main(string[] args)
{
    AccountManager accountManager = new AccountManager();
    Random rnd = new Random();

    Client defaultClient1 = new("Pedro", "Petean", "123.123.123-54", "Advogado");
    Client defaultClient2 = new("Otávio", "Do Bem", "153.183.635-90", "1 / 6 médico");

    BankAccount account1 = new(defaultClient1, rnd.Next(5001));
    BankAccount account2 = new(defaultClient2, rnd.Next(5001));
    accountManager.AddAccount(account1);
    accountManager.AddAccount(account2);


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
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                accountManager.CreateAccount();
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("Deseja acessar as informações de que conta?");
                accountManager.ShowAccounts(false);
                break;
            case "3":
                Console.Clear();
                Console.WriteLine("Deseja realizar um saque em que conta?");
                accountManager.ShowAccounts(true);
                break;
        }
    }
}


Main(args);