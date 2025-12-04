using System.Text;

namespace Logic
{
    public class Day4Processor
    {
        public double AccesbileRollsOfPaper(string input)
        {
            var lineLength = input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None)[0].Length;
            var newInput = input.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");

            var maxForAccess = 3;
            var total = 0;

            for (int i = 0; i < newInput.Length; i++)
            {
                if (newInput[i] != '@')
                    continue;

                if (GetNumberOfTouchingRolls(newInput, i, lineLength) <= maxForAccess)                
                    total++;               
            }

            return total;
        }

        public double RemoveRollsOfPaper(string input, bool? part2 = false)
        {
            var lineLength = input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None)[0].Length;
            var newInput = input.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            var maxForAccess = 3;
            var removed = 0;
            var removedPrevious = -1;

            while (removed != removedPrevious)
            {
                removedPrevious = removed;
                var removedPositions = new List<int>();

                for (int i = 0; i < newInput.Length; i++)
                {
                    if (newInput[i] != '@')
                        continue;

                    if (GetNumberOfTouchingRolls(newInput, i, lineLength) > maxForAccess)                   
                        continue;
                    
                    removed++;
                    removedPositions.Add(i);
                }

                var sb = new StringBuilder(newInput);
                foreach (var pos in removedPositions)
                    sb[pos] = 'x';
                newInput = sb.ToString();
            }            

            return removed;
        }

        private int GetNumberOfTouchingRolls(string input, int position, int lineLength)
        {
            var linePointer = (position % lineLength) + 1;
            var touching = 0;

            if (North(input, position, lineLength))
                touching++;
            if (NorthEast(input, position, lineLength, linePointer))
                touching++;
            if (East(input, position, lineLength, linePointer))
                touching++;
            if (SouthEast(input, position, lineLength, linePointer))
                touching++;
            if (South(input, position, lineLength))
                touching++;
            if (SouthWest(input, position, lineLength, linePointer))
                touching++;
            if (West(input, position, lineLength, linePointer))
                touching++;
            if (NorthWest(input, position, lineLength, linePointer))
                touching++;

            return touching;
        }

        public bool North(string input, int position, int lineLength) 
            => position - lineLength >= 0 && input[position - lineLength] == '@';

        public bool NorthEast(string input, int position, int lineLength, int linePointer) 
            => position - lineLength + 1 >= 0 && linePointer != lineLength && input[position - lineLength + 1] == '@';

        public bool East(string input, int position, int lineLength, int linePointer) 
            => linePointer != lineLength && input[position + 1] == '@';

        public bool SouthEast(string input, int position, int lineLength, int linePointer) 
            => position + lineLength + 1 < input.Length && input[position + lineLength + 1] == '@' && linePointer != lineLength;

        public bool South(string input, int position, int lineLength) 
            => position + lineLength < input.Length && input[position + lineLength] == '@';

        public bool SouthWest(string input, int position, int lineLength, int linePointer) 
            => position + lineLength - 1 < input.Length && input[position + lineLength - 1] == '@' && linePointer != 1;

        public bool West(string input, int position, int lineLength, int linePointer) 
            => linePointer != 1 && input[position - 1] == '@';

        public bool NorthWest(string input, int position, int lineLength, int linePointer) 
            => position - lineLength - 1 >= 0 && linePointer != 1 && input[position - lineLength - 1] == '@' && position > lineLength;
    }
}
