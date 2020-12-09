using System;
using System.Collections.Generic;
using System.Text;

namespace Day05.BL
{
    internal class Ticket
    {
        private readonly string _code;

        private int _row;
        private int _column;
        private int _seatId;
        private bool _isInitialized = false;

        public int SeatId
        {
            get 
            {
                if (!_isInitialized)
                    Initialize();
                return _seatId;
               
            }
        }

        public int Row
        {
            get
            {
                if (!_isInitialized)
                    Initialize();
                return _row;
            }
        }

        public int Column
        {
            get 
            {
                if (!_isInitialized)
                    Initialize();
                return _column; 
            }
        }

        public Ticket(string code)
        {
            _code = code;
        }

        private void Initialize()
        {
            _row = GetNumber(_code.Substring(0, 7), 0, 127);
            _column = GetNumber(_code.Substring(7, 3), 0, 7);
            _seatId = _row * 8 + _column;
        }

        private int GetNumber(string code, int min, int max)
        {
            if (string.IsNullOrEmpty(code))
                return min;
            int diff = (max - min + 1)/2;
            switch (code[0])
            {
                case 'B':
                case 'R':
                    return GetNumber(code.Remove(0, 1), min + diff, max);
                case 'F':
                case 'L':
                    return GetNumber(code.Remove(0, 1), min, max - diff);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
