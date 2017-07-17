
namespace RoyalLondonTest
{
    public interface IMaturityValueCalculation
    {
        /// <summary>
        /// Calculate the Maturity Value of the supplied policy
        /// </summary>
        /// <param name="policyMaturing">Policy that is maturing</param>
        /// <returns>Maturity Value of policy</returns>
        decimal CalculateMaturityValue(Policy policyMaturing);
    }
}
