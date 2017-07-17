using System;
using NUnit.Framework;
using RoyalLondonTest;

namespace RoyalLondonUnitTestProject
{
    [TestFixture]
    public class PolicyTypeAMaturityValueFixture
    {
        /// <summary>
        /// Calculate the Maturity Value when Start Date is before 01/01/1990 and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeA_WhenStartDateBefore1990AndDiscretionaryBonus()
        {
            // Arrange
            var policyTypeA = new PolicyTypeAMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'A',
                PolicyNumber = "A100001",
                StartDate = DateTime.Parse("01/06/1986"),
                Premiums = 10000,
                Membership = true,
                DiscretionaryBonus = 1000,
                UpliftPercentage = 40
            };

            // Act
            var res = policyTypeA.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(14980m, res);
        }

        /// <summary>
        /// Calculate the Maturity Value when Start Date is after 01/01/1990 and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeA_WhenStartDateAfter1990()
        {
            // Arrange
            var policyTypeA = new PolicyTypeAMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'A',
                PolicyNumber = "A100009",
                StartDate = DateTime.Parse("01/06/1996"),
                Premiums = 10000,
                Membership = true,
                DiscretionaryBonus = 1000,
                UpliftPercentage = 40
            };

            // Act
            var res = policyTypeA.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(13580m, res);
        }

        /// <summary>
        /// Calculate the Maturity Value when Start Date is before 01/01/1990 and there is a no discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeA_WhenStartDateBefore1990AndNoDiscretionaryBonus()
        {
            // Arrange
            var policyTypeA = new PolicyTypeAMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'A',
                PolicyNumber = "A100001",
                StartDate = DateTime.Parse("01/06/1986"),
                Premiums = 10000,
                Membership = true,
                DiscretionaryBonus = 0,
                UpliftPercentage = 40
            };

            // Act
            var res = policyTypeA.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(13580m, res);
        }

        /// <summary>
        /// Calculate the Maturity Value based on whether policy start date before 01/01/1990
        /// and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        [TestCase("01/06/1986", true, 1000, Result = 14712.50)]
        [TestCase("01/06/1986", false, 1000, Result = 14712.50)]
        [TestCase("01/01/1990", true, 1000, Result = 13337.50)]
        [TestCase("01/01/1990", false, 1000, Result = 13337.50)]
        [TestCase("01/06/1996", true, 1000, Result = 13337.50)]
        [TestCase("01/06/1996", false, 1000, Result = 13337.50)]
        public decimal CalculateMaturityValue_ForPolicyTypeA(string policyStartDate, bool membershipRights, decimal discretionaryBonus)
        {
            // Arrange
            var policyTypeA = new PolicyTypeAMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'A',
                PolicyNumber = "A100001",
                StartDate = DateTime.Parse(policyStartDate),
                Premiums = 10000,
                Membership = membershipRights,
                DiscretionaryBonus = discretionaryBonus,
                UpliftPercentage = 37.50m
            };

            // Act
            var res = policyTypeA.CalculateMaturityValue(policy);
            return res;
        }
    }

}
