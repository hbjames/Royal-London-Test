using System;
using NUnit.Framework;
using RoyalLondonTest;

namespace RoyalLondonUnitTestProject
{
    public class PolicyTypeCMaturityValueFixture
    {
        /// <summary>
        /// Calculate the Maturity Value based on whether policy start date after 01/01/1990, policy has membership rights 
        /// and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        [TestCase("01/06/1996", true, 1000, Result = 14420.00)]
        [TestCase("01/06/1996", false, 1000, Result = 13020.00)]
        [TestCase("01/01/1990", true, 1000, Result = 14420.00)]
        [TestCase("01/01/1990", false, 1000, Result = 13020.00)]
        [TestCase("01/06/1986", true, 1000, Result = 13020.00)]
        [TestCase("01/06/1986", false, 1000, Result = 13020.00)]
        public decimal CalculateMaturityValue_ForPolicyTypeC(string policyStartDate, bool membershipRights, decimal discretionaryBonus)
        {
            // Arrange
            var policyTypeC = new PolicyTypeCMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'C',
                PolicyNumber = "C100001",
                StartDate = DateTime.Parse(policyStartDate),
                Premiums = 10000,
                Membership = membershipRights,
                DiscretionaryBonus = discretionaryBonus,
                UpliftPercentage = 40
            };

            // Act
            var res = policyTypeC.CalculateMaturityValue(policy);
            return res;
        }

        /// <summary>
        /// Calculate the Maturity Value when policy was taken out after 01/01/1990 and has membership rights 
        /// and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeC_WhenPolicyHasMembershipRightsAndStartedAfter1990AndDiscretionaryBonus()
        {
            // Arrange
            var policyTypeC = new PolicyTypeCMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'C',
                PolicyNumber = "C100001",
                StartDate = DateTime.Parse("01/06/1996"),
                Premiums = 10000,
                Membership = true,
                DiscretionaryBonus = 1000,
                UpliftPercentage = 37.5m
            };

            // Act
            var res = policyTypeC.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(14162.50m, res);
        }

        /// <summary>
        /// Calculate the Maturity Value when policy has no membership right but started after 01/01/1990 and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeC_WhenPolicyHasNoMembershipRightsButStartedAfter1990()
        {
            // Arrange
            var policyTypeC = new PolicyTypeCMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'C',
                PolicyNumber = "C100009",
                StartDate = DateTime.Parse("01/06/1996"),
                Premiums = 10000,
                Membership = false,
                DiscretionaryBonus = 1000,
                UpliftPercentage = 37.5m
            };

            // Act
            var res = policyTypeC.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(12787.50m, res);
        }

        /// <summary>
        /// Calculate the Maturity Value when policy has membership rights and started after 01/01/1990 and there is a no discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeC_WhenPolicyHasMembershipRightsAndStartedAfter1990AndNoDiscretionaryBonus()
        {
            // Arrange
            var policyTypeC = new PolicyTypeCMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'C',
                PolicyNumber = "C100001",
                StartDate = DateTime.Parse("01/06/1996"),
                Premiums = 10000,
                Membership = true,
                DiscretionaryBonus = 0,
                UpliftPercentage = 25.5m
            };

            // Act
            var res = policyTypeC.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(11671.50m, res);
        }

    /// <summary>
        /// Calculate the Maturity Value when policy was taken out after 01/01/1990 and has membership rights 
        /// and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeC_WhenPolicyHasMembershipRightsAndStartedBefore1990AndDiscretionaryBonus()
        {
            // Arrange
            var policyTypeC = new PolicyTypeCMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'C',
                PolicyNumber = "C100001",
                StartDate = DateTime.Parse("01/06/1986"),
                Premiums = 10000,
                Membership = true,
                DiscretionaryBonus = 1000,
                UpliftPercentage = 25.5m
            };

            // Act
            var res = policyTypeC.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(11671.50m, res);
        }

        /// <summary>
        /// Calculate the Maturity Value when policy has no membership right but started before 01/01/1990 and there is a discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeC_WhenPolicyHasNoMembershipRightsButStartedBefore1990()
        {
            // Arrange
            var policyTypeC = new PolicyTypeCMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'C',
                PolicyNumber = "C100009",
                StartDate = DateTime.Parse("01/06/1976"),
                Premiums = 10000,
                Membership = false,
                DiscretionaryBonus = 1000,
                UpliftPercentage = 25.5m
            };

            // Act
            var res = policyTypeC.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(11671.50m, res);
        }

        /// <summary>
        /// Calculate the Maturity Value when policy has membership rights and started before 01/01/1990 and there is a no discretionary bonus to be applied
        /// </summary>
        [Test]
        public void CalculateMaturityValue_ForPolicyTypeC_WhenPolicyHasMembershipRightsAndStartedBefore1990AndNoDiscretionaryBonus()
        {
            // Arrange
            var policyTypeC = new PolicyTypeCMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'C',
                PolicyNumber = "C100001",
                StartDate = DateTime.Parse("01/06/1996"),
                Premiums = 10000,
                Membership = true,
                DiscretionaryBonus = 0,
                UpliftPercentage = 25.5m
            };

            // Act
            var res = policyTypeC.CalculateMaturityValue(policy);

            // Assert
            Assert.AreEqual(11671.50m, res);
        }
    }
}
