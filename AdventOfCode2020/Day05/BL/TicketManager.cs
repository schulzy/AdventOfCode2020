using System;
using System.Collections.Generic;
using System.Text;

namespace Day05.BL
{
    internal class TicketManager
    {
        private List<Ticket> _tickets = new List<Ticket>();
        private HashSet<int> _seatId = new HashSet<int>();
        private List<int> _notTher = new List<int>();
        private int _highest;
        private int _lowest;

        public TicketManager()
        {
            var data = new DataProcessor().GetData();
            foreach (var code in data)
                _tickets.Add(new Ticket(code));
        }

        public int GetHighestSeatId()
        {
            int highestSeatId = int.MinValue;
            foreach (var ticket in _tickets)
            {
                if (ticket.SeatId > highestSeatId)
                    highestSeatId = ticket.SeatId;
            }

            return highestSeatId;
        }

        public int GetMySeatId()
        {
            SetHashSet();
            SetExtremums();
            for (int i = _lowest; i <= _highest; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (!_seatId.Contains(i * 8 + j))
                        _notTher.Add(i * 8 + j);
                }
            }

            foreach (var item in _notTher)
            {
                if (_seatId.Contains(item - 1) && _seatId.Contains(item + 1))
                    return item;
            }

            return 0;
        }

        private void SetHashSet()
        {
            foreach (var ticket in _tickets)
            {
                _seatId.Add(ticket.SeatId);
            }
        }

        private void SetExtremums()
        {
            _highest = int.MinValue;
            _lowest = int.MaxValue;
            foreach (var ticket in _tickets)
            {
                if (ticket.Row > _highest)
                    _highest = ticket.Row;
                if (ticket.Row < _lowest)
                    _lowest = ticket.Row;
            }
        }

    }
}
