using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Bankappvedant.Controllers
{
    public class CustomerController
    {
        // List is used here to store all customer objects in memory
        // Concept used: Collection / Encapsulation
        private List<Customer> _customers = new List<Customer>();

        // This keeps track of the next customer ID so each customer gets unique id
        // Concept used: Encapsulation
        private int _nextCustomerId = 1;

        public Customer NewCustomer(string name, string email, bool isStaff)
        {
            // trimming spaces so user cant accidently add blank spaces before/after input
            name = (name ?? "").Trim();
            email = (email ?? "").Trim();

            // basic validation
            // Concept used: Input validation
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name is required.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                throw new ArgumentException("A valid email is required.");

            // loop through existing customers to make sure email is not duplicate
            // Concept used: Iteration / foreach loop
            foreach (var c in _customers)
            {
                if (c.CustomerEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException("This email is already used by another customer.");
            }

            // creating a new customer object and adding it into the list
            // Concept used: Object creation
            var customer = new Customer(_nextCustomerId++, name, email, isStaff);
            _customers.Add(customer);
            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            // returns the full list of customers
            return _customers;
        }

        public Customer FindCustomerById(int id)
        {
            // searching customer by id
            // Concept used: Lambda expression
            return _customers.Find(c => c.CustomerID == id);
        }

        public bool UpdateCustomer(int id, string name, string email, bool isStaff)
        {
            // first find the customer we want to update
            var customer = FindCustomerById(id);
            if (customer == null) return false;

            name = (name ?? "").Trim();
            email = (email ?? "").Trim();

            // validation again so bad data does not get saved
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name is required.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                throw new ArgumentException("A valid email is required.");

            // making sure updated email does not clash with another customer email
            foreach (var c in _customers)
            {
                if (c.CustomerID != id &&
                    c.CustomerEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException("This email is already used by another customer.");
            }

            // update method from Customer class is called here
            // Concept used: Abstraction / method call
            customer.UpdateCustomer(name, email, isStaff);
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            // find customer before deleting
            var customer = FindCustomerById(id);
            if (customer == null) return false;

            // removing object from list
            // Concept used: Collection manipulation
            _customers.Remove(customer);
            return true;
        }

        public Account AddAccountToCustomer(int customerId, string accountType, double openingBalance)
        {
            var customer = FindCustomerById(customerId);
            if (customer == null)
                throw new ArgumentException("Customer not found.");

            if (openingBalance < 0)
                throw new ArgumentException("Opening balance cannot be negative.");

            // parent class reference is used here
            // Concept used: Polymorphism
            Account account = null;

            // selecting which child class object to create depending on account type
            // Concept used: Inheritance + Polymorphism + Selection
            switch (accountType)
            {
                case "Everyday":
                    account = new EverydayAccount(openingBalance);
                    break;

                case "Investment":
                    account = new InvestmentAccount(openingBalance, 5, 10);
                    break;

                case "Omni":
                    account = new OmniAccount(openingBalance, 4, 1000, 10);
                    break;

                default:
                    throw new ArgumentException("Invalid account type.");
            }

            // adds the created account into the selected customer's account list
            customer.AddAccount(account);
            return account;
        }

        public List<Account> GetAccountsForCustomer(int customerId)
        {
            var customer = FindCustomerById(customerId);
            if (customer == null)
                throw new ArgumentException("Customer not found.");

            // returns all accounts of that customer
            return customer.Accounts;
        }

        public Account FindAccount(int customerId, int accountId)
        {
            var customer = FindCustomerById(customerId);
            if (customer == null)
                return null;

            // LINQ is used here to find the matching account
            // Concept used: LINQ / Lambda expression
            return customer.Accounts.FirstOrDefault(a => a.AccountID == accountId);
        }

        public void DepositToAccount(int customerId, int accountId, double amount)
        {
            var account = FindAccount(customerId, accountId);
            if (account == null)
                throw new ArgumentException("Account not found.");

            // calls Deposit method from Account class
            // Concept used: Method invocation / OOP
            account.Deposit(amount);
        }

        public bool WithdrawFromAccount(int customerId, int accountId, double amount)
        {
            var customer = FindCustomerById(customerId);
            if (customer == null)
                throw new ArgumentException("Customer not found.");

            var account = FindAccount(customerId, accountId);
            if (account == null)
                throw new ArgumentException("Account not found.");

            // staff status is passed so withdraw rules can change if needed
            // Concept used: Polymorphism / business logic
            return account.Withdraw(amount, customer.IsStaff);
        }

        public bool TransferBetweenAccounts(int customerId, int fromAccountId, int toAccountId, double amount)
        {
            var customer = FindCustomerById(customerId);
            if (customer == null)
                throw new ArgumentException("Customer not found.");

            var fromAccount = FindAccount(customerId, fromAccountId);
            var toAccount = FindAccount(customerId, toAccountId);

            if (fromAccount == null || toAccount == null)
                throw new ArgumentException("One or both accounts were not found.");

            // stopping user from transfering into same account
            if (fromAccountId == toAccountId)
                throw new ArgumentException("Cannot transfer to the same account.");

            // transfer logic is handled by account class
            // Concept used: Abstraction / Reusability
            return fromAccount.TransferTo(toAccount, amount, customer.IsStaff);
        }

        public double ApplyInterestToAccount(int customerId, int accountId)
        {
            var account = FindAccount(customerId, accountId);
            if (account == null)
                throw new ArgumentException("Account not found.");

            // calculate interest depending on the account type
            // Concept used: Polymorphism
            return account.CalculateInterest();
        }

        public void SaveToFile(string filePath)
        {
            // Json options used to make file look neat and readable
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // converting object list into JSON string
            // Concept used: Serialization
            string json = JsonSerializer.Serialize(_customers, options);

            // writing JSON into file
            File.WriteAllText(filePath, json);
        }

        public void LoadFromFile(string filePath)
        {
            // if file doesnt exist, start with empty customer list
            if (!File.Exists(filePath))
            {
                _customers = new List<Customer>();
                _nextCustomerId = 1;
                return;
            }

            var options = new JsonSerializerOptions();

            // reading JSON data from file
            string json = File.ReadAllText(filePath);

            // converting JSON back into object list
            // Concept used: Deserialization
            var loadedCustomers = JsonSerializer.Deserialize<List<Customer>>(json, options);

            _customers = loadedCustomers ?? new List<Customer>();

            // setting next customer id properly so duplicate ids dont happen
            _nextCustomerId = _customers.Count > 0 ? _customers.Max(c => c.CustomerID) + 1 : 1;

            // finding the next account id from all loaded accounts
            // Concept used: LINQ
            int nextAccountId = _customers
                .Where(c => c.Accounts != null)
                .SelectMany(c => c.Accounts)
                .Select(a => a.AccountID)
                .DefaultIfEmpty(0)
                .Max() + 1;

            // static method used to continue account ids from last saved data
            // Concept used: Static method
            Account.SetNextID(nextAccountId);
        }
    }
}