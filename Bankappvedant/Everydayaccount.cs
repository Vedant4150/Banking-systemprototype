using System;

namespace Bankappvedant
{
    // this class inherits from Account class
    // Concept used: Inheritance
    public class EverydayAccount : Account
    {
        // default constructor (used mostly in JSON loading)
        public EverydayAccount()
        {
            AccountType = "Everyday";

            // everyday account has no interest and no overdraft
            InterestRate = 0;
            Overdraft = 0;
            FailedTransactionFee = 0;
        }

        // parameterized constructor which calls base class constructor
        // Concept used: Constructor chaining (base keyword)
        public EverydayAccount(double balance)
            : base(balance, 0, 0, 0, "Everyday")
        {
        }

        // overriding withdraw method from base class
        // Concept used: Polymorphism (method overriding)
        public override bool Withdraw(double amount, bool isStaff)
        {
            // basic validation
            if (amount <= 0)
            {
                LastTransaction = "Everyday: Withdrawal failed (invalid amount).";

                // exception handling
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            // checking if enough balance is available
            if (Balance >= amount)
            {
                Balance -= amount;

                // updating last transaction message
                LastTransaction = $"Everyday: Withdraw ${amount:F2}, Balance ${Balance:F2}";
                return true;
            }

            // if not enough balance
            LastTransaction = "Everyday: Withdrawal failed (insufficient funds).";
            return false;
        }

        // overriding interest calculation (but everyday acc has no interest)
        // Concept used: Polymorphism
        public override double CalculateInterest()
        {
            // just returning 0 becuase no interest applies
            LastTransaction = "Everyday: No interest for this account type.";
            return 0;
        }
    }
}