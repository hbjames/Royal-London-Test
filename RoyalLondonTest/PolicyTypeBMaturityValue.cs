

namespace RoyalLondonTest
{
    public class PolicyTypeBMaturityValue : PolicyMaturityValue
    {
        /// <summary>
        /// For Policy Type B, ManagementFee is 5%
        /// </summary>
        public PolicyTypeBMaturityValue()
        {
            ManagementFee = 5m;
        }

        /// <summary>
        /// Discretionary Bonus Is To Be Applied if policy has membership rights
        /// </summary>
        /// <param name="policy">policy that is maturing</param>
        public override void IsDiscretionaryBonusToBeApplied(Policy policy)
        {
            ApplyDiscretionaryBonus = false;

            if (policy.Membership)
            {
                ApplyDiscretionaryBonus = true;
            }
        }

    }
}
