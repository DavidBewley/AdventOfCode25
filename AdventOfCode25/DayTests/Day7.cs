using Shouldly;

namespace AdventOfCode25.DayTests
{
    public class Day7
    {
        private string _inputString;
        public Day7() => _inputString = File.ReadAllText($"Inputs\\{this.GetType().Name}.txt");

        [Theory]
        [InlineData("..S..\r\n.....\r\n.....\r\n.....\r\n^.^.^\r\n.....", 1)]
        [InlineData("..S..\r\n.....\r\n..^..\r\n.....\r\n^.^.^\r\n.....", 1)]
        [InlineData("..S..\r\n.....\r\n..^..\r\n.....\r\n.^..^\r\n.....", 2)]
        [InlineData("..S..\r\n.....\r\n..^..\r\n.....\r\n.^.^.\r\n.....", 3)]
        [InlineData(".......S.......\r\n...............\r\n.......^.......\r\n...............\r\n......^.^......\r\n...............\r\n.....^.^.^.....\r\n...............\r\n....^.^...^....\r\n...............\r\n...^.^...^.^...\r\n...............\r\n..^...^.....^..\r\n...............\r\n.^.^.^.^.^...^.\r\n...............", 21)]
        public void Part1Theroy(string input, double expectedOutput)
        {
            var processor = new Logic.Day7Processor();
            var result = processor.Part1(input);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartOne()
        {
            var processor = new Logic.Day7Processor();
            var result = processor.Part1(_inputString);
            result.ShouldBe(1678);
        }

        [Theory]
        [InlineData("..S..\r\n.....\r\n..^..\r\n.....\r\n.^.^.\r\n.....", 4)]
        [InlineData(".......S.......\r\n...............\r\n.......^.......\r\n...............\r\n......^.^......\r\n...............\r\n.....^.^.^.....\r\n...............\r\n....^.^...^....\r\n...............\r\n...^.^...^.^...\r\n...............\r\n..^...^.....^..\r\n...............\r\n.^.^.^.^.^...^.\r\n...............", 40)]
        public void Part2Theroy(string input, int expectedOutput)
        {
            var processor = new Logic.Day7Processor();
            var result = processor.Part2(input);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartTwo()
        {
            var processor = new Logic.Day7Processor();
            var result = processor.Part2(_inputString);
            result.ShouldBe(357525737893560);
        }
    }
}
