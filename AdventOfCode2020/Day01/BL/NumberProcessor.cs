using System.Collections.Generic;

namespace Day01.BL
{
    internal class NumberProcessor
    {
        private readonly IEnumerable<int> _numbers;
        HashSet<int> _hashedNumbers;

        public NumberProcessor(IEnumerable<int> numbers)
        {
            _numbers = numbers;
            _hashedNumbers = new HashSet<int>(numbers); 
        }

        public int GetFirstResult()
        {
            foreach (var number in _numbers)
            {
                int guess = 2020 - number;
                if (_hashedNumbers.Contains(guess))
                {
                    return number * guess;
                }
            }

            return -1;
        }

        public int GetSecondResult()
        {
            foreach (var number in _numbers)
            {
                foreach (var number2 in _numbers)
                {
                    int guess = 2020 - number - number2;
                    if (_hashedNumbers.Contains(guess))
                    {
                        return number * guess* number2;
                    }
                }
            }

            return -1;
        }
    }
}
