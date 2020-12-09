using System;
using System.Collections.Generic;
using System.Text;

namespace Day06.BL
{
    internal class GroupManager
    {
        private List<Group> _groups = new List<Group>();
        private Group _actualGroup = new Group();
        public void Init()
        {
            var dataProcessor = new DataProcessor().GetData();
            _groups.Add(_actualGroup);
            foreach (var item in dataProcessor)
            {
                if(string.IsNullOrEmpty(item))
                {
                    _actualGroup = new Group();
                    _groups.Add(_actualGroup);
                    continue;
                }
                _actualGroup.AddElements(item);

            }
        }

        public int GetAllAnswerSum()
        {
            int sum = 0;
            foreach (var group in _groups)
            {
                sum += group.GetYesAnswers();
            }

            return sum;
        }

        public int GetAllCommonYesAnswerSum()
        {
            int sum = 0;
            foreach (var group in _groups)
            {
                sum += group.GetAllYesAnswer();
            }

            return sum;
        }
    }
}
