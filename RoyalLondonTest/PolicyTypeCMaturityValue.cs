using System;

namespace RoyalLondonTest
{
    public class PolicyTypeCMaturityValue : PolicyMaturityValue
    {
        /// <summary>
        /// For Policy Type C, ManagementFee is 7%
        /// </summary>
        public PolicyTypeCMaturityValue()
        {
            ManagementFee = 7m;
        }

        /// <summary>
        /// Discretionary Bonus Is To Be Applied if policy started on or after  01/01/1990 AND has membership rights
        /// </summary>
        /// <param name="policy">policy that is maturing</param>
        public override void IsDiscretionaryBonusToBeApplied(Policy policy)
        {
            ApplyDiscretionaryBonus = false;

            if ((policy.StartDate >= DateTime.Parse("01/01/1990")) && policy.Membership)
            {
                ApplyDiscretionaryBonus = true;
            }
        }

    }
}
