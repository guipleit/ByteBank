﻿using ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    internal class BankAccount
    {
        public BankAccount(Client account, int accNumber, double accBalance = 500)
        {
            this.AccOwner = account;
            this.AccNumber = accNumber;
            this.AccBalance = accBalance;
        }
        public Client AccOwner { get; set; }
        public double AccBalance = 100;
        public int AccNumber;

        public bool showAccInfo(string remove = "")
        {
            if (remove == "remove")
            {
                Console.Clear();
                Console.WriteLine("Tem certeza que quer remover essa conta? (y/n)");
                Console.WriteLine($"Número da conta: {this.AccNumber}");
                Console.WriteLine($"Proprietário da conta: {this.AccOwner.FullName}");
                Console.WriteLine($"Saldo da conta: R${this.AccBalance}");
                var key = Console.ReadKey();
                return key.Key == ConsoleKey.Y;
            }

            Console.Clear();
            Console.WriteLine($"Número da conta: {this.AccNumber}");
            Console.WriteLine($"Proprietário da conta: {this.AccOwner.FullName}");
            Console.WriteLine($"Saldo da conta: R${this.AccBalance}");
            Console.ReadLine();
            return true;
        }
        public bool WithdrawFunds(double value)
        {
            if (AccBalance < value)
            {
                Console.WriteLine("Não foi possível realizar o saque. Saldo insuficiente.");
                Console.ReadLine();
                return false;
            }
            else
            {
                AccBalance -= value;
                Console.WriteLine($"Você realizou o saque com sucesso! Saldo restante: {this.AccBalance}");
                Console.ReadLine();
                return true;
            }
        }

        public void AddFunds(double value)
        {
            AccBalance += value;
        }

        public bool TransferFunds(double value, BankAccount targetAccount) 
        { 
            if (AccBalance < value)
            {
                Console.WriteLine("Não foi possível realizar a transferência. Saldo insuficiente.");
                Console.ReadLine ();
                return false;
            }
            else
            {
                Console.WriteLine($"Sucesso! {this.AccOwner.Name} enviou R${value} para {targetAccount.AccOwner.Name}");
                AccBalance -= value;
                targetAccount.AddFunds(value);
                Console.ReadLine();
                return true;
            }
        }
    }
}
