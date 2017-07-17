using System;

namespace RoyalLondonTest
{
    public class PolicyTypeAMaturityValue : PolicyMaturityValue
    {
        /// <summary>
        /// For Policy Type A, ManagementFee is 3%
        /// </summary>
        public PolicyTypeAMaturityValue()
        {
            ManagementFee = 3m; 
        }

        /// <summary>
        /// Discretionary Bonus Is To Be Applied if policy started before 01/01/1990
        /// </summary>
        /// <param name="policy">policy to be checked</param>
        public override void IsDiscretionaryBonusToBeApplied(Policy policy)
        {
            ApplyDiscretionaryBonus = false;

            if (policy.StartDate < DateTime.Parse("01/01/1990"))
            {
                ApplyDiscretionaryBonus = true;
            }
        }
    }
}
