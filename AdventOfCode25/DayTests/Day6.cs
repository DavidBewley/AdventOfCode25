using Shouldly;

namespace AdventOfCode25.DayTests
{
    public class Day6
    {
        private string _inputString;
        public Day6() => _inputString = File.ReadAllText($"Inputs\\{this.GetType().Name}.txt");

        [Theory]
        [InlineData("123\r\n 45 \r\n  6\r\n*", 33210)]
        [InlineData("328\r\n 64 \r\n 98\r\n+", 490)]
        [InlineData(" 51\r\n387\r\n215\r\n*", 4243455)]
        [InlineData(" 64 \r\n23\r\n314\r\n+", 401)]
        [InlineData("123 328  51 64 \r\n 45 64  387 23 \r\n  6 98  215 314\r\n*   +   *   + ", 4277556)]
        public void Part1Theroy(string input, double expectedOutput)
        {
            var processor = new Logic.Day6Processor();
            var result = processor.Part1(input);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartOne()
        {
            var processor = new Logic.Day6Processor();
            var result = processor.Part1(_inputString);
            result.ShouldBe(6371789547734);
        }

        [Theory]
        [InlineData("64 \r\n23 \r\n314\r\n+  ", 1058)]
        [InlineData(" 51\r\n387\r\n215\r\n*  ", 3253600)]
        [InlineData("328\r\n64 \r\n98 \r\n+  ", 625)]
        [InlineData("123\r\n 45\r\n  6\r\n*  ", 8544)]
        [InlineData("123 328  51 64 \r\n 45 64  387 23 \r\n  6 98  215 314\r\n*   +   *   +   ", 3263827)]
        public void Part2Theroy(string input, int expectedOutput)
        {
            var processor = new Logic.Day6Processor();
            var result = processor.Part2(input);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartTwo()
        {
            var processor = new Logic.Day6Processor();
            var result = processor.Part2(_inputString);
            result.ShouldBe(11419862653216);
        }
    }
}
