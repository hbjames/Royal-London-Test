using System;
using System.Collections.Generic;
using System.Linq;

namespace RoyalLondonTest
{
    class Program
    {
        private static string  inputFile = "C:\\Royal London Test\\RoyalLondonTest\\Data\\MaturityData.csv";
        private static string outputFile = "C:\\Royal London Test\\RoyalLondonTest\\Data\\MaturityValues.xml";
        static void Main(string[] args)
        {
            var policyTypeA = new PolicyTypeAMaturityValue();
            var policyTypeB = new PolicyTypeBMaturityValue();
            var policyTypeC = new PolicyTypeCMaturityValue();

            var policies = GetMaturityData();

            foreach(Policy policy in policies)
            {
                switch(policy.PolicyType)
                {
                    case 'A':
                         policy.MaturityValue = policyTypeA.CalculateMaturityValue(policy);
                        break;
                    case 'B':
                        policy.MaturityValue = policyTypeB.CalculateMaturityValue(policy);
                        break;
                    case 'C':
                         policy.MaturityValue = policyTypeC.CalculateMaturityValue(policy);
                        break;
                    default:
                        break;
                }
            }

            WriteMaturityData(policies);
        }

        /// <summary>
        /// Read in the maturity data from the CSV file and map into Policy objects.
        /// </summary>
        /// <returns>list of Policy objects</returns>
        private static List<Policy> GetMaturityData()
        {
            var policies = new List<Policy>();

            var policyLines = ReadMaturityDataFromFile().ToList();

            foreach (string policyLine in policyLines)
            {
                var pol = policyLine.Split(',');

                var policy = new Policy
                {
                    PolicyType = Char.Parse(pol[0].Substring(0, 1)),
                    PolicyNumber = pol[0],
                    StartDate = DateTime.Parse(pol[1]),
                    Premiums = decimal.Parse(pol[2]),
                    Membership = pol[3] == "Y", // ? true : false,
                    DiscretionaryBonus = decimal.Parse(pol[4]),
                    UpliftPercentage = decimal.Parse(pol[5])
                };

                policies.Add(policy);
            }

            return policies;
        }

        /// <summary>
        /// Read in the maturity data from the CSV file, ignoring the first row as its a header row.
        /// </summary>
        /// <returns>IEnumerable of maturity data rows after header row ignored</returns>
        private static IEnumerable<string> ReadMaturityDataFromFile()
        {
            IEnumerable<string> lines = System.IO.File.ReadAllLines(inputFile);
            lines = lines.Skip(1);
            return lines; 
        }

        /// <summary>
        /// Create the output file and write each policy number and the associated maturity value to it
        /// </summary>
        /// <param name="policies">Policies data to be written to the output file</param>
        private static void WriteMaturityData(List<Policy> policies)
        {
            var xmlWriter = System.Xml.XmlWriter.Create(outputFile);

            xmlWriter.WriteStartElement("MaturityValues");

            foreach(Policy policy in policies)
            {
                xmlWriter.WriteStartElement("PolicyMaturityValue");
                xmlWriter.WriteStartElement("PolicyNumber");
                xmlWriter.WriteValue(policy.PolicyNumber);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("MaturityValue");
                xmlWriter.WriteValue(policy.MaturityValue);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }
    }
}
