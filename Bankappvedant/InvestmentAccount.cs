using System;

namespace Bankappvedant
{
    // this class inherits from Account class
    // Concept used: Inheritance
    public class InvestmentAccount : Account
    {
        // default constructor (used during deserialization mostly)
        public InvestmentAccount()
        {
            AccountType = "Investment";

            // investment acc does not allow overdraft
            Overdraft = 0;
        }

        // parameterized constructor calling base class constructor
        // Concept used: Constructor chaining
        public InvestmentAccount(double balance, double interestRate, double failedFee)
            : base(balance, interestRate, 0, failedFee, "Investment")
        {
        }

        // overriding withdraw method from parent class
        // Concept used: Polymorphism (method overriding)
        public override bool Withdraw(double amount, bool isStaff)
        {
            // validation for invalid amount
            if (amount <= 0)
            {
                LastTransaction = "Investment: Withdrawal failed (invalid amount).";
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            // if enough balance available
            if (Balance >= amount)
            {
                Balance -= amount;

                // updating last transaction
                LastTransaction = $"Investment: Withdraw ${amount:F2}, Balance ${Balance:F2}";
                return true;
            }

            // if withdraw fails, fee is charged
            // staff gets discount on failed fee
            // Concept used: Conditional operator (ternary)
            double fee = isStaff ? FailedTransactionFee / 2 : FailedTransactionFee;

            Balance -= fee;

            LastTransaction = $"Investment: Withdrawal failed, Fee ${fee:F2}, Balance ${Balance:F2}";
            return false;
        }

        // overriding interest calculation method
        // Concept used: Polymorphism
        public override double CalculateInterest()
        {
            // interest calculated using percentage
            double interest = Balance * (InterestRate / 100);

            Balance += interest;

            LastTransaction = $"Investment: Interest ${interest:F2} added, Balance ${Balance:F2}";
            return interest;
        }
    }
}