using system;
using craft;

namespace craft.Tests
{
    [TestClass]
    public class AccountBuilderTests
    {
        [TestMethod]
        public void DemonstrationOfCreatingAccount()
        {
            var passDueAccount = new Account();
            account.Balance = 9000;
            account.Customer = new Customer();
            account.Customer.Address = new Address();
            account.Customer.Address.City = "Loundon";
            account.Customer.Address.Country = "UK";
            account.DueDate = DateTime.Now.AddDays(-1);
            account.Customer.Name = "Penelope";
        }

        [TestMethod]
        public viod CanCreateAccount()
        {
            var acccount = AccountBuilder.DefaultAccount().Build();

            Assert.IsNotNull(account);
        }


        [TestMethod]
        public viod AssignsDefaultValues()
        {
            var account = AccountBuilder.DefaultAccount().Build();

            Assert.IsTrue(account.Balance >0);
            Assert.IsTrue(account.DueDate > DateTime.Now);
            Assert.IsNotNull(account.Customer.Address.City); 
            Assert.IsNotNull(account.Customer.Address.Country); 
            Assert.IsFalse(account.Customer.IsVip); 
            Assert.IsNotNull(account.Customer.Name);
        }


    }

    public class AccountBuilder
    {
        public static AccountBuilder DefaultAccount()
        {
            return new AccountBuilder();
        }


        public AccountBuilder()
        {
            _account = new Account();
            _account.Balance = 10000;
            _account.DueDate = DateTime.No
            _account.Customer = new Customer();
            _account.Customer.Name = "Bob";
            _account.Customer.IsVip = false;
            _account.Customer.Adress = new Address();
            _account.Customer.Adress.City = "Melborne"
            _account.Customer.Adress.Country = "Australia"
        }

        public Account Build()
        {
            return _account;
        }

        private Account _account;

    }
}