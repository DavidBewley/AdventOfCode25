using System.IO;
using System.Text.RegularExpressions;

namespace Logic
{
    public class Day2Processor
    {
        public bool Part2 { get; set; }

        public double SumOfInvalidIds(string input, bool? part2 = false)
        {
            Part2 = part2.Value;
            var InvalidIds = new List<double>();
            foreach (var id in input.Split(','))          
                InvalidIds.AddRange(GenerateInvalidIds(id));

            return InvalidIds.Sum();
        }

        private List<double> GenerateInvalidIds(string input)
        {
            var invalidIds = new List<double>();
            var startingId = double.Parse(input.Split('-')[0].Trim());
            var finalId = double.Parse(input.Split('-')[1].Trim());

            for (double i = startingId; i <= finalId; i++)
                if (Part2)
                {
                    if (!IdIsValidPart2(i))
                        invalidIds.Add(i);
                }
                else
                    if (!IdIsValid(i))
                        invalidIds.Add(i);
            
            return invalidIds;
        }

        private bool IdIsValid(double id)
        {
            var idString = id.ToString();

            if(idString.Length % 2 == 0)
            {
                var half = idString.Substring(0, idString.Length / 2);
                if ($"{half}{half}" == idString)
                    return false;
            }

            return true;
        }
        private bool IdIsValidPart2(double id)
        {
            var regexPattern = "^([1-9]\\d*?)\\1+$";

            return !Regex.IsMatch(id.ToString(), regexPattern);
        }
    }
}
