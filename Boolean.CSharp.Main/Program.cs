using System;
using Boolean.CSharp.Main;

public class Program
{
    public static void Main(string[] args)
    {
        var account = new Account("Tjommert", "12345", BranchType.Personal);

        var savings1 = new SavingsAccount("Piggy Bank", BranchType.Personal);
        var savings2 = new SavingsAccount("Store Budget", BranchType.Business);

        account.AddSavingsAccount(savings1);
        account.AddSavingsAccount(savings2);

        account.SelectedSavings.Deposit(1000, DateTime.Now);
        account.SelectedSavings.Deposit(2000, DateTime.Now);
        account.SelectedSavings.Withdraw(500, DateTime.Now);

        Console.WriteLine(account.GenerateSelectedSavingsStatement());

        account.SwitchSavings(savings2.Id);

        account.SelectedSavings.Deposit(1250, DateTime.Now);


        Console.WriteLine(account.GenerateSelectedSavingsStatement());
    }
}