namespace Logic
{
    public class Day6Processor
    {
        public double Part1(string input)
        {
            var equations = GetAllEquations(input);
            var total = 0d;

            foreach (var (op, items) in equations)
            {
                double result = op switch
                {
                    "+" => items.Sum(),
                    "*" => items.Aggregate(1d, (a, b) => a * b),
                    _ => 0d
                };
                total += result;
            }

            return total;
        }

        public double Part2(string input)
        {
            var equations = GetAllEquationsPart2(input);
            var total = 0d;

            foreach (var (op, items) in equations)
            {
                double result = op switch
                {
                    "+" => items.Sum(),
                    "*" => items.Aggregate(1d, (a, b) => a * b),
                    _ => 0d
                };
                total += result;
            }

            return total;
        }

        private List<(string op, List<double> items)> GetAllEquations(string input)
        {
            var equations = new List<(string op, List<double> items)>();
            var lines = input.Split('\n');
            var operators = lines.Last().ToString().Split(' ').ToList();
            operators.RemoveAll(s => string.IsNullOrWhiteSpace(s));

            foreach (var op in operators)
                equations.Add(new(op, []));

            for (var i = 0; i < lines.Length - 1; i++)
            {
                var items = lines[i].ToString().Split(' ').ToList();
                items.RemoveAll(s => string.IsNullOrWhiteSpace(s));
                for (var j = 0; j < items.Count; j++)
                    equations[j].items.Add(double.Parse(items[j]));
            }

            return equations;
        }

        private List<(string op, List<double> items)> GetAllEquationsPart2(string input)
        {
            var equations = new List<(string op, List<double> items)>();
            var lines = input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
            var op = "";
            var currentNumbers = new List<double>();


            for (var i = lines.First().Length - 1; i >= 0; i--)
            {
                var line = "";
                for (var k = 0; k < lines.Length; k++)
                    line += lines[k][i];

                if(string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.Contains("*"))
                {
                    op = "*";
                    line = line.Replace("*", "");
                }
                if (line.Contains("+"))
                {
                    op = "+";
                    line = line.Replace("+", "");
                }
                if (!string.IsNullOrWhiteSpace(line))
                    currentNumbers.Add(double.Parse(line));
                if (op != "")
                {
                    equations.Add((op, currentNumbers));
                    currentNumbers = new List<double>();
                    op = "";
                }

            }

            return equations;
        }
    }
}
