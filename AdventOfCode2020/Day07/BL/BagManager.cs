using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07.BL
{
    internal class BagManager
    {
        private Dictionary<string, Bag> _bags = new Dictionary<string, Bag>();
        public void Init()
        {
            foreach (var item in new DataProcessor().GetData())
            {
                ProcessData(item);
            }
        }

        public int Calculate(string bagString)
        {
            if (!_bags.ContainsKey(bagString))
                throw new ArgumentOutOfRangeException(bagString);
            var referenceBag = _bags[bagString];

            return CalculateInsideBags(referenceBag);
        }

        private int CalculateInsideBags(Bag referenceBag)
        {
            int sum = 0;
            foreach (var item in referenceBag.InsideBag.Content)
            {
                sum += item.Value;
                sum += item.Value * CalculateInsideBags(item.Key);
            }

            return sum;
        }

        public int CountOfBags(string bagString)
        {
            if (!_bags.ContainsKey(bagString))
                throw new ArgumentOutOfRangeException(bagString);
            var hasChecked = new Dictionary<Bag, bool>();
            var referenceBag = _bags[bagString];
            hasChecked.Add(referenceBag, false);
            while (hasChecked.Values.Any(x => !x))
            {
                var newBags = new List<Bag>();
                List<Bag> hasToSet = new List<Bag>();
                foreach (var item in hasChecked.Where(x=>!x.Value))
                {
                    newBags.AddRange(FindBagParents(item.Key));
                    hasToSet.Add(item.Key);
                }

                foreach (var item in hasToSet)
                {
                    hasChecked[item] = true;
                }

                foreach (var item in newBags)
                {
                    if (!hasChecked.ContainsKey(item))
                        hasChecked.Add(item, false);
                }
            }

            return hasChecked.Count - 1;
        }

        private List<Bag> FindBagParents(Bag referenceBag)
        {
            List<Bag> parentBags = new List<Bag>();
            foreach (var bag in _bags)
            {
                if (bag.Value.ContainsInside(referenceBag))
                    parentBags.Add(bag.Value);
            }

            return parentBags;
        }

        private void ProcessData(string line)
        {
            var splittedData = line.Split("contain");
            var bag = CreateBag(splittedData[0].Replace("bags", string.Empty).Trim());
            CreateContent(splittedData[1].Replace("bags", string.Empty).Replace("bag", string.Empty).Replace(".", string.Empty).Trim(), bag);
        }

        private void CreateContent(string content, Bag bag)
        {
            var inside = new BagInside();
            var insideBags = content.Split(",");
            if(insideBags.Length == 1 && insideBags[0].Contains("no other"))
                return;

            foreach (var item in insideBags)
            {
                var bagDesc = item.Trim().Split(" ");
                int count = int.Parse(item.Trim()[0].ToString());
                var insidedBag = CreateBag($"{bagDesc[1]} {bagDesc[2]}");
                inside.AddContent(count, insidedBag);
            }
            bag.AddInside(inside);
        }

        private Bag CreateBag(string bagDesc)
        {
            var colors = bagDesc.Split(" ");
            Bag bag;
            if (_bags.ContainsKey(bagDesc))
            {
                bag = _bags[bagDesc];
            }
            else
            {
                bag = new Bag(colors[0], colors[1]);
                _bags.Add(bagDesc, bag);
            }
            return bag;
        }
    }
}
