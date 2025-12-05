using Shouldly;

namespace AdventOfCode25.DayTests
{
    public class Day2
    {
        private string _inputString;
        public Day2() => _inputString = File.ReadAllText($"Inputs\\{this.GetType().Name}.txt");

        [Theory]
        [InlineData("11-22", 33)]
        [InlineData("95-115", 99)]
        [InlineData("11-22,95-115", 132)]
        [InlineData("998-1012", 1010)]
        [InlineData("1188511880-1188511890", 1188511885)]
        [InlineData("222220-222224", 222222)]
        [InlineData("1698522-1698528", 0)]
        [InlineData("446443-446449", 446446)]
        [InlineData("38593856-38593862", 38593859)]
        [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\r\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\r\n824824821-824824827,2121212118-2121212124", 1227775554)]
        public void Part1Theroy(string input, int expectedOutput)
        {
            var processor = new Logic.Day2Processor();
            var result = processor.SumOfInvalidIds(input);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartOne()
        {
            var processor = new Logic.Day2Processor();
            var result = processor.SumOfInvalidIds(_inputString);
            result.ShouldBe(41294979841);
        }


        [Theory]
        [InlineData("11-22", 33)]
        [InlineData("95-115", 210)]
        [InlineData("11-22,95-115", 243)]
        [InlineData("998-1012", 2009)]
        [InlineData("1188511880-1188511890", 1188511885)]
        [InlineData("222220-222224", 222222)]
        [InlineData("1698522-1698528", 0)]
        [InlineData("446443-446449", 446446)]
        [InlineData("565653-565659", 565656)]
        [InlineData("824824821-824824827", 824824824)]
        [InlineData("2121212118-2121212124", 2121212121)]
        [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\r\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\r\n824824821-824824827,2121212118-2121212124", 4174379265)]
        public void Part2Theroy(string input, double expectedOutput)
        {
            var processor = new Logic.Day2Processor();
            var result = processor.SumOfInvalidIds(input, true);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartTwo()
        {
            var processor = new Logic.Day2Processor();
            var result = processor.SumOfInvalidIds(_inputString, true);
            result.ShouldBe(66500947346);
        }
    }
}
