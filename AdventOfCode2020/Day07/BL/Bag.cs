namespace Day07.BL
{
    internal class Bag
    {
        private string _hue;
        private string _color;
        private BagInside _bagInside = new BagInside();

        public BagInside InsideBag { get { return _bagInside; } }

        public Bag(string hue, string color)
        {
            _hue = hue;
            _color = color;
        }

        public bool ContainsInside(Bag bag)
        {
            return _bagInside.Contain(bag);
        }

        public void AddInside(BagInside inside)
        {
            _bagInside = inside;
        }
    }
}
