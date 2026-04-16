using System.Collections.Generic;
using System.Linq;

namespace Bankappvedant
{
    public class Customer
    {
        // basic properties to store customer details
        // Concept used: Encapsulation (get/set properties)
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public bool IsStaff { get; set; }

        // list to store all accounts of a customer
        // Concept used: Collection (List)
        public List<Account> Accounts { get; set; }

        // default constructor (mainly used during deserialization)
        public Customer()
        {
            // initializing list so it doesnt give null error later
            Accounts = new List<Account>();
        }

        // parameterized constructor used when creating new customer
        // Concept used: Constructor overloading
        public Customer(int id, string name, string email, bool isStaff)
        {
            CustomerID = id;
            CustomerName = name;
            CustomerEmail = email;
            IsStaff = isStaff;

            // list must be initialized here also
            Accounts = new List<Account>();
        }

        public void AddAccount(Account acc)
        {
            // checking null so program doesnt crash
            // basic validation
            if (acc != null)
                Accounts.Add(acc);
        }

        public void UpdateCustomer(string name, string email, bool isStaff)
        {
            // updating customer details
            // Concept used: Encapsulation / updating state
            CustomerName = name;
            CustomerEmail = email;
            IsStaff = isStaff;
        }

        public Account GetAccountById(int accountId)
        {
            // using LINQ to find account in the list
            // Concept used: LINQ + Lambda expression
            return Accounts.FirstOrDefault(a => a.AccountID == accountId);
        }

        public string DisplayDetails()
        {
            // returning formatted string with all customer info
            // Concept used: String interpolation
            return $"ID: {CustomerID} | Name: {CustomerName} | Email: {CustomerEmail} | Staff: {IsStaff}";
        }

        public override string ToString()
        {
            // overriding ToString so it shows useful info instead of object ref
            // Concept used: Method overriding (Polymorphism)
            return $"{CustomerID} - {CustomerName}";
        }
    }
}