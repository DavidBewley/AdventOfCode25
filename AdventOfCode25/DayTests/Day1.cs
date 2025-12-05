using Shouldly;

namespace AdventOfCode25.DayTests
{
    public class Day1
    {
        private string _inputString;
        public Day1() => _inputString = File.ReadAllText($"Inputs\\{this.GetType().Name}.txt");

        [Theory]
        [InlineData("R50", 1)]
        [InlineData("L50", 1)]
        [InlineData("L50\r\nL100\r\nR100", 3)]
        [InlineData("L68\r\nL30\r\nR48\r\nL5\r\nR60\r\nL55\r\nL1\r\nL99\r\nR14\r\nL82", 3)]
        public void TimesZero(string input, int expectedOutput)
        {
            var processor = new Logic.Day1Processor(50);
            var result = processor.ProcessLeftTurns(input, 1);
            result.ShouldBe(expectedOutput);
        }

        [Fact]
        public void PartOne()
        {
            var processor = new Logic.Day1Processor(50);
            var result = processor.ProcessLeftTurns(_inputString, 1);
            result.ShouldBe(1129);
        }


        [Theory]
        [InlineData("R100\r\nR100", 2)]
        [InlineData("L100\r\nL100", 2)]
        [InlineData("R50\r\nL50\r\nL50\r\nR50\r\nR50\r\nR100", 4)]
        [InlineData("R100\r\nR200\r\nL300", 6)]
        [InlineData("L68\r\nL30\r\nR48\r\nL5\r\nR60\r\nL55\r\nL1\r\nL99\r\nR14\r\nL82", 6)]
        public void TimesZeroPart2(string input, int expectedOutput)
        {
            var processor = new Logic.Day1Processor(50);
            var result = processor.ProcessLeftTurns(input, 2);
            result.ShouldBe(expectedOutput);
        }
    }
}
