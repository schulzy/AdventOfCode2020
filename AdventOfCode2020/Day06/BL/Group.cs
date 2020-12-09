using System;
using System.Collections.Generic;
using System.Linq;

namespace Day06.BL
{
    internal class Group
    {
        private List<string> _elements = new List<string>();

        public void AddElements(string answers)
        {
            _elements.Add(answers);
        }

        public int GetYesAnswers()
        {
            HashSet<char> yesAnswers = new HashSet<char>();
            foreach (string personAnswer in _elements)
            {
                foreach (var item in personAnswer)
                {
                    yesAnswers.Add(item);
                }
            }

            return yesAnswers.Count;
        }

        public int GetAllYesAnswer()
        {
            IEnumerable<char> result = new List<char>();
            result = _elements.First().ToList<char>();
            foreach (var item in _elements)
            {
                result = result.Intersect(item.ToList<char>());
            }

            return result.Count();
        }
    }
}
