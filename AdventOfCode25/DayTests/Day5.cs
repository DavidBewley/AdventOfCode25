using Shouldly;

namespace AdventOfCode25.DayTests
{
    public class Day5
    {
        private string _inputString;
        public Day5() => _inputString = File.ReadAllText($"Inputs\\{this.GetType().Name}.txt");

        [Theory]
        [InlineData("3-5\r\n\r\n4", 1)]
        [InlineData("3-5\r\n\r\n1", 0)]
        [InlineData("3-5\r\n\r\n3\r\n4\r\n5", 3)]
        [InlineData("3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32", 3)]
        public void Part1Theroy(string input, int expectedOutput)
        {
            var processor = new Logic.Day5Processor();
            var result = processor.DetermineFreshIngredients(input);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartOne()
        {
            var processor = new Logic.Day5Processor();
            var result = processor.DetermineFreshIngredients(_inputString);
            result.ShouldBe(613);
        }

        [Theory]
        [InlineData("3-5\r\n\r\n4", 3)]
        [InlineData("3-5\r\n\r\n1", 3)]
        [InlineData("3-5\r\n8-10\r\n\r\n1", 6)]
        [InlineData("3-5\r\n2-10\r\n8-9\r\n1-5\r\n8-10\r\n\r\n1", 10)]
        [InlineData("3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32", 14)]
        public void Part2Theroy(string input, int expectedOutput)
        {
            var processor = new Logic.Day5Processor();
            var result = processor.DetermineFreshIngredientCount(input);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartTwo()
        {
            var processor = new Logic.Day5Processor();
            var result = processor.DetermineFreshIngredientCount(_inputString);
            result.ShouldBe(336495597913098);
        }
    }
}
