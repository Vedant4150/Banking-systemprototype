using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bankappvedant;
using Bankappvedant.Exceptions;

namespace Bankappvedant.Tests
{
    [TestClass]
    public class OmniAccountTests
    {
        // Test if withdrawal works when it is still within the overdraft limit
        // Concept: overdraft allows balance to go negative
        [TestMethod]
        public void Withdraw_WithinOverdraft_AllowsNegativeBalance()
        {
            var acc = new OmniAccount(0, 4, 200, 10); // balance=0, interest=4%, overdraft=200, fee=10

            acc.withdraw(150, false); // withdraw within overdraft

            // Balance should become -150 because overdraft allows it
            Assert.AreEqual(-150, acc.Balance, 0.001);
        }

        // Test if withdrawal fails when amount exceeds overdraft
        // Concept: custom exception + withdrawal rules
        [TestMethod]
        public void Withdraw_ExceedsOverdraft_ThrowsException()
        {
            var acc = new OmniAccount(0, 4, 200, 10);

            // Withdrawal beyond overdraft should throw custom exception
            Assert.ThrowsException<WithdrawalFailedException>(() =>
                acc.withdraw(250, false));

            // When withdrawal fails, penalty fee is applied
            Assert.AreEqual(-10, acc.Balance, 0.001);
        }

        // Test if staff users get half penalty fee
        // Concept: conditional logic depending on staff status
        [TestMethod]
        public void Withdraw_ExceedsOverdraft_StaffHalfFee()
        {
            var acc = new OmniAccount(0, 4, 200, 10);

            // Staff trying to exceed overdraft
            Assert.ThrowsException<WithdrawalFailedException>(() =>
                acc.withdraw(250, true));

            // Staff only pay half the penalty fee
            Assert.AreEqual(-5, acc.Balance, 0.001);
        }

        // Test if interest is calculated when balance is greater than 1000
        // Concept: interest calculation rule
        [TestMethod]
        public void CalculateInterest_AppliesWhenAbove1000()
        {
            var acc = new OmniAccount(1500, 4, 200, 10);

            acc.calculateInterest(); // apply interest

            // 4% interest on 1500 = 60, so new balance should be 1560
            Assert.AreEqual(1560, acc.Balance, 0.001);
        }

        // Test if interest is NOT applied when balance is 1000 or below
        // Concept: business rule validation
        [TestMethod]
        public void CalculateInterest_NotAppliedBelow1000()
        {
            var acc = new OmniAccount(1000, 4, 200, 10);

            acc.calculateInterest();

            // Balance should stay the same because it is not above 1000
            Assert.AreEqual(1000, acc.Balance, 0.001);
        }
    }
}