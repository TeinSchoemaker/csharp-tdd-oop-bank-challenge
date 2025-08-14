using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void UserCanCreateNewAccount()
        {
            string userName = "Tjommert";
            string password = "12345";
            var branchType = BranchType.Personal;

            var account = new Account(userName, password, branchType);

            Assert.That(account.Name, Is.EqualTo("Tjommert"));
            Assert.That(account.Password, Is.EqualTo("12345"));
            Assert.That(account.Branch, Is.EqualTo(BranchType.Personal));

        }

        [Test]
        public void UserCanHaveMultipleSavingAccounts()
        {
            var account = new Account("Tjommert", "12345", BranchType.Personal);

            var savings1 = new SavingsAccount("Piggy Bank", BranchType.Personal);
            var savings2 = new SavingsAccount("Store Budget", BranchType.Business);

            account.AddSavingsAccount(savings1);
            account.AddSavingsAccount(savings2);

            Assert.That(account.Savings.Count, Is.EqualTo(2));
        }

        [Test]
        public void UserCanDepositAndWithdrawMoney()
        {
            var account = new Account("Tjommert", "12345", BranchType.Personal);
            var savings1 = new SavingsAccount("Piggy Bank", BranchType.Personal);
            account.AddSavingsAccount(savings1);

            account.SelectedSavings.Deposit(1000, DateTime.Now);
            Assert.That(account.SelectedSavings.GetTotal(), Is.EqualTo(1000));

            account.SelectedSavings.Withdraw(300, DateTime.Now);
            Assert.That(account.SelectedSavings.GetTotal(), Is.EqualTo(700));
        }

        [Test]
        public void CustomerCanGenerateTransactionStatement()
        {
            var account = new Account("Tjommert", "12345", BranchType.Personal);
            var savings1 = new SavingsAccount("Piggy Bank", BranchType.Personal);
            account.AddSavingsAccount(savings1);

            account.SelectedSavings.Deposit(1000, DateTime.Now);
            account.SelectedSavings.Deposit(2000, DateTime.Now);
            account.SelectedSavings.Withdraw(500, DateTime.Now);
            var statement = account.GenerateSelectedSavingsStatement();

            Assert.IsTrue(statement.Contains("date"));
            Assert.IsTrue(statement.Contains("credit"));
            Assert.IsTrue(statement.Contains("debit"));
            Assert.IsTrue(statement.Contains("balance"));
            Assert.IsTrue(statement.Contains("1000.00"));
            Assert.IsTrue(statement.Contains("2000.00"));
            Assert.IsTrue(statement.Contains("500.00"));
        }
    }
}
