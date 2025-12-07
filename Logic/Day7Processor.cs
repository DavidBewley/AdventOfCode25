namespace Logic
{
    public class Day7Processor
    {
        public double Part1(string input)
        {
            var lines = input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
            var beamPositions = new List<int>();
            var splitCount = 0;
            beamPositions.Add(lines[0].IndexOf('S'));

            for (int i = 1; i < lines.Length; i++)
            {
                if (!lines[i].Contains('^'))
                    continue;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '^' && beamPositions.Contains(j))
                    {
                        beamPositions.Remove(j);
                        if (!beamPositions.Contains(j - 1))
                            beamPositions.Add(j - 1);
                        if (!beamPositions.Contains(j + 1))
                            beamPositions.Add(j + 1);
                        splitCount++;
                    }
                }
            }

            return splitCount;
        }

        //.......S.......
        //...............
        //.......^.......
        //...............
        //......^.^......
        //...............
        //.....^.^.^.....
        //...............
        //....^.^...^....
        //...............
        //...^.^...^.^...
        //...............
        //..^...^.....^..
        //...............
        //.^.^.^.^.^...^.
        //...............

        //Track beam positions as a list.
        //loop through the rows, for each row, find the beam positions if it splits


        public double Part2(string input)
        {
            var lines = input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
            var beamPositions = new List<int>();
            beamPositions.Add(lines[0].IndexOf('S'));
            var timelines = new Dictionary<int, double>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (!lines[i].Contains('^'))
                    continue;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '^' && beamPositions.Contains(j))
                    {
                        beamPositions.Remove(j);

                        if (timelines.ContainsKey(j - 1))
                            timelines[j - 1] += timelines[j];
                        else
                            timelines[j - 1] = 1;

                        if (timelines.ContainsKey(j + 1))
                            timelines[j + 1] += timelines[j];
                        else
                            timelines[j + 1] = 1;

                        timelines[j] = 0;

                        if (!beamPositions.Contains(j + 1))
                            beamPositions.Add(j + 1);
                        if (!beamPositions.Contains(j - 1))
                            beamPositions.Add(j - 1);

                    }
                }
            }
            return timelines.Sum(t => t.Value);
        }
    }
}
