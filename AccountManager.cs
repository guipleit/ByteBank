using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank
{
    internal class AccountManager
    {
        private List<BankAccount> _BankAccounts = new List<BankAccount>();
        Random rnd = new Random();
        
        public void AddAccount(BankAccount bankAccount)
        {
            _BankAccounts.Add(bankAccount);
        }
        public BankAccount CreateAccount()
        {
            Console.Clear();
            Console.WriteLine("Qual o seu nome?");
            string name = Console.ReadLine();     
            while (string.IsNullOrEmpty(name) || !name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) || name.Length < 3)
            {
                Console.WriteLine("Nome inválido. Deve ter pelo menos 3 caracteres e conter apenas letras e espaços. Por favor, tente novamente:");
                name = Console.ReadLine();
            }

            Console.WriteLine("Qual o seu sobrenome?");
            string surname = Console.ReadLine();
            while (string.IsNullOrEmpty(name) || !name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) || name.Length < 3)
            {
                Console.WriteLine("Sobrenome inválido. Deve ter pelo menos 3 caracteres e conter apenas letras e espaços. Por favor, tente novamente:");
                name = Console.ReadLine();
            }


            Console.WriteLine("Qual o seu CPF?");
            string cpf = Console.ReadLine();
            while (!Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$")) // "xxx.xxx.xxx-xx"
            {
                Console.WriteLine("CPF inválido. Por favor, use o formato xxx.xxx.xxx-xx e tente novamente:");
                cpf = Console.ReadLine();
            }

            Console.WriteLine("Qual o seu emprego?");
            string emprego = Console.ReadLine();
            while (string.IsNullOrEmpty(emprego) || !emprego.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) || emprego.Length < 3)
            {
                Console.WriteLine("Emprego inválido. Deve ter pelo menos 3 caracteres e conter apenas letras. Por favor, tente novamente:");
                emprego = Console.ReadLine();
            }

            Client newClient = new Client(name, surname, cpf, emprego);
            BankAccount account = new BankAccount(newClient, rnd.Next(5001));
            _BankAccounts.Add(account);
            Console.WriteLine($"Parabéns, {account.AccOwner.Name}! Sua conta foi criada com sucesso!");
            Console.ReadLine();
            return account;
        }


        public void ShowAccounts(bool withdraw = false)
        {
            int index = 1;
            foreach (BankAccount bankAccount in _BankAccounts)
            {
                Console.WriteLine($"{index}. Número da conta: {bankAccount.AccNumber}, {bankAccount.AccOwner.FullName}");
                index++;
            }
            Console.WriteLine("Digite o número correspondente à conta que deseja acessar:");
            string input = Console.ReadLine();

            int chosenIndex;
            bool isNumber = Int32.TryParse(input, out chosenIndex);

            if (!isNumber || chosenIndex < 1 || chosenIndex > _BankAccounts.Count)
            {
                Console.WriteLine("Índice inválido. Por favor, tente novamente.");
                return;
            }

            BankAccount chosenAccount = _BankAccounts[chosenIndex - 1];

            if (withdraw)
            {
                Console.WriteLine($"Saldo disponível: R${chosenAccount.AccBalance}");
                Console.WriteLine("Digite o valor que deseja sacar");      
                string withdrawInput = Console.ReadLine();
                double withdrawAmount;
                if (double.TryParse(withdrawInput, out withdrawAmount))
                {
                    chosenAccount.WithdrawFunds(withdrawAmount);
                }
            }
            else
            {
                chosenAccount.showAccInfo();
            }
        }

        public void HandleTransfer()
        {
            Console.WriteLine("Digite o número correspondente à conta origem:");
            int indexOrigin = 1;
            foreach (BankAccount bankAccount in _BankAccounts)
            {
                Console.WriteLine($"{indexOrigin}. Número da conta: {bankAccount.AccNumber}, {bankAccount.AccOwner.FullName} Saldo disponível: R${bankAccount.AccBalance}");
                indexOrigin++;
            }
            
            string inputOrigin = Console.ReadLine();

            int chosenIndexOrigin;
            bool isNumberOrigin = Int32.TryParse(inputOrigin, out chosenIndexOrigin);

            if (!isNumberOrigin || chosenIndexOrigin < 1 || chosenIndexOrigin > _BankAccounts.Count)
            {
                Console.WriteLine("Índice inválido. Por favor, tente novamente.");
                return;
            }

            BankAccount originAccount = _BankAccounts[chosenIndexOrigin - 1];

            Console.WriteLine("Digite o número correspondente à conta destino:");
            int index = 1;
            foreach (BankAccount bankAccount in _BankAccounts)
            {
                Console.WriteLine($"{index}. Número da conta: {bankAccount.AccNumber}, {bankAccount.AccOwner.FullName}");
                index++;
            }

            string input = Console.ReadLine();

            int chosenIndex;
            bool isNumber = Int32.TryParse(input, out chosenIndex);

            if (!isNumber || chosenIndex < 1 || chosenIndex > _BankAccounts.Count || chosenIndex == indexOrigin)
            {
                Console.WriteLine("Índice inválido. Por favor, tente novamente.");
                return;
            }

            BankAccount finalAccount = _BankAccounts[chosenIndex - 1];
            Console.Clear();
            Console.WriteLine("Digite o valor da transferência:");
            Console.WriteLine($"Saldo restante: R${originAccount.AccBalance}");
            string valueInput = Console.ReadLine();

            double parsedDouble;
            bool isDouble = Double.TryParse(valueInput, out parsedDouble);

            if(isDouble)
            {
                originAccount.TransferFunds(parsedDouble, finalAccount);
            } else
            {
                Console.WriteLine("Valo inválido.");
            }
        }

    }

}
