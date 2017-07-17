using System;

namespace RoyalLondonTest
{
    /// <summary>
    /// Policy Maturity Value base class which does not apply a management fee and assumes that discretionary bonus is to be applied
    /// </summary>
    public class PolicyMaturityValue : IMaturityValueCalculation
    {
        public PolicyMaturityValue()
        {
            ManagementFee = 0m;
        }

        /// <summary>
        /// % Management Fees applicable to this policy
        /// </summary>
        public decimal ManagementFee { get; protected set; }

        /// <summary>
        /// Should Discrectionary Bonus to be applied or not
        /// </summary>
        public bool ApplyDiscretionaryBonus { get; protected set; }

        /// <summary>
        /// Calcualate maturity value based on the following calculation
        /// ((premiums – management fee) + discretionary bonus if qualifying) * uplift
        /// </summary>
        /// <param name="policyMaturing">Policy that is maturing</param>
        /// <returns>Maturity Value rounded to two decimal places</returns>
        public decimal CalculateMaturityValue(Policy policyMaturing)
        {
            IsDiscretionaryBonusToBeApplied(policyMaturing);

            decimal maturityValue = (policyMaturing.Premiums - (policyMaturing.Premiums * (ManagementFee / 100)) 
                + (ApplyDiscretionaryBonus ? policyMaturing.DiscretionaryBonus : 0)) 
                * (1 + policyMaturing.UpliftPercentage / 100);

            return Math.Round(maturityValue, 2);
        }

        /// <summary>
        /// Should be Discretionary Bonus be applied
        /// </summary>
        /// <param name="policy">Policy that is maturing</param>
        /// <returns>true</returns>
        public virtual void IsDiscretionaryBonusToBeApplied(Policy policy)
        {
            ApplyDiscretionaryBonus = true;
        }
    }
}
