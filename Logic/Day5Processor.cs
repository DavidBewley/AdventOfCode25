using System;
using System.Text;
using static Logic.Day5Processor;

namespace Logic
{
    public class Day5Processor
    {
        public double DetermineFreshIngredients(string input)
        {
            var ranges = GetRanges(input);
            var ingredients = input.Split(["\r\n\r\n", "\n\n", "\r\r"], StringSplitOptions.None)[1].Split(["\r\n", "\n", "\r"], StringSplitOptions.None).ToList();

            var freshIngredients = new List<double>();

            foreach (var ingredient in ingredients)
            {
                var ingredientValue = double.Parse(ingredient);

                foreach (var range in ranges)
                {
                    var splitRange = range.Split('-');
                    var startRange = double.Parse(splitRange[0]);
                    var endRange = double.Parse(splitRange[1]);
                    if (ingredientValue >= startRange && ingredientValue <= endRange)
                    {
                        freshIngredients.Add(ingredientValue);
                        break;
                    }

                }
            }

            return freshIngredients.Count();
        }

        public double DetermineFreshIngredientCount(string input)
        {
            var rangeStrings = GetRanges(input);
            var ranges = new List<Range>();

            foreach(var r in rangeStrings)
            {
                var splitRange = r.Split('-');
                var startRange = double.Parse(splitRange[0]);
                var endRange = double.Parse(splitRange[1]);
                ranges.Add(new Range { Start = startRange, End = endRange });
            }

            ranges = ranges.OrderBy(r => r.Start).ToList();

            double totalCount = 0;

            double currentStart = ranges.First().Start;
            double currentEnd = ranges.First().End;

            foreach (var r in ranges.Skip(1))
            {
                if (r.Start <= currentEnd + 1)
                    currentEnd = Math.Max(currentEnd, r.End);         
                else
                {
                    totalCount += (currentEnd - currentStart + 1);
                    currentStart = r.Start;
                    currentEnd = r.End;
                }
            }
            totalCount += (currentEnd - currentStart + 1);

            return totalCount;
        }

        public class Range
        {
            public double Start { get; set; }
            public double End { get; set; }
        }

        private List<string> GetRanges(string input)
            => input.Split(["\r\n\r\n", "\n\n", "\r\r"], StringSplitOptions.None)[0].Split(["\r\n", "\n", "\r"], StringSplitOptions.None).ToList();
    }
}
