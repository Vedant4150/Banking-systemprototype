using System;

namespace Bankappvedant
{
    // this class inherits from Account class
    // Concept used: Inheritance
    public class OmniAccount : Account
    {
        // default constructor (used when loading from JSON etc)
        public OmniAccount()
        {
            AccountType = "Omni";
        }

        // parameterized constructor calling base constructor
        // Concept used: Constructor chaining
        public OmniAccount(double balance, double interestRate, double overdraftLimit, double failedFee)
            : base(balance, interestRate, overdraftLimit, failedFee, "Omni")
        {
        }

        // overriding withdraw method from base class
        // Concept used: Polymorphism
        public override bool Withdraw(double amount, bool isStaff)
        {
            // validation check
            if (amount <= 0)
            {
                LastTransaction = "Omni: Withdrawal failed (invalid amount).";

                // throwing exception for invalid input
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            // omni account allows overdraft (extra money borrowing)
            // so we check balance + overdraft
            if (Balance + Overdraft >= amount)
            {
                Balance -= amount;

                // updating last transaction message
                LastTransaction = $"Omni: Withdraw ${amount:F2}, Balance ${Balance:F2}";
                return true;
            }

            // if withdraw fails, fee is applied
            // staff gets discount
            // Concept used: Conditional operator
            double fee = isStaff ? FailedTransactionFee / 2 : FailedTransactionFee;

            Balance -= fee;

            LastTransaction = $"Omni: Withdrawal failed, Fee ${fee:F2}, Balance ${Balance:F2}";
            return false;
        }

        // overriding interest method
        // Concept used: Polymorphism
        public override double CalculateInterest()
        {
            // interest only applies if balance is above 1000
            if (Balance > 1000)
            {
                double interest = Balance * (InterestRate / 100);

                Balance += interest;

                LastTransaction = $"Omni: Interest ${interest:F2} added, Balance ${Balance:F2}";
                return interest;
            }

            // no interest if balance is low
            LastTransaction = "Omni: No interest applied (balance below $1000).";
            return 0;
        }
    }
}