using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RoyalLondonTest;

namespace RoyalLondonUnitTestProject
{
    public class PolicyMaturityValueFixture
    {
        /// <summary>
        /// Calculate the Maturity Value based on policy start date, membership rights and discretionary bonus value
        /// </summary>
        [Test]
        [TestCase("01/06/1986", true, 1000, Result = 15400.00)]
        [TestCase("01/06/1986", false, 1000, Result = 15400.00)]
        [TestCase("01/06/1986", true, 0, Result = 14000.00)]
        [TestCase("01/06/1986", false, 0, Result = 14000.00)]
        [TestCase("01/06/1986", true, 1000.95, Result = 15401.33)]
        [TestCase("01/06/1986", false, 990.52, Result = 15386.73)]
        public decimal CalculateMaturityValue(string policyStartDate, bool membershipRights, decimal discretionaryBonus)
        {
            // Arrange
            var policyType = new PolicyMaturityValue();

            var policy = new Policy
            {
                PolicyType = 'A',
                PolicyNumber = "A100001",
                StartDate = DateTime.Parse(policyStartDate),
                Premiums = 10000,
                Membership = membershipRights,
                DiscretionaryBonus = discretionaryBonus,
                UpliftPercentage = 40
            };

            // Act
            var res = policyType.CalculateMaturityValue(policy);

            return res;
        }
    }
}
