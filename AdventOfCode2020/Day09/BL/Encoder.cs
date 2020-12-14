using System;
using System.Collections.Generic;
using System.Linq;

namespace Day09.BL
{
    internal class Encoder
    {
        private int _preamble;
        private List<long> _numbers;

        public void Init(int preamble)
        {
            _preamble = preamble;
            _numbers = new List<long>();
            foreach (var data in new DataProcessor().GetData())
            {
                _numbers.Add(long.Parse(data));
            }
        }

        public long GetInvalidCode()
        {
            for (int i = _preamble; i < _numbers.Count; i++)
            {
                HashSet<long> hashset = new HashSet<long>(_numbers.GetRange(i - _preamble, _preamble));
                if (!IsValidNumber(hashset, _numbers[i]))
                    return _numbers[i];
            }

            throw new Exception("No result");   
        }

        public long GetContiguousMinMaxSum()
        {
            long invalidNumber = GetInvalidCode();
            var set = GetInvalidCodeSumSet(invalidNumber);
            return set.Max() + set.Min();
        }

        private List<long> GetInvalidCodeSumSet(long invalidNumber)
        {
            for (int i = 0; i < _numbers.Count; i++)
            {
                int actualCounter = i;
                long actualSum = 0;
                while (true)
                {
                    actualSum += _numbers[actualCounter];
                    if (actualSum > invalidNumber)
                        break;
                    if (actualSum == invalidNumber)
                        return _numbers.GetRange(i, actualCounter - i + 1);
                    actualCounter++;
                }
            }
            throw new Exception("No result");
        }

        private bool IsValidNumber(HashSet<long> hashset, long refNumber)
        {
            foreach (var item in hashset)
            {
                if (hashset.Contains(refNumber - item) && item * 2 != refNumber)
                    return true;
            }
            return false;
        }
    }
}
