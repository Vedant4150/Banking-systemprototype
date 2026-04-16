using System;

namespace Bankappvedant.Exceptions
{
    // Custom Exception Handling (OOP) + Inheritance
    // A custom exception thrown when a withdrawal fails (e.g., insufficient funds / limit exceeded).
    public class WithdrawalFailedException : Exception
    {
        // Encapsulation Properties
        public string AccountType { get; }
        public double AttemptedAmount { get; }
        public double CurrentBalance { get; }

        // Constructors + Inheritance (Exception base class)
        public WithdrawalFailedException(string accountType, double attemptedAmount, double currentBalance)
            : base(CreateMessage(accountType, attemptedAmount, currentBalance))
        {
            AccountType = accountType;
            AttemptedAmount = attemptedAmount;
            CurrentBalance = currentBalance;
        }

        // Selection switch   message changes depending on account type
        private static string CreateMessage(string accountType, double amount, double balance)
        {
            return accountType switch
            {
                "Everyday" =>
                    $"Everyday: Withdrawal failed (insufficient funds).\nAttempted: ${amount:F2}\nAvailable: ${balance:F2}",

                "Investment" =>
                    $"Investment: Withdrawal failed.\nAttempted: ${amount:F2}\nAvailable: ${balance:F2}",

                "Omni" =>
                    $"Omni: Withdrawal failed (limit exceeded).\nAttempted: ${amount:F2}\nAvailable: ${balance:F2}",

                _ =>
                    $"Withdrawal failed.\nAttempted: ${amount:F2}\nAvailable: ${balance:F2}"
            };
        }
    }
}