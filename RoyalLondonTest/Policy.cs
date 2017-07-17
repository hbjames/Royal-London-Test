using System;

namespace RoyalLondonTest
{
    public class Policy
    {
        /// <summary>
        /// Policy Type is the first character of Policy Number
        /// </summary>
        public char PolicyType { get; set; }

        /// <summary>
        /// Policy Number
        /// </summary>
        public string PolicyNumber { get; set; }

        /// <summary>
        /// Date policy started on
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Total value of premiums paid over policy lifetime
        /// </summary>
        public decimal Premiums { get; set; }

        /// <summary>
        /// Policy confers Membership Rights
        /// </summary>
        public bool Membership { get; set; }

        /// <summary>
        /// Discretionary Bonus to be applied on maturity
        /// </summary>
        public decimal DiscretionaryBonus { get; set; }

        /// <summary>
        /// Percentage bonus amount to be applied to policy value on maturity 
        /// </summary>
        public decimal UpliftPercentage { get; set; }

        /// <summary>
        /// Maturity Value of Policy after calcualtion
        /// </summary>
        public decimal MaturityValue { get; set; }
    }
}
