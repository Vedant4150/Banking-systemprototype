using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bankappvedant;
using Bankappvedant.Exceptions;

namespace Bankappvedant.Tests
{
    [TestClass]
    public class EverydayAccountTests
    {
        // Test if constructor correctly sets the starting balance
        // Concept: object initialization
        [TestMethod]
        public void Constructor_SetsInitialBalance()
        {
            var acc = new EverydayAccount(100);

            // Balance should match the value passed to constructor
            Assert.AreEqual(100, acc.Balance, 0.001);
        }

        // Test withdrawal when account has enough money
        // Concept: normal withdrawal behaviour
        [TestMethod]
        public void Withdraw_WhenEnoughBalance_ReducesBalance()
        {
            var acc = new EverydayAccount(100);

            acc.withdraw(40, false);

            // Balance should reduce after withdrawal
            Assert.AreEqual(60, acc.Balance, 0.001);
        }

        // Test withdrawal when there are insufficient funds
        // Concept: custom exception handling
        [TestMethod]
        public void Withdraw_WhenInsufficientFunds_ThrowsException()
        {
            var acc = new EverydayAccount(0);

            // Should throw WithdrawalFailedException if balance is not enough
            Assert.ThrowsException<WithdrawalFailedException>(() =>
                acc.withdraw(25, false));
        }

        // Test withdrawal when amount is zero
        // Concept: input validation
        [TestMethod]
        public void Withdraw_WhenAmountZero_ThrowsArgumentException()
        {
            var acc = new EverydayAccount(100);

            // Withdrawal amount cannot be zero
            Assert.ThrowsException<System.ArgumentException>(() =>
                acc.withdraw(0, false));
        }

        // Test interest calculation for EverydayAccount
        // Concept: everyday accounts do not earn interest
        [TestMethod]
        public void CalculateInterest_NoInterestApplied()
        {
            var acc = new EverydayAccount(100);

            acc.calculateInterest();

            // Balance should remain the same
            Assert.AreEqual(100, acc.Balance, 0.001);
        }
    }
}