using System;
using NUnit.Framework;
using RoyalLondonTest;

namespace RoyalLondonUnitTestProject
{
    [TestFixture]
    public class PolicyTypeBMaturityValueFixture
    {
        /// <summary>
        /// Calculate the Maturity Value when policy has membership right and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeB_WhenPolicyHasMembershipRightsAndDiscretionaryBonus()
        {
            // Arrange
            var policyTypeB = new PolicyTypeBMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'B',
                PolicyNumber = "B100001",
                StartDate = DateTime.Parse("01/06/1986"),
                Premiums = 10000,
                Membership = true,
                DiscretionaryBonus = 1000,
                UpliftPercentage = 40
            };

            // Act
            var res = policyTypeB.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(14700m, res);
        }

        /// <summary>
        /// Calculate the Maturity Value when policy has no membership right and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeB_WhenPolicyHasNoMembershipRights()
        {
            // Arrange
            var policyTypeB = new PolicyTypeBMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'B',
                PolicyNumber = "B100009",
                StartDate = DateTime.Parse("01/06/1996"),
                Premiums = 10000,
                Membership = false,
                DiscretionaryBonus = 1000,
                UpliftPercentage = 40
            };

            // Act
            var res = policyTypeB.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(13300m, res);
        }

        /// <summary>
        /// Calculate the Maturity Value when policy has membersship rights and there is a no discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeB_WhenPolicyHasMembershipRightsAndNoDiscretionaryBonus()
        {
            // Arrange
            var policyTypeB = new PolicyTypeBMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'B',
                PolicyNumber = "B100001",
                StartDate = DateTime.Parse("01/06/1986"),
                Premiums = 10000,
                Membership = true,
                DiscretionaryBonus = 0,
                UpliftPercentage = 40
            };

            // Act
            var res = policyTypeB.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(13300m, res);
        }

        /// <summary>
        /// Calculate the Maturity Value based on whether policy has membership rights 
        /// and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        [TestCase("01/06/1986", true, 1000, Result = 14437.50)]
        [TestCase("01/06/1986", false, 1000, Result = 13062.50)]
        [TestCase("01/01/1990", true, 1000, Result = 14437.50)]
        [TestCase("01/01/1990", false, 1000, Result = 13062.50)]
        [TestCase("01/06/1996", true, 1000, Result = 14437.50)]
        [TestCase("01/06/1996", false, 1000, Result = 13062.50)]
        public decimal CalculateMaturityValue_ForPolicyTypeB(string policyStartDate, bool membershipRights, decimal discretionaryBonus)
        {
            // Arrange
            var policyTypeB = new PolicyTypeBMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'B',
                PolicyNumber = "B100001",
                StartDate = DateTime.Parse(policyStartDate),
                Premiums = 10000,
                Membership = membershipRights,
                DiscretionaryBonus = discretionaryBonus,
                UpliftPercentage = 37.50m
            };

            // Act
            var res = policyTypeB.CalculateMaturityValue(policy);
            return res;
        }
    }
}
