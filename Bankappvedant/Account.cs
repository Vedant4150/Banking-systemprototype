using System;
using System.Text.Json.Serialization;

namespace Bankappvedant
{
    // these attributes are used for JSON polymorphism so system knows which child class to create
    // Concept used: Serialization + Polymorphism
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(EverydayAccount), "everyday")]
    [JsonDerivedType(typeof(InvestmentAccount), "investment")]
    [JsonDerivedType(typeof(OmniAccount), "omni")]

    // abstract class means object of this class cant be created directly
    // Concept used: Abstraction + Inheritance
    public abstract class Account
    {
        // static variable to keep track of next account id
        // Concept used: Static variable
        private static int nextID = 1;

        // properties for account details
        // Concept used: Encapsulation (get/set)
        public int AccountID { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }
        public double Overdraft { get; set; }
        public double FailedTransactionFee { get; set; }
        public string LastTransaction { get; set; }

        // protected set so only child classes can change account type
        // Concept used: Access modifiers
        public string AccountType { get; protected set; }

        // empty constructor required for JSON deserialization
        public Account()
        {
        }

        // parameterized constructor used when creating new account
        // Concept used: Constructor overloading
        public Account(double balance, double interest, double overdraft, double fee, string accountType)
        {
            AccountID = nextID++; // auto increment id
            Balance = balance;
            InterestRate = interest;
            Overdraft = overdraft;
            FailedTransactionFee = fee;
            AccountType = accountType;

            // setting default transaction message
            LastTransaction = "Account created.";
        }

        // virtual method so child classes can override if needed
        // Concept used: Polymorphism
        public virtual void Deposit(double amount)
        {
            // validation so invalid deposits dont happen
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be greater than zero.");

            Balance += amount;

            // updating last transaction message
            LastTransaction = $"Deposited ${amount:F2}. Balance is now ${Balance:F2}.";
        }

        // abstract method must be implemented in child classes
        // Concept used: Abstraction
        public abstract bool Withdraw(double amount, bool isStaff);

        // virtual method for calculating interest
        // can be overridden by child classes if logic is diff
        public virtual double CalculateInterest()
        {
            double interestAmount = Balance * InterestRate;

            Balance += interestAmount;

            LastTransaction = $"Interest of ${interestAmount:F2} applied. Balance is now ${Balance:F2}.";
            return interestAmount;
        }

        // transfer method between accounts
        // Concept used: Method reuse + Polymorphism
        public virtual bool TransferTo(Account destinationAccount, double amount, bool isStaff)
        {
            // checking if destination account is null
            if (destinationAccount == null)
                throw new ArgumentNullException(nameof(destinationAccount));

            // preventing transfer to same account
            if (destinationAccount.AccountID == this.AccountID)
            {
                LastTransaction = "Transfer failed. Cannot transfer to the same account.";
                return false;
            }

            // withdraw first from source account
            // Concept used: Method call
            bool success = Withdraw(amount, isStaff);

            if (success)
            {
                // deposit into destination account
                destinationAccount.Deposit(amount);

                // updating both account transaction messages
                LastTransaction = $"Transferred ${amount:F2} to Account {destinationAccount.AccountID}. Balance is now ${Balance:F2}.";
                destinationAccount.LastTransaction = $"Received ${amount:F2} from Account {this.AccountID}. Balance is now ${destinationAccount.Balance:F2}.";
                return true;
            }

            // if withdraw fails, transfer also fails
            return false;
        }

        // overriding ToString method to display account info
        // Concept used: Method overriding (Polymorphism)
        public override string ToString()
        {
            return $"{AccountType} Account - ID: {AccountID} - Balance: ${Balance:F2}";
        }

        // static method to reset/set next account id after loading data
        // Concept used: Static method
        public static void SetNextID(int nextId)
        {
            if (nextId > 0)
                nextID = nextId;
        }
    }
}