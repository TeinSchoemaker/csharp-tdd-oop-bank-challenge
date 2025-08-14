using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{

    public enum BranchType
    {
        Personal,
        Business,
        Gift
    }

    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public BranchType Branch { get; set; }
        public List<Transaction> Transactions { get; set; } = new();
        public List<SavingsAccount> Savings { get; set; } = new();
        public SavingsAccount SelectedSavings { get; set; }

        public Account(string name, string password, BranchType branch)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
            Branch = branch;
        }

        public void Deposit(decimal amount, DateTime date)
        {
            Transactions.Add(new Transaction(date, amount, 0));
        }

        public void Withdraw(decimal amount, DateTime date)
        {
            Transactions.Add(new Transaction(date, 0, amount));
        }

        public string GenerateStatement()
        {
            var statement = new StringBuilder();
            decimal balance = 0;

            statement.AppendLine("date       || credit  || debit  || balance");

            foreach (var transaction in Transactions)
            {
                balance += transaction.Credit - transaction.Debit;
                statement.AppendLine($"{transaction.Date:dd/mm/yyyy} || " + $"{transaction.Credit} || " + $"{transaction.Debit} || " + $"{balance}");
            }

            return statement.ToString();
        }

        public string GenerateSelectedSavingsStatement()
        {
            return SelectedSavings.GenerateStatement();
        }

        public void AddSavingsAccount(SavingsAccount savingsAccount)
        {
            Savings.Add(savingsAccount);
            if (SelectedSavings == null) SelectedSavings = savingsAccount;
        }

        public void SwitchSavings(Guid savingsId)
        {
            var savings = Savings.First(s => s.Id == savingsId);
            SelectedSavings = savings;
        }
    }
}