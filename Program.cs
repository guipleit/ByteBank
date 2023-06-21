// See https://aka.ms/new-console-template for more information

using ByteBank;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

static void Main(string[] args)
{
    Client joao = new Client("João", "123.123.123-67", "Músico");
    BankAccount account1 = new BankAccount(joao, 53265, 1000);
    account1.showAccInfo();
}

Main(args);