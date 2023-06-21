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

        public void showAccInfo()
        {
            Console.WriteLine($"Número da conta: {this.AccNumber}");
            Console.WriteLine($"Proprietário da conta: {this.AccOwner.Name}");
            Console.WriteLine($"Saldo da conta: {this.AccBalance}");
        }
        public bool WithdrawFunds(double value)
        {
            if (AccBalance < value)
            {
                Console.WriteLine("Não foi possível realizar o saque. Saldo insuficiente.");
                return false;
            }
            else
            {
                AccBalance -= value;
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
                return false;
            }
            else
            {
                Console.WriteLine($"Sucesso! {this.AccOwner.Name} enviou R${value} reais para {targetAccount.AccOwner.Name}");
                AccBalance -= value;
                targetAccount.AddFunds(value);
                return true;
            }
        }
    }
}