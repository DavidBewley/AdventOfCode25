using Shouldly;

namespace AdventOfCode25.DayTests
{
    public class Day4
    {
        private string _inputString;
        public Day4() => _inputString = File.ReadAllText($"Inputs\\{this.GetType().Name}.txt");

        [Theory]
        [InlineData("@@@@@@", 6)]
        [InlineData("......\r\n..@...\r\n......", 1)]
        [InlineData("......\r\n@@@...\r\n......", 3)]
        [InlineData(".@....\r\n@@@...\r\n.@....", 4)]
        [InlineData("@@@@@@\r\n@@@@@@\r\n@@@@@@", 4)]
        [InlineData("@@@.@.@.@@\r\n@@@@@.@.@@\r\n@.@@@@..@.", 9)]
        [InlineData("..@@.@@@@.\r\n@@@.@.@.@@\r\n@@@@@.@.@@\r\n@.@@@@..@.\r\n@@.@@@@.@@\r\n.@@@@@@@.@\r\n.@.@.@.@@@\r\n@.@@@.@@@@\r\n.@@@@@@@@.\r\n@.@.@@@.@.", 13)]
        public void Part1Theroy(string input, int expectedOutput)
        {
            var processor = new Logic.Day4Processor();
            var result = processor.AccesbileRollsOfPaper(input);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartOne()
        {
            var processor = new Logic.Day4Processor();
            var result = processor.AccesbileRollsOfPaper(_inputString);
            result.ShouldBe(1537);
        }


        [Theory]
        [InlineData("..@@.@@@@.\r\n@@@.@.@.@@\r\n@@@@@.@.@@\r\n@.@@@@..@.\r\n@@.@@@@.@@\r\n.@@@@@@@.@\r\n.@.@.@.@@@\r\n@.@@@.@@@@\r\n.@@@@@@@@.\r\n@.@.@@@.@.", 43)]

        public void Part2Theroy(string input, double expectedOutput)
        {
            var processor = new Logic.Day4Processor();
            var result = processor.RemoveRollsOfPaper(input);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartTwo()
        {
            var processor = new Logic.Day4Processor();
            var result = processor.RemoveRollsOfPaper(_inputString);
            result.ShouldBe(8707);
        }
    }
}
