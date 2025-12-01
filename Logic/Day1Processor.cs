namespace Logic
{
    public class Day1Processor
    {

        private int _startingNumber;
        private int _currentNumber;
        private int _timesZeroPart2 = 0;
        private int _timesZeroPart1 = 0;

        public Day1Processor(int startingNumber)
        {
            _startingNumber = startingNumber;
        }

        public int ProcessLeftTurns(string input, int returnType)
        {
            _currentNumber = _startingNumber;

            var instructions = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var instruction in instructions)
            {
                var direction = instruction[0];
                var numberOfTurns = int.Parse(instruction[1..]);
                if (direction == 'L')
                    TurnLeft(numberOfTurns);
                else if (direction == 'R')
                    TurnRight(numberOfTurns);
                if (_currentNumber == 0)
                    _timesZeroPart1++;
            }

            if (returnType == 1)
                return _timesZeroPart1;
            return _timesZeroPart2;
        }

        private void TurnLeft(int numberOfTurns)
        {
            _currentNumber = _currentNumber - numberOfTurns;
            while (_currentNumber < 0)
            {
                _currentNumber += 100;
                _timesZeroPart2++;
            }
        }

        private void TurnRight(int numberOfTurns)
        {
            _currentNumber = _currentNumber + numberOfTurns;
            while (_currentNumber > 99)
            {
                _currentNumber -= 100;
                _timesZeroPart2++;
            }
        }

        public int BruteForcePart2(string input)
        {
            var instructions = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var instruction in instructions)
            {
                var direction = instruction[0];
                var numberOfTurns = int.Parse(instruction[1..]);
                if (direction == 'R')
                {
                    for (int i = 0; i < numberOfTurns; i++)
                    {
                        if (_currentNumber == 99)                       
                            _currentNumber = 0;
                        else
                            _currentNumber++;
                        if (_currentNumber == 0)
                            _timesZeroPart2++;
                    }                   
                }
                else
                {
                    for (int i = 0; i < numberOfTurns; i++)
                    {
                        if (_currentNumber == 0)
                            _currentNumber = 99;
                        else
                            _currentNumber--;
                        if (_currentNumber == 0)
                            _timesZeroPart2++;
                    }
                }
            }
            return _timesZeroPart2;
        }
    }
}
