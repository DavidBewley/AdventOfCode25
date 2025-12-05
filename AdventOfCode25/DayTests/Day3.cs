using Shouldly;

namespace AdventOfCode25.DayTests
{
    public class Day3
    {
        private string _inputString;
        public Day3() => _inputString = File.ReadAllText($"Inputs\\{this.GetType().Name}.txt");

        [Theory]
        [InlineData("987654321111111", 98)]
        [InlineData("811111111111119", 89)]
        [InlineData("234234234234278", 78)]
        [InlineData("818181911112111", 92)]
        [InlineData("987654321111111\r\n811111111111119\r\n234234234234278\r\n818181911112111", 357)]

        public void Part1Theroy(string input, int expectedOutput)
        {
            var processor = new Logic.Day3Processor();
            var result = processor.GenerateVoltage(input);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartOne()
        {
            var processor = new Logic.Day3Processor();
            var result = processor.GenerateVoltage(_inputString);
            result.ShouldBe(17244);
        }


        [Theory]
        [InlineData("987654321111111", 987654321111)]
        [InlineData("811111111111119", 811111111119)]
        [InlineData("234234234234278", 434234234278)]
        [InlineData("818181911112111", 888911112111)]
        [InlineData("987654321111111\r\n811111111111119\r\n234234234234278\r\n818181911112111", 3121910778619)]

        public void Part2Theroy(string input, double expectedOutput)
        {
            var processor = new Logic.Day3Processor();
            var result = processor.GenerateVoltage(input, true);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartTwo()
        {
            var processor = new Logic.Day3Processor();
            var result = processor.GenerateVoltage(_inputString, true);
            result.ShouldBe(171435596092638);
        }
    }
}
