using System.Collections.Generic;

namespace Day07.BL
{
    internal class BagInside
    {
        private Dictionary<Bag, int> _content = new Dictionary<Bag, int>();

        public IDictionary<Bag, int> Content { get { return _content; } }

        public void AddContent(int count, Bag bag)
        {
            _content.Add(bag, count);
        }

        public bool Contain(Bag bag)
        {
            return _content.ContainsKey(bag);
        }
    }
}
