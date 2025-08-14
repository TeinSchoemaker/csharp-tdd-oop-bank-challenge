using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{

    [TestFixture]
    public class ExtensionTests
    {

        [Test]
        public void BalanceShouldBeCalculatedFromTransactions()
        {
            var personalAccount = new Account("Bob", "password1", BranchType.Personal);
            var savings = new SavingsAccount("Vacation Funds", BranchType.Personal);

            personalAccount.AddSavingsAccount(savings);

            personalAccount.SelectedSavings.Deposit(1000, DateTime.Now);
            personalAccount.SelectedSavings.Withdraw(200, DateTime.Now);

            Assert.That(savings.GetTotal(), Is.EqualTo(800));

            savings.Transactions.Add(new Transaction(DateTime.Now, 300, 0));

            Assert.That(savings.GetTotal, Is.EqualTo(1100));
        }

        [Test]
        public void AccountIsAssociatedWithCorrectBranch()
        {
            var personalAccount = new Account("Bob", "password1", BranchType.Personal);
            var businessAccount = new Account("Greg", "5412", BranchType.Business);

            Assert.That(personalAccount.Branch, Is.EqualTo(BranchType.Personal));
            Assert.That(businessAccount.Branch, Is.EqualTo(BranchType.Business));
        }
    }
}