using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bankappvedant;
using Bankappvedant.Exceptions;

namespace Bankappvedant.Tests
{
    // Unit tests for InvestmentAccount class
    // Using MSTest framework
    [TestClass]
    public class InvestmentAccountTests
    {
        [TestMethod]
        public void Withdraw_Success_ReducesBalance()
        {
            // Arrange – create account object
            var acc = new InvestmentAccount(200, 4, 10);

            // Act – perform withdrawal
            acc.withdraw(50, false);

            // Assert – check if balance updated correctly
            // Assertion verifies expected vs actual result
            Assert.AreEqual(150, acc.Balance, 0.001);
        }

        [TestMethod]
        public void Withdraw_Fail_NonStaff_AppliesFee()
        {
            // Arrange – account with no balance
            var acc = new InvestmentAccount(0, 4, 10);

            // Act + Assert – expecting custom exception
            // Exception testing ensures system handles errors correctly
            Assert.ThrowsException<WithdrawalFailedException>(() =>
                acc.withdraw(25, false));

            // Non-staff users get full withdrawal fee applied
            Assert.AreEqual(-10, acc.Balance, 0.001);
        }

        [TestMethod]
        public void Withdraw_Fail_Staff_AppliesHalfFee()
        {
            // Arrange – empty account
            var acc = new InvestmentAccount(0, 4, 10);

            // Testing exception handling again
            Assert.ThrowsException<WithdrawalFailedException>(() =>
                acc.withdraw(25, true));

            // Staff members only pay half fee
            Assert.AreEqual(-5, acc.Balance, 0.001);
        }

        [TestMethod]
        public void CalculateInterest_IncreasesBalance()
        {
            // Arrange – account with 1000 balance
            var acc = new InvestmentAccount(1000, 4, 10);

            // Act – apply interest calculation
            acc.calculateInterest();

            // Assert – verify interest logic works
            // 4% of 1000 = 40 → total = 1040
            Assert.AreEqual(1040, acc.Balance, 0.001);
        }
    }
}