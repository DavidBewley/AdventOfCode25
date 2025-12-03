namespace Logic
{
    public class Day3Processor
    {
        public bool Part2 { get; set; }

        public double GenerateVoltage(string input, bool? part2 = false)
        {
            Part2 = part2.Value;

            var lines = input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
            var total = 0d;

            foreach (var line in lines.Where(l => !string.IsNullOrEmpty(l)))
            {
                if (part2 == false)
                    total += GetLargestVoltage(line);
                else
                    total += GetLargestVoltagePart2(line);
            }

            return total;
        }

        private double GetLargestVoltage(string input)
        {
            var numberStrings = input.Select(c => c.ToString()).ToList();
            var generatedNumbers = new List<double>();

            for (var i = 0; i < numberStrings.Count - 1; i++)
            {
                for (var j = i + 1; j < numberStrings.Count; j++)
                    generatedNumbers.Add(double.Parse($"{numberStrings[i]}{numberStrings[j]}"));
            }

            return generatedNumbers.OrderByDescending(n => n).ToList()[0];
        }

        public double GetLargestVoltagePart2(string digits)
        {
            const int target = 12;
            int toRemove = digits.Length - target;
            var stack = new Stack<char>(digits.Length);

            foreach (char d in digits)
            {
                while (stack.Count > 0 && toRemove > 0 && stack.Peek() < d)
                {
                    stack.Pop();
                    toRemove--;
                }

                stack.Push(d);
            }

            while (stack.Count > target)
                stack.Pop();

            return double.Parse(new string(stack.Reverse().ToArray()));
        }
    }
}
