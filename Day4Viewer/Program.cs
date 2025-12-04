namespace Day4Viewer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = "..@@.@@@@.\r\n@@@.@.@.@@\r\n@@@@@.@.@@\r\n@.@@@@..@.\r\n@@.@@@@.@@\r\n.@@@@@@@.@\r\n.@.@.@.@@@\r\n@.@@@.@@@@\r\n.@@@@@@@@.\r\n@.@.@@@.@.";

            var processor = new Logic.Day4Processor();

            processor.RemoveRollsOfPaper(input);
        }
    }
}
